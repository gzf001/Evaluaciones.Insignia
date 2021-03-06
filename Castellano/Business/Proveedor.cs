using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class Proveedor
    {
        public static Proveedor Get(Guid id)
        {
            return Query.GetProveedores().SingleOrDefault<Castellano.Proveedor>(x => x.Id == id);
        }

        public static Proveedor Get(int rutCuerpo, char rutDigito)
        {
            return Query.GetProveedores().SingleOrDefault<Castellano.Proveedor>(x => x.RutCuerpo == rutCuerpo && x.RutDigito == rutDigito);
        }

        public static List<Proveedor> GetAll()
        {
            return
                (
                from query in Query.GetProveedores()
                orderby query.RazonSocial
                select query
                ).ToList<Proveedor>();
        }
    }
}