using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoVivienda : IEquatable<TipoVivienda>
	{
		public TipoVivienda()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.TipoViviendas.Attach(this);
		}

		public bool Equals(TipoVivienda other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoVivienda)) return false;
			return Equals((TipoVivienda)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}