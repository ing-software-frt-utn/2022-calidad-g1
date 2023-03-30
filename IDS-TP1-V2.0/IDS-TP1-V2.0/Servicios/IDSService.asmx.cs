using IDS;
using IDS.Aplicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IDS_TP1_V2._0.Servicios {
	/// <summary>
	/// Descripción breve de IDSService
	/// </summary>
	[WebService(Namespace = URI)]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
	// [System.Web.Script.Services.ScriptService]
	public partial class IDSService : System.Web.Services.WebService {

		public const string URI = "http://tempuri.org/";

		public IDSService() {}

		[WebMethod]
		public ControladorLogin.LoginRespuesta Login(string usuario, string contraseña) => ControladorLogin.InicioDeSesion(usuario, contraseña);

#if DEBUG
		[WebMethod]
		public void InicializarBaseDeDatos()
			=> ControladorDatosIniciales.InicializarBaseDeDatos();
#endif

		[WebMethod]
		public LineaDeTrabajo[] ListarLineasDeTrabajo()
			=> ControladorABM.ListarLineasDeTrabajo();

		[WebMethod]
		public EstadoLinea[] EstadoDeLineasDeTrabajo(Empleado empleado)
			=> ControladorLineasDeTrabajo.GetLineasDeTabajo(empleado);

		[WebMethod]
		public LineaDeTrabajo GetLineaDeTrabajo(OrdenDeProduccion op)
			=> ControladorABM.BuscarLineaDeTrabajo(op);

		[WebMethod]
		public Defecto[] GetDefectos()
			=> ControladorABM.GetDefectos();

	}
}
