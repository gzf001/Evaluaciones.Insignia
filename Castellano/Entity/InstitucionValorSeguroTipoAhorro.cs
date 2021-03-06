using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class InstitucionValorSeguroTipoAhorro : IEquatable<InstitucionValorSeguroTipoAhorro>
	{
		public InstitucionValorSeguroTipoAhorro()
		{
			this.institucionValorSeguro = default(EntityRef<Castellano.InstitucionValorSeguro>);
			this.tipoAhorro = default(EntityRef<Castellano.TipoAhorro>);
		}

		public Int32 TipoInstitucionValorSeguroCodigo { get; set; }

		public Int32 InstitucionValorSeguroCodigo { get; set; }

		public Int32 TipoAhorroCodigo { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.InstitucionValorSeguro> institucionValorSeguro;
		public Castellano.InstitucionValorSeguro InstitucionValorSeguro
		{
			get { return this.institucionValorSeguro.Entity; }
			set { this.institucionValorSeguro.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.TipoAhorro> tipoAhorro;
		public Castellano.TipoAhorro TipoAhorro
		{
			get { return this.tipoAhorro.Entity; }
			set { this.tipoAhorro.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.InstitucionValorSeguroTipoAhorros.Attach(this);
		}

		public bool Equals(InstitucionValorSeguroTipoAhorro other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.TipoInstitucionValorSeguroCodigo.Equals(TipoInstitucionValorSeguroCodigo) && other.InstitucionValorSeguroCodigo.Equals(InstitucionValorSeguroCodigo) && other.TipoAhorroCodigo.Equals(TipoAhorroCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(InstitucionValorSeguroTipoAhorro)) return false;
			return Equals((InstitucionValorSeguroTipoAhorro)obj);
		}

		public override int GetHashCode()
		{
			return this.TipoInstitucionValorSeguroCodigo.GetHashCode() ^ this.InstitucionValorSeguroCodigo.GetHashCode() ^ this.TipoAhorroCodigo.GetHashCode();
		}
	}
}