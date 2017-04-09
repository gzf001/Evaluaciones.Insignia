using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class MenuItem
	{
		private const int NIVELES = 6;

		#region Propiedades
		public string Numeracion
		{
			get
			{
				MenuItem aux = this;
				string nombre = this.Titulo;

				while (aux.Padre != null)
				{
					int numero = 0;

					foreach (MenuItem menuItem in MenuItem.GetAll(aux.Padre))
					{
						numero++;

						if (aux.Id.Equals(menuItem.Id))
						{
							nombre = numero.ToString() + "." + nombre;
							break;
						}
					}

					aux = aux.Padre;
				}

				return nombre;
			}
		}
		#endregion

        private List<MenuItem> hijos = new List<MenuItem>();
        public List<MenuItem> Hijos
        {
            get { return this.hijos; }
            set { this.hijos = value; }
        }

		public static void SubirOrden(MenuItem menuItem)
		{
			Context.Instancia.MenuItemes.Attach(menuItem);

			using (Context context = new Context())
			{
				PreOrder(context, menuItem.Aplicacion.Inicio, 1000000000000 * menuItem.Aplicacion.Orden, 1);
			}

			List<MenuItem> lista = MenuItem.GetAll(menuItem.Menu, menuItem.Aplicacion, menuItem.Padre, menuItem.Publico);

			int indice = lista.LastIndexOf(menuItem);

			if (indice > 0)
			{
				long ordenActual = lista[indice].Orden;
				long ordenAnterior = lista[indice - 1].Orden;

				using (Context context = new Context())
				{
					lista[indice].Orden = ordenAnterior;
					lista[indice].Save(context);

					lista[indice - 1].Orden = ordenActual;
					lista[indice - 1].Save(context);

					context.SubmitChanges();
				}
			}
		}

		public static void BajarOrden(MenuItem menuItem)
		{
			Context.Instancia.MenuItemes.Attach(menuItem);

			using (Context context = new Context())
			{
				PreOrder(context, menuItem.Aplicacion.Inicio, 1000000000000 * menuItem.Aplicacion.Orden, 1);
			}

			List<MenuItem> lista = MenuItem.GetAll(menuItem.Menu, menuItem.Aplicacion, menuItem.Padre, menuItem.Publico);

			int indice = lista.LastIndexOf(menuItem);

			if (indice + 1 < lista.Count)
			{
				long ordenActual = lista[indice].Orden;
				long ordenSiguiente = lista[indice + 1].Orden;

				using (Context context = new Context())
				{
					lista[indice].Orden = ordenSiguiente;
					lista[indice].Save(context);

					lista[indice + 1].Orden = ordenActual;
					lista[indice + 1].Save(context);

					context.SubmitChanges();
				}
			}
		}

		public static void SubirNivel(MenuItem menuItem)
		{
			Context.Instancia.MenuItemes.Attach(menuItem);

			List<MenuItem> lista = MenuItem.GetAll(menuItem.Menu, menuItem.Aplicacion, menuItem.Padre, menuItem.Publico);

			int indice = lista.LastIndexOf(menuItem);

			if (indice > 0)
			{
				using (Context context = new Context())
				{
					lista[indice].MenuItemId = lista[indice - 1].Id;

					lista[indice].Save(context);

					context.SubmitChanges();

					PreOrder(context, menuItem.Aplicacion.Inicio, 1000000000000 * menuItem.Aplicacion.Orden, 1);
				}
			}
		}

		public static void BajarNivel(MenuItem menuItem)
		{
			Context.Instancia.MenuItemes.Attach(menuItem);

			List<MenuItem> lista = MenuItem.GetAll(menuItem.Menu, menuItem.Aplicacion, menuItem.Padre, menuItem.Publico);

			int indice = lista.LastIndexOf(menuItem);

			using (Context context = new Context())
			{
				if (lista[indice].Padre != null)
				{
					lista[indice].MenuItemId = lista[indice].Padre.MenuItemId;

					lista[indice].Save(context);

					context.SubmitChanges();
				}

				PreOrder(context, menuItem.Aplicacion.Inicio, 1000000000000 * menuItem.Aplicacion.Orden, 1);
			}
		}

		private static void PreOrder(Context context, MenuItem parent, long preorder, int nivel)
		{
			if (parent == null) throw new Exception("Error al ordenar");

			long order = preorder;

			IQueryable<MenuItem> query = (from menuItem in context.MenuItemes where (menuItem.MenuItemId == parent.Id) && (menuItem.AplicacionId == parent.AplicacionId) && (menuItem.MenuId == parent.MenuId) && (menuItem.Publico == parent.Publico) orderby menuItem.Orden select menuItem);

			foreach (MenuItem menuItem in query)
			{
				order += Convert.ToInt64(Math.Pow(10, (NIVELES - nivel) * 2));

				menuItem.Orden = order;

				menuItem.Save(context);

				context.SubmitChanges();

				PreOrder(context, menuItem, order, nivel + 1);
			}
		}

		public static bool Exists(MenuItem menuItem, Aplicacion aplicacion)
		{
			return Query.GetMenuItemes().Any<MenuItem>(x => x == menuItem && x.Aplicacion == aplicacion);
		}

		public static MenuItem Get(Guid aplicacionId, Guid menuId, Guid id)
		{
			return Query.GetMenuItemes().SingleOrDefault<MenuItem>(x => x.AplicacionId == aplicacionId && x.MenuId == menuId && x.Id == id);
		}

		public static MenuItem Get(string url, bool publico)
		{
			return Query.GetMenuItemes().SingleOrDefault<MenuItem>(x => x.Url == url && x.Publico == publico);
		}

		public static MenuItem Get(Membresia.Menu menu, string url, bool publico)
		{
			return Query.GetMenuItemes().SingleOrDefault<MenuItem>(x => x.Menu == menu && x.Url == url && x.Publico == publico);
		}

		public static List<MenuItem> GetAll()
		{
			return
				(
				from query in Query.GetMenuItemes()
				select query
				).ToList<MenuItem>();
		}

		public static List<MenuItem> GetAll(Menu menu, Aplicacion aplicacion, bool publico)
		{
			return aplicacion == null ?
					(
					from menuItem in Query.GetMenuItemes(menu, publico)
					orderby menuItem.Orden
					select menuItem
					).ToList<MenuItem>()
					:
					(
					from menuItem in Query.GetMenuItemes(menu, aplicacion, publico)
					orderby menuItem.Orden
					select menuItem
					).ToList<MenuItem>();
		}

		public static List<MenuItem> GetAll(Menu menu, Aplicacion aplicacion, Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Persona persona)
		{
			List<MenuItem> padres = new List<MenuItem>();
			List<MenuItem> result =
				(
				from query in Query.GetMenuItemes(menu, aplicacion, empresa, centroCosto, persona)
				orderby query.Orden
				select query
				).ToList<MenuItem>();

			foreach (MenuItem menuItem in result)
			{
				MenuItem padre = menuItem.Padre;

				while (padre != null && !padre.Equals(aplicacion.Inicio))
				{
					if (!result.Contains<MenuItem>(padre) && !padres.Contains<MenuItem>(padre)) padres.Add(padre);

					padre = padre.Padre;
				}
			}

			result.AddRange(padres);

			return result.OrderBy(x => x.Orden).ToList<MenuItem>();
		}

		public static List<MenuItem> GetAll(Menu menu, Aplicacion aplicacion, MenuItem padre, bool publico)
		{
			if (aplicacion == null)
			{
				return padre == null ?
						(
						from menuItem in Query.GetMenuItemes(menu, publico)
						where (menuItem.MenuItemId == null)
						orderby menuItem.Orden
						select menuItem
						).ToList<MenuItem>()
						:
						(
						from menuItem in Query.GetMenuItemes(menu, publico)
						where menuItem.MenuItemId == padre.Id
						orderby menuItem.Orden
						select menuItem
						).ToList<MenuItem>();
			}
			else
			{
				return padre == null ?
						(
						from menuItem in Query.GetMenuItemes(menu, aplicacion, publico)
						where (menuItem.MenuItemId == null)
						orderby menuItem.Orden
						select menuItem
						).ToList<MenuItem>()
						:
						(
						from menuItem in Query.GetMenuItemes(menu, aplicacion, publico)
						where menuItem.MenuItemId == padre.Id
						orderby menuItem.Orden
						select menuItem
						).ToList<MenuItem>();
			}
		}

		public static List<MenuItem> GetAll(MenuItem parent)
		{
			return parent == null ?
					(
					from menuItem in Query.GetMenuItemes()
					where (menuItem.MenuItemId == null)
					orderby menuItem.Orden
					select menuItem
					).ToList<MenuItem>()
					:
					(
					from menuItem in Query.GetMenuItemes()
					where menuItem.Padre == parent
					orderby menuItem.Orden
					select menuItem
					).ToList<MenuItem>();
		}

		public static List<MenuItem> GetTree(Menu menu, Aplicacion aplicacion, Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Persona persona)
		{
			return BuildTree(GetAll(menu, aplicacion, empresa, centroCosto, persona));
		}

		private static List<MenuItem> BuildTree(List<MenuItem> list)
		{
			List<MenuItem> result = new List<MenuItem>();

			List<MenuItem> l = list.FindAll(x => x.MenuItemId.HasValue && list.FindAll(y => y.Id == x.MenuItemId.Value).Count == 0);

			foreach (MenuItem menuItem in l)
			{
				menuItem.Padre = null;
				menuItem.Hijos = new List<MenuItem>();

				BuildTree(list, menuItem);

				result.Add(menuItem);
			}

			return result;
		}

		private static void BuildTree(List<MenuItem> list, MenuItem parent)
		{
			foreach (MenuItem menuItem in list.FindAll(x => x.Padre == parent))
			{
				menuItem.Padre = parent;
				parent.Hijos.Add(menuItem);

				menuItem.Hijos = new List<MenuItem>();

				BuildTree(list, menuItem);
			}
		}
	}
}