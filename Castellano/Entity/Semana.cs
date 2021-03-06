using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Semana : IEquatable<Semana>
	{
		public Semana()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
		}

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumro { get; set; }

		public Int32 Numero { get; set; }

		public DateTime Inicio { get; set; }

		public DateTime Termino { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Semanas.Attach(this);
		}

		public bool Equals(Semana other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AnoNumero.Equals(AnoNumero) && other.MesNumro.Equals(MesNumro) && other.Numero.Equals(Numero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Semana)) return false;
			return Equals((Semana)obj);
		}

		public override int GetHashCode()
		{
			return this.AnoNumero.GetHashCode() ^ this.MesNumro.GetHashCode() ^ this.Numero.GetHashCode();
		}
	}
}