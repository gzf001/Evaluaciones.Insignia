using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class AnoMes : IEquatable<AnoMes>
	{
		public AnoMes()
		{
			this.ano = default(EntityRef<Castellano.Ano>);
			this.mes = default(EntityRef<Castellano.Mes>);
		}

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public DateTime Inicio { get; set; }

		public DateTime Termino { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Ano> ano;
		public Castellano.Ano Ano
		{
			get { return this.ano.Entity; }
			set { this.ano.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Mes> mes;
		public Castellano.Mes Mes
		{
			get { return this.mes.Entity; }
			set { this.mes.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.AnoMeses.Attach(this);
		}

		public bool Equals(AnoMes other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(AnoMes)) return false;
			return Equals((AnoMes)obj);
		}

		public override int GetHashCode()
		{
			return this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode();
		}
	}
}