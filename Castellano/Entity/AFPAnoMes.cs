using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class AFPAnoMes : IEquatable<AFPAnoMes>
	{
		public AFPAnoMes()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
			this.institucionValorSeguro = default(EntityRef<Castellano.InstitucionValorSeguro>);
		}

		public Int32 TipoInstitucionValorSeguroCodigo { get; set; }

		public Int32 InstitucionValorSeguroCodigo { get; set; }

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Decimal Cotizacion { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.InstitucionValorSeguro> institucionValorSeguro;
		public Castellano.InstitucionValorSeguro InstitucionValorSeguro
		{
			get { return this.institucionValorSeguro.Entity; }
			set { this.institucionValorSeguro.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.AFPAnoMeses.Attach(this);
		}

		public bool Equals(AFPAnoMes other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.TipoInstitucionValorSeguroCodigo.Equals(TipoInstitucionValorSeguroCodigo) && other.InstitucionValorSeguroCodigo.Equals(InstitucionValorSeguroCodigo) && other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(AFPAnoMes)) return false;
			return Equals((AFPAnoMes)obj);
		}

		public override int GetHashCode()
		{
			return this.TipoInstitucionValorSeguroCodigo.GetHashCode() ^ this.InstitucionValorSeguroCodigo.GetHashCode() ^ this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode();
		}
	}
}