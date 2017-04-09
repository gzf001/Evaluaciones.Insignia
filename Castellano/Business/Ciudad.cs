using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Ciudad
	{
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