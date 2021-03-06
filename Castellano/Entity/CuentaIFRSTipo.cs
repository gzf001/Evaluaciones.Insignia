using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class CuentaIFRSTipo : IEquatable<CuentaIFRSTipo>
	{
		public CuentaIFRSTipo()
		{
			this.cuentaIFRSTipoInforme = default(EntityRef<Castellano.CuentaIFRSTipoInforme>);
		}

		public String Codigo { get; set; }

		public String Nombre { get; set; }

		public Int32 TipoInforme { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.CuentaIFRSTipoInforme> cuentaIFRSTipoInforme;
		public Castellano.CuentaIFRSTipoInforme CuentaIFRSTipoInforme
		{
			get { return this.cuentaIFRSTipoInforme.Entity; }
			set { this.cuentaIFRSTipoInforme.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.CuentaIFRSTipos.Attach(this);
		}

		public bool Equals(CuentaIFRSTipo other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(CuentaIFRSTipo)) return false;
			return Equals((CuentaIFRSTipo)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}