using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormABMEmpleados: Form{

		private Empleado seleccion;
		private DataTable lista;

		public FormABMEmpleados() {
			seleccion = null;
			InitializeComponent();
			dgvEmpleados.SelectionChanged += DgvEmpleados_SelectionChanged;
			dgvEmpleados.MultiSelect = false;
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaEmpleados();
			}
			CargarEmpleados(lista);
		}

		private void DgvEmpleados_SelectionChanged(object sender, EventArgs e) {
			var rows = dgvEmpleados.SelectedRows;
			if (rows.Count > 0) {
				var idSeleccionado = lista.Rows[rows[0].Index].Field<int>(0);
				using (var service = new WebService.DSServiceSoapClient()) {
					seleccion = service.BuscarEmpleado(idSeleccionado);
				}
				if (seleccion!=null)
					txtId.Text = seleccion.Id.ToString();
			} else seleccion = null;
		}

		private void BtnEliminar_Click(object sender, EventArgs e) {
			if (int.TryParse(txtId.Text, out var id)) {
				using (var service = new WebService.DSServiceSoapClient()) {
					var respuesta = service.EliminarEmpleado(id);
					switch (respuesta) {
						case RespuestaABM.Error_Otro:
							Mensajes.MostrarError("Ocurrió un error al eliminar el empleado");
							break;
						case RespuestaABM.Error_EnUso:
							Mensajes.MostrarError("No se puede eliminar el empleado");
							break;
					}
					lista = service.GetTablaFiltradaEmpleados(txtFiltro.Text);
					ActualizarEmpleados(lista);
				}
			}
		}

		private void TxtFiltro_TextChanged(object sender, EventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaFiltradaEmpleados(txtFiltro.Text);
				ActualizarEmpleados(lista);
			}
		}

		private void BtnModificar_Click(object sender, EventArgs e) {
			if (seleccion != null) {
				var form = new FormEmpleado();
				form.Cargar(seleccion);
				form.FormClosed += Form_FormClosed;
				form.ShowDialog();
			}
		}

		private void BtnAgregar_Click(object sender, EventArgs e) {
			var form = new FormEmpleado();
			form.FormClosed += Form_FormClosed;
			form.ShowDialog();
		}

		private void Form_FormClosed(object sender, FormClosedEventArgs e) {
			using (var service = new WebService.DSServiceSoapClient()) {
				lista = service.GetTablaFiltradaEmpleados(txtFiltro.Text);
				ActualizarEmpleados(lista);
			}
		}

		public void CargarEmpleados(DataTable tabla) {
			dgvEmpleados.DataSource = tabla;
		}

		public void ActualizarEmpleados(DataTable tabla) {
			dgvEmpleados.DataSource = null;
			dgvEmpleados.DataSource = tabla;
		}
	}
}
