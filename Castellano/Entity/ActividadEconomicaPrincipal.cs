using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class ActividadEconomicaPrincipal : IEquatable<ActividadEconomicaPrincipal>
	{
		public ActividadEconomicaPrincipal()
		{
		}

		public Int32 Codigo { get; set; }

		public String Descripcion { get; set; }

		public void Attach()
		{
			Context.Instancia.ActividadEconomicaPrincipales.Attach(this);
		}

		public bool Equals(ActividadEconomicaPrincipal other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(ActividadEconomicaPrincipal)) return false;
			return Equals((ActividadEconomicaPrincipal)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}