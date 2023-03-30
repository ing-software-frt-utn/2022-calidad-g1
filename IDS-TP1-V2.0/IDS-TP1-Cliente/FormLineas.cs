using IDS_TP1_Cliente.WebService;
using System;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormLineas : Form {
		public event Action<int, JornadaLaboral> LineaSeleccionada;

		private const int BORDE = 20;

		public FormLineas() {
			InitializeComponent();

			using (var service = new DSServiceSoapClient()) {
				var lineas = service.EstadoDeLineasDeTrabajo(Program.EmpleadoActivo);
				Button temp;
				string texto;
				bool activo;
				tableLineas.ColumnCount = lineas.Length;
				tableLineas.Width = lineas.Length * 100;
				this.Width = BORDE * 2 + tableLineas.Width;
				int i = 1;
				foreach (var l in lineas) {
					texto = $"Linea #{i}\n";
					activo = false;
					switch (l) {
						case EstadoLinea.Libre:
							texto += "Libre"; break;
						case EstadoLinea.Disponible:
							activo = true;
							texto += "Disponible"; break;
						case EstadoLinea.Inactiva:
							texto += "Inactiva"; break;
						case EstadoLinea.Iniciada:
							activo = true;
							texto += "Iniciada"; break;
						case EstadoLinea.Ocupada:
							texto += "Ocupada"; break;
						default:
							texto += "N/A"; break;
					}
					temp = new Button();
					temp.Dock = DockStyle.Fill;
					temp.TabIndex = i;
					temp.Click += Temp_Click;
					temp.Text = texto;
					temp.Enabled = activo;
					tableLineas.Controls.Add(temp);
					++i;
				}
			}

		}

		private void Temp_Click(object sender, System.EventArgs e) {
			var nroLinea = (sender as Button).TabIndex;

			using (var service = new WebService.DSServiceSoapClient()) {
				var respuesta = service.IniciarJornada(nroLinea, Program.EmpleadoActivo);

				switch (respuesta) {
					case WebService.RespuestaJornada.Error_Otro:
						Mensajes.MostrarError("Ocurrió un error al iniciar la jornada");
						break;
					case WebService.RespuestaJornada.Error_LineaInexistente:
						Mensajes.MostrarError("La línea seleccionada no es válida");
						break;
					case WebService.RespuestaJornada.Error_SinOrden:
						Mensajes.MostrarError("La línea seleccionada no posee una orden de producción");
						break;
					case WebService.RespuestaJornada.Error_OrdenInactiva:
						Mensajes.MostrarError("La línea seleccionada posee una orden inactiva");
						break;
					case WebService.RespuestaJornada.Error_SinPermiso:
						Mensajes.MostrarError("No tiene permiso para iniciar una jornada");
						break;
					case WebService.RespuestaJornada.Error_FueraDeTurno:
						Mensajes.MostrarError("No existe un turno en este horario");
						break;
					case WebService.RespuestaJornada.Error_LineaOcupada:
						Mensajes.MostrarError("La línea seleccionada está ocupada");
						break;
					case WebService.RespuestaJornada.Exito_Continuacion:
					case WebService.RespuestaJornada.Exito_Creacion:
						var jornada = service.ObtenerJornada(nroLinea, Program.EmpleadoActivo);

						if (jornada == null) {
							Mensajes.MostrarError("Ocurrió un error");
						} else {
							LineaSeleccionada?.Invoke(nroLinea, jornada);
						}
						Close();
						break;
				}
			}
		}

		private void ActualizarLineas() {
			using (var service = new WebService.DSServiceSoapClient()) {
				var lineas = service.ListarLineasDeTrabajo();
			}
		}

		private void BtnActualizar_Click(object sender, System.EventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				var lineas = service.EstadoDeLineasDeTrabajo(Program.EmpleadoActivo);
				bool activo;
				string texto;
				Button temp;
				int i = 0;
				foreach (var l in lineas) {
					texto = $"Linea #{i + 1}\n";
					activo = false;
					switch (l) {
						case EstadoLinea.Libre:
							texto += "Libre"; break;
						case EstadoLinea.Disponible:
							activo = true;
							texto += "Disponible"; break;
						case EstadoLinea.Inactiva:
							texto += "Inactiva"; break;
						case EstadoLinea.Iniciada:
							activo = true;
							texto += "Iniciada"; break;
						case EstadoLinea.Ocupada:
							texto += "Ocupada"; break;
						default:
							texto += "N/A"; break;
					}
					temp = tableLineas.Controls[i] as Button;
					temp.Text = texto;
					temp.Enabled = activo;
					++i;
				}
			}
		}
	}
}
