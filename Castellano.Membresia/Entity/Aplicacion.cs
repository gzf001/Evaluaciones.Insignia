using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class Aplicacion : IEquatable<Aplicacion>
	{
		public Aplicacion()
		{
			this.Id = Guid.NewGuid();
			this.inicio = default(EntityRef<Castellano.Membresia.MenuItem>);
		}

		public Guid Id { get; set; }

		public Nullable<Guid> MenuId { get; set; }

		public Nullable<Guid> MenuItemId { get; set; }

        [Display(Name = "Nombre:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el Nombre")]
        [DataType(DataType.Text)]
        [StringLength(60, ErrorMessage = "El nombre no puede superar los 60 caracteres")]
        public String Nombre { get; set; }

        [Display(Name = "Clave:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar la clave")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "La clave no puede superar los 50 caracteres")]
        public String Clave { get; set; }

        [Display(Name = "Orden:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el orden")]
        [Range(1,30, ErrorMessage = "El rango para el orden debe estar entre 1 y 30")]
        public Byte Orden { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Membresia.MenuItem> inicio;
		public Castellano.Membresia.MenuItem Inicio
		{
			get { return this.inicio.Entity; }
			set { this.inicio.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Aplicaciones.Attach(this);
		}

		public bool Equals(Aplicacion other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Aplicacion)) return false;
			return Equals((Aplicacion)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}