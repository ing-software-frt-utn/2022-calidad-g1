using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IDS.PruebasUnitarias {
	[TestClass]
	public class JornadaLaboral_Test {
		[TestMethod]
		public void ContarDefectos_SinDefectos() {
			var fechaIncidencias = DateTime.Now;
			var fechaCuenta = fechaIncidencias.Subtract(new TimeSpan(0, 15, 0));
			var tipoDefecto = TipoDefecto.OBSERVADO;

			var jornada = new JornadaLaboral();
			
			var respuesta = jornada.ContarDefectos(tipoDefecto, fechaCuenta);

			Assert.AreEqual(0, respuesta);
		}

		[TestMethod]
		public void ContarDefectos_ConDefectos() {
			var fechaIncidencias = DateTime.Now;
			var fechaCuenta = fechaIncidencias.Subtract(new TimeSpan(0, 15, 0));
			var incidenciasObservado = 5;
			var incidenciasReproceso = 3;

			var defectoO = new Mock<Defecto>();
			defectoO.Object.TipoDef = TipoDefecto.OBSERVADO;
			var defectoR = new Mock<Defecto>();
			defectoR.Object.TipoDef = TipoDefecto.REPROCESO;

			var pie = TipoPie.DERECHO;

			var jornada = new JornadaLaboral();

			for (int i = 0; i < incidenciasObservado; i++) {
				jornada.AgregarIncidencia(fechaIncidencias, fechaIncidencias, defectoO.Object, pie);
			}

			for (int i = 0; i < incidenciasReproceso; i++) {
				jornada.AgregarIncidencia(fechaIncidencias, fechaIncidencias, defectoR.Object, pie);
			}


			var respuestaO = jornada.ContarDefectos(TipoDefecto.OBSERVADO, fechaCuenta);
			var respuestaR = jornada.ContarDefectos(TipoDefecto.REPROCESO, fechaCuenta);

			Assert.AreEqual(incidenciasObservado, respuestaO);
			Assert.AreEqual(incidenciasReproceso, respuestaR);
		}

		[TestMethod]
		public void AgregarParDePrimera() {

			var fecha = DateTime.Now;
			var jornada = new JornadaLaboral();
			
			jornada.AgregarParPrimera(fecha);

			Assert.AreEqual(1, jornada.Incidencias.Count);
			Assert.AreEqual(TipoIncidencia.PRIMERA, jornada.Incidencias[0].TipoIncidencia);
		}

		[TestMethod]
		public void AgregarDefecto() {

			var fecha = DateTime.Now;
			var jornada = new JornadaLaboral();

			var defecto = new Mock<Defecto>();
			var pie = TipoPie.DERECHO;

			jornada.AgregarIncidencia(fecha, fecha, defecto.Object, pie);

			var incidencia = jornada.Incidencias[0];

			Assert.AreEqual(1, jornada.Incidencias.Count);
			Assert.AreEqual(TipoIncidencia.DEFECTO, incidencia.TipoIncidencia);
			Assert.AreEqual(defecto.Object, incidencia.Defecto);
			Assert.AreEqual(pie, incidencia.Pie);
		}
	}
}
