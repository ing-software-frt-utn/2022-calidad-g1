using System;
using IDS;
using IDS.Aplicacion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IDS.PruebasIntegracion {
	[TestClass]
	public class Controlador_OP {
		[TestMethod]
		public void Agregar_Exito() {
			ControladorDatos.Prueba = true;

			var idModelo = 256;
			var idColor = 5;
			var numLinea = 3;
			var numOp = "12345";

			var empleado = new Empleado() { Rol = RolEmpleado.SupervisorLinea };
			using (var bd = ControladorDatos.CrearGestor()) {
				bd.Agregar(new Modelo() { Id = idModelo });
				bd.Agregar(new Color() { Id = idColor });
				bd.Agregar(new LineaDeTrabajo() { Numero = numLinea });
			}

			var respuesta = ControladorOP.CrearOrdenDeProduccion(empleado, numOp, numLinea, idModelo, idColor);

			Assert.AreEqual(ControladorOP.RespuestaCreacionOP.Exito, respuesta);

			ControladorDatos.Prueba = false;
		}

		[TestMethod]
		public void Agregar_Error_Existente() {
			ControladorDatos.Prueba = true;

			var idModelo = 256;
			var idColor = 5;
			var numLinea = 3;
			var numOp = "1";

			var empleado = new Empleado() { Rol = RolEmpleado.SupervisorLinea };
			using (var bd = ControladorDatos.CrearGestor()) {
				bd.Agregar(new OrdenDeProduccion() { Numero = numOp });
				bd.Agregar(new Modelo() { Id = idModelo });
				bd.Agregar(new Color() { Id = idColor });
				bd.Agregar(new LineaDeTrabajo() { Numero = numLinea });
			}

			var respuesta = ControladorOP.CrearOrdenDeProduccion(empleado, numOp, numLinea, idModelo, idColor);

			Assert.AreEqual(ControladorOP.RespuestaCreacionOP.Error_Existente, respuesta);

			ControladorDatos.Prueba = false;
		}

		[TestMethod]
		public void Agregar_Error_LineaInexistente() {
			ControladorDatos.Prueba = true;

			var idModelo = 256;
			var idColor = 5;
			var numLinea = 3;
			var numOp = "1";

			var empleado = new Empleado() { Rol = RolEmpleado.SupervisorLinea };
			using (var bd = ControladorDatos.CrearGestor()) {
				bd.Agregar(new Color() { Id = idColor });
			}

			var respuesta = ControladorOP.CrearOrdenDeProduccion(empleado, numOp, numLinea, idModelo, idColor);

			Assert.AreEqual(ControladorOP.RespuestaCreacionOP.Error_DatosInvalidos, respuesta);

			ControladorDatos.Prueba = false;
		}

		[TestMethod]
		public void Agregar_Error_Invalido() {
			ControladorDatos.Prueba = true;

			var idModelo = 256;
			var idColor = 5;
			var numLinea = 3;
			var numOp = "1";

			var empleado = new Empleado() { Rol = RolEmpleado.SupervisorLinea };
			using (var bd = ControladorDatos.CrearGestor()) {
				bd.Agregar(new Color() { Id = idColor });
				bd.Agregar(new LineaDeTrabajo() { Numero = numLinea });
			}

			var respuesta = ControladorOP.CrearOrdenDeProduccion(empleado, numOp, numLinea, idModelo, idColor);

			Assert.AreEqual(ControladorOP.RespuestaCreacionOP.Error_DatosInvalidos, respuesta);

			ControladorDatos.Prueba = false;
		}

		[TestMethod]
		public void Agregar_Error_SinPermiso() {
			ControladorDatos.Prueba = true;

			var idModelo = 256;
			var idColor = 5;
			var numLinea = 3;
			var numOp = "1";

			var empleado = new Empleado() { Rol = RolEmpleado.SupervisorCalidad };

			var respuesta = ControladorOP.CrearOrdenDeProduccion(empleado, numOp, numLinea, idModelo, idColor);

			Assert.AreEqual(ControladorOP.RespuestaCreacionOP.Error_Permisos, respuesta);

			ControladorDatos.Prueba = false;
		}

		[TestMethod]
		public void Agregar_Error_LineaOcupada() {
			ControladorDatos.Prueba = true;

			var idModelo = 256;
			var idColor = 5;
			var numLinea = 3;
			var numOp = "1";

			var empleado1 = new Mock<Empleado>();
			empleado1.Object.Id = 1;
			empleado1.Object.Rol = RolEmpleado.SupervisorLinea;

			var empleado2 = new Mock<Empleado>();
			empleado2.Object.Id = 2;
			empleado2.Object.Rol = RolEmpleado.SupervisorLinea;

			var orden = new Mock<OrdenDeProduccion>();
			orden.SetupGet((o) => o.SupervisorLinea).Returns(empleado1.Object);

			var linea = new Mock<LineaDeTrabajo>();
			linea.Object.Numero = numLinea;

			linea.SetupGet((l) => l.OrdenAsociada).Returns(orden.Object);
			
			using (var bd = ControladorDatos.CrearGestor()) {
				bd.Agregar(new Modelo() { Id = idModelo });
				bd.Agregar(new Color() { Id = idColor });
				bd.Agregar(linea.Object);
			}

			var respuesta = ControladorOP.CrearOrdenDeProduccion(empleado2.Object, numOp, numLinea, idModelo, idColor);

			Assert.AreEqual(ControladorOP.RespuestaCreacionOP.Error_Linea, respuesta);

			ControladorDatos.Prueba = false;
		}
	}
}
