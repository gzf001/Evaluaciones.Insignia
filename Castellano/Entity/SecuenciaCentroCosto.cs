using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class SecuenciaCentroCosto : IEquatable<SecuenciaCentroCosto>
	{
		public SecuenciaCentroCosto()
		{
			this.centroCosto = default(EntityRef<Castellano.CentroCosto>);
			this.empresa = default(EntityRef<Castellano.Empresa>);
		}

		public Guid EmpresaId { get; set; }

		public Guid CentroCostoId { get; set; }

		public String Clave { get; set; }

		public Int32 Numero { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.CentroCosto> centroCosto;
		public Castellano.CentroCosto CentroCosto
		{
			get { return this.centroCosto.Entity; }
			set { this.centroCosto.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Empresa> empresa;
		public Castellano.Empresa Empresa
		{
			get { return this.empresa.Entity; }
			set { this.empresa.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.SecuenciaCentroCostos.Attach(this);
		}

		public bool Equals(SecuenciaCentroCosto other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.EmpresaId.Equals(EmpresaId) && other.CentroCostoId.Equals(CentroCostoId) && other.Clave.Equals(Clave);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(SecuenciaCentroCosto)) return false;
			return Equals((SecuenciaCentroCosto)obj);
		}

		public override int GetHashCode()
		{
			return this.EmpresaId.GetHashCode() ^ this.CentroCostoId.GetHashCode() ^ this.Clave.GetHashCode();
		}
	}
}