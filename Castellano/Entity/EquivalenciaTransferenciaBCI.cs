using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class EquivalenciaTransferenciaBCI : IEquatable<EquivalenciaTransferenciaBCI>
	{
		public EquivalenciaTransferenciaBCI()
		{
			this.institucionValorSeguro = default(EntityRef<Castellano.InstitucionValorSeguro>);
		}

		public Int32 TipoInstitucionValorSeguroCodigo { get; set; }

		public Int32 BancoCodigo { get; set; }

		public String Equivalencia { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.InstitucionValorSeguro> institucionValorSeguro;
		public Castellano.InstitucionValorSeguro InstitucionValorSeguro
		{
			get { return this.institucionValorSeguro.Entity; }
			set { this.institucionValorSeguro.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.EquivalenciaTransferenciaBCIs.Attach(this);
		}

		public bool Equals(EquivalenciaTransferenciaBCI other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.TipoInstitucionValorSeguroCodigo.Equals(TipoInstitucionValorSeguroCodigo) && other.BancoCodigo.Equals(BancoCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(EquivalenciaTransferenciaBCI)) return false;
			return Equals((EquivalenciaTransferenciaBCI)obj);
		}

		public override int GetHashCode()
		{
			return this.TipoInstitucionValorSeguroCodigo.GetHashCode() ^ this.BancoCodigo.GetHashCode();
		}
	}
}