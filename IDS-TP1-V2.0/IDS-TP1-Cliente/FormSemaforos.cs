using IDS_TP1_Cliente.Properties;
using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormSemaforos : Form {

		private const int INTERVALO_TIEMPO = 1000, INTERVALO_TIEMPO_FONDO = 5000;
		private bool _silencioso;

		private bool Silencioso {
			get => _silencioso;
			set {
				if (value) {
					imgSemaforoO.Image = Resources.semaforo_apagado;
					imgSemaforoR.Image = Resources.semaforo_apagado;
					lblDefectos.Text = "";
					lblTotal.Text = "";
					_silencioso = true;
					timer.Interval = INTERVALO_TIEMPO_FONDO;
				} else {
					_silencioso = false;
					timer.Interval = INTERVALO_TIEMPO;
				}
			}
		}

		private Timer timer;
		private int nroLinea;

		public FormSemaforos(int linea) {
			InitializeComponent();
			lblLinea.Text = "Linea #" + linea;
			lblDefectos.Text = "";
			nroLinea = linea;

			timer = new Timer();
			timer.Interval = INTERVALO_TIEMPO_FONDO;
			timer.Tick += Timer_Tick;
			timer.Start();
			Silencioso = true;
		}

		private void Timer_Tick(object sender, EventArgs e) {
			if (Silencioso) {
				if (ActualizarSemaforosDeFondo()) {
					Silencioso = false;
				}
			} else {
				if (!ActualizarSemaforos()) {
					Silencioso = true;
				}
			}
		}

		private bool ActualizarSemaforosDeFondo() {
			using (var service = new WebService.DSServiceSoapClient()) {
				var informacion = service.ObtenerInformacionSemaforo(nroLinea, Program.EmpleadoActivo);
				imgSemaforoO.Image = Resources.semaforo_apagado;
				imgSemaforoR.Image = Resources.semaforo_apagado;
				lblDefectos.Text = "";
				lblTotal.Text = "";
				if (informacion.respuesta == RespuestaSemaforo.Exito) {
					Silencioso = false;
					timer.Interval = INTERVALO_TIEMPO;
					return true;
				} else
					return false;
			}
		}

		private bool ActualizarSemaforos() {
			using (var service = new WebService.DSServiceSoapClient()) {
				var informacion = service.ObtenerInformacionSemaforo(nroLinea, Program.EmpleadoActivo);

				if (informacion.respuesta != RespuestaSemaforo.Exito) {
					Silencioso = true;
					switch (informacion.respuesta) {
						case RespuestaSemaforo.Error_Otro:
							Mensajes.MostrarError("Ocurrio un error inesperado");
							return false;
						case RespuestaSemaforo.Error_LineaSinOrden:
							Mensajes.MostrarError("La linea actual no tiene una orden de produccion");
							return false;
						case RespuestaSemaforo.Error_LineaInexistente:
							Mensajes.MostrarError("No se pudo acceder a la linea de trabajo");
							return false;
						case RespuestaSemaforo.Error_FueraDeJornada:
							Mensajes.MostrarError("No hay una jornada laboral activa");
							return false;
						case RespuestaSemaforo.Error_EmpleadoSinPermiso:
							Mensajes.MostrarError("No tiene permisos para ver los semaforos");
							return false;
						default:
							Mensajes.MostrarError("Ocurrio un error desconocido");
							return false;
					}
				}

				switch (informacion.observado) {
					case EstadoAlerta.VERDE:
						imgSemaforoO.Image = Resources.semaforo_verde;
						break;
					case EstadoAlerta.AMARILLO:
						imgSemaforoO.Image = Resources.semaforo_amarillo;
						break;
					case EstadoAlerta.ROJO:
						imgSemaforoO.Image = Resources.semaforo_rojo;
						break;
					default:
						imgSemaforoO.Image = Resources.semaforo_apagado;
						break;
				}

				switch (informacion.reproceso) {
					case EstadoAlerta.VERDE:
						imgSemaforoR.Image = Resources.semaforo_verde;
						break;
					case EstadoAlerta.AMARILLO:
						imgSemaforoR.Image = Resources.semaforo_amarillo;
						break;
					case EstadoAlerta.ROJO:
						imgSemaforoR.Image = Resources.semaforo_rojo;
						break;
					default:
						imgSemaforoR.Image = Resources.semaforo_apagado;
						break;
				}

				var builder = new StringBuilder();

				foreach (var cuenta in informacion.defectosRecientes) {
					builder.AppendLine($"- {cuenta.defecto} ({cuenta.cantidad})");
				}

				lblDefectos.Text = builder.ToString();

				lblTotal.Text = "Total: " + informacion.defectosTotales;
			}
			return true;
		}

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);
			timer.Stop();
		}
	}
}
