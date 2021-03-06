using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Parentesco : IEquatable<Parentesco>
	{
		public Parentesco()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.Parentescos.Attach(this);
		}

		public bool Equals(Parentesco other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Parentesco)) return false;
			return Equals((Parentesco)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}