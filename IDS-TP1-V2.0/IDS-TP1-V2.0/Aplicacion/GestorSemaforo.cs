using IDS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDS.Aplicacion {
	public class GestorSemaforo {

		public static EstadoAlerta ConsultarSemaforo(JornadaLaboral jornada, Modelo modelo, DateTime fechaInicio, TipoDefecto tipoDefecto) {
			if (jornada == null) return EstadoAlerta.VERDE;
			var cantDefectos = jornada.ContarDefectos(tipoDefecto, fechaInicio);
			int limiteInferior = 0, limiteSuperior = 0;
			switch (tipoDefecto) {
				case TipoDefecto.OBSERVADO:
					limiteInferior = modelo.LimiteInferiorObservado;
					limiteSuperior = modelo.LimiteSuperiorObservado;
					break;
				case TipoDefecto.REPROCESO:
					limiteInferior = modelo.LimiteInferiorReproceso;
					limiteSuperior = modelo.LimiteSuperiorReproceso;
					break;
			}
			if (cantDefectos >= limiteSuperior) {
				return EstadoAlerta.ROJO;
			} else if (cantDefectos >= limiteInferior) {
				return EstadoAlerta.AMARILLO;
			} else {
				return EstadoAlerta.VERDE;
			}
		}

	}
}