using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Castellano
{
	public partial class Region
    {
        public static IEnumerable<SelectListItem> Regiones
        {
            get
            {
                IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "[Seleccione]"
                }, count: 1);

                SelectList lista = new SelectList(Castellano.Region.GetAll(), "Codigo", "Nombre");

                return defaultItem.Concat(lista);
            }
        }

		public static Region Get(Int16 codigo)
		{
			return Query.GetRegiones().SingleOrDefault<Region>(x => x.Codigo == codigo);
		}

		public static List<Region> GetAll()
		{
			return
				(
				from query in Query.GetRegiones()
				select query
				).ToList<Region>();
		}
	}
}