using IDS;
using IDS.Aplicacion;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;

namespace IDS_TP1_V2._0.Servicios {
	public partial class IDSService : System.Web.Services.WebService {

		[WebMethod]
		public InformacionSemaforo ObtenerInformacionSemaforo(int linea, Empleado empleado)
			=> ControladorSemaforo.ConsultarSemaforo(linea, empleado);

	}

	public struct InformacionSemaforo {
		public EstadoAlerta reproceso, observado;
		public Cuenta[] defectosRecientes;
		public int defectosTotales;
		public RespuestaSemaforo respuesta;
	}

	public struct Cuenta {
		public string defecto;
		public int cantidad;

		public Cuenta(string def, int can) {
			defecto = def;
			cantidad = can;
		}
	}
}