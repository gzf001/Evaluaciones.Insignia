using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class CuentaIFRSClasificacion : IEquatable<CuentaIFRSClasificacion>
	{
		public CuentaIFRSClasificacion()
		{
			this.cuentaIFRSSubTipo = default(EntityRef<Castellano.CuentaIFRSSubTipo>);
		}

		public String CuentaTipoCodigo { get; set; }

		public String CuentaSubTipoCodigo { get; set; }

		public String Codigo { get; set; }

		public String Nombre { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.CuentaIFRSSubTipo> cuentaIFRSSubTipo;
		public Castellano.CuentaIFRSSubTipo CuentaIFRSSubTipo
		{
			get { return this.cuentaIFRSSubTipo.Entity; }
			set { this.cuentaIFRSSubTipo.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.CuentaIFRSClasificaciones.Attach(this);
		}

		public bool Equals(CuentaIFRSClasificacion other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.CuentaTipoCodigo.Equals(CuentaTipoCodigo) && other.CuentaSubTipoCodigo.Equals(CuentaSubTipoCodigo) && other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(CuentaIFRSClasificacion)) return false;
			return Equals((CuentaIFRSClasificacion)obj);
		}

		public override int GetHashCode()
		{
			return this.CuentaTipoCodigo.GetHashCode() ^ this.CuentaSubTipoCodigo.GetHashCode() ^ this.Codigo.GetHashCode();
		}
	}
}