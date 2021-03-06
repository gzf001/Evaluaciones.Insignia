using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoMoneda : IEquatable<TipoMoneda>
	{
		public TipoMoneda()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public Boolean Porcentual { get; set; }

		public void Attach()
		{
			Context.Instancia.TipoMonedas.Attach(this);
		}

		public bool Equals(TipoMoneda other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoMoneda)) return false;
			return Equals((TipoMoneda)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}