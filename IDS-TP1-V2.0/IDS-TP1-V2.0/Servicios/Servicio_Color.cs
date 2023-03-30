using IDS;
using IDS.Aplicacion;
using System.Data;
using System.Web.Services;

namespace IDS_TP1_V2._0.Servicios {
	public partial class IDSService : System.Web.Services.WebService {

		[WebMethod]
		public RespuestaABM AñadirColor(string desc)
			=> ControladorABM.AñadirColor(desc);

		[WebMethod]
		public RespuestaABM ModificarColor(Color Color)
			=> ControladorABM.ModificarColor(Color);

		[WebMethod]
		public RespuestaABM EliminarColor(int ID)
			=> ControladorABM.EliminarColor(ID);

		[WebMethod]
		public Color[] ListarColores()
			=> ControladorABM.ListarColores();

		[WebMethod]
		public DataTable GetTablaColores()
			=> ControladorABM.GetTablaColores();

		[WebMethod]
		public DataTable GetTablaFiltradaColores(string filtro)
			=> ControladorABM.FiltrarColores(filtro);

		[WebMethod]
		public Color BuscarColor(int id)
			=> ControladorABM.BuscarColor(id);

	}
}