using IDS_TP1_Cliente.WebService;
using System;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormMain : Form {

		private const string TITULO = "Sistema IDS";

		public FormMain() {
			Text = TITULO;
			InitializeComponent();
			btnLogout.Enabled = false;
			DeshabilitarAcciones();
		}

		private void IniciarSesion_Click(object sender, EventArgs e) {
			var login = new FormLogin();
			login.FormClosed += Login_FormClosed;
			login.Show();
		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e) {
			if (Program.EmpleadoActivo == null) {
				btnLogin.Enabled = true;
				btnLogout.Enabled = false;
				DeshabilitarAcciones();
				Text = $"{TITULO}";
			} else {
				Text = $"{TITULO} - {Program.EmpleadoActivo.Apellido}, {Program.EmpleadoActivo.Nombre}";
				btnLogin.Enabled = false;
				btnLogout.Enabled = true;
				DeshabilitarAcciones();
				switch (Program.EmpleadoActivo.Rol) {
					case WebService.RolEmpleado.Administrativo:
						menuGestion.Visible = true;
						break;
					case WebService.RolEmpleado.SupervisorLinea:
						menuVer.Visible = true;
						menuOPs.Visible = true;
						menuSemaforos.Visible = true;
						break;
					case WebService.RolEmpleado.SupervisorCalidad:
						//menuOPs.Visible = true;
						menuInspeccion.Visible = true;
						break;
				}
			}
		}

		public void DeshabilitarAcciones() {
			menuOPs.Visible = false;
			menuVer.Visible = false;
			menuGestion.Visible = false;
			menuInspeccion.Visible = false;
			menuSemaforos.Visible = false;
		}

		private void CerrarSesion_Click(object sender, EventArgs e) {
			Program.EmpleadoActivo = null;
			DeshabilitarAcciones();
			btnLogin.Enabled = true;
			btnLogout.Enabled = false;
			Text = $"{TITULO}";
		}

		private void Modelos_Click(object sender, EventArgs e) {
			var form = new FormABMModelos();
			form.MdiParent = this;
			form.Show();
		}

		private void Ordenes_Click(object sender, EventArgs e) {
			var form = new FormOPs_SupLinea();
			form.MdiParent = this;
			form.Show();
		}

		private void Colores_Click(object sender, EventArgs e) {
			var form = new FormABMColores();
			form.MdiParent = this;
			form.Show();
		}

		private void Empleados_Click(object sender, EventArgs e) {
			var form = new FormABMEmpleados();
			form.MdiParent = this;
			form.Show();
		}

		private void IniciarJornada_Click(object sender, EventArgs e) {
			var form = new FormLineas();
			form.LineaSeleccionada += Form_LineaSeleccionada;
			form.ShowDialog();
		}
			
		private void Form_LineaSeleccionada(int nroLinea, JornadaLaboral jornada) {
			var form = new FormInspeccion(nroLinea, jornada);
			form.MdiParent = this;
			if (!form.IsDisposed)
				form.Show();
		}

		private void Linea1ToolStripMenuItem_Click(object sender, EventArgs e) {
			var form = new FormSemaforos(1);
			form.Show();
		}

		private void Linea2ToolStripMenuItem_Click(object sender, EventArgs e) {
			var form = new FormSemaforos(2);
			form.Show();
		}

		private void Linea3ToolStripMenuItem_Click(object sender, EventArgs e) {
			var form = new FormSemaforos(3);
			form.Show();
		}

		private void Linea4ToolStripMenuItem_Click(object sender, EventArgs e) {
			var form = new FormSemaforos(4);
			form.Show();
		}
	}
}
