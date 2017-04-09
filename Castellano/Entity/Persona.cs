using System;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;

namespace Castellano
{
	[Serializable]
	public partial class Persona : IEquatable<Persona>
	{
		public Persona()
		{
			this.Id = Guid.NewGuid();
			this.comuna = default(EntityRef<Castellano.Comuna>);
			this.estadoCivil = default(EntityRef<Castellano.EstadoCivil>);
			this.nacionalidad = default(EntityRef<Castellano.Nacionalidad>);
			this.nivelEducacional = default(EntityRef<Castellano.NivelEducacional>);
			this.sexo = default(EntityRef<Castellano.Sexo>);
		}

		public Guid Id { get; set; }

        [Display(Name = "R.U.N.:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el R.U.N.")]
		public String Run { get; set; }

		public Int32 RunCuerpo { get; set; }

		public Char RunDigito { get; set; }

        [Display(Name = "Nombres:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el nombre")]
		public String Nombre { get; set; }

        [Display(Name = "Nombres:")]
		public String Nombres { get; set; }

        [Display(Name = "Apellidos:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el apellido paterno")]
		public String ApellidoPaterno { get; set; }

        [Display(Name = "Apellido materno:")]
		public String ApellidoMaterno { get; set; }

        [Display(Name = "Email:")]
		public String Email { get; set; }

        [Display(Name = "Sexo:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar el sexo")]
		public Int16 SexoCodigo { get; set; }

        [Display(Name = "Fecha de nacimiento:")]
        [DataType(DataType.Date)]
		public Nullable<DateTime> FechaNacimiento { get; set; }

        [Display(Name = "Nacionalidad:")]
		public Nullable<Int16> NacionalidadCodigo { get; set; }

        [Display(Name = "Estado civil:")]
		public Nullable<Int16> EstadoCivilCodigo { get; set; }

        [Display(Name = "Nivel educacional:")]
		public Nullable<Int32> NivelEducacionalCodigo { get; set; }

         [Display(Name = "Región:")]
		public Nullable<Int16> RegionCodigo { get; set; }

        [Display(Name = "Ciudad:")]
		public Nullable<Int16> CiudadCodigo { get; set; }

        [Display(Name = "Comuna:")]
		public Nullable<Int16> ComunaCodigo { get; set; }

        [Display(Name = "Villa o población:")]
		public String VillaPoblacion { get; set; }

        [Display(Name = "Dirección:")]
		public String Direccion { get; set; }

        [Display(Name = "Teléfono:")]
		public Nullable<Int32> Telefono { get; set; }

        [Display(Name = "Teléfono celular:")]
		public Nullable<Int32> Celular { get; set; }

        [Display(Name = "Observaciones:")]
		public String Observaciones { get; set; }

        [Display(Name = "Ocupación:")]
		public String Ocupacion { get; set; }

        [Display(Name = "Teléfono laboral:")]
		public Nullable<Int32> TelefonoLaboral { get; set; }

        [Display(Name = "Dirección laboral:")]
		public String DireccionLaboral { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Comuna> comuna;
		public Castellano.Comuna Comuna
		{
			get { return this.comuna.Entity; }
			set { this.comuna.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.EstadoCivil> estadoCivil;
		public Castellano.EstadoCivil EstadoCivil
		{
			get { return this.estadoCivil.Entity; }
			set { this.estadoCivil.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Nacionalidad> nacionalidad;
		public Castellano.Nacionalidad Nacionalidad
		{
			get { return this.nacionalidad.Entity; }
			set { this.nacionalidad.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.NivelEducacional> nivelEducacional;
		public Castellano.NivelEducacional NivelEducacional
		{
			get { return this.nivelEducacional.Entity; }
			set { this.nivelEducacional.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Sexo> sexo;
		public Castellano.Sexo Sexo
		{
			get { return this.sexo.Entity; }
			set { this.sexo.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Personas.Attach(this);
		}

		public bool Equals(Persona other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Persona)) return false;
			return Equals((Persona)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}