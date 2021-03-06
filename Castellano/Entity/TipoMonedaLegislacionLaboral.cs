using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoMonedaLegislacionLaboral : IEquatable<TipoMonedaLegislacionLaboral>
	{
		public TipoMonedaLegislacionLaboral()
		{
			this.tipoMoneda = default(EntityRef<Castellano.TipoMoneda>);
		}

		public Int32 TipoMonedaCodigo { get; set; }

		public Int32 LegislacionLaboralCodigo { get; set; }

		public Boolean Haber { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.TipoMoneda> tipoMoneda;
		public Castellano.TipoMoneda TipoMoneda
		{
			get { return this.tipoMoneda.Entity; }
			set { this.tipoMoneda.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.TipoMonedaLegislacionLaborales.Attach(this);
		}

		public bool Equals(TipoMonedaLegislacionLaboral other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.TipoMonedaCodigo.Equals(TipoMonedaCodigo) && other.LegislacionLaboralCodigo.Equals(LegislacionLaboralCodigo) && other.Haber.Equals(Haber);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoMonedaLegislacionLaboral)) return false;
			return Equals((TipoMonedaLegislacionLaboral)obj);
		}

		public override int GetHashCode()
		{
			return this.TipoMonedaCodigo.GetHashCode() ^ this.LegislacionLaboralCodigo.GetHashCode() ^ this.Haber.GetHashCode();
		}
	}
}