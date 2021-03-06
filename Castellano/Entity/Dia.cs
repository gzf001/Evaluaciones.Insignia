using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Dia : IEquatable<Dia>
	{
		public Dia()
		{
		}

		public Int16 Numero { get; set; }

		public String Nombre { get; set; }

		public Boolean Laboral { get; set; }

		public void Attach()
		{
			Context.Instancia.Dias.Attach(this);
		}

		public bool Equals(Dia other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Numero.Equals(Numero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Dia)) return false;
			return Equals((Dia)obj);
		}

		public override int GetHashCode()
		{
			return this.Numero.GetHashCode();
		}
	}
}