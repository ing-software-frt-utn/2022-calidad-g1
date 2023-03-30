using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public class ControladorCacheInspeccion {

		private const int FILA_PRIMERA = 0, FILA_OBSERVADO = 1, FILA_REPROCESO = 2;

		public delegate void EventoDeActualizacion(DisplayIncidencia[] incidencias, int totalPrimera, (int, int) defectosObs, (int, int) defectosRep);

		public event EventoDeActualizacion ActualizarLista;

		private readonly object lockAcciones;
		private List<AccionDeInspeccion> acciones;
		private List<Incidencia> incidencias;

		public ControladorCacheInspeccion(Incidencia[] incidencias, EventoDeActualizacion accionActualizar) {
			this.incidencias = new List<Incidencia>(incidencias);
			acciones = new List<AccionDeInspeccion>();
			lockAcciones = new object();
			ActualizarLista += accionActualizar;
			Actualizar();
		}

		private void Actualizar() {
			var displays = new DisplayIncidencia[incidencias.Count];
			int i = 0;
			string texto = null;
			int totPrimera = 0;
			int totObsIzq = 0;
			int totObsDer = 0;
			int totRepIzq = 0;
			int totRepDer = 0;
			foreach (var inc in incidencias) {
				if (inc.TipoIncidencia == TipoIncidencia.PRIMERA) {
					texto = $"[{inc.FechaHora.Hour}:00 hs] - Par de primera";
					++totPrimera;
				} else {
					if (inc.Defecto.TipoDef == TipoDefecto.OBSERVADO) {
						texto = $"[{inc.FechaHora.Hour}:00 hs] - Defecto de observado: \"{inc.Defecto.Descripcion}\"({inc.Pie})";
						if (inc.Pie == TipoPie.DERECHO) {
							++totObsDer;
						} else {
							++totObsIzq;
						}
					} else {
						texto = $"[{inc.FechaHora.Hour}:00 hs] - Defecto de reproceso: \"{inc.Defecto.Descripcion}\"({inc.Pie})";
						if (inc.Pie == TipoPie.DERECHO) {
							++totRepDer;
						} else {
							++totRepIzq;
						}
					}
				}
				displays[i] = new DisplayIncidencia() {
					Id = inc.Id,
					Texto = texto
				};
				++i;
			}
			ActualizarLista?.Invoke(displays, totPrimera, (totObsIzq, totObsDer), (totRepIzq, totRepDer));
		}

		public void Sincronizar(out string error) {
			error = null;
			lock (lockAcciones) {
				using (var service = new WebService.DSServiceSoapClient()) {
					if (acciones.Count > 0) {
						var respuesta = service.RegistrarAccionesInspeccion(Program.EmpleadoActivo, acciones.ToArray());
						switch (respuesta) {
							case RespuestaSincronizacion.Error_Otro:
								error = "Ocurrió un error al sincronizar las acciones";
								break;
							case RespuestaSincronizacion.Error_SinPermiso:
								error = "No tiene permiso para realizar acciones de inspección.";
								break;
							case RespuestaSincronizacion.Error_JornadaNoExistente:
								error = "No se pudo acceder a la jornada laboral.";
								break;
							case RespuestaSincronizacion.Error_OrdenNoActiva:
								error = "La orden de producción no esta activa.";
								break;
							case RespuestaSincronizacion.Exito:
								acciones.Clear();
								break;
						}
					}
					var lista = service.GetListaIncidencias(Program.EmpleadoActivo);
					if (lista != null) {
						incidencias.Clear();
						incidencias.AddRange(lista);
						Actualizar();
					}
				}
			}
		}

		public void AddRegistroDefecto(int hora, Defecto def, TipoPie pie) {
			lock (lockAcciones) {
				acciones.Add(new AccionDeInspeccion() {
					fecha = DateTime.Today + new TimeSpan(hora, 0, 0),
					tipo = TipoIncidencia.DEFECTO,
					tipoDefecto = def.TipoDef,
					idDefecto = def.Id,
					pie = pie
				});
			}
		}

		public void AddRegistroPrimera(int hora) {
			lock (lockAcciones) {
				acciones.Add(new AccionDeInspeccion() {
					fecha = DateTime.Today + new TimeSpan(hora, 0, 0),
					tipo = TipoIncidencia.PRIMERA
				});
			}
		}

		public void EliminarRegistro(int id) {
			lock (lockAcciones) {
				acciones.Add(new AccionDeInspeccion() {
					eliminar = true,
					idIncidencia = id
				});
			}
		}

		public void Dispose() {
			acciones.Clear();
			acciones = null;
			incidencias.Clear();
			incidencias = null;
			ActualizarLista = null;
		}

	}
}
