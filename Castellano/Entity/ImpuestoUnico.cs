using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class ImpuestoUnico : IEquatable<ImpuestoUnico>
	{
		public ImpuestoUnico()
		{
			this.Id = Guid.NewGuid();
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
		}

		public Guid Id { get; set; }

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Decimal Desde { get; set; }

		public Nullable<Decimal> Hasta { get; set; }

		public Decimal Rebaja { get; set; }

		public Decimal Factor { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.ImpuestoUnicos.Attach(this);
		}

		public bool Equals(ImpuestoUnico other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id) && other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(ImpuestoUnico)) return false;
			return Equals((ImpuestoUnico)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode() ^ this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode();
		}
	}
}