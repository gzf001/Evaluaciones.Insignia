using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Sexo : IEquatable<Sexo>
	{
		public Sexo()
		{
		}

		public Int16 Codigo { get; set; }

		public String Nombre { get; set; }

		public Char Letra { get; set; }

		public void Attach()
		{
			Context.Instancia.Sexos.Attach(this);
		}

		public bool Equals(Sexo other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Sexo)) return false;
			return Equals((Sexo)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}