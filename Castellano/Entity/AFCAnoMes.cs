using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class AFCAnoMes : IEquatable<AFCAnoMes>
	{
		public AFCAnoMes()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
			this.tipoAFC = default(EntityRef<Castellano.TipoAFC>);
		}

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Int32 TipoAFCCodigo { get; set; }

		public Decimal Empleador { get; set; }

		public Decimal Trabajador { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.TipoAFC> tipoAFC;
		public Castellano.TipoAFC TipoAFC
		{
			get { return this.tipoAFC.Entity; }
			set { this.tipoAFC.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.AFCAnoMeses.Attach(this);
		}

		public bool Equals(AFCAnoMes other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero) && other.TipoAFCCodigo.Equals(TipoAFCCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(AFCAnoMes)) return false;
			return Equals((AFCAnoMes)obj);
		}

		public override int GetHashCode()
		{
			return this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode() ^ this.TipoAFCCodigo.GetHashCode();
		}
	}
}