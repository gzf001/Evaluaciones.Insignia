using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class MonedaDiaria : IEquatable<MonedaDiaria>
	{
		public MonedaDiaria()
		{
			this.calendario = default(EntityRef<Castellano.Calendario>);
			this.tipoMoneda = default(EntityRef<Castellano.TipoMoneda>);
		}

		public DateTime CalendarioFecha { get; set; }

		public Int32 TipoMonedaCodigo { get; set; }

		public Decimal Valor { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Calendario> calendario;
		public Castellano.Calendario Calendario
		{
			get { return this.calendario.Entity; }
			set { this.calendario.Entity = value; }
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
			Context.Instancia.MonedaDiarias.Attach(this);
		}

		public bool Equals(MonedaDiaria other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.CalendarioFecha.Equals(CalendarioFecha) && other.TipoMonedaCodigo.Equals(TipoMonedaCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(MonedaDiaria)) return false;
			return Equals((MonedaDiaria)obj);
		}

		public override int GetHashCode()
		{
			return this.CalendarioFecha.GetHashCode() ^ this.TipoMonedaCodigo.GetHashCode();
		}
	}
}