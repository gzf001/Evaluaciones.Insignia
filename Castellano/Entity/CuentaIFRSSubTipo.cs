using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class CuentaIFRSSubTipo : IEquatable<CuentaIFRSSubTipo>
	{
		public CuentaIFRSSubTipo()
		{
			this.cuentaIFRSTipo = default(EntityRef<Castellano.CuentaIFRSTipo>);
		}

		public String CuentaTipoCodigo { get; set; }

		public String Codigo { get; set; }

		public String Descripcion { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.CuentaIFRSTipo> cuentaIFRSTipo;
		public Castellano.CuentaIFRSTipo CuentaIFRSTipo
		{
			get { return this.cuentaIFRSTipo.Entity; }
			set { this.cuentaIFRSTipo.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.CuentaIFRSSubTipos.Attach(this);
		}

		public bool Equals(CuentaIFRSSubTipo other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.CuentaTipoCodigo.Equals(CuentaTipoCodigo) && other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(CuentaIFRSSubTipo)) return false;
			return Equals((CuentaIFRSSubTipo)obj);
		}

		public override int GetHashCode()
		{
			return this.CuentaTipoCodigo.GetHashCode() ^ this.Codigo.GetHashCode();
		}
	}
}