using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormCreacionOP : Form {

		public FormCreacionOP() {
			InitializeComponent();

			using (var service = new DSServiceSoapClient()) {
				var lineas = service.ListarLineasDeTrabajo();
				var modelos = service.ListarModelos();
				var colores = service.ListarColores();
				Cargar(lineas, modelos, colores);
			}
		}

		public void Cargar(LineaDeTrabajo[] lineas, Modelo[] modelos, Color[] colores) {
			if (lineas?.Length == 0) {
				Mensajes.MostrarError("No hay lineas de trabajo cargadas en el sistema");
				Close();
				return;
			}
			if (modelos?.Length == 0) {
				Mensajes.MostrarError("No hay modelos cargados en el sistema");
				Close();
				return;
			}
			if (colores?.Length == 0) {
				Mensajes.MostrarError("No hay colores cargados en el sistema");
				Close();
				return;
			}

			cmbLinea.DataSource = lineas;
			cmbColor.DataSource = colores;
			cmbModelo.DataSource = modelos;
		}

		private void BtnCancelar_Click(object sender, EventArgs e) {
			Close();
		}

		private void BtnAceptar_Click(object sender, EventArgs e) {
			var linea = cmbLinea.SelectedItem as LineaDeTrabajo;
			var modelo = cmbModelo.SelectedValue as Modelo;
			var color = cmbColor.SelectedValue as Color;

			if (linea==null || modelo==null || color == null) {
				Mensajes.MostrarError("Los datos no son validos");
				return;
			}

			using (var service = new DSServiceSoapClient()) {
				var respuesta = service.CrearOrdenDeProduccion(
					Program.EmpleadoActivo,
					txtNumero.Text,
					linea.Numero,
					modelo.Id,
					color.Id
				);
				switch (respuesta) {
					case RespuestaCreacionOP.Error_Otro:
						Mensajes.MostrarError("Error al crear la orden");
						break;
					case RespuestaCreacionOP.Error_Permisos:
						Mensajes.MostrarError("No tiene los permisos para realizar esta accion");
						break;
					case RespuestaCreacionOP.Error_DatosFaltantes:
						Mensajes.MostrarError("Hay datos faltantes");
						break;
					case RespuestaCreacionOP.Error_DatosInvalidos:
						Mensajes.MostrarError("Los datos no son validos");
						break;
					case RespuestaCreacionOP.Error_Existente:
						Mensajes.MostrarError("Ya existe una orden con ese numero");
						break;
					case RespuestaCreacionOP.Error_Linea:
						Mensajes.MostrarError("La linea de trabajo está ocupada");
						break;
					case RespuestaCreacionOP.Error_SupervisorOcupado:
						Mensajes.MostrarError("Ya está asociado a otra linea.");
						break;
					case RespuestaCreacionOP.Exito:
						Close();
						break;
				}
			}
		}
	}
}
