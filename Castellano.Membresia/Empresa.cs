using System.Collections.Generic;
using System.Linq;

namespace Castellano.Membresia
{
    public class Empresa
    {
        public static bool Exists(Castellano.Empresa empresa, Castellano.Membresia.Rol rol)
        {
            List<Castellano.Empresa> empresas = Query.GetEmpresas(rol).ToList<Castellano.Empresa>();

            if (empresas.Count == 0)
            {
                return true;
            }
            else if (empresas.Count == 1)
            {
                return empresas[0].Equals(empresa);
            }
            else 
            {
                return false;
            }
        }

        public static List<Castellano.Empresa> GetAll(Castellano.Persona persona, Aplicacion aplicacion)
        {
            return
                (
                from query in Query.GetEmpresas(persona, aplicacion)
                orderby query.RazonSocial
                select query
                ).ToList<Castellano.Empresa>();
        }

        public static List<Castellano.Empresa> GetAll(Rol rol)
        {
            return
                (
                from query in Query.GetEmpresas(rol)
                orderby query.RazonSocial
                select query
                ).ToList<Castellano.Empresa>();
        }
    }
}
