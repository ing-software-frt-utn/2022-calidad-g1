using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormABMColores : Form{

		private Color seleccion;
		private DataTable tabla;

		public FormABMColores() {
			seleccion = null;
			InitializeComponent();
			dgvColores.SelectionChanged += DgvColores_SelectionChanged;
			dgvColores.MultiSelect = false;
			using (var service = new WebService.DSServiceSoapClient()) {
				tabla = service.GetTablaColores();
			}
			CargarColores(tabla);
		}

		private void DgvColores_SelectionChanged(object sender, EventArgs e) {
			var rows = dgvColores.SelectedRows;
			if (rows.Count > 0) {
				var idSeleccionado = tabla.Rows[rows[0].Index].Field<int>(0);
				using (var service = new WebService.DSServiceSoapClient()) {
					seleccion = service.BuscarColor(idSeleccionado);
				}
				if (seleccion!=null)
					txtId.Text = seleccion.Id.ToString();
			} else seleccion = null;
		}

		private void BtnEliminar_Click(object sender, EventArgs e) {
			if (int.TryParse(txtId.Text, out var id)) {
				using (var service = new WebService.DSServiceSoapClient()) {
					var respuesta = service.EliminarColor(id);
					switch (respuesta) {
						case RespuestaABM.Error_Otro:
							Mensajes.MostrarError("Ocurrió un error al eliminar el color");
							break;
						case RespuestaABM.Error_EnUso:
							Mensajes.MostrarError("No se puede eliminar el color");
							break;
					}
					tabla = service.GetTablaFiltradaColores(txtFiltro.Text);
					ActualizarColors(tabla);
				}
			}
		}

		private void TxtFiltro_TextChanged(object sender, EventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				tabla = service.GetTablaFiltradaColores(txtFiltro.Text);
				ActualizarColors(tabla);
			}
		}

		private void BtnModificar_Click(object sender, EventArgs e) {
			if (seleccion != null) {
				var form = new FormColor();
				form.Cargar(seleccion);
				form.FormClosed += Form_FormClosed;
				form.ShowDialog();
			}
		}

		private void BtnAgregar_Click(object sender, EventArgs e) {
			var form = new FormColor();
			form.FormClosed += Form_FormClosed;
			form.ShowDialog();
		}

		private void Form_FormClosed(object sender, FormClosedEventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				tabla = service.GetTablaFiltradaColores(txtFiltro.Text);
				ActualizarColors(tabla);
			}
		}

		public void CargarColores(DataTable tabla) {
			dgvColores.DataSource = tabla;
		}

		public void ActualizarColors(DataTable tabla) {
			dgvColores.DataSource = null;
			dgvColores.DataSource = tabla;
		}
	}
}
