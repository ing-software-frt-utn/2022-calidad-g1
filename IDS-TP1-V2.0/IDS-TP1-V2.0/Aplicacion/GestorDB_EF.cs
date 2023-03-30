using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace IDS.Aplicacion {
	public class GestorDB_EF : GestorDB {

		private BaseDeDatos context;

		public GestorDB_EF() {
			context = new BaseDeDatos();
		}

		public override void Agregar<T>(T objeto) {
			context.Set<T>().Add(objeto);
		}

		public override T Buscar<T>(int clave) {
			var obj = context.Set<T>().Find(clave);
			return obj;
		}

		public override void Asociar<T>(T objeto) {
			context.Set<T>().Attach(objeto);
		}

		public override void Cargar<T>(T objeto, string referencia) {
			context.Entry(objeto).Reference(referencia).Load();
		}

		public override void CargarLista<T>(T objeto, string referencia) {
			context.Entry(objeto).Collection(referencia).Load();
		}

		public override void Dispose() {
			context.Dispose();
		}

		public override IEnumerable<T> Enumerar<T>() {
			foreach (T obj in context.Set<T>()) {
				yield return obj;
			}
		}

		public override T[] Listar<T>() {
			var lista = new List<T>();
			foreach (T obj in context.Set<T>()) {
				lista.Add(obj);
			}
			return lista.ToArray();
		}

		public override void Modificar<T>(T objeto) {
			var obj = context.Set<T>().Find(objeto.Id);
			context.Entry(obj).CurrentValues.SetValues(objeto);
		}

		public override void Quitar<T>(T objeto) {
			var obj = context.Set<T>().Find(objeto.Id);
			context.Set<T>().Remove(obj);
		}

		public override void Guardar() {
			context.SaveChanges();
		}
	}
}