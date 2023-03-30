using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	static class Program {

		public static Empleado EmpleadoActivo { get; set; }

		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		static void Main() {
			/*try {
				using (var service = new WebService.DSServiceSoapClient()) {
					_ = service.ListarColores();
					Console.WriteLine("Cargado");
				}
			} finally { }*/

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormMain());
		}
	}
}
