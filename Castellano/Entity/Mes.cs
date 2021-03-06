using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Mes : IEquatable<Mes>
	{
		public Mes()
		{
		}

		public Int32 Numero { get; set; }

		public String Nombre { get; set; }

		public String Inicial { get; set; }

		public void Attach()
		{
			Context.Instancia.Meses.Attach(this);
		}

		public bool Equals(Mes other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Numero.Equals(Numero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Mes)) return false;
			return Equals((Mes)obj);
		}

		public override int GetHashCode()
		{
			return this.Numero.GetHashCode();
		}
	}
}