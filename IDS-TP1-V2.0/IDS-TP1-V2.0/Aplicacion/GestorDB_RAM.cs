using System;
using System.Collections.Generic;

namespace IDS.Aplicacion {
	public class GestorDB_RAM : GestorDB {
		private static Dictionary<Type, List<object>> objetos;

		public static void Inicializar() {
			objetos = new Dictionary<Type, List<object>>();
			objetos.Add(typeof(LineaDeTrabajo), new List<object>());
			objetos.Add(typeof(Modelo), new List<object>());
			objetos.Add(typeof(OrdenDeProduccion), new List<object>());
			objetos.Add(typeof(Turno), new List<object>());
			objetos.Add(typeof(Alerta), new List<object>());
			objetos.Add(typeof(Color), new List<object>());
			objetos.Add(typeof(Defecto), new List<object>());
			objetos.Add(typeof(JornadaLaboral), new List<object>());
			objetos.Add(typeof(Incidencia), new List<object>());
			objetos.Add(typeof(Empleado), new List<object>());
		}

		public static void Limpiar() {
			foreach (var lista in objetos.Values) {
				lista.Clear();
			}
			objetos.Clear();
		}

		public override void Cargar<T>(T objeto, string referencia) { }
		public override void CargarLista<T>(T objeto, string referencia) { }
		public override void Asociar<T>(T objeto) { }

		public override void Agregar<T>(T objeto) {
			var lista = objetos[typeof(T)];
			if (objeto.Id == 0) {
				if (lista.Count > 0) {
					objeto.Id = ((IIdentificable)lista[lista.Count - 1]).Id + 1;
				} else {
					objeto.Id = 1;
				}
			}
			lista.Add(objeto);
		}

		public override T Buscar<T>(int id) {
			foreach (var obj in objetos[typeof(T)]) {
				if (((IIdentificable) obj).Id == id){
					return obj as T;
				}
			}
			return default;
		}

		public override void Dispose() {
		}

		public override void Guardar() { }

		public override IEnumerable<T> Enumerar<T>() {
			foreach (T obj in objetos[typeof(T)]) {
				yield return obj;
			}
		}

		public override T[] Listar<T>() {
			var lista = new List<T>();
			foreach (T obj in objetos[typeof(T)]) {
				lista.Add(obj);
			}
			return lista.ToArray();
		}

		public override void Modificar<T>(T objeto) {
			int i = 0;
			var lista = objetos[typeof(T)];
			foreach (var obj in lista) {
				if (((IIdentificable)obj).Id == objeto.Id) {
					break;
				}
				i++;
			}
			if (lista.Count > i) {
				lista.RemoveAt(i);
				lista.Insert(i, objeto);
			}
		}

		public override void Quitar<T>(T objeto) {
			int i = 0;
			var lista = objetos[typeof(T)];
			foreach (var obj in lista) {
				if (((IIdentificable)obj).Id == objeto.Id) {
					break;
				}
				i++;
			}
			if (lista.Count > i) {
				lista.RemoveAt(i);
			}
		}
	}
}