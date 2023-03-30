using IDS;
using System;

namespace IDS.Aplicacion {
	public static class ControladorDatosIniciales {

		public static void InicializarBaseDeDatos() {
			using (var db = new BaseDeDatos()) {
				db.Database.Delete();

				//Empleados
				db.Empleados.Add(new Empleado() {
					FechaNac = DateTime.Now,
					Apellido = "Administrador",
					Nombre = "Administrador",
					Correo = "-",
					DNI = 0,
					Legajo = 0,
					Usuario = "admin",
					Contraseña = "admin",
					Rol = RolEmpleado.Administrativo
				});

				//Lineas
				db.LineasDeTrabajo.Add(new LineaDeTrabajo() {
					Numero = 1
				});
				db.LineasDeTrabajo.Add(new LineaDeTrabajo() {
					Numero = 2
				});
				db.LineasDeTrabajo.Add(new LineaDeTrabajo() {
					Numero = 3
				});
				db.LineasDeTrabajo.Add(new LineaDeTrabajo() {
					Numero = 4
				});

				//Turnos
				db.Turnos.Add(new Turno() {
					HoraInicio = 8,
					HoraFin = 12
				});
				db.Turnos.Add(new Turno() {
					HoraInicio = 12,
					HoraFin = 16
				});
				db.Turnos.Add(new Turno() {
					HoraInicio = 16,
					HoraFin = 20
				});
				db.Turnos.Add(new Turno() {
					HoraInicio = 20,
					HoraFin = 24
				});

				db.Defectos.Add(new Defecto() {
					Descripcion = "Def Observado 1",
					TipoDef = TipoDefecto.OBSERVADO
				});

				db.Defectos.Add(new Defecto() {
					Descripcion = "Def Observado 2",
					TipoDef = TipoDefecto.OBSERVADO
				});

				db.Defectos.Add(new Defecto() {
					Descripcion = "Def Observado 3",
					TipoDef = TipoDefecto.OBSERVADO
				});

				db.Defectos.Add(new Defecto() {
					Descripcion = "Def Reproceso 1",
					TipoDef = TipoDefecto.REPROCESO
				});

				db.Defectos.Add(new Defecto() {
					Descripcion = "Def Reproceso 2",
					TipoDef = TipoDefecto.REPROCESO
				});

				db.Defectos.Add(new Defecto() {
					Descripcion = "Def Reproceso 3",
					TipoDef = TipoDefecto.REPROCESO
				});

				db.SaveChanges();
			}
		}

	}
}