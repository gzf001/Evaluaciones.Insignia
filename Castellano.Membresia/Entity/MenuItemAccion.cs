using System;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class MenuItemAccion : IEquatable<MenuItemAccion>
	{
		public MenuItemAccion()
		{
			this.accion = default(EntityRef<Castellano.Membresia.Accion>);
			this.menuItem = default(EntityRef<Castellano.Membresia.MenuItem>);
		}

		public Guid AplicacionId { get; set; }

		public Guid MenuId { get; set; }

		public Guid MenuItemId { get; set; }

		public Int32 AccionCodigo { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Accion> accion;
		public Castellano.Membresia.Accion Accion
		{
			get { return this.accion.Entity; }
			set { this.accion.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Membresia.MenuItem> menuItem;
		public Castellano.Membresia.MenuItem MenuItem
		{
			get { return this.menuItem.Entity; }
			set { this.menuItem.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.MenuItemAcciones.Attach(this);
		}

		public bool Equals(MenuItemAccion other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AplicacionId.Equals(AplicacionId) && other.MenuId.Equals(MenuId) && other.MenuItemId.Equals(MenuItemId) && other.AccionCodigo.Equals(AccionCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(MenuItemAccion)) return false;
			return Equals((MenuItemAccion)obj);
		}

		public override int GetHashCode()
		{
			return this.AplicacionId.GetHashCode() ^ this.MenuId.GetHashCode() ^ this.MenuItemId.GetHashCode() ^ this.AccionCodigo.GetHashCode();
		}
	}
}