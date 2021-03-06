using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class SecuenciaEmpresa : IEquatable<SecuenciaEmpresa>
	{
		public SecuenciaEmpresa()
		{
			this.empresa = default(EntityRef<Castellano.Empresa>);
		}

		public Guid EmpresaId { get; set; }

		public String Clave { get; set; }

		public Int32 Numero { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Empresa> empresa;
		public Castellano.Empresa Empresa
		{
			get { return this.empresa.Entity; }
			set { this.empresa.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.SecuenciaEmpresas.Attach(this);
		}

		public bool Equals(SecuenciaEmpresa other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.EmpresaId.Equals(EmpresaId) && other.Clave.Equals(Clave);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(SecuenciaEmpresa)) return false;
			return Equals((SecuenciaEmpresa)obj);
		}

		public override int GetHashCode()
		{
			return this.EmpresaId.GetHashCode() ^ this.Clave.GetHashCode();
		}
	}
}