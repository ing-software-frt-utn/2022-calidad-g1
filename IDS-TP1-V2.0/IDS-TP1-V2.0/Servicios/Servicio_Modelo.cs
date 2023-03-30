using IDS;
using IDS.Aplicacion;
using System.Data;
using System.Web.Services;

namespace IDS_TP1_V2._0.Servicios {
	public partial class IDSService : System.Web.Services.WebService {
		[WebMethod]
		public RespuestaABM AñadirModelo(long sku, string denom, int lir, int lio, int lsr, int lso)
			=> ControladorABM.AñadirModelo(sku, denom, lir, lio, lsr, lso);

		[WebMethod]
		public RespuestaABM ModificarModelo(Modelo modelo)
			=> ControladorABM.ModificarModelo(modelo);

		[WebMethod]
		public RespuestaABM EliminarModelo(int SKU)
			=> ControladorABM.EliminarModelo(SKU);

		[WebMethod]
		public Modelo[] ListarModelos()
			=> ControladorABM.ListarModelos();

		[WebMethod]
		public DataTable GetTablaModelos()
			=> ControladorABM.GetTablaModelos();

		[WebMethod]
		public DataTable GetTablaFiltradaModelos(string filtro)
			=> ControladorABM.GetTablaFiltradaModelos(filtro);

		[WebMethod]
		public Modelo BuscarModelo(int SKU)
			=> ControladorABM.BuscarModelo(SKU);
	}
}