using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class RolAccion : IEquatable<RolAccion>
	{
		public RolAccion()
		{
			this.menuItemAccion = default(EntityRef<Castellano.Membresia.MenuItemAccion>);
			this.rol = default(EntityRef<Castellano.Membresia.Rol>);
		}

        [Display(Name = "Rol:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar el rol")]
        public Guid RolId { get; set; }

        [Display(Name = "Aplicación:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar la aplicación")]
        public Guid AplicacionId { get; set; }

		public Guid MenuId { get; set; }

        [Display(Name = "Ítem de menú:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar el ítem de menú")]
        public Guid MenuItemId { get; set; }

        [Display(Name = "Acción:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe seleccionar la acción")]
        public Int32 AccionCodigo { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Membresia.MenuItemAccion> menuItemAccion;
		public Castellano.Membresia.MenuItemAccion MenuItemAccion
		{
			get { return this.menuItemAccion.Entity; }
			set { this.menuItemAccion.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Rol> rol;
		public Castellano.Membresia.Rol Rol
		{
			get { return this.rol.Entity; }
			set { this.rol.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.RolAcciones.Attach(this);
		}

		public bool Equals(RolAccion other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.RolId.Equals(RolId) && other.AplicacionId.Equals(AplicacionId) && other.MenuId.Equals(MenuId) && other.MenuItemId.Equals(MenuItemId) && other.AccionCodigo.Equals(AccionCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(RolAccion)) return false;
			return Equals((RolAccion)obj);
		}

		public override int GetHashCode()
		{
			return this.RolId.GetHashCode() ^ this.AplicacionId.GetHashCode() ^ this.MenuId.GetHashCode() ^ this.MenuItemId.GetHashCode() ^ this.AccionCodigo.GetHashCode();
		}
	}
}