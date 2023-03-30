using IDS;
using IDS.Aplicacion;
using System;
using System.Data;
using System.Web.Services;

namespace IDS_TP1_V2._0.Servicios {
	public partial class IDSService : System.Web.Services.WebService {

		[WebMethod]
		public ControladorOP.RespuestaCreacionOP CrearOrdenDeProduccion(
						Empleado empleado,
						string numero, int numeroLinea,
						int skuModelo, int color)
			=> ControladorOP.CrearOrdenDeProduccion(empleado, numero, numeroLinea, skuModelo, color);

		[WebMethod]
		public ControladorOP.RespuestaCambioDeEstado PausarOrden(int id, Empleado empleado)
			=> ControladorOP.PausarOrden(id, empleado);

		[WebMethod]
		public ControladorOP.RespuestaCambioDeEstado ReanudarOrden(int id, Empleado empleado)
			=> ControladorOP.ReanudarOrden(id, empleado);

		[WebMethod]
		public ControladorOP.RespuestaCambioDeEstado FinalizarOrden(int id)
			=> ControladorOP.FinalizarOrden(id);

		[WebMethod]
		public OrdenDeProduccion BuscarOrden(int id)
			=> ControladorOP.BuscarOrden(id);

		[WebMethod]
		public OrdenDeProduccion BuscarOrdenEnLinea(int nroLinea)
			=> ControladorOP.BuscarOrdenEnLinea(nroLinea);

		[WebMethod]
		public OrdenDeProduccion[] ListarOrdenes()
			=> ControladorOP.ListarOrdenes();

		[WebMethod]
		public DataTable GetTablaOrdenes() => ControladorOP.GetTablaOrdenes();

		[WebMethod]
		public DataTable GetTablaFiltradaOrdenes(string filtro)
			=> ControladorOP.GetTablaFiltradaOrdenes(filtro);

#if DEBUG
		[WebMethod]
		public void EliminarOrden(int id) {
			using (var db = ControladorDatos.CrearGestor()) {
				var op = db.Buscar<OrdenDeProduccion>(id);
				if (op != null) {
					foreach (var linea in db.Listar<LineaDeTrabajo>()) {
						if (linea.OrdenAsociada?.Id == op.Id) {
							linea.OrdenAsociada = null;
							break;
						}
					}
					db.Quitar(op);
				}
				db.Guardar();
			}
		}
#endif

	}
}