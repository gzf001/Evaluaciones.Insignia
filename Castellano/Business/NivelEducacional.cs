using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Castellano
{
	public partial class NivelEducacional
    {
        public static IEnumerable<SelectListItem> NivelesEducacionales
        {
            get
            {
                IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "[Seleccione]"
                }, count: 1);

                SelectList lista = new SelectList(Castellano.NivelEducacional.GetAll(), "Codigo", "Nombre");

                return defaultItem.Concat(lista);
            }
        }

		public static NivelEducacional Get(Int32 codigo)
		{
			return Query.GetNivelEducacionales().SingleOrDefault<NivelEducacional>(x => x.Codigo == codigo);
		}

		public static List<NivelEducacional> GetAll()
		{
			return
				(
				from query in Query.GetNivelEducacionales()
				select query
				).ToList<NivelEducacional>();
		}
	}
}