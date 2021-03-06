using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class ActividadEconomica : IEquatable<ActividadEconomica>
	{
		public ActividadEconomica()
		{
			this.sectorActividadEconomica = default(EntityRef<Castellano.SectorActividadEconomica>);
		}

		public Int32 ActividadEconomicaPrincipalCodigo { get; set; }

		public Int32 SectorActividadEconomicaCodigo { get; set; }

		public Int32 Codigo { get; set; }

		public String Descripcion { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.SectorActividadEconomica> sectorActividadEconomica;
		public Castellano.SectorActividadEconomica SectorActividadEconomica
		{
			get { return this.sectorActividadEconomica.Entity; }
			set { this.sectorActividadEconomica.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.ActividadEconomicas.Attach(this);
		}

		public bool Equals(ActividadEconomica other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.ActividadEconomicaPrincipalCodigo.Equals(ActividadEconomicaPrincipalCodigo) && other.SectorActividadEconomicaCodigo.Equals(SectorActividadEconomicaCodigo) && other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(ActividadEconomica)) return false;
			return Equals((ActividadEconomica)obj);
		}

		public override int GetHashCode()
		{
			return this.ActividadEconomicaPrincipalCodigo.GetHashCode() ^ this.SectorActividadEconomicaCodigo.GetHashCode() ^ this.Codigo.GetHashCode();
		}
	}
}