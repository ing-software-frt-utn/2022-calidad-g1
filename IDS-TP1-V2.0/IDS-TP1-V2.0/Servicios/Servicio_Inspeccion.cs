using IDS;
using IDS.Aplicacion;
using System;
using System.Data;
using System.Web.Services;

namespace IDS_TP1_V2._0.Servicios {
	public partial class IDSService : System.Web.Services.WebService {
		[WebMethod]
		public JornadaLaboral ObtenerJornada(int nroLinea, Empleado empleado)
			=> ControladorInspeccion.ObtenerJornada(nroLinea, empleado);

		[WebMethod]
		public RespuestaJornada IniciarJornada(int nroLinea, Empleado empleado)
			=> ControladorInspeccion.IniciarJornada(nroLinea, empleado);

		[WebMethod]
		public Incidencia[] GetListaIncidencias(Empleado empleado)
			=> ControladorInspeccion.GetListaIncidencias(empleado);

		[WebMethod]
		public RespuestaSincronizacion RegistrarAccionesInspeccion(Empleado empleado, params AccionDeInspeccion[] acciones)
			=> ControladorInspeccion.RegistrarAcciones(empleado, acciones);

		[WebMethod]
		public RespuestaDesvinculacion DesvincularSupervisorDeCalidad(Empleado empleado)
			=> ControladorInspeccion.DesvincularSupervisor(empleado);

		[WebMethod]
		public RespuestaHermanado RegistrarHermanado(Empleado empleado, int totalesPrimera, int totalesSegunda, bool validar)
			=> ControladorInspeccion.RegistrarHermanado(empleado, totalesPrimera, totalesSegunda, validar);

	}
}