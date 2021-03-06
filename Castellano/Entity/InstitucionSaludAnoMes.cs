using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class InstitucionSaludAnoMes : IEquatable<InstitucionSaludAnoMes>
	{
		public InstitucionSaludAnoMes()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
			this.institucionSalud = default(EntityRef<Castellano.InstitucionSalud>);
		}

		public Int32 InstitucionSaludCodigo { get; set; }

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Nullable<Double> Cotizacion { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.InstitucionSalud> institucionSalud;
		public Castellano.InstitucionSalud InstitucionSalud
		{
			get { return this.institucionSalud.Entity; }
			set { this.institucionSalud.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.InstitucionSaludAnoMeses.Attach(this);
		}

		public bool Equals(InstitucionSaludAnoMes other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.InstitucionSaludCodigo.Equals(InstitucionSaludCodigo) && other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(InstitucionSaludAnoMes)) return false;
			return Equals((InstitucionSaludAnoMes)obj);
		}

		public override int GetHashCode()
		{
			return this.InstitucionSaludCodigo.GetHashCode() ^ this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode();
		}
	}
}