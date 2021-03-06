using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TramoAsignacionFamiliar : IEquatable<TramoAsignacionFamiliar>
	{
		public TramoAsignacionFamiliar()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.TramoAsignacionFamiliares.Attach(this);
		}

		public bool Equals(TramoAsignacionFamiliar other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TramoAsignacionFamiliar)) return false;
			return Equals((TramoAsignacionFamiliar)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}