using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoAFC : IEquatable<TipoAFC>
	{
		public TipoAFC()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.TipoAFCes.Attach(this);
		}

		public bool Equals(TipoAFC other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoAFC)) return false;
			return Equals((TipoAFC)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}