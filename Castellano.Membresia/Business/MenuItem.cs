using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                string nombre = this.Nombre;

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

        public static bool Exists(MenuItem menuItem, Aplicacion aplicacion)
        {
            return Query.GetMenuItemes().Any<MenuItem>(x => x == menuItem && x.Aplicacion == aplicacion);
        }

        public static int Last(MenuItem menuItem)
        {
            IQueryable<Castellano.Membresia.MenuItem> menuItems = (from query in Query.GetMenuItemes()
                                                                   where query.Padre.Equals(menuItem)
                                                                   select query);

            if (menuItems.Any<Castellano.Membresia.MenuItem>())
            {
                return menuItems.Max<Castellano.Membresia.MenuItem>(x => x.Orden) + 1;
            }
            else
            {
                return 1;
            }
        }

        public static MenuItem Get(Guid aplicacionId, Guid menuId, Guid id)
        {
            return Query.GetMenuItemes().SingleOrDefault<MenuItem>(x => x.AplicacionId == aplicacionId && x.MenuId == menuId && x.Id == id);
        }

        public static MenuItem Get(string url, bool publico)
        {
            return Query.GetMenuItemes().SingleOrDefault<MenuItem>(x => x.Url == url);
        }

        public static MenuItem Get(Membresia.Menu menu, string url, bool publico)
        {
            return Query.GetMenuItemes().SingleOrDefault<MenuItem>(x => x.Menu == menu && x.Url == url);
        }

        public static List<MenuItem> GetAll()
        {
            return
                (
                from query in Query.GetMenuItemes()
                select query
                ).ToList<MenuItem>();
        }

        public static List<MenuItem> GetAll(Menu menu, Aplicacion aplicacion)
        {
            return aplicacion == null ?
                    (
                    from menuItem in Query.GetMenuItemes(menu)
                    orderby menuItem.Orden
                    select menuItem
                    ).ToList<MenuItem>()
                    :
                    (
                    from menuItem in Query.GetMenuItemes(menu, aplicacion)
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

        public static List<MenuItem> GetAll(Menu menu, Aplicacion aplicacion, MenuItem padre)
        {
            if (aplicacion == null)
            {
                return padre == null ?
                        (
                        from menuItem in Query.GetMenuItemes(menu)
                        where (menuItem.MenuItemId == null)
                        orderby menuItem.Orden
                        select menuItem
                        ).ToList<MenuItem>()
                        :
                        (
                        from menuItem in Query.GetMenuItemes(menu)
                        where menuItem.MenuItemId == padre.Id
                        orderby menuItem.Orden
                        select menuItem
                        ).ToList<MenuItem>();
            }
            else
            {
                return padre == null ?
                        (
                        from menuItem in Query.GetMenuItemes(menu, aplicacion)
                        where (menuItem.MenuItemId == null)
                        orderby menuItem.Orden
                        select menuItem
                        ).ToList<MenuItem>()
                        :
                        (
                        from menuItem in Query.GetMenuItemes(menu, aplicacion)
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

        public static void OrderMenu(string data)
        {
            List<MenuAuxiliar> menusauxiliares = new List<MenuAuxiliar>();

            JArray jsonArray = JsonConvert.DeserializeObject(data) as JArray;

            Guid menuItemId = (Guid)(jsonArray.First["id"]);

            Castellano.Membresia.Aplicacion aplicacion = Castellano.Membresia.Aplicacion.GetAplicacion(menuItemId);

            //Se rompe la relación  recursiva del padre con el hijo
            using (Castellano.Membresia.Context context = new Castellano.Membresia.Context())
            {
                foreach (Castellano.Membresia.MenuItem menuItem in Castellano.Membresia.MenuItem.GetAll(Castellano.Membresia.Menu.MenuPrincipal, aplicacion).Where<Castellano.Membresia.MenuItem>(x => !x.Equals(aplicacion.Inicio)))
                {
                    new Castellano.Membresia.MenuItem
                    {
                        AplicacionId = menuItem.AplicacionId,
                        MenuId = menuItem.MenuId,
                        Id = menuItem.Id,
                        MenuItemId = default(Guid),
                        Nombre = menuItem.Nombre,
                        Informacion = menuItem.Informacion,
                        Icono = menuItem.Icono,
                        Url = menuItem.Url,
                        Visible = menuItem.Visible,
                        MuestraMenus = menuItem.MuestraMenus,
                        Orden = menuItem.Orden
                    }.Save(context);
                }

                context.SubmitChanges();
            }

            //Se obtiene el orden y los nuevos padres e hijos desde el Json generado por el control
            foreach (JObject j in jsonArray)
            {
                menusauxiliares.Add(new MenuAuxiliar
                {
                    Padre = aplicacion.Inicio.Id,
                    Hijo = (Guid)j["id"]
                });

                JArray array = j["children"] as JArray;

                if (array != null)
                {
                    MenuItem.OrderMenu(array, (Guid)j["id"], menusauxiliares);
                }
            }

            int order = (aplicacion.Orden * 1000) + 1;

            using (Castellano.Membresia.Context context = new Castellano.Membresia.Context())
            {
                foreach (MenuAuxiliar menuAuxiliar in menusauxiliares)
                {
                    Castellano.Membresia.MenuItem menuItem = Castellano.Membresia.Query.GetMenuItemes().SingleOrDefault<Castellano.Membresia.MenuItem>(x => x.Id.Equals(menuAuxiliar.Hijo));

                    new Castellano.Membresia.MenuItem
                    {
                        AplicacionId = menuItem.AplicacionId,
                        MenuId = menuItem.MenuId,
                        Id = menuItem.Id,
                        MenuItemId = menuAuxiliar.Padre,
                        Nombre = menuItem.Nombre,
                        Informacion = menuItem.Informacion,
                        Icono = menuItem.Icono,
                        Url = menuItem.Url,
                        Visible = menuItem.Visible,
                        MuestraMenus = menuItem.MuestraMenus,
                        Orden = order
                    }.Save(context);

                    order++;
                }

                context.SubmitChanges();
            }
        }

        private static List<MenuAuxiliar> OrderMenu(JArray jsonArray, Guid padre, List<MenuAuxiliar> pruebas)
        {
            foreach (JObject j in jsonArray)
            {
                pruebas.Add(new MenuAuxiliar
                {
                    Padre = padre,
                    Hijo = (Guid)j["id"]
                });

                if (j["children"] != null)
                {
                    MenuItem.OrderMenu(j["children"] as JArray, (Guid)j["id"], pruebas);
                }
            }

            return pruebas;
        }

        private class MenuAuxiliar
        {
            public Guid Padre
            {
                get;
                set;
            }

            public Guid Hijo
            {
                get;
                set;
            }
        }
    }
}