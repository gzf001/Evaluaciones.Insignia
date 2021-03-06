using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class CentroCosto : IEquatable<CentroCosto>
	{
		public CentroCosto()
		{
			this.Id = Guid.NewGuid();
			this.administrador = default(EntityRef<Castellano.Persona>);
			this.areaGeografica = default(EntityRef<Castellano.AreaGeografica>);
			this.comuna = default(EntityRef<Castellano.Comuna>);
			this.departamento = default(EntityRef<Castellano.Departamento>);
			this.empresa = default(EntityRef<Castellano.Empresa>);
			this.tipoEstablecimientoSalud = default(EntityRef<Castellano.TipoEstablecimientoSalud>);
		}

		public Guid EmpresaId { get; set; }

		public Guid Id { get; set; }

		public Nullable<Guid> AdministradorId { get; set; }

		public String Nombre { get; set; }

		public String Sigla { get; set; }

		public Int32 AreaGeograficaCodigo { get; set; }

		public Nullable<Int32> TipoEstablecimientoSaludCodigo { get; set; }

		public Nullable<Int16> RegionCodigo { get; set; }

		public Nullable<Int16> CiudadCodigo { get; set; }

		public Nullable<Int16> ComunaCodigo { get; set; }

		public String Email { get; set; }

		public String Direccion { get; set; }

		public Nullable<Int32> Telefono1 { get; set; }

		public Nullable<Int32> Telefono2 { get; set; }

		public Nullable<Int32> Fax { get; set; }

		public Nullable<Int32> Celular { get; set; }

		public String CodigoContabilidad { get; set; }

		public Boolean LibroRemuneraciones { get; set; }

		public String RutaReporte { get; set; }

		public Nullable<Guid> DepartamentoId { get; set; }

		public Nullable<Guid> UnidadId { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Persona> administrador;
		public Castellano.Persona Administrador
		{
			get { return this.administrador.Entity; }
			set { this.administrador.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.AreaGeografica> areaGeografica;
		public Castellano.AreaGeografica AreaGeografica
		{
			get { return this.areaGeografica.Entity; }
			set { this.areaGeografica.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Comuna> comuna;
		public Castellano.Comuna Comuna
		{
			get { return this.comuna.Entity; }
			set { this.comuna.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Departamento> departamento;
		public Castellano.Departamento Departamento
		{
			get { return this.departamento.Entity; }
			set { this.departamento.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Empresa> empresa;
		public Castellano.Empresa Empresa
		{
			get { return this.empresa.Entity; }
			set { this.empresa.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.TipoEstablecimientoSalud> tipoEstablecimientoSalud;
		public Castellano.TipoEstablecimientoSalud TipoEstablecimientoSalud
		{
			get { return this.tipoEstablecimientoSalud.Entity; }
			set { this.tipoEstablecimientoSalud.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.CentroCostos.Attach(this);
		}

		public bool Equals(CentroCosto other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.EmpresaId.Equals(EmpresaId) && other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(CentroCosto)) return false;
			return Equals((CentroCosto)obj);
		}

		public override int GetHashCode()
		{
			return this.EmpresaId.GetHashCode() ^ this.Id.GetHashCode();
		}
	}
}