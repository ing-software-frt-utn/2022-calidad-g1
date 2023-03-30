using System.Data;

namespace IDS {
	public interface ITabla {
		void AgregarColumnas(DataColumnCollection columnas);
		object[] GetValores();
		bool Filtrar(string filtro);
		bool Valido();
		bool Completo();
	}

	public interface IIdentificable {
		int Id { get; set; }
		bool Eliminado { get; set; }
		string[] Referencias { get; }
		string[] Listas { get; }
	}
}