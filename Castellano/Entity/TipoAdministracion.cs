using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoAdministracion : IEquatable<TipoAdministracion>
	{
		public TipoAdministracion()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.TipoAdministraciones.Attach(this);
		}

		public bool Equals(TipoAdministracion other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoAdministracion)) return false;
			return Equals((TipoAdministracion)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}