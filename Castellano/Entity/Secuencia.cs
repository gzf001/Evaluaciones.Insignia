using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Secuencia : IEquatable<Secuencia>
	{
		public Secuencia()
		{
		}

		public String Clave { get; set; }

		public Int32 Numero { get; set; }

		public void Attach()
		{
			Context.Instancia.Secuencias.Attach(this);
		}

		public bool Equals(Secuencia other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Clave.Equals(Clave);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Secuencia)) return false;
			return Equals((Secuencia)obj);
		}

		public override int GetHashCode()
		{
			return this.Clave.GetHashCode();
		}
	}
}