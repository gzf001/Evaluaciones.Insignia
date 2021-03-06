using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class ParametroPrevisional : IEquatable<ParametroPrevisional>
	{
		public ParametroPrevisional()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
		}

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Decimal MaximoImponibleAFP { get; set; }

		public Decimal MaximoImponilbeRegimenAntiguo { get; set; }

		public Decimal MaximoImponibleAFC { get; set; }

		public Decimal TopeCotizacionSalud { get; set; }

		public Decimal TopeCotizacionRegimenAntiguo { get; set; }

		public Decimal SIS { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.ParametroPrevisionales.Attach(this);
		}

		public bool Equals(ParametroPrevisional other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(ParametroPrevisional)) return false;
			return Equals((ParametroPrevisional)obj);
		}

		public override int GetHashCode()
		{
			return this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode();
		}
	}
}