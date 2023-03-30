using System;
using IDS;
using IDS.Aplicacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IDS.PruebasUnitarias {
	[TestClass]
	public class OrdenDeProduccion_Test {

		[TestMethod]
		public void UltimaAlerta_SinAlertas() {
			var tipoDefecto = TipoDefecto.OBSERVADO;
			var fechaInicio = DateTime.Now;

			var op = new OrdenDeProduccion() { FechaInicio = fechaInicio };

			var respuesta = op.UltimaAlerta(tipoDefecto);

			Assert.AreEqual(fechaInicio, respuesta);
		}

		[TestMethod]
		public void UltimaAlerta_ConAlertas() {
			var tipoDefecto = TipoDefecto.OBSERVADO;
			var fechaInicio = DateTime.Now;
			var fechaAlerta = fechaInicio + new TimeSpan(2, 0, 0);
			var fechaReinicio = fechaAlerta + new TimeSpan(2, 0, 0);

			var op = new OrdenDeProduccion() { FechaInicio = fechaInicio };
			op.GenerarAlerta(fechaAlerta, EstadoAlerta.ROJO, tipoDefecto);
			op.Reactivar(fechaReinicio);

			var respuesta = op.UltimaAlerta(tipoDefecto);

			Assert.AreEqual(fechaReinicio, respuesta);
		}

		[TestMethod]
		public void JornadaActual_EnJornada() {
			var horaInicioTurno = 10;
			var horaFinTurno = horaInicioTurno + 10;

			var fechaCreacion = DateTime.Now.Date + new TimeSpan(horaInicioTurno, 0, 0);
			var fechaActual = fechaCreacion + new TimeSpan(5, 0, 0);
			var fechaFin = DateTime.Now.Date + new TimeSpan(horaFinTurno, 0, 0);

			var turno = new Turno() { HoraInicio = horaInicioTurno, HoraFin = horaFinTurno };
			var empleado = new Mock<Empleado>();
			empleado.Object.Rol = RolEmpleado.SupervisorCalidad;

			var op = new OrdenDeProduccion() {};

			op.CrearJornadaLaboral(turno, empleado.Object, fechaActual);

			var jornada = op.ObtenerJornadaActual(fechaActual);

			Assert.IsNotNull(jornada);
			Assert.AreEqual(fechaActual, jornada.FechaInicio);
			Assert.AreEqual(fechaFin, jornada.FechaFin);
		}

		[TestMethod]
		public void JornadaActual_FueraDeJornada() {
			var horaInicioTurno = 10;
			var horaFinTurno = horaInicioTurno + 10;

			var fechaCreacion = DateTime.Now.Date + new TimeSpan(horaInicioTurno, 0, 0);
			var fechaFin = DateTime.Now.Date + new TimeSpan(horaFinTurno, 0, 0);

			var fechaActual = fechaFin + new TimeSpan(5, 0, 0);

			var turno = new Turno() { HoraInicio = horaInicioTurno, HoraFin = horaFinTurno };
			var empleado = new Mock<Empleado>();
			empleado.Object.Rol = RolEmpleado.SupervisorCalidad;

			var op = new OrdenDeProduccion() { };

			op.CrearJornadaLaboral(turno, empleado.Object, fechaCreacion);
			op.SupervisorCalidad = null;

			var respuesta = op.ObtenerJornadaActual(fechaActual);

			Assert.IsNull(respuesta);
		}

		[TestMethod]
		public void ReactivarOP() {
			var op = new OrdenDeProduccion();
			var fechaAlerta = DateTime.Now;
			var fechaReinicio = DateTime.Now;

			op.GenerarAlerta(fechaAlerta, EstadoAlerta.ROJO, TipoDefecto.OBSERVADO);

			op.Reactivar(fechaReinicio);
			
			var alerta = op.Alertas[0];
			Assert.AreEqual(fechaReinicio, alerta.FechaReinicio);
		}

		[TestMethod]
		public void GenerarAlerta() {
			var op = new OrdenDeProduccion();
			var fechaAlerta = DateTime.Now;
			var estado = EstadoAlerta.ROJO;
			var tipo = TipoDefecto.OBSERVADO;

			op.GenerarAlerta(fechaAlerta, estado, tipo);

			Assert.AreEqual(1, op.Alertas.Count);

			var alerta = op.Alertas[0];
			Assert.AreEqual(estado, alerta.Estado);
			Assert.AreEqual(tipo, alerta.Tipo);
			Assert.AreEqual(fechaAlerta, alerta.FechaAlerta);
		}
	}
}
