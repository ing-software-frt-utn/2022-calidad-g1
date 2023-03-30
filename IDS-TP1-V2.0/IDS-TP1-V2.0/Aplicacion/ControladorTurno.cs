using System;

namespace IDS.Aplicacion {
	public static class ControladorTurno {

		public static Turno GetTurnoActual() {
			var hora = DateTime.Now.Hour;
			using (var bd = ControladorDatos.CrearGestor()) {
				foreach (var turno in bd.Enumerar<Turno>()) {
					if (hora>=turno.HoraInicio && hora < turno.HoraFin) {
						return turno;
					}
				}
			}
			return null;
		}

	}
}