using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class MenuItem : IEquatable<MenuItem>
	{
		public MenuItem()
		{
			this.Id = Guid.NewGuid();
			this.aplicacion = default(EntityRef<Castellano.Membresia.Aplicacion>);
			this.menu = default(EntityRef<Castellano.Membresia.Menu>);
			this.padre = default(EntityRef<Castellano.Membresia.MenuItem>);
		}

        [Display(Name = "Aplicación:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar la aplicación")]
        public Guid AplicacionId { get; set; }

        [Display(Name = "Menú:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar el menú")]
        public Guid MenuId { get; set; }

		public Guid Id { get; set; }

		public Nullable<Guid> MenuItemId { get; set; }

        [Display(Name = "Nombre:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(50, ErrorMessage = "El nombre debe contener como máximo 50 caracteres")]
        public String Nombre { get; set; }

        [Display(Name = "Tíulo:")]
        [MaxLength(80, ErrorMessage = "El título debe contener como máximo 80 caracteres")]
        public String Titulo { get; set; }

        [Display(Name = "Tooltip:")]
        public String ToolTip { get; set; }

        [Display(Name = "Información:")]
        public String Informacion { get; set; }

        [Display(Name = "Ícono:")]
        [MaxLength(70, ErrorMessage = "El texto del ícono debe contener como máximo 70 cacteres")]
        public String Icono { get; set; }

        [Display(Name = "URL:")]
        [MaxLength(256, ErrorMessage = "La URL debe contener como máximo 256 cacteres")]
        public String Url { get; set; }

        [Display(Name = "Visible")]
        public Boolean Visible { get; set; }

        [Display(Name = "Muestra menús")]
        public Boolean MuestraMenus { get; set; }

        [Display(Name = "Público")]
        public Boolean Publico { get; set; }

        [Display(Name = "Orden:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el orden del ítem de menú")]
        public Int64 Orden { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Aplicacion> aplicacion;
		public Castellano.Membresia.Aplicacion Aplicacion
		{
			get { return this.aplicacion.Entity; }
			set { this.aplicacion.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Menu> menu;
		public Castellano.Membresia.Menu Menu
		{
			get { return this.menu.Entity; }
			set { this.menu.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Membresia.MenuItem> padre;
		public Castellano.Membresia.MenuItem Padre
		{
			get { return this.padre.Entity; }
			set { this.padre.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.MenuItemes.Attach(this);
		}

		public bool Equals(MenuItem other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AplicacionId.Equals(AplicacionId) && other.MenuId.Equals(MenuId) && other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(MenuItem)) return false;
			return Equals((MenuItem)obj);
		}

		public override int GetHashCode()
		{
			return this.AplicacionId.GetHashCode() ^ this.MenuId.GetHashCode() ^ this.Id.GetHashCode();
		}
	}
}