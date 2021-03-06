using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Cliente
    {
        public static Cliente Get(Empresa empresa, Guid id)
        {
            return Query.GetClientes(empresa).SingleOrDefault<Castellano.Cliente>(x => x.Id == id);
        }

        public static Cliente Get(Empresa empresa, int rutCuerpo, char rutDigito)
        {
            return Query.GetClientes(empresa).SingleOrDefault<Castellano.Cliente>(x => x.RutCuerpo == rutCuerpo && x.RutDigito == rutDigito);
        }

        public static List<Cliente> GetAll()
        {
            return
                (
                from query in Query.GetClientes()
                select query
                ).ToList<Cliente>();
        }

        public static List<Cliente> GetAll(FindType findType, Empresa empresa, string nombre)
        {
            return
                (
                from query in Query.GetClientes(findType, empresa, nombre)
                select query
                ).ToList<Cliente>();
        }

        public static List<Cliente> GetAll(Empresa empresa, int rutCuerpo, char rutDigito)
        {
            return
                (
                from query in Query.GetClientes(empresa, rutCuerpo, rutDigito)
                select query
                ).ToList<Cliente>();
        }
    }
}