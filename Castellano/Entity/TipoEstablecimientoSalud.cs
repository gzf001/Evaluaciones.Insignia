using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoEstablecimientoSalud : IEquatable<TipoEstablecimientoSalud>
	{
		public TipoEstablecimientoSalud()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.TipoEstablecimientoSaludes.Attach(this);
		}

		public bool Equals(TipoEstablecimientoSalud other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoEstablecimientoSalud)) return false;
			return Equals((TipoEstablecimientoSalud)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}