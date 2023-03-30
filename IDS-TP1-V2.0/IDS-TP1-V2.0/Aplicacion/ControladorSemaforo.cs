using IDS_TP1_V2._0.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IDS.Aplicacion {
	public static class ControladorSemaforo {

		public static InformacionSemaforo ConsultarSemaforo(int nroLinea, Empleado empleado) {
			var informacion = new InformacionSemaforo();

			if (empleado == null || empleado.Rol != RolEmpleado.SupervisorLinea) {
				informacion.respuesta = RespuestaSemaforo.Error_EmpleadoSinPermiso;
				return informacion;
			}

			var linea = ControladorABM.BuscarLineaDeTrabajo(nroLinea);

			if (linea == null) {
				informacion.respuesta = RespuestaSemaforo.Error_LineaInexistente;
				return informacion;
			}

			if (linea.OrdenAsociada == null) {
				informacion.respuesta = RespuestaSemaforo.Error_LineaSinOrden;
				return informacion;
			}

			using (var db = ControladorDatos.CrearGestor()) {
				var op = db.Buscar<OrdenDeProduccion>(linea.OrdenAsociada.Id);
				db.Llenar(op);

				var jornada = op.ObtenerJornadaActual(DateTime.Now);
				if (jornada == null) {
					informacion.respuesta = RespuestaSemaforo.Error_FueraDeJornada;
					return informacion;
				}
				db.Llenar(jornada);

				foreach (var inc in jornada.Incidencias) {
					db.Llenar(inc);
				}

				informacion.observado = GestorSemaforo.ConsultarSemaforo(jornada, op.Modelo, op.UltimaAlerta(TipoDefecto.OBSERVADO), TipoDefecto.OBSERVADO);
				informacion.reproceso = GestorSemaforo.ConsultarSemaforo(jornada, op.Modelo, op.UltimaAlerta(TipoDefecto.REPROCESO), TipoDefecto.REPROCESO);

				var cuentaDefectos = new Dictionary<string, int>();

				var fechaInicio = DateTime.Now.Subtract(new TimeSpan(1, 0, 0));

				foreach (var inc in jornada.Incidencias) {
					if (inc.TipoIncidencia == TipoIncidencia.DEFECTO && inc.FechaHoraRegistro >= fechaInicio) {
						var desc = inc.Defecto?.Descripcion;
						if (cuentaDefectos.ContainsKey(desc)) {
							cuentaDefectos[desc] = cuentaDefectos[desc] + 1;
						} else {
							cuentaDefectos[desc] = 1;
						}
					}
				}

				var top5 = (from x in cuentaDefectos select new Cuenta(x.Key, x.Value))
					.OrderByDescending((x) => x.cantidad)
					.ThenBy((x) => x.defecto)
					.Take(5);

				var alertaObs = op.EstadoDeAlerta(TipoDefecto.OBSERVADO);
				var alertaRep = op.EstadoDeAlerta(TipoDefecto.REPROCESO);

				if (informacion.observado > alertaObs) {
					op.GenerarAlerta(DateTime.Now, informacion.observado, TipoDefecto.OBSERVADO);
				}

				if (informacion.reproceso > alertaRep) {
					op.GenerarAlerta(DateTime.Now, informacion.reproceso, TipoDefecto.REPROCESO);
				}

				informacion.defectosRecientes = top5.ToArray();
				informacion.defectosTotales = jornada.CantidadDeIncidencias();
				informacion.respuesta = RespuestaSemaforo.Exito;
				db.Guardar();
			}
			return informacion;
		}

	}

	public enum RespuestaSemaforo {
		Error_Otro,
		Error_LineaInexistente,
		Error_LineaSinOrden,
		Error_FueraDeJornada,
		Error_EmpleadoSinPermiso,
		Exito
	}
}