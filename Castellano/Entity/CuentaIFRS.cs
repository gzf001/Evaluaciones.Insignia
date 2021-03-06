using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class CuentaIFRS : IEquatable<CuentaIFRS>
	{
		public CuentaIFRS()
		{
			this.Id = Guid.NewGuid();
			this.ano = default(EntityRef<Castellano.Ano>);
			this.cuentaIFRSClasificacion = default(EntityRef<Castellano.CuentaIFRSClasificacion>);
			this.cuentaIFRSTipoInforme = default(EntityRef<Castellano.CuentaIFRSTipoInforme>);
			this.empresa = default(EntityRef<Castellano.Empresa>);
		}

		public Guid Id { get; set; }

		public String CodigoCuenta { get; set; }

		public Int32 AnoNumero { get; set; }

		public String Descripcion { get; set; }

		public Guid EmpresaId { get; set; }

		public String CuentaTipoCodigo { get; set; }

		public String CuentaSubTipoCodigo { get; set; }

		public String CuentaClasificacionCodigo { get; set; }

		public String Codigo { get; set; }

		public Boolean Habilitado { get; set; }

		public Int32 TipoInforme { get; set; }

		public Nullable<Boolean> Clasificado { get; set; }

		public Nullable<Boolean> Funcion { get; set; }

		public Nullable<Boolean> Naturaleza { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Ano> ano;
		public Castellano.Ano Ano
		{
			get { return this.ano.Entity; }
			set { this.ano.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.CuentaIFRSClasificacion> cuentaIFRSClasificacion;
		public Castellano.CuentaIFRSClasificacion CuentaIFRSClasificacion
		{
			get { return this.cuentaIFRSClasificacion.Entity; }
			set { this.cuentaIFRSClasificacion.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.CuentaIFRSTipoInforme> cuentaIFRSTipoInforme;
		public Castellano.CuentaIFRSTipoInforme CuentaIFRSTipoInforme
		{
			get { return this.cuentaIFRSTipoInforme.Entity; }
			set { this.cuentaIFRSTipoInforme.Entity = value; }
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
			Context.Instancia.CuentaIFRSes.Attach(this);
		}

		public bool Equals(CuentaIFRS other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(CuentaIFRS)) return false;
			return Equals((CuentaIFRS)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}