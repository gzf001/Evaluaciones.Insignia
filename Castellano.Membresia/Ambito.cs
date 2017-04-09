using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public static class Ambito
	{
		public static bool IsAplicacion(Persona persona)
		{
			return Query.GetRolPersonas(persona).Any<RolPersona>();
		}

		public static List<Castellano.Ambito> GetAll(Aplicacion aplicacion, Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Persona persona)
		{
			List<Castellano.Ambito> list = new List<Castellano.Ambito>();

			if (Query.GetRolPersonas(persona, aplicacion).Any<RolPersona>())
			{
				list.Add(Castellano.Ambito.Aplicacion);

                if (empresa != null)
                {
                    list.Add(Castellano.Ambito.Empresa);
                }

                if (centroCosto != null)
                {
                    list.Add(Castellano.Ambito.CentroCosto);
                }
			}
			else if (Query.GetRolPersonaEmpresas(persona, aplicacion, empresa).Any<RolPersonaEmpresa>())
			{
				list.Add(Castellano.Ambito.Empresa);

                if (centroCosto != null)
                {
                    list.Add(Castellano.Ambito.CentroCosto);
                }
			}
			else if (Query.GetRolPersonaCentroCostos(persona, aplicacion, centroCosto).Any<RolPersonaCentroCosto>())
			{
				list.Add(Castellano.Ambito.CentroCosto);
			}

			return list;
		}
	}
}
