using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Comuna
	{
		public static Comuna Get(Int16 regionCodigo, Int16 ciudadCodigo, Int16 codigo)
		{
			return Query.GetComunas().SingleOrDefault<Comuna>(x => x.RegionCodigo == regionCodigo && x.CiudadCodigo == ciudadCodigo && x.Codigo == codigo);
		}

        public static Comuna Get(string nombre)
        {
            return Query.GetComunas().SingleOrDefault<Comuna>(x => x.Nombre == nombre);
        }

		public static List<Comuna> GetAll()
		{
			return
				(
				from query in Query.GetComunas()
				orderby query.Nombre
				select query
				).ToList<Comuna>();
		}

		public static List<Comuna> GetAll(Ciudad ciudad)
		{
			return
				(
				from query in Query.GetComunas(ciudad)
				orderby query.Nombre
				select query
				).ToList<Comuna>();
		}
	}
}