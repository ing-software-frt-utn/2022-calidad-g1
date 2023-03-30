using IDS;
using IDS.Aplicacion;
using System;
using System.Data;
using System.Web.Services;

namespace IDS_TP1_V2._0.Servicios {
	public partial class IDSService : System.Web.Services.WebService {
		[WebMethod]
		public RespuestaABM AñadirEmpleado(
					int legajo, int dni, string nombre, string apellido, RolEmpleado rol,
					string correo, string usuario, string contraseña, DateTime fecha)
			=> ControladorABM.AñadirEmpleado(legajo, dni, nombre, apellido, rol, correo, usuario, contraseña, fecha);

		[WebMethod]
		public RespuestaABM ModificarEmpleado(Empleado Empleado)
			=> ControladorABM.ModificarEmpleado(Empleado);

		[WebMethod]
		public RespuestaABM EliminarEmpleado(int id)
			=> ControladorABM.EliminarEmpleado(id);

		[WebMethod]
		public Empleado[] ListarEmpleados()
			=> ControladorABM.ListarEmpleados();

		[WebMethod]
		public DataTable GetTablaEmpleados()
			=> ControladorABM.GetTablaEmpleados();

		[WebMethod]
		public DataTable GetTablaFiltradaEmpleados(string filtro)
			=> ControladorABM.GetTablaFiltradaEmpleados(filtro);

		[WebMethod]
		public Empleado BuscarEmpleado(int id)
			=> ControladorABM.BuscarEmpleado(id);
	}
}