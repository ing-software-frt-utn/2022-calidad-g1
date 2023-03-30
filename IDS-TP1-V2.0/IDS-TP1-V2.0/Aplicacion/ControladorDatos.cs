using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IDS.Aplicacion {
	public static class ControladorDatos {

#if DEBUG
		private static bool usandoPruebas;

		public static bool Prueba {
			get => usandoPruebas;
			set {
				if (value) {
					GestorDB_RAM.Inicializar();
				} else {
					GestorDB_RAM.Limpiar();
				}
				usandoPruebas = value;
			}
		}

		public static GestorDB CrearGestor() => Prueba ? (GestorDB)new GestorDB_RAM() : (GestorDB)new GestorDB_EF();
#else
		public static GestorDB CrearGestor() => new GestorDB_EF();
#endif

	}

	public abstract class GestorDB : IDisposable {

		public abstract void Agregar<T>(T objeto) where T : class, IIdentificable;
		public abstract void Modificar<T>(T objeto) where T : class, IIdentificable;
		public abstract void Quitar<T>(T objeto) where T : class, IIdentificable;

		public abstract void Asociar<T>(T objeto) where T : class, IIdentificable;

		public abstract void Cargar<T>(T objeto, string referencia) where T : class, IIdentificable;
		public abstract void CargarLista<T>(T objeto, string referencia) where T : class, IIdentificable;

		public void Llenar<T>(T objeto) where T:class, IIdentificable{
			foreach (var r in objeto.Referencias) {
				Cargar(objeto, r);
			}

			foreach (var l in objeto.Listas) {
				CargarLista(objeto, l);
			}
		}

		public abstract T Buscar<T>(int id) where T : class, IIdentificable;
		public abstract T[] Listar<T>() where T : class, IIdentificable;
		public abstract IEnumerable<T> Enumerar<T>() where T : class, IIdentificable;

		public abstract void Guardar();
		public abstract void Dispose();
	}

	public enum RespuestaABM {
		Error_Otro,
		Exito,
		Error_Existente,
		Error_Inexistente,
		Error_DatosFaltantes,
		Error_DatosInvalidos,
		Error_EnUso
	}
}