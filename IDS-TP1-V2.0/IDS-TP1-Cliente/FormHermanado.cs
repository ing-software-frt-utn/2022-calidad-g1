using System;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormHermanado : Form {
		public FormHermanado() {
			InitializeComponent();
		}

		private void BtnAceptar_Click(object sender, EventArgs e) {
			RegistrarPares(true);
		}

		private void RegistrarPares(bool validacion) {
			using (var service = new WebService.DSServiceSoapClient()) {
				var respuesta = service.RegistrarHermanado(Program.EmpleadoActivo, (int)numPrimera.Value, (int)numSegunda.Value, validacion);

				switch (respuesta) {
					case WebService.RespuestaHermanado.Error_Otro:
						Mensajes.MostrarError("Ocurrió un error al registrar el hermanado");
						break;
					case WebService.RespuestaHermanado.Error_EmpleadoSinPermiso:
						Mensajes.MostrarError("No tiene permiso para realizar esta acción");
						break;
					case WebService.RespuestaHermanado.Error_FueraDeJornada:
						Mensajes.MostrarError("No se puede realizar el hermanado para esta jornada");
						break;
					case WebService.RespuestaHermanado.Error_TotalesNoValidos:
						if (validacion) {
							var continuar = Mensajes.MostrarPregunta("Los totales no parecen correctos. ¿Desea continuar de todas formas?");
							if (continuar) {
								RegistrarPares(false);
							}
						}
						break;
					case WebService.RespuestaHermanado.Exito:
						Mensajes.MostrarMensaje("Pares registrados");
						Close();
						break;
				}
			}
		}

		private void BtnCancelar_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
