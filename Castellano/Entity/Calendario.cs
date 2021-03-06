using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Calendario : IEquatable<Calendario>
	{
		public Calendario()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
			this.dia = default(EntityRef<Castellano.Dia>);
			this.semana = default(EntityRef<Castellano.Semana>);
		}

		public DateTime Fecha { get; set; }

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Int32 SemanaNumero { get; set; }

		public Int16 DiaNumero { get; set; }

		public String Nombre { get; set; }

		public Boolean Festivo { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Dia> dia;
		public Castellano.Dia Dia
		{
			get { return this.dia.Entity; }
			set { this.dia.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Semana> semana;
		public Castellano.Semana Semana
		{
			get { return this.semana.Entity; }
			set { this.semana.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Calendarios.Attach(this);
		}

		public bool Equals(Calendario other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Fecha.Equals(Fecha);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Calendario)) return false;
			return Equals((Calendario)obj);
		}

		public override int GetHashCode()
		{
			return this.Fecha.GetHashCode();
		}
	}
}