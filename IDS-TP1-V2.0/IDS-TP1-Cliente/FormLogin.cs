using System;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormLogin : Form {

		public const string Empleado_No_Encontrado = "Usuario no encontrado",
							Contraseña_Invalida = "La contraseña no es correcta";

		public FormLogin() {
			InitializeComponent();
		}

		private void BtnAceptar_Click(object sender, EventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				var respuesta = service.Login(txtUsuario.Text, txtPass.Text);
				if (!respuesta.encontrado) {
					Mensajes.MostrarError(Empleado_No_Encontrado);
				} else if (respuesta.empleado==null) {
					Mensajes.MostrarError(Contraseña_Invalida);
				} else {
					Program.EmpleadoActivo = respuesta.empleado;
					Mensajes.MostrarMensaje($"Bienvenido {respuesta.empleado.Apellido}");
					Close();
				}
			}
		}

		private void BtnCancelar_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
