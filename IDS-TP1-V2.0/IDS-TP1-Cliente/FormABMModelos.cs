using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormABMModelos : Form{

		private Modelo seleccion;
		private DataTable lista;

		public FormABMModelos() {
			seleccion = null;
			InitializeComponent();
			dgvModelos.SelectionChanged += DgvModelos_SelectionChanged;
			dgvModelos.MultiSelect = false;
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaModelos();
			}
			CargarModelos(lista);
		}

		private void DgvModelos_SelectionChanged(object sender, EventArgs e) {
			var rows = dgvModelos.SelectedRows;
			if (rows.Count > 0) {
				var skuSeleccionado = lista.Rows[rows[0].Index].Field<int>(0);
				using (var service = new WebService.DSServiceSoapClient()) {
					seleccion = service.BuscarModelo(skuSeleccionado);
				}
				if (seleccion!=null)
					txtSKU.Text = seleccion.Id.ToString();
			} else seleccion = null;
		}

		private void BtnEliminar_Click(object sender, EventArgs e) {
			if (int.TryParse(txtSKU.Text, out var sku)) {
				using (var service = new WebService.DSServiceSoapClient()) {
					var respuesta = service.EliminarModelo(sku);
					switch (respuesta) {
						case RespuestaABM.Error_Otro:
							Mensajes.MostrarError("Ocurrió un error al eliminar el modelo");
							break;
						case RespuestaABM.Error_EnUso:
							Mensajes.MostrarError("No se puede eliminar el modelo");
							break;
					}
					lista = service.GetTablaFiltradaModelos(txtFiltro.Text);
					ActualizarModelos(lista);
				}
			}
		}

		private void TxtFiltro_TextChanged(object sender, EventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaFiltradaModelos(txtFiltro.Text);
				ActualizarModelos(lista);
			}
		}

		private void BtnModificar_Click(object sender, EventArgs e) {
			if (seleccion != null) {
				var form = new FormModelo();
				form.Cargar(seleccion);
				form.FormClosed += Form_FormClosed;
				form.ShowDialog();
			}
		}

		private void BtnAgregar_Click(object sender, EventArgs e) {
			var form = new FormModelo();
			form.FormClosed += Form_FormClosed;
			form.ShowDialog();
		}

		private void Form_FormClosed(object sender, FormClosedEventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaFiltradaModelos(txtFiltro.Text);
				ActualizarModelos(lista);
			}
		}

		public void CargarModelos(DataTable tabla) {
			dgvModelos.DataSource = tabla;
		}

		public void ActualizarModelos(DataTable tabla) {
			dgvModelos.DataSource = null;
			dgvModelos.DataSource = tabla;
		}
	}
}
