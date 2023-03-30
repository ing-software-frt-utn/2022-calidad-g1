namespace IDS {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Data;
	using System.Data.Entity;
	using System.Linq;

	public class BaseDeDatos : DbContext {
		// El contexto se ha configurado para usar una cadena de conexión 'Model' del archivo 
		// de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
		// esta cadena de conexión tiene como destino la base de datos '.Model' de la instancia LocalDb. 
		// 
		// Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
		// modifique la cadena de conexión 'Model'  en el archivo de configuración de la aplicación.
		public BaseDeDatos()
			: base("Database") {
			Configuration.LazyLoadingEnabled = true;
			Configuration.ProxyCreationEnabled = false;
		}

		// Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
		// sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
		public virtual DbSet<LineaDeTrabajo> LineasDeTrabajo { get; set; }
		public virtual DbSet<Modelo> Modelos { get; set; }
		public virtual DbSet<OrdenDeProduccion> OrdenesDeProduccion { get; set; }
		public virtual DbSet<Turno> Turnos { get; set; }
		public virtual DbSet<Alerta> Alertas { get; set; }
		public virtual DbSet<Color> Colores { get; set; }
		public virtual DbSet<Defecto> Defectos { get; set; }
		public virtual DbSet<JornadaLaboral> Jornadas { get; set; }
		public virtual DbSet<Incidencia> Incidencias { get; set; }
		public virtual DbSet<Empleado> Empleados { get; set; }
		
	}

	public class LineaDeTrabajo : IIdentificable {
		public int Id { get; set; }
		public int Numero { get; set; }
		public bool Eliminado { get; set; }
		public virtual OrdenDeProduccion OrdenAsociada { get; set; }

		public override string ToString() => $"Linea #{Numero}";
		public string[] Referencias => new string[] { "OrdenAsociada" };
		public string[] Listas => new string[] { };
	}

	public class Modelo : ITabla, IIdentificable {
		public int Id { get; set; }
		public long SKU { get; set; }
		public string Denominacion { get; set; }
		public int LimiteInferiorReproceso { get; set; }
		public int LimiteInferiorObservado { get; set; }
		public int LimiteSuperiorReproceso { get; set; }
		public int LimiteSuperiorObservado { get; set; }
		public bool Eliminado { get; set; }
		public string[] Referencias => new string[] { };
		public string[] Listas => new string[] { };

		public void AgregarColumnas(DataColumnCollection tabla) {
			tabla.Add("Id", typeof(int));
			tabla.Add("SKU", typeof(long));
			tabla.Add("Denominación", typeof(string));
			tabla.Add("L.I reproceso", typeof(int));
			tabla.Add("L.I observado", typeof(int));
			tabla.Add("L.S reproceso", typeof(int));
			tabla.Add("L.S observado", typeof(int));
		}

		public object[] GetValores() => new object[] { Id, SKU, Denominacion, LimiteInferiorReproceso, LimiteInferiorObservado, LimiteSuperiorReproceso, LimiteSuperiorObservado };

		public override string ToString() => Denominacion;

		public bool Filtrar(string filtro) {
			return Denominacion.Contains(filtro) || SKU.ToString().Contains(filtro);
		}

		public bool Completo() {
			return !string.IsNullOrWhiteSpace(Denominacion)
				&& SKU>0
				&& LimiteInferiorObservado > 0
				&& LimiteInferiorReproceso > 0
				&& LimiteSuperiorObservado > 0
				&& LimiteSuperiorReproceso > 0;
		}

		public bool Valido() {
			return Completo()
				&& SKU>0
				&& LimiteInferiorObservado<LimiteSuperiorObservado
				&& LimiteInferiorReproceso<LimiteSuperiorReproceso;
		}
	}

	public class OrdenDeProduccion : ITabla, IIdentificable {
		public int Id { get; set; }
		public string Numero { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime? FechaFin { get; set; }
		public EstadoOP Estado { get; set; }
		public virtual Empleado SupervisorLinea { get; set; }
		public virtual Empleado SupervisorCalidad { get; set; }
		public virtual Color Color { get; set; }
		public virtual Modelo Modelo { get; set; }
		public int NumeroLinea { get; set; }
		public virtual List<Alerta> Alertas { get; set; }
		public virtual List<JornadaLaboral> Jornadas { get; set; }
		public bool Eliminado { get; set; }

		public string[] Referencias => new string[] { "Color", "Modelo", "SupervisorLinea", "SupervisorCalidad"};
		public string[] Listas => new string[] {"Jornadas", "Alertas" };

		public OrdenDeProduccion() {
			Alertas = new List<Alerta>();
			Jornadas = new List<JornadaLaboral>();
		}

		public virtual JornadaLaboral ObtenerJornadaActual(DateTime fecha) {
			if (SupervisorCalidad == null) return null;
			JornadaLaboral j;
			for (int i = Jornadas.Count - 1; i >= 0; --i) {
				j = Jornadas[i];
				if (j.Supervisor.Id == SupervisorCalidad.Id) {
					return j;
				}
				/*if (j.FechaInicio <= fecha && j.FechaFin >= fecha) {
					return j;
				}*/
			}
			return null;
		}

		public virtual DateTime UltimaAlerta(TipoDefecto def) {
			Alerta alerta;
			for (int i = Alertas.Count - 1; i >= 0; --i) {
				alerta = Alertas[i];
				if (alerta.Tipo == def && alerta.FechaReinicio != null) {
					return alerta.FechaReinicio.Value;
				}
			}
			return FechaInicio;
		}

		public EstadoAlerta EstadoDeAlerta(TipoDefecto def) {
			Alerta alerta;
			for (int i = Alertas.Count - 1; i >= 0; --i) {
				alerta = Alertas[i];
				if (alerta.Tipo == def) {
					if (alerta.FechaReinicio == null)
						return alerta.Estado;
					else
						return EstadoAlerta.VERDE;
				}
			}
			return EstadoAlerta.VERDE;
		}

		public void GenerarAlerta(DateTime fecha, EstadoAlerta tipoAlerta, TipoDefecto tipoDefecto) {
			if (tipoAlerta == EstadoAlerta.ROJO) {
				Estado = EstadoOP.PAUSADA;
			}
			Alertas.Add(new Alerta() {
				FechaAlerta = fecha,
				Estado = tipoAlerta,
				FechaReinicio = null,
				Tipo = tipoDefecto
			});
		}

		public void Reactivar(DateTime fechaActual) {
			if (Estado != EstadoOP.PAUSADA) return;
			if (Alertas.Count > 0) {
				var alerta = Alertas[Alertas.Count - 1];
				if (alerta.FechaReinicio == null) {
					alerta.FechaReinicio = fechaActual;
				}
			}
			Estado = EstadoOP.ACTIVADA;
		}

		public JornadaLaboral CrearJornadaLaboral(Turno turno, Empleado supervisor, DateTime fecha) {
			//Establece la fecha de inicio en el dia dado a la hora de creacion
			var fechaInicio = fecha.Date + new TimeSpan(fecha.Hour, 0, 0);
			//Establece la fecha de finalizacion en el dia dado a la hora de finalizacion del turno
			var fechaFin = fecha.Date + new TimeSpan(turno.HoraFin, 0, 0);
			var jornada = new JornadaLaboral() {
				Supervisor = supervisor,
				Turno = turno,
				FechaInicio = fechaInicio,
				FechaFin = fechaFin
			};
			SupervisorCalidad = supervisor;
			Jornadas.Add(jornada);
			return jornada;
		}

		public void AgregarColumnas(DataColumnCollection columnas) {
			columnas.Add("Id", typeof(int));
			columnas.Add("Numero", typeof(string));
			columnas.Add("Inicio", typeof(DateTime));
			columnas.Add("Fin", typeof(DateTime));
			columnas.Add("Linea", typeof(int));
			columnas.Add("Estado", typeof(string));
			columnas.Add("Color", typeof(string));
			columnas.Add("Modelo", typeof(string));
			columnas.Add("Alertas generadas", typeof(int));
			columnas.Add("Jornadas laborales", typeof(int));
		}

		public object[] GetValores() => new object[] {
			Id, Numero, FechaInicio, FechaFin, NumeroLinea, Estado.ToString(), Color.Descripcion, Modelo.Denominacion,
			Alertas.Count, Jornadas.Count
		};

		public bool Filtrar(string filtro) {
			return Numero.ToString().Contains(filtro)
				|| Estado.ToString().Contains(filtro)
				|| Color.ToString().Contains(filtro)
				|| Modelo.ToString().Contains(filtro);
		}

		public bool Valido() {
			return Completo()
				&& (FechaFin == null || FechaFin > FechaInicio);
		}

		public bool Completo() {
			return string.IsNullOrWhiteSpace(Numero)
				&& Color != null
				&& Modelo != null
				&& NumeroLinea > 0;
		}
	}

	public enum EstadoOP {
		ACTIVADA,
		PAUSADA,
		FINALIZADA
	}

	public class Turno : IIdentificable {
		public int Id { get; set; }
		public int HoraInicio { get; set; }
		public int HoraFin { get; set; }
		public bool Eliminado { get; set; }
		public string[] Referencias => new string[] { };
		public string[] Listas => new string[] { };
	}

	public class Alerta : IIdentificable {
		public int Id { get; set; }
		public DateTime FechaAlerta { get; set; }
		public DateTime? FechaReinicio { get; set; }
		public TipoDefecto Tipo { get; set; }
		public EstadoAlerta Estado { get; set; }
		public bool Eliminado { get; set; }
		public string[] Referencias => new string[] { };
		public string[] Listas => new string[] { };
	}

	public enum EstadoAlerta {
		VERDE,
		AMARILLO,
		ROJO
	}

	public class Color : ITabla, IIdentificable {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public bool Eliminado { get; set; }
		public string[] Referencias => new string[] { };
		public string[] Listas => new string[] { };

		public void AgregarColumnas(DataColumnCollection columnas) {
			columnas.Add("Id", typeof(int));
			columnas.Add("Descripcion", typeof(string));
		}

		public object[] GetValores() => new object[] { Id, Descripcion };

		public override string ToString() => Descripcion;

		public bool Filtrar(string filtro) {
			return Descripcion.Contains(filtro);
		}

		public bool Completo() {
			return !string.IsNullOrEmpty(Descripcion);
		}

		public bool Valido() {
			return !string.IsNullOrEmpty(Descripcion);
		}

	}

	public class Defecto : IIdentificable {
		public int Id { get; set; }
		public string Descripcion { get; set; }
		public TipoDefecto TipoDef { get; set; }
		public bool Eliminado { get; set; }
		public string[] Referencias => new string[] { };
		public string[] Listas => new string[] { };
	}

	public enum TipoDefecto {
		OBSERVADO,
		REPROCESO
	}

	public class JornadaLaboral : IIdentificable {
		public int Id { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFin { get; set; }
		public virtual Turno Turno { get; set; }
		public virtual Empleado Supervisor { get; set; }
		public virtual List<Incidencia> Incidencias { get; set; }
		public int HermanadoPrimera { get; set; }
		public int HermanadoSegunda { get; set; }
		public bool Eliminado { get; set; }
		public string[] Referencias => new string[] {"Turno", "Supervisor"};
		public string[] Listas => new string[] { "Incidencias" };

		public JornadaLaboral() {
			Incidencias = new List<Incidencia>();
		}

		public virtual int ContarDefectos(TipoDefecto defecto, DateTime fechaDesde) {
			int i = 0;
			foreach (var inc in Incidencias) {
				if (inc.FechaHoraRegistro>=fechaDesde)
				if (inc.TipoIncidencia == TipoIncidencia.DEFECTO && inc.Defecto.TipoDef == defecto) {
					i += 1;
				}
			}
			return i;
		}

		public void AgregarParPrimera(DateTime fecha) {
			var inc = new Incidencia() {
				TipoIncidencia = TipoIncidencia.PRIMERA,
				FechaHoraRegistro = fecha,
				FechaHora = fecha
			};
			Incidencias.Add(inc);
		}

		public void AgregarIncidencia(DateTime fecha, DateTime fechaActual, Defecto defecto, TipoPie pie) {
			var inc = new Incidencia() {
				TipoIncidencia = TipoIncidencia.DEFECTO,
				Defecto = defecto,
				FechaHoraRegistro = fechaActual,
				Pie = pie,
				FechaHora = fecha
			};
			Incidencias.Add(inc);
		}

		public int CantidadDeIncidencias() {
			int x = 0;
			foreach (var inc in Incidencias) {
				if (inc.TipoIncidencia == TipoIncidencia.DEFECTO) {
					x++;
				}
			}
			return x;
		}

		public void RegistrarHermanado(int totalesPrimera, int totalesSegunda) {
			HermanadoPrimera = totalesPrimera;
			HermanadoSegunda = totalesSegunda;
		}
	}

	public class Incidencia : IIdentificable {
		public int Id { get; set; }
		public DateTime FechaHora { get; set; }
		public DateTime FechaHoraRegistro { get; set; }
		public TipoPie Pie { get; set; }
		public virtual Defecto Defecto { get; set; }
		public TipoIncidencia TipoIncidencia { get; set; }
		public bool Eliminado { get; set; }

		public string[] Referencias => new string[] {"Defecto"};
		public string[] Listas => new string[] { };
	}

	public enum TipoPie {
		IZQUIERDO,
		DERECHO
	}

	public enum TipoIncidencia {
		PRIMERA,
		DEFECTO
	}

	public class Empleado : ITabla, IIdentificable {
		public int Id { get; set; }
		public int Legajo { get; set; }
		public int DNI { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public DateTime FechaNac { get; set; }
		public RolEmpleado Rol { get; set; }
		public string Correo { get; set; }
		public string Usuario { get; set; }
		public string Contraseña { get; set; }
		public bool Eliminado { get; set; }
		public string[] Referencias => new string[] { };
		public string[] Listas => new string[] { };

		public void AgregarColumnas(DataColumnCollection columnas) {
			columnas.Add("Id", typeof(int));
			columnas.Add("Legajo", typeof(int));
			columnas.Add("DNI", typeof(int));
			columnas.Add("Nombre", typeof(string));
			columnas.Add("Apellido", typeof(string));
			columnas.Add("Fecha de nacimiento", typeof(DateTime));
			columnas.Add("Rol", typeof(string));
			columnas.Add("Correo", typeof(string));
			columnas.Add("Usuario", typeof(string));
		}

		public object[] GetValores() => new object[] {
			Id, Legajo, DNI, Nombre, Apellido, FechaNac, Rol.ToString(), Correo, Usuario
		};

		public bool Filtrar(string filtro) {
			return Legajo.ToString().Contains(filtro)
				|| DNI.ToString().Contains(filtro)
				|| Nombre.Contains(filtro)
				|| Apellido.Contains(filtro)
				|| FechaNac.ToString().Contains(filtro)
				|| Rol.ToString().Contains(filtro)
				|| Correo.Contains(filtro)
				|| Usuario.Contains(filtro);
		}

		public bool Completo() {
			return Legajo > 0
				&& DNI > 0
				&& !string.IsNullOrWhiteSpace(Nombre)
				&& !string.IsNullOrWhiteSpace(Apellido)
				&& !string.IsNullOrWhiteSpace(Usuario)
				&& !string.IsNullOrWhiteSpace(Contraseña)
				&& !string.IsNullOrWhiteSpace(Correo)
				&& Rol != RolEmpleado.Ninguno
				&& FechaNac > new DateTime(1900, 1, 1);
		}

		public bool Valido() {
			return Completo();
		}
	}

	public enum RolEmpleado {
		Ninguno = 0,
		SupervisorCalidad = 1,
		SupervisorLinea = 2,
		Administrativo = 3
	}
}