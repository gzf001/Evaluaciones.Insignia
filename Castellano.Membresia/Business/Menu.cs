using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class Menu
	{
		public static Menu MenuUsuario
		{
			get { return Get("MenuUsuario"); }
		}

		public static Menu MenuPrincipal
		{
			get { return Get("MenuPrincipal"); }
		}

		public static Menu Get(Guid id)
		{
			return Query.GetMenus().SingleOrDefault<Menu>(x => x.Id == id);
		}

		public static Menu Get(String clave)
		{
			return Query.GetMenus().SingleOrDefault<Menu>(x => x.Clave == clave);
		}

		public static List<Menu> GetAll()
		{
			return
				(
				from query in Query.GetMenus()
				select query
				).ToList<Menu>();
		}
	}
}