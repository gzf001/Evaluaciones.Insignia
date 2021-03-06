using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class InstitucionValorSeguro : IEquatable<InstitucionValorSeguro>
	{
		public InstitucionValorSeguro()
		{
			this.tipoInstitucionValorSeguro = default(EntityRef<Castellano.TipoInstitucionValorSeguro>);
		}

		public Int32 TipoInstitucionValorSeguroCodigo { get; set; }

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.TipoInstitucionValorSeguro> tipoInstitucionValorSeguro;
		public Castellano.TipoInstitucionValorSeguro TipoInstitucionValorSeguro
		{
			get { return this.tipoInstitucionValorSeguro.Entity; }
			set { this.tipoInstitucionValorSeguro.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.InstitucionValorSeguros.Attach(this);
		}

		public bool Equals(InstitucionValorSeguro other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.TipoInstitucionValorSeguroCodigo.Equals(TipoInstitucionValorSeguroCodigo) && other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(InstitucionValorSeguro)) return false;
			return Equals((InstitucionValorSeguro)obj);
		}

		public override int GetHashCode()
		{
			return this.TipoInstitucionValorSeguroCodigo.GetHashCode() ^ this.Codigo.GetHashCode();
		}
	}
}