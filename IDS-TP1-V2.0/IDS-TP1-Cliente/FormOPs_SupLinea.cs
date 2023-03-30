using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormOPs_SupLinea : Form {

		private OrdenDeProduccion seleccion;
		private DataTable lista;

		public FormOPs_SupLinea() {
			InitializeComponent();
			dgvOrdenes.MultiSelect = false;
			dgvOrdenes.SelectionChanged += DgvOrdenes_SelectionChanged;
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaOrdenes();
			}
			CargarOrdenesDeProduccion(lista);
			btnFinalizar.Enabled = false;
			btnPausar.Enabled = false;
			btnReanudar.Enabled = false;
		}

		private void DgvOrdenes_SelectionChanged(object sender, EventArgs e) {
			var rows = dgvOrdenes.SelectedRows;
			if (rows.Count > 0) {
				var idSeleccionado = lista.Rows[rows[0].Index].Field<int>(0);
				using (var service = new WebService.DSServiceSoapClient()) {
					seleccion = service.BuscarOrden(idSeleccionado);
				}
			} else seleccion = null;

			if (seleccion != null) {
				btnFinalizar.Enabled = seleccion.Estado!=EstadoOP.FINALIZADA;
				btnPausar.Enabled = seleccion.Estado==EstadoOP.ACTIVADA;
				btnReanudar.Enabled = seleccion.Estado==EstadoOP.PAUSADA;
			} else {
				btnFinalizar.Enabled = false;
				btnPausar.Enabled = false;
				btnReanudar.Enabled = false;
			}
		}

		private void TxtFiltro_TextChanged(object sender, EventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaFiltradaOrdenes(txtFiltro.Text);
				ActualizarOrdenesDeProduccion(lista);
			}
		}

		private void BtnCrear_Click(object sender, EventArgs e) {
			var form = new FormCreacionOP();
			form.FormClosed += Form_FormClosed;
			form.ShowDialog();
		}

		private void Form_FormClosed(object sender, FormClosedEventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaFiltradaOrdenes(txtFiltro.Text);
				ActualizarOrdenesDeProduccion(lista);
			}
		}

		private void BtnPausar_Click(object sender, EventArgs e) {
			if (seleccion != null) {
				using (var service = new WebService.DSServiceSoapClient()) {
					var respuesta = service.PausarOrden(seleccion.Id, Program.EmpleadoActivo);
					switch (respuesta) {
						case RespuestaCambioDeEstado.Error_Otro:
							Mensajes.MostrarError("Ocurrio un error al pausar la orden");
							break;
						case RespuestaCambioDeEstado.Error_Invalido:
							Mensajes.MostrarError("No se puede pausar la orden");
							break;
						case RespuestaCambioDeEstado.Error_EnInspeccion:
							Mensajes.MostrarError("El proceso de inspección se está realizando. Por favor solicite al supervisor de calidad la desvinculación de la orden.");
							break;
						case RespuestaCambioDeEstado.Error_SinPermisos:
							Mensajes.MostrarError("No tiene permisos para reanudar la orden");
							break;
						case RespuestaCambioDeEstado.Exito:
							lista = service.GetTablaFiltradaOrdenes(txtFiltro.Text);
							ActualizarOrdenesDeProduccion(lista);
							break;
					}
				}
			}
		}

		private void BtnReanudar_Click(object sender, EventArgs e) {
			if (seleccion != null) {
				using (var service = new WebService.DSServiceSoapClient()) {
					var respuesta = service.ReanudarOrden(seleccion.Id, Program.EmpleadoActivo);
					switch (respuesta) {
						case RespuestaCambioDeEstado.Error_Otro:
							Mensajes.MostrarError("Ocurrio un error al reanudar la orden");
							break;
						case RespuestaCambioDeEstado.Error_Invalido:
							Mensajes.MostrarError("No se puede reanudar la orden");
							break;
						case RespuestaCambioDeEstado.Error_SinPermisos:
							Mensajes.MostrarError("No tiene permisos para reanudar la orden");
							break;
						case RespuestaCambioDeEstado.Exito:
							lista = service.GetTablaFiltradaOrdenes(txtFiltro.Text);
							ActualizarOrdenesDeProduccion(lista);
							break;
					}
				}
			}
		}

		private void BtnFinalizar_Click(object sender, EventArgs e) {
			if (seleccion != null) {
				using (var service = new WebService.DSServiceSoapClient()) {
					var respuesta = service.FinalizarOrden(seleccion.Id);
					switch (respuesta) {
						case RespuestaCambioDeEstado.Error_Otro:
							Mensajes.MostrarError("Ocurrio un error al finalizar la orden");
							break;
						case RespuestaCambioDeEstado.Error_Invalido:
							Mensajes.MostrarError("No se puede finalizar la orden");
							break;
						case RespuestaCambioDeEstado.Exito:
							lista = service.GetTablaFiltradaOrdenes(txtFiltro.Text);
							ActualizarOrdenesDeProduccion(lista);
							break;
					}
				}
			}
		}

		public void CargarOrdenesDeProduccion(DataTable tabla) {
			dgvOrdenes.DataSource = tabla;
		}

		public void ActualizarOrdenesDeProduccion(DataTable tabla) {
			dgvOrdenes.DataSource = null;
			dgvOrdenes.DataSource = tabla;
		}
	}
}
