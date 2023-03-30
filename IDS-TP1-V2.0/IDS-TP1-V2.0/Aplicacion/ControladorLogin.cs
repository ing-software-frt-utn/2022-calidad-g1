namespace IDS.Aplicacion {
	public static class ControladorLogin {

		public static LoginRespuesta InicioDeSesion(string usuario, string contra) {
			var respuesta = new LoginRespuesta();
			respuesta.empleado = null;
			respuesta.encontrado = false;
			using (var db = ControladorDatos.CrearGestor()) {
				foreach (var empleado in db.Enumerar<Empleado>()) {
					if (empleado.Usuario == usuario) {
						respuesta.encontrado = true;
						if (empleado.Contraseña == contra) {
							respuesta.empleado = empleado;
							return respuesta;
						}
						break;
					}
				}
			}
			return respuesta;
		}

		public struct LoginRespuesta {
			public bool encontrado;
			public Empleado empleado;
		}
	}
}