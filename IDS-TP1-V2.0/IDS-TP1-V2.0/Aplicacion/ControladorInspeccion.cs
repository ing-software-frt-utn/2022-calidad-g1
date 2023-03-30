using System;
using System.Collections.Generic;
using System.Data;

namespace IDS.Aplicacion {
	public static class ControladorInspeccion {

		public static JornadaLaboral ObtenerJornada(int nroLinea, Empleado empleado) {
			var linea = ControladorABM.BuscarLineaDeTrabajo(nroLinea);
			if (linea==null)
				return null;

			if (linea.OrdenAsociada == null)
				return null;

			using (var db = ControladorDatos.CrearGestor()) {
				var op = db.Buscar<OrdenDeProduccion>(linea.OrdenAsociada.Id);
				db.Llenar(op);

				var jornada = op.ObtenerJornadaActual(DateTime.Now);
				if (jornada == null) return null;
				db.Llenar(jornada);

				if (empleado == null || jornada?.Supervisor.Id != empleado.Id)
					return null;

				return jornada;
			}
		}

		public static RespuestaJornada IniciarJornada(int nroLinea, Empleado empleado) {
			var linea = ControladorABM.BuscarLineaDeTrabajo(nroLinea);

			if (linea == null)
				return RespuestaJornada.Error_LineaInexistente;

			if (empleado == null || empleado.Rol != RolEmpleado.SupervisorCalidad)
				return RespuestaJornada.Error_SinPermiso;

			if (linea.OrdenAsociada == null)
				return RespuestaJornada.Error_SinOrden;

			if (linea.OrdenAsociada.Estado != EstadoOP.ACTIVADA)
				return RespuestaJornada.Error_OrdenInactiva;

			JornadaLaboral jornada = null;

			using (var db = ControladorDatos.CrearGestor()) {
				db.Asociar(linea.OrdenAsociada);
				db.Llenar(linea.OrdenAsociada);
				jornada = linea.OrdenAsociada.ObtenerJornadaActual(DateTime.Now);
				if (jornada != null) {
					db.Llenar(jornada);
					if (jornada.Supervisor == null) {
						throw new Exception("Faltan includes");
					} else if (jornada.Supervisor.Id == empleado.Id) {
						return RespuestaJornada.Exito_Continuacion;
					} else {
						return RespuestaJornada.Error_LineaOcupada;
					}
				}
			}

			var turno = ControladorTurno.GetTurnoActual();

			if (turno == null)
				return RespuestaJornada.Error_FueraDeTurno;

			using (var bd = ControladorDatos.CrearGestor()) {
				bd.Asociar(linea);
				bd.Asociar(linea.OrdenAsociada);
				bd.Asociar(turno);
				bd.Asociar(empleado);
				jornada = linea.OrdenAsociada.CrearJornadaLaboral(turno, empleado, DateTime.Now);
				bd.Asociar(linea.OrdenAsociada.SupervisorCalidad);
				bd.Agregar(jornada);
				bd.Guardar();
			}

			return RespuestaJornada.Exito_Creacion;
		}

		public static RespuestaDesvinculacion DesvincularSupervisor(Empleado empleado) {
			if (empleado == null || empleado.Rol != RolEmpleado.SupervisorCalidad)
				return RespuestaDesvinculacion.Error_NoCalidad;

			using (var db = ControladorDatos.CrearGestor()) {
				foreach (var linea in db.Listar<LineaDeTrabajo>()) {
					db.Llenar(linea);
					if (linea.OrdenAsociada == null) continue;

					var op = db.Buscar<OrdenDeProduccion>(linea.OrdenAsociada.Id);
					if (op == null) continue;
					db.Llenar(op);

					foreach (var j in op.Jornadas) {
						db.Llenar(j);
					}

					var jornada = op.ObtenerJornadaActual(DateTime.Now);
					if (jornada == null) continue;

					db.Llenar(jornada);

					if (jornada?.Supervisor.Id == empleado.Id) {
						op.SupervisorCalidad = null;
						if (DateTime.Now.Hour >= jornada.Turno.HoraFin) {
							op.Estado = EstadoOP.PAUSADA;
						}
					}
					db.Guardar();
					break;
				}
			}

			return RespuestaDesvinculacion.Exito;
		}

		public static JornadaLaboral JornadaPendiente(Empleado empleado, out OrdenDeProduccion orden) {
			orden = null;
			if (empleado == null || empleado.Rol != RolEmpleado.SupervisorCalidad)
				return null;

			using (var db = ControladorDatos.CrearGestor()) {
				foreach (var linea in db.Listar<LineaDeTrabajo>()) {
					db.Llenar(linea);
					if (linea.OrdenAsociada == null) continue;

					var op = db.Buscar<OrdenDeProduccion>(linea.OrdenAsociada.Id);
					if (op == null) continue;
					db.Llenar(op);

					foreach (var j in op.Jornadas) {
						db.Llenar(j);
					}

					var jornada = op.ObtenerJornadaActual(DateTime.Now);
					if (jornada == null) continue;

					db.Llenar(jornada);

					if (jornada?.Supervisor.Id != empleado.Id)
						continue;

					orden = op;
					return jornada;
				}
			}

			return null;
		}

		public static RespuestaSincronizacion RegistrarAcciones(Empleado empleado, AccionDeInspeccion[] acciones) {
			if (empleado == null) return RespuestaSincronizacion.Error_SinPermiso;
			var jornada = JornadaPendiente(empleado, out var op);
			if (jornada == null) return RespuestaSincronizacion.Error_JornadaNoExistente;

			if (op.Estado != EstadoOP.ACTIVADA) return RespuestaSincronizacion.Error_OrdenNoActiva;

			using (var db = ControladorDatos.CrearGestor()) {
				db.Asociar(jornada);
				db.Llenar(jornada);
				foreach (var accion in acciones) {
					if (accion.eliminar) {
						var inc = db.Buscar<Incidencia>(accion.idIncidencia);
						if (inc != null)
							db.Quitar(inc);
					} else {
						if (accion.tipo == TipoIncidencia.PRIMERA) {
							jornada.AgregarParPrimera(accion.fecha);
						} else {
							var def = db.Buscar<Defecto>(accion.idDefecto);
							if (def != null)
								jornada.AgregarIncidencia(accion.fecha, DateTime.Now, def, accion.pie);
						}
					}
				}
				db.Guardar();
			}
			return RespuestaSincronizacion.Exito;
		}

		public static Incidencia[] GetListaIncidencias(Empleado empleado) {
			if (empleado == null) return null;
			var jornada = JornadaPendiente(empleado, out _);
			if (jornada == null) return null;
			var lista = new List<Incidencia>();
			
			using (var db = ControladorDatos.CrearGestor()) {
				db.Asociar(jornada);
				foreach (var inc in jornada.Incidencias) {
					db.Llenar(inc);
					lista.Add(inc);
				}
			}
			return lista.ToArray();
		}

		public static RespuestaHermanado RegistrarHermanado(Empleado empleado, int paresPrimera, int paresSegunda, bool validar) {
			if (empleado == null || empleado.Rol!=RolEmpleado.SupervisorCalidad)
				return RespuestaHermanado.Error_EmpleadoSinPermiso;
			var jornada = JornadaPendiente(empleado, out _);
			if (jornada == null)
				return RespuestaHermanado.Error_FueraDeJornada;
			using (var db = ControladorDatos.CrearGestor()) {
				db.Asociar(jornada);
				if (validar) {
					bool cuentaValida = true;
					db.Llenar(jornada);
					foreach (var inc in jornada.Incidencias) {
						db.Llenar(inc);
					}
					var defObs = jornada.ContarDefectos(TipoDefecto.OBSERVADO, jornada.FechaInicio);
					var defRep = jornada.ContarDefectos(TipoDefecto.REPROCESO, jornada.FechaInicio);
					int max = Math.Max(defObs, defRep);

					if (paresPrimera < 0 || paresPrimera > max) {
						cuentaValida = false;
					}
					if (paresSegunda < 0 || paresSegunda > max) {
						cuentaValida = false;
					}
					if (cuentaValida) {
						jornada.RegistrarHermanado(paresPrimera, paresSegunda);
						db.Guardar();
					} else {
						return RespuestaHermanado.Error_TotalesNoValidos;
					}
				} else {
					jornada.RegistrarHermanado(paresPrimera, paresSegunda);
					db.Guardar();
				}
			}
			return RespuestaHermanado.Exito;
		}

	}

	public struct AccionDeInspeccion {
		public bool eliminar;
		public int idIncidencia;

		public TipoIncidencia tipo;
		public TipoDefecto tipoDefecto;
		public TipoPie pie;
		public DateTime fecha;
		public int idDefecto;
	}

	public enum RespuestaSincronizacion {
		Error_Otro,
		Error_SinPermiso,
		Error_JornadaNoExistente,
		Error_OrdenNoActiva,
		Exito
	}

	public enum RespuestaJornada {
		Error_Otro,
		Error_LineaInexistente,
		Error_SinOrden,
		Error_OrdenInactiva,
		Error_SinPermiso,
		Error_FueraDeTurno,
		Error_LineaOcupada,
		Exito_Continuacion,
		Exito_Creacion
	}

	public enum RespuestaDesvinculacion {
		Error_Otro,
		Error_NoCalidad,
		Error_NoVinculado,
		Exito
	}

	public enum RespuestaInspeccion {
		Error_Otro,
		Error_LineaSinOrden,
		Error_LineaInexistente,
		Error_EmpleadoSinPermiso,
		Error_FueraDeJornada,
		Error_OrdenNoActiva,
		Exito
	}

	public enum RespuestaHermanado {
		Error_Otro,
		Error_EmpleadoSinPermiso,
		Error_FueraDeJornada,
		Error_TotalesNoValidos,
		Exito
	}
}