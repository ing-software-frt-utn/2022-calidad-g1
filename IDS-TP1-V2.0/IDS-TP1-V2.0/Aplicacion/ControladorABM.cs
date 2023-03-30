using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IDS.Aplicacion {
	public static class ControladorABM {

		#region Colores
		public static RespuestaABM AñadirColor(string descripcion) {
			if (string.IsNullOrEmpty(descripcion))
				return RespuestaABM.Error_DatosFaltantes;
			using (var db = ControladorDatos.CrearGestor()) {
				db.Agregar(new Color {
					Descripcion = descripcion
				});
				db.Guardar();
				return RespuestaABM.Exito;
			}
		}

		public static RespuestaABM ModificarColor(Color objeto) {
			if (!objeto.Completo())
				return RespuestaABM.Error_DatosFaltantes;
			if (!objeto.Valido())
				return RespuestaABM.Error_DatosInvalidos;
			using (var db = ControladorDatos.CrearGestor()) {
				db.Modificar(objeto);
				db.Guardar();
				return RespuestaABM.Exito;
			}
		}

		public static RespuestaABM EliminarColor(int id) {
			using (var db = ControladorDatos.CrearGestor()) {
				var color = db.Buscar<Color>(id);
				if (color == null) {
					return RespuestaABM.Error_Inexistente;
				} else {
					try {
						db.Quitar(color);
						db.Guardar();
						return RespuestaABM.Exito;
					} catch {
						return RespuestaABM.Error_EnUso;
					}
				}
			}
		}

		public static Color BuscarColor(int id) {
			using (var db = ControladorDatos.CrearGestor()) {
				return db.Buscar<Color>(id);
			}
		}

		public static Color[] ListarColores() {
			using (var db = ControladorDatos.CrearGestor()) {
				return db.Listar<Color>();
			}
		}

		public static DataTable GetTablaColores() {
			using (var db = ControladorDatos.CrearGestor()) {
				var table = new DataTable("Colores");
				new Color().AgregarColumnas(table.Columns);
				foreach (var obj in db.Enumerar<Color>()) {
					table.Rows.Add(obj.GetValores());
				}
				return table;
			}
		}

		public static DataTable FiltrarColores(string filtro) {
			if (string.IsNullOrEmpty(filtro)) return GetTablaColores();
			using (var db = ControladorDatos.CrearGestor()) {
				var table = new DataTable("Colores");
				new Color().AgregarColumnas(table.Columns);
				foreach (var obj in db.Enumerar<Color>()) {
					if (obj.Filtrar(filtro))
						table.Rows.Add(obj.GetValores());
				}
				return table;
			}
		}
		#endregion

		#region Empleados
		public static RespuestaABM AñadirEmpleado(
					int legajo, int dni, string nombre, string apellido, RolEmpleado rol,
					string correo, string usuario, string contraseña, DateTime fechaNacimiento) {
			var empleado = new Empleado() {
				Legajo = legajo,
				DNI = dni,
				Apellido = apellido,
				Nombre = nombre,
				Usuario = usuario,
				Contraseña = contraseña,
				Correo = correo,
				Rol = rol,
				FechaNac = fechaNacimiento
			};
			if (!empleado.Completo())
				return RespuestaABM.Error_DatosFaltantes;
			if (!empleado.Valido())
				return RespuestaABM.Error_DatosInvalidos;
			using (var db = ControladorDatos.CrearGestor()) {
				foreach (var emp in db.Enumerar<Empleado>()) {
					if (emp.Legajo == legajo || emp.DNI == dni || emp.Usuario == usuario)
						return RespuestaABM.Error_Existente;
				}
				db.Agregar(empleado);
				db.Guardar();
				return RespuestaABM.Exito;
			}
		}

		public static RespuestaABM ModificarEmpleado(Empleado objeto) {
			if (!objeto.Completo())
				return RespuestaABM.Error_DatosFaltantes;
			if (!objeto.Valido())
				return RespuestaABM.Error_DatosInvalidos;
			using (var db = ControladorDatos.CrearGestor()) {
				db.Modificar(objeto);
				db.Guardar();
				return RespuestaABM.Exito;
			}
		}

		public static RespuestaABM EliminarEmpleado(int id) {
			using (var db = ControladorDatos.CrearGestor()) {
				var empleado = db.Buscar<Empleado>(id);
				if (empleado == null) {
					return RespuestaABM.Error_Inexistente;
				} else {
					if (empleado.Rol == RolEmpleado.Administrativo) {
						var empleados = db.Listar<Empleado>();
						bool borrable = false;
						foreach (var emp in empleados) {
							if (emp.Rol == RolEmpleado.Administrativo && emp.Id != empleado.Id) {
								borrable = true;
								break;
							}
						}
						if (!borrable) {
							return RespuestaABM.Error_EnUso;
						}
					}
					try {
						db.Quitar(empleado);
						db.Guardar();
						return RespuestaABM.Exito;
					} catch {
						return RespuestaABM.Error_EnUso;
					}
				}
			}
		}

		public static Empleado[] ListarEmpleados() {
			using (var db = ControladorDatos.CrearGestor()) {
				return db.Listar<Empleado>();
			}
		}

		public static Empleado BuscarEmpleado(int id) {
			using (var db = ControladorDatos.CrearGestor()) {
				return db.Buscar<Empleado>(id);
			}
		}

		public static DataTable GetTablaEmpleados() {
			using (var db = ControladorDatos.CrearGestor()) {
				var table = new DataTable("Empleados");
				new Empleado().AgregarColumnas(table.Columns);
				foreach (var obj in db.Enumerar<Empleado>()) {
					table.Rows.Add(obj.GetValores());
				}
				return table;
			}
		}

		public static DataTable GetTablaFiltradaEmpleados(string filtro) {
			if (string.IsNullOrEmpty(filtro)) return GetTablaEmpleados();
			using (var db = ControladorDatos.CrearGestor()) {
				var table = new DataTable("Empleados");
				new Empleado().AgregarColumnas(table.Columns);
				foreach (var obj in db.Listar<Empleado>()) {
					if (obj.Filtrar(filtro))
						table.Rows.Add(obj.GetValores());
				}
				return table;
			}
		}
		#endregion

		#region Modelos
		public static RespuestaABM AñadirModelo(long sku, string denom, int lir, int lio, int lsr, int lso) {
			var modelo = new Modelo() {
				SKU = sku,
				Denominacion = denom,
				LimiteInferiorReproceso = lir,
				LimiteInferiorObservado = lio,
				LimiteSuperiorReproceso = lsr,
				LimiteSuperiorObservado = lso
			};
			if (!modelo.Completo())
				return RespuestaABM.Error_DatosFaltantes;

			if (!modelo.Valido())
				return RespuestaABM.Error_DatosInvalidos;

			using (var db = ControladorDatos.CrearGestor()) {
				var modelos = db.Listar<Modelo>();
				foreach (var mod in modelos) {
					if (mod.Id==modelo.Id || mod.SKU == modelo.SKU) {
						return RespuestaABM.Error_Existente;
					}
				}
				db.Agregar(modelo);
				db.Guardar();
				return RespuestaABM.Exito;
			}
		}

		public static RespuestaABM ModificarModelo(Modelo modeloNuevo) {
			using (var db = ControladorDatos.CrearGestor()) {
				var modelo = db.Buscar<Modelo>(modeloNuevo.Id);
				if (modelo != null) {
					if (!modelo.Completo())
						return RespuestaABM.Error_DatosFaltantes;

					if (!modelo.Valido())
						return RespuestaABM.Error_DatosInvalidos;

					modelo.Denominacion = modeloNuevo.Denominacion;
					modelo.LimiteInferiorReproceso = modeloNuevo.LimiteInferiorReproceso;
					modelo.LimiteInferiorObservado = modeloNuevo.LimiteInferiorObservado;
					modelo.LimiteSuperiorReproceso = modeloNuevo.LimiteSuperiorReproceso;
					modelo.LimiteSuperiorObservado = modeloNuevo.LimiteSuperiorObservado;
					db.Guardar();
					return RespuestaABM.Exito;
				} else {
					return RespuestaABM.Error_Inexistente;
				}
			}
		}

		public static RespuestaABM EliminarModelo(int SKU) {
			using (var db = ControladorDatos.CrearGestor()) {
				var modelo = db.Buscar<Modelo>(SKU);
				if (modelo == null) {
					return RespuestaABM.Error_Inexistente;
				} else {
					try {
						db.Quitar(modelo);
						db.Guardar();
						return RespuestaABM.Exito;
					} catch {
						return RespuestaABM.Error_EnUso;
					}
				}
			}
		}

		public static Modelo BuscarModelo(int SKU) {
			using (var db = ControladorDatos.CrearGestor()) {
				return db.Buscar<Modelo>(SKU);
			}
		}

		public static Modelo[] ListarModelos() {
			using (var db = ControladorDatos.CrearGestor()) {
				return db.Listar<Modelo>();
			}
		}

		public static DataTable GetTablaModelos() {
			using (var db = ControladorDatos.CrearGestor()) {
				var table = new DataTable("Modelos");
				new Modelo().AgregarColumnas(table.Columns);
				foreach (var obj in db.Enumerar<Modelo>()) {
					table.Rows.Add(obj.GetValores());
				}
				return table;
			}
		}

		public static DataTable GetTablaFiltradaModelos(string filtro) {
			if (string.IsNullOrEmpty(filtro)) return GetTablaModelos();
			using (var db = ControladorDatos.CrearGestor()) {
				var table = new DataTable("Modelos");
				new Modelo().AgregarColumnas(table.Columns);
				foreach (var obj in db.Enumerar<Modelo>()) {
					if (obj.Filtrar(filtro))
						table.Rows.Add(obj.GetValores());
				}
				return table;
			}
		}
		#endregion

		#region LineasDeTrabajo
		public static LineaDeTrabajo[] ListarLineasDeTrabajo() {
			using (var db = ControladorDatos.CrearGestor()) {
				var lista = db.Listar<LineaDeTrabajo>();
				foreach (var linea in lista) {
					db.Llenar(linea);
				}
				return lista;
			}
		}

		public static LineaDeTrabajo BuscarLineaDeTrabajo(OrdenDeProduccion op) {
			using (var db = ControladorDatos.CrearGestor()) {
				var lista = db.Listar<LineaDeTrabajo>();
				foreach (var linea in lista) {
					if (linea.OrdenAsociada.Id == op.Id) {
						db.Llenar(linea);
						return linea;
					}
				}
			}
			return null;
		}

		public static LineaDeTrabajo BuscarLineaDeTrabajo(int num) {
			using (var db = ControladorDatos.CrearGestor()) {
				foreach (var linea in db.Listar<LineaDeTrabajo>()) {
					if (linea.Numero == num) {
						db.Llenar(linea);
						return linea;
					}
				}
			}
			return null;
		}
		#endregion

		public static Defecto[] GetDefectos() {
			using (var db = ControladorDatos.CrearGestor()) {
				return db.Listar<Defecto>();
			}
		}
	}
}