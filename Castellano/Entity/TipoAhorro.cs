using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoAhorro : IEquatable<TipoAhorro>
	{
		public TipoAhorro()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.TipoAhorros.Attach(this);
		}

		public bool Equals(TipoAhorro other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoAhorro)) return false;
			return Equals((TipoAhorro)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}