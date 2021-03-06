using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Castellano
{
	public partial class Nacionalidad
	{
        public static IEnumerable<SelectListItem> Nacionalidades
        {
            get
            {
                IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "[Seleccione]"
                }, count: 1);

                SelectList lista = new SelectList(Castellano.Nacionalidad.GetAll(), "Codigo", "Nombre");

                return defaultItem.Concat(lista);
            }
        }

		public static Nacionalidad Chilena
		{
			get
			{
				return Castellano.Nacionalidad.Get(1);
			}
		}

		public static Nacionalidad Get(Int16 codigo)
		{
			return Query.GetNacionalidades().SingleOrDefault<Nacionalidad>(x => x.Codigo == codigo);
		}

		public static List<Nacionalidad> GetAll()
		{
			return
				(
				from query in Query.GetNacionalidades()
				select query
				).ToList<Nacionalidad>();
		}
	}
}