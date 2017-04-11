using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Castellano
{
	public partial class Ciudad
    {
        public static IEnumerable<SelectListItem> Ciudades
        {
            get
            {
                IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "[Seleccione]"
                }, count: 1);

                return defaultItem;
            }
        }

		public static Ciudad Get(Int16 regionCodigo, Int16 codigo)
		{
			return Query.GetCiudades().SingleOrDefault<Ciudad>(x => x.RegionCodigo == regionCodigo && x.Codigo == codigo);
		}

		public static List<Ciudad> GetAll()
		{
			return
				(
				from query in Query.GetCiudades()
				select query
				).ToList<Ciudad>();
		}

		public static List<Ciudad> GetAll(Region region)
		{
			return
				(
				from query in Query.GetCiudades(region)
				select query
				).ToList<Ciudad>();
		}
	}
}