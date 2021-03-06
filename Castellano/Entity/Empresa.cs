using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Empresa : IEquatable<Empresa>
	{
		public Empresa()
		{
			this.Id = Guid.NewGuid();
			this.actividadEconomica = default(EntityRef<Castellano.ActividadEconomica>);
			this.administrador = default(EntityRef<Castellano.Persona>);
			this.comuna = default(EntityRef<Castellano.Comuna>);
			this.gerenteRRHH = default(EntityRef<Castellano.Persona>);
			this.tipoAdministracion = default(EntityRef<Castellano.TipoAdministracion>);
		}

		public Guid Id { get; set; }

		public String Rut { get; set; }

		public Int32 RutCuerpo { get; set; }

		public Char RutDigito { get; set; }

		public String RazonSocial { get; set; }

		public Nullable<Int16> RegionCodigo { get; set; }

		public Nullable<Int16> CiudadCodigo { get; set; }

		public Nullable<Int16> ComunaCodigo { get; set; }

		public Int32 TipoAdministracionCodigo { get; set; }

		public Nullable<Int32> ActividadEconomicaPrincipalCodigo { get; set; }

		public Nullable<Int32> SectorActividadEconomicaCodigo { get; set; }

		public Nullable<Int32> ActividadEconomicaCodigo { get; set; }

		public String Giro { get; set; }

		public String Direccion { get; set; }

		public String Email { get; set; }

		public String PaginaWeb { get; set; }

		public Nullable<Int32> Telefono1 { get; set; }

		public Nullable<Int32> Telefono2 { get; set; }

		public Nullable<Int32> Fax { get; set; }

		public Nullable<Int32> Celular { get; set; }

		public Nullable<Guid> AdministradorId { get; set; }

		public Nullable<Guid> GerenteRRHHId { get; set; }

		public Boolean Bloqueada { get; set; }

		public String RutaReporte { get; set; }

		public String PieFirmaLiquidacion { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.ActividadEconomica> actividadEconomica;
		public Castellano.ActividadEconomica ActividadEconomica
		{
			get { return this.actividadEconomica.Entity; }
			set { this.actividadEconomica.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Persona> administrador;
		public Castellano.Persona Administrador
		{
			get { return this.administrador.Entity; }
			set { this.administrador.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Comuna> comuna;
		public Castellano.Comuna Comuna
		{
			get { return this.comuna.Entity; }
			set { this.comuna.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Persona> gerenteRRHH;
		public Castellano.Persona GerenteRRHH
		{
			get { return this.gerenteRRHH.Entity; }
			set { this.gerenteRRHH.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.TipoAdministracion> tipoAdministracion;
		public Castellano.TipoAdministracion TipoAdministracion
		{
			get { return this.tipoAdministracion.Entity; }
			set { this.tipoAdministracion.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Empresas.Attach(this);
		}

		public bool Equals(Empresa other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Empresa)) return false;
			return Equals((Empresa)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}