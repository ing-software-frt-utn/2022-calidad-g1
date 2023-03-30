using IDS_TP1_Cliente.WebService;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System;

namespace IDS_TP1_Cliente {
	public partial class FormInspeccion : Form {

		private const int INTERVALO_TIEMPO = 1000;

		private ControladorCacheInspeccion cache;
		private FormIncidencia incidencias;
		private FormHermanado hermanado;
		private Timer timer;
		private string[] horas;
		private int cantidadDeIncidencias;

		public FormInspeccion(int nroLinea, JornadaLaboral jornada) {
			InitializeComponent();
			cantidadDeIncidencias = 0;

			using (var service = new WebService.DSServiceSoapClient()) {

				var op = service.BuscarOrdenEnLinea(nroLinea);
				if (op == null) {
					Mensajes.MostrarError("Ocurrió un error. Orden no encontrada");
					Close();
					return;
				}

				lblOP.Text = "Orden de producción: " + op.Numero;
				lblModelo.Text = "Modelo: " + op.Modelo.Denominacion;
				lblColor.Text = "Color: " + op.Color.Descripcion;
				lblTurno.Text = $"Turno: {jornada.Turno.HoraInicio} hs a {jornada.Turno.HoraFin} hs";

				var horaInicio = jornada.FechaInicio.Hour;
				int cantidadHoras = jornada.Turno.HoraFin - horaInicio;
				horas = new string[cantidadHoras];
				for (int i = 0; i < cantidadHoras; i++) {
					horas[i] = $"{horaInicio + i}:00";
				}

				var incidencias = service.GetListaIncidencias(Program.EmpleadoActivo);
				if (incidencias != null) {
					cache = new ControladorCacheInspeccion(incidencias, ActualizarListaIncidencias);
				} else {
					Mensajes.MostrarError("Ocurrió un error al cargar incidencias");
					Close();
					return;
				}
			}

			lstIncidencias.DoubleClick += LstIncidencias_DoubleClick;

			timer = new Timer();
			timer.Interval = INTERVALO_TIEMPO;
			timer.Tick += Timer_Tick;

			MostrarCarga();
		}

		private void LstIncidencias_DoubleClick(object sender, EventArgs e) {
			var inc = (DisplayIncidencia)lstIncidencias.SelectedItem;
			if (inc != null) {
				if (Mensajes.MostrarPregunta($"¿Desea eliminar la incidencia: {inc.Texto}?")) {
					cache.EliminarRegistro(inc.Id);
				}
			}
		}

		private void ActualizarListaIncidencias(DisplayIncidencia[] displays, int totPrimera, (int izq, int der) defObs, (int izq, int der) defRep) {
			if (displays.Length == cantidadDeIncidencias) return;
			cantidadDeIncidencias = displays.Length;
			lstIncidencias.DataSource = null;
			lstIncidencias.DataSource = displays;
			lstIncidencias.DisplayMember = "Texto";
			lblTotalPrimera.Text = $"Pares de primera: {totPrimera}";
			lblTotalObs.Text = $"Defectos de observado: {defObs.izq+defObs.der} - (I:{defObs.izq}, D:{defObs.der})";
			lblTotalRep.Text = $"Defectos de reproceso: {defRep.izq + defRep.der} - (I:{defRep.izq}, D:{defRep.der})";
		}

		private void Timer_Tick(object sender, EventArgs e) {
			cache.Sincronizar(out var error);
			if (error != null) {
				timer.Stop();
				Mensajes.MostrarError(error);
				incidencias.Close();
			}
		}

		private void MostrarCarga() {
			incidencias = new FormIncidencia(horas, cache);
			incidencias.FormClosed += Incidencias_FormClosed;
			incidencias.RegistroPrimera += Incidencias_RegistroPrimera;
			incidencias.RegistroDefecto += Incidencias_RegistroDefecto;
			timer.Start();
			incidencias.Show();
		}

		private void Incidencias_RegistroDefecto(Defecto def, int hora, TipoPie pie) {
			cache.AddRegistroDefecto(hora, def, pie);
		}

		private void Incidencias_RegistroPrimera(int hora) {
			cache.AddRegistroPrimera(hora);
		}

		private void Incidencias_FormClosed(object sender, FormClosedEventArgs e) {
			incidencias = null;
			if (timer.Enabled) {
				cache.Sincronizar(out _);
				timer.Stop();
			}
		}

		private void BtnRegistro_Click(object sender, System.EventArgs e) {
			if (incidencias == null) {
				MostrarCarga();
			}
		}

		private void BtnHermanado_Click(object sender, System.EventArgs e) {
			if (hermanado != null) {
				hermanado.Close();
			}
			hermanado = new FormHermanado();
			hermanado.FormClosed += Hermanado_FormClosed;
			hermanado.Show();
		}

		private void Hermanado_FormClosed(object sender, FormClosedEventArgs e) {
			hermanado = null;
		}

		private void BtnDesvincular_Click(object sender, System.EventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				var respuesta = service.DesvincularSupervisorDeCalidad(Program.EmpleadoActivo);
				switch (respuesta) {
					case RespuestaDesvinculacion.Error_Otro:
						Mensajes.MostrarError("Ocurrió un error al desvincular");
						break;
					case RespuestaDesvinculacion.Error_NoCalidad:
						Mensajes.MostrarError("El empleado no es supervisor de calidad");
						break;
					case RespuestaDesvinculacion.Error_NoVinculado:
						Mensajes.MostrarError("No está vinculado.");
						break;
					case RespuestaDesvinculacion.Exito:
						Mensajes.MostrarMensaje("Se ha desvinculado de la OP.");
						Close();
						break;
				}
			}
		}
	}

	public class DisplayIncidencia {
		public int Id { get; set; }
		public string Texto { get; set; }

		public override string ToString() => Texto;
	}
}
