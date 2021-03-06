using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class RolAccion
	{
		public static bool Exists(Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Castellano.Persona persona, MenuItem menuItem, Accion accion)
		{
			return Query.GetRolAcciones(empresa, centroCosto, persona, menuItem).Any<RolAccion>(x => x.MenuItemAccion.Accion.Equals(accion));
		}

		public static RolAccion Get(Guid rolId, Guid aplicacionId, Guid menuId, Guid menuItemId, Int32 accionCodigo)
		{
			return Query.GetRolAcciones().SingleOrDefault<RolAccion>(x => x.RolId == rolId && x.AplicacionId == aplicacionId && x.MenuId == menuId && x.MenuItemId == menuItemId && x.AccionCodigo == accionCodigo);
		}

		public static List<RolAccion> GetAll()
		{
			return
				(
				from query in Query.GetRolAcciones()
				select query
				).ToList<RolAccion>();
		}

		public static List<RolAccion> GetAll(Rol rol)
		{
			return Query.GetRolAcciones(rol).ToList<RolAccion>();
		}

		public static List<RolAccion> GetAll(Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Persona persona)
		{
			return
				(
				from query in Query.GetRolAcciones(empresa, centroCosto, persona)
				orderby query.Rol.AmbitoCodigo, query.Rol.Clave, query.Rol.Nombre
				select query
				).ToList<RolAccion>();
		}
	}
}