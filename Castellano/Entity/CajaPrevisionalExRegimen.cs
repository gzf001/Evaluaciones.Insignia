using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class CajaPrevisionalExRegimen : IEquatable<CajaPrevisionalExRegimen>
	{
		public CajaPrevisionalExRegimen()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public Decimal Cotizacion { get; set; }

		public void Attach()
		{
			Context.Instancia.CajaPrevisionalExRegimenes.Attach(this);
		}

		public bool Equals(CajaPrevisionalExRegimen other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(CajaPrevisionalExRegimen)) return false;
			return Equals((CajaPrevisionalExRegimen)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}