using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public static class Mensajes {

		public static void MostrarMensaje(string msj) {
			MessageBox.Show(msj, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static void MostrarError(string msj) {
			MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static bool MostrarPregunta(string msj) {
			return MessageBox.Show(msj, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

	}
}