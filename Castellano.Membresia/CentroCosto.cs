using System.Collections.Generic;
using System.Linq;

namespace Castellano.Membresia
{
	public class CentroCosto
    {      
		public static List<Castellano.CentroCosto> GetAll(Castellano.Persona persona, Castellano.Empresa empresa, Aplicacion aplicacion)
		{
			return
				(
				from query in Query.GetCentroCostos(persona, empresa, aplicacion)
				orderby query.Nombre
				select query
				).ToList<Castellano.CentroCosto>();
		}
    }
}
