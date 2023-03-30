using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IDS.Aplicacion {
	public static class ControladorOP {
		public static RespuestaCreacionOP CrearOrdenDeProduccion(Empleado empleado, string numeroOP, int numeroLinea, int modeloSKU, int colorId) {
			if (empleado==null || empleado.Rol != RolEmpleado.SupervisorLinea) {
				return RespuestaCreacionOP.Error_Permisos;
			}

			if (string.IsNullOrWhiteSpace(numeroOP)) {
				return RespuestaCreacionOP.Error_DatosFaltantes;
			}

			using (var db = ControladorDatos.CrearGestor()) {
				var lineasDeTrabajo = db.Listar<LineaDeTrabajo>();
				foreach (var l in lineasDeTrabajo) {
					db.Llenar(l);
					if (l.OrdenAsociada != null) {
						db.Llenar(l.OrdenAsociada);
						if (l.OrdenAsociada.SupervisorLinea.Id == empleado.Id) {
							return RespuestaCreacionOP.Error_SupervisorOcupado;
						}
					}
				};
			}

			var linea = ControladorABM.BuscarLineaDeTrabajo(numeroLinea);
			var modelo = ControladorABM.BuscarModelo(modeloSKU);
			var color = ControladorABM.BuscarColor(colorId);

			if (linea==null || modelo==null || color == null) {
				return RespuestaCreacionOP.Error_DatosInvalidos;
			}

			if (linea.OrdenAsociada != null) {
				return RespuestaCreacionOP.Error_Linea;
			}

			var op = BuscarOPPorNumero(numeroOP);
			
			if (op != null) {
				return RespuestaCreacionOP.Error_Existente;
			}

			//Obtiene la fecha actual sin considerar minutos o segundos
			var fecha = DateTime.Now.Date + new TimeSpan(DateTime.Now.Hour, 0, 0);

			op = new OrdenDeProduccion() {
				Color = color,
				Estado = EstadoOP.ACTIVADA,
				FechaInicio = fecha,
				FechaFin = null,
				NumeroLinea = linea.Numero,
				Modelo = modelo,
				Numero = numeroOP,
				SupervisorLinea=empleado
			};

			using (var db = ControladorDatos.CrearGestor()) {
				db.Asociar(op.Modelo);
				db.Asociar(op.Color);
				db.Asociar(op.SupervisorLinea);
				db.Asociar(linea);
				db.Agregar(op);
				linea.OrdenAsociada = op;
				db.Modificar(linea);
				db.Guardar();
				return RespuestaCreacionOP.Exito;
			}
		}

		public static RespuestaCambioDeEstado PausarOrden(int id, Empleado empleado) {
			using (var db = ControladorDatos.CrearGestor()) {
				var op = db.Buscar<OrdenDeProduccion>(id);
				if (op == null) return RespuestaCambioDeEstado.Error_Otro;
				if (op.Estado != EstadoOP.ACTIVADA) return RespuestaCambioDeEstado.Error_Invalido;
				db.Llenar(op);
				if (op.SupervisorLinea?.Id != empleado.Id) {
					return RespuestaCambioDeEstado.Error_SinPermisos;
				}
				if (op.SupervisorCalidad != null) {
					return RespuestaCambioDeEstado.Error_EnInspeccion;
				}
				op.Estado = EstadoOP.PAUSADA;
				op.SupervisorCalidad = null;
				db.Guardar();
				return RespuestaCambioDeEstado.Exito;
			}
		}

		public static RespuestaCambioDeEstado ReanudarOrden(int id, Empleado empleado) {
			using (var db = ControladorDatos.CrearGestor()) {
				var op = db.Buscar<OrdenDeProduccion>(id);
				if (op == null) return RespuestaCambioDeEstado.Error_Otro;
				if (op.Estado != EstadoOP.PAUSADA) return RespuestaCambioDeEstado.Error_Invalido;
				db.Llenar(op);
				if (op.SupervisorLinea?.Id != empleado.Id)
					return RespuestaCambioDeEstado.Error_SinPermisos;
				foreach (var al in op.Alertas) {
					db.Asociar(al);
				}
				op.Reactivar(DateTime.Now);
				db.Guardar();
				return RespuestaCambioDeEstado.Exito;
			}
		}

		public static RespuestaCambioDeEstado FinalizarOrden(int id) {
			using (var db = ControladorDatos.CrearGestor()) {
				var op = db.Buscar<OrdenDeProduccion>(id);
				if (op == null) return RespuestaCambioDeEstado.Error_Otro;
				if (op.Estado == EstadoOP.FINALIZADA) return RespuestaCambioDeEstado.Error_Invalido;
				op.Estado = EstadoOP.FINALIZADA;
				op.FechaFin = DateTime.Now;

				
				foreach (var linea in db.Listar<LineaDeTrabajo>()) {
					db.Llenar(linea);
					if (linea.OrdenAsociada?.Id == op.Id) {
						linea.OrdenAsociada = null;
						db.Modificar(linea);
						break;
					}
				}

				op.NumeroLinea = 0;
				db.Guardar();
				return RespuestaCambioDeEstado.Exito;
			}
		}

		public static OrdenDeProduccion BuscarOrden(int id) {
			using (var db = ControladorDatos.CrearGestor()) {
				var op = db.Buscar<OrdenDeProduccion>(id);
				db.Llenar(op);
				return op;
			}
		}

		public static OrdenDeProduccion BuscarOrdenEnLinea(int nroLinea) {
			using (var db = ControladorDatos.CrearGestor()) {
				foreach (var l in db.Listar<LineaDeTrabajo>()) {
					if (l.Numero == nroLinea) {
						db.Llenar(l);
						var op = db.Buscar<OrdenDeProduccion>(l.OrdenAsociada.Id);
						db.Llenar(op);
						return op;
					}
				}
			}
			return null;
		}

		public static OrdenDeProduccion[] ListarOrdenes() {
			using (var db = ControladorDatos.CrearGestor()) {
				var lista = db.Listar<OrdenDeProduccion>();
				foreach (var op in lista) {
					db.Llenar(op);
				}
				return lista;
			}
		}

		public static OrdenDeProduccion BuscarOPPorNumero(string num) {
			using (var db = ControladorDatos.CrearGestor()) {
				foreach (var op in db.Listar<OrdenDeProduccion>()) {
					if (op.Numero == num) {
						db.Llenar(op);
						return op;
					}
				}
			}
			return null;
		}

		public static DataTable GetTablaOrdenes() {
			using (var db = ControladorDatos.CrearGestor()) {
				var table = new DataTable("Ordenes");
				new OrdenDeProduccion().AgregarColumnas(table.Columns);
				var list = db.Listar<OrdenDeProduccion>();
				foreach (var obj in list) {
					db.Llenar(obj);
					table.Rows.Add(obj.GetValores());
				}
				return table;
			}
		}

		public static DataTable GetTablaFiltradaOrdenes(string filtro) {
			if (string.IsNullOrEmpty(filtro)) return GetTablaOrdenes();
			using (var db = ControladorDatos.CrearGestor()) {
				var table = new DataTable("Ordenes");
				new OrdenDeProduccion().AgregarColumnas(table.Columns);
				var list = db.Listar<OrdenDeProduccion>();
				foreach (var obj in list) {
					db.Llenar(obj);
					if (obj.Filtrar(filtro))
						table.Rows.Add(obj.GetValores());
				}
				return table;
			}
		}

		public enum RespuestaCreacionOP {
			Error_Otro,
			Error_Permisos,
			Error_DatosFaltantes,
			Error_DatosInvalidos,
			Error_Existente,
			Error_Linea,
			Error_SupervisorOcupado,
			Exito
		}

		public enum RespuestaCambioDeEstado {
			Error_Otro,
			Error_Invalido,
			Error_SinPermisos,
			Error_EnInspeccion,
			Exito
		}
	}
}