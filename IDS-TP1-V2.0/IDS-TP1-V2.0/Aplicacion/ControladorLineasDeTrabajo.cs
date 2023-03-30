using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDS.Aplicacion {
	public static class ControladorLineasDeTrabajo {

		public static EstadoLinea[] GetLineasDeTabajo(Empleado empleado) {
			if (empleado == null) return null;
			EstadoLinea[] estados = null;
			using (var db = ControladorDatos.CrearGestor()) {
				var lineas = db.Listar<LineaDeTrabajo>();
				estados = new EstadoLinea[lineas.Count()];
				int i = 0;
				foreach (var l in lineas) {
					db.Llenar(l);
					if (l.OrdenAsociada != null) {
						db.Llenar(l.OrdenAsociada);
						if (l.OrdenAsociada.Estado == EstadoOP.ACTIVADA) {
							var jornada = l.OrdenAsociada.ObtenerJornadaActual(DateTime.Now);
							if (jornada == null || l.OrdenAsociada.SupervisorCalidad==null) {
								estados[i] = EstadoLinea.Disponible;
							} else {
								db.Llenar(jornada);
								if (l.OrdenAsociada.SupervisorCalidad.Id == empleado.Id) {
									for (int j = 0; j < estados.Length; j++) {
										estados[j] = EstadoLinea.Inactiva;
									}
									estados[i] = EstadoLinea.Iniciada;
									return estados;
								} else {
									estados[i] = EstadoLinea.Ocupada;
								}
							}
						} else {
							estados[i] = EstadoLinea.Inactiva;
						}
					} else {
						estados[i] = EstadoLinea.Libre;
					}
					++i;
				}
			}
			return estados;
		}

	}

	public enum EstadoLinea {
		Libre,
		Disponible,
		Inactiva,
		Iniciada,
		Ocupada
	}
}