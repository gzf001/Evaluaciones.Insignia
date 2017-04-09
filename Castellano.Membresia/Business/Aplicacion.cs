using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class Aplicacion
	{
		public static int Count(Castellano.Empresa empresa)
		{
			return Query.GetAplicaciones(empresa).Count<Aplicacion>();
		}

		public static Aplicacion Get(Guid id)
		{
			return Query.GetAplicaciones().SingleOrDefault<Aplicacion>(x=>x.Id == id);
		}

		public static Aplicacion Get(string clave)
		{
			return Query.GetAplicaciones().SingleOrDefault<Aplicacion>(x => x.Clave == clave);
		}

		public static List<Aplicacion> GetAll()
		{
			return
				(
				from query in Query.GetAplicaciones()
				orderby query.Orden
				select query
				).ToList<Aplicacion>();
		}

		public static List<Aplicacion> GetAll(Castellano.CentroCosto centroCosto)
		{
			return
				(
				from query in Query.GetAplicaciones(centroCosto)
				orderby query.Orden
				select query
				).ToList<Aplicacion>();
		}

		public static List<Aplicacion> GetAll(Castellano.Empresa empresa)
		{
			return
				(
				from query in Query.GetAplicaciones(empresa)
				orderby query.Orden
				select query
				).ToList<Aplicacion>();
		}

		public static List<Aplicacion> GetAll(Persona persona)
		{
			return
				(
				from query in Query.GetAplicaciones(persona)
				orderby query.Orden
				select query
				).ToList<Aplicacion>();
		}

		public static List<Aplicacion> GetAll(MenuItem menuItem)
		{
			return
				(
				from query in Query.GetAplicaciones(menuItem)
				orderby query.Orden
				select query
				).ToList<Aplicacion>();
		}
	}
}