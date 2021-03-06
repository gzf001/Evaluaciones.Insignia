using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class MonedaMensual : IEquatable<MonedaMensual>
	{
		public MonedaMensual()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
			this.tipoMoneda = default(EntityRef<Castellano.TipoMoneda>);
		}

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Int32 TipoMonedaCodigo { get; set; }

		public Decimal Valor { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.TipoMoneda> tipoMoneda;
		public Castellano.TipoMoneda TipoMoneda
		{
			get { return this.tipoMoneda.Entity; }
			set { this.tipoMoneda.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.MonedaMensuales.Attach(this);
		}

		public bool Equals(MonedaMensual other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero) && other.TipoMonedaCodigo.Equals(TipoMonedaCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(MonedaMensual)) return false;
			return Equals((MonedaMensual)obj);
		}

		public override int GetHashCode()
		{
			return this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode() ^ this.TipoMonedaCodigo.GetHashCode();
		}
	}
}