using System;
using IDS_TP1_Cliente.WebService;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormColor : Form {
		private Color modificando;

		public FormColor() {
			modificando = null;
			InitializeComponent();
		}

		public void Cargar(Color color) {
			txtDesc.Text = color.Descripcion;
			modificando = color;
		}

		private void BtnAceptar_Click(object sender, EventArgs e) {
			RespuestaABM respuesta;
			using (var service = new WebService.DSServiceSoapClient()) {
				if (modificando != null) {
					modificando.Descripcion = txtDesc.Text;
					respuesta = service.ModificarColor(modificando);
				} else {
					respuesta = service.AñadirColor(
						txtDesc.Text
					);
				}
			}
			switch (respuesta) {
				case RespuestaABM.Exito:
					if (modificando != null)
						Mensajes.MostrarMensaje("Color modificado");
					else
						Mensajes.MostrarMensaje("Color añadido");
					modificando = null;
					Close();
					break;
				case RespuestaABM.Error_Existente:
					Mensajes.MostrarError("Ya existe ese color");
					break;
				case RespuestaABM.Error_DatosInvalidos:
					Mensajes.MostrarError("Los datos no son validos");
					break;
				case RespuestaABM.Error_DatosFaltantes:
					Mensajes.MostrarError("Hay datos faltantes");
					break;
			}
		}

		private void BtnCancelar_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
