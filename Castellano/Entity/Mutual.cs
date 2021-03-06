using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Mutual : IEquatable<Mutual>
	{
		public Mutual()
		{
		}

		public Int32 Codigo { get; set; }

		public String RUT { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.Mutuales.Attach(this);
		}

		public bool Equals(Mutual other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Mutual)) return false;
			return Equals((Mutual)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}