using IDS.Aplicacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace IDS.PruebasUnitarias {
	[TestClass]
	public class GestorSemaforo_Test {

		[TestMethod]
		public void Semaforo_EnVerde() {
			var incidencias = 2;
			var limiteInferior = 5;
			var limiteSuperior = 10;
			var fecha = DateTime.Now;

			var tipoDefecto = TipoDefecto.OBSERVADO;
			var jornada = new Mock<JornadaLaboral>();
			jornada.Setup<int>((x) => x.ContarDefectos(tipoDefecto, fecha)).Returns(incidencias);

			var modelo = new Modelo {
				LimiteInferiorObservado = limiteInferior,
				LimiteSuperiorObservado = limiteSuperior
			};

			var alerta = GestorSemaforo.ConsultarSemaforo(jornada.Object, modelo, fecha, tipoDefecto);

			Assert.AreEqual(IDS.EstadoAlerta.VERDE, alerta);
		}

		[TestMethod]
		public void Semaforo_EnAmarillo() {
			var incidencias = 5;
			var limiteInferior = 5;
			var limiteSuperior = 10;
			var fecha = DateTime.Now;

			var tipoDefecto = TipoDefecto.OBSERVADO;
			var jornada = new Mock<JornadaLaboral>();
			jornada.Setup<int>((x) => x.ContarDefectos(tipoDefecto, fecha)).Returns(incidencias);

			var modelo = new Modelo {
				LimiteInferiorObservado = limiteInferior,
				LimiteSuperiorObservado = limiteSuperior
			};

			var alerta = GestorSemaforo.ConsultarSemaforo(jornada.Object, modelo, fecha, tipoDefecto);

			Assert.AreEqual(EstadoAlerta.AMARILLO, alerta);
		}

		[TestMethod]
		public void Semaforo_EnRojo() {
			var incidencias = 10;
			var limiteInferior = 5;
			var limiteSuperior = 10;
			var fecha = DateTime.Now;

			var tipoDefecto = TipoDefecto.OBSERVADO;
			var jornada = new Mock<JornadaLaboral>();
			jornada.Setup<int>((x) => x.ContarDefectos(tipoDefecto, fecha)).Returns(incidencias);

			var modelo = new Modelo {
				LimiteInferiorObservado = limiteInferior,
				LimiteSuperiorObservado = limiteSuperior
			};

			var alerta = GestorSemaforo.ConsultarSemaforo(jornada.Object, modelo, fecha, tipoDefecto);

			Assert.AreEqual(EstadoAlerta.ROJO, alerta);
		}

	}
}
