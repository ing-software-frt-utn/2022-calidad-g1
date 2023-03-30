using IDS_TP1_Cliente.WebService;
using System;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormIncidencia : Form {

		public event Action<Defecto, int, TipoPie> RegistroDefecto;
		public event Action<int> RegistroPrimera;

		private string[] horas;
		private int horaInicio;

		private ControladorCacheInspeccion cache;

		public FormIncidencia(string[] horas, ControladorCacheInspeccion controlador) {
			InitializeComponent();
			cmbHora.Enabled = false;
			cbHoraActual.Checked = true;
			this.horas = horas;
			cmbHora.DataSource = horas;
			horaInicio = int.Parse(horas[0].Replace(":00", ""));
			cache = controlador;
			btnDefecto.Enabled = false;

			using (var service = new WebService.DSServiceSoapClient()) {
				var defectos = service.GetDefectos();
				lstDefectos.DataSource = defectos;
				lstDefectos.DisplayMember = "Descripcion";
			}
		}

		private void CbHoraActual_CheckedChanged(object sender, EventArgs e) {
			cmbHora.Enabled = !cbHoraActual.Checked;
		}

		private void BtnDefecto_Click(object sender, EventArgs e) {
			if (cbHoraActual.Checked) {
				int i = DateTime.Now.Hour - horaInicio;
				if (i >= horas.Length) i = horas.Length - 1;
				cmbHora.SelectedIndex = i;
			}
			var hora = cmbHora.SelectedIndex + horaInicio;
			if (lstDefectos.SelectedItem is Defecto defecto) {
				RegistroDefecto?.Invoke(defecto, hora, rdIzquierdo.Checked ? TipoPie.IZQUIERDO : TipoPie.DERECHO);
			}
		}

		private void BtnPrimera_Click(object sender, EventArgs e) {
			if (cbHoraActual.Checked) {
				int i = DateTime.Now.Hour - horaInicio;
				if (i >= horas.Length) i = horas.Length - 1;
				cmbHora.SelectedIndex = i;
			}
			var hora = cmbHora.SelectedIndex + horaInicio;
			RegistroPrimera?.Invoke(hora);
		}

		private void LstDefectos_SelectedIndexChanged(object sender, EventArgs e) {
			var defecto = lstDefectos.SelectedItem as Defecto;
			btnDefecto.Enabled = defecto != null;
		}
	}
}
