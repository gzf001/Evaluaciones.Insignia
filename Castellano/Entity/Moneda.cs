using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Moneda : IEquatable<Moneda>
	{
		public Moneda()
		{
			this.tipoMoneda = default(EntityRef<Castellano.TipoMoneda>);
		}

		public Int32 TipoMonedaCodigo { get; set; }

		public Decimal Valor { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.TipoMoneda> tipoMoneda;
		public Castellano.TipoMoneda TipoMoneda
		{
			get { return this.tipoMoneda.Entity; }
			set { this.tipoMoneda.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Monedas.Attach(this);
		}

		public bool Equals(Moneda other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.TipoMonedaCodigo.Equals(TipoMonedaCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Moneda)) return false;
			return Equals((Moneda)obj);
		}

		public override int GetHashCode()
		{
			return this.TipoMonedaCodigo.GetHashCode();
		}
	}
}