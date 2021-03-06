using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoMonedaTipoPrevision : IEquatable<TipoMonedaTipoPrevision>
	{
		public TipoMonedaTipoPrevision()
		{
			this.tipoMoneda = default(EntityRef<Castellano.TipoMoneda>);
			this.tipoPrevision = default(EntityRef<Castellano.TipoPrevision>);
		}

		public Int32 TipoMonedaCodigo { get; set; }

		public Int32 TipoPrevisionCodigo { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.TipoMoneda> tipoMoneda;
		public Castellano.TipoMoneda TipoMoneda
		{
			get { return this.tipoMoneda.Entity; }
			set { this.tipoMoneda.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.TipoPrevision> tipoPrevision;
		public Castellano.TipoPrevision TipoPrevision
		{
			get { return this.tipoPrevision.Entity; }
			set { this.tipoPrevision.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.TipoMonedaTipoPrevisiones.Attach(this);
		}

		public bool Equals(TipoMonedaTipoPrevision other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.TipoMonedaCodigo.Equals(TipoMonedaCodigo) && other.TipoPrevisionCodigo.Equals(TipoPrevisionCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoMonedaTipoPrevision)) return false;
			return Equals((TipoMonedaTipoPrevision)obj);
		}

		public override int GetHashCode()
		{
			return this.TipoMonedaCodigo.GetHashCode() ^ this.TipoPrevisionCodigo.GetHashCode();
		}
	}
}