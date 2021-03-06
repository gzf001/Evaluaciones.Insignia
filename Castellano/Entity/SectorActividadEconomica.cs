using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class SectorActividadEconomica : IEquatable<SectorActividadEconomica>
	{
		public SectorActividadEconomica()
		{
			this.actividadEconomicaPrincipal = default(EntityRef<Castellano.ActividadEconomicaPrincipal>);
		}

		public Int32 ActividadEconomicaPrincipalCodigo { get; set; }

		public Int32 Codigo { get; set; }

		public String Descripcion { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.ActividadEconomicaPrincipal> actividadEconomicaPrincipal;
		public Castellano.ActividadEconomicaPrincipal ActividadEconomicaPrincipal
		{
			get { return this.actividadEconomicaPrincipal.Entity; }
			set { this.actividadEconomicaPrincipal.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.SectorActividadEconomicas.Attach(this);
		}

		public bool Equals(SectorActividadEconomica other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.ActividadEconomicaPrincipalCodigo.Equals(ActividadEconomicaPrincipalCodigo) && other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(SectorActividadEconomica)) return false;
			return Equals((SectorActividadEconomica)obj);
		}

		public override int GetHashCode()
		{
			return this.ActividadEconomicaPrincipalCodigo.GetHashCode() ^ this.Codigo.GetHashCode();
		}
	}
}