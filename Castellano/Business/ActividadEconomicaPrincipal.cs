using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class ActividadEconomicaPrincipal
    {
        public static List<ActividadEconomicaPrincipal> GetAll()
        {
            return
                (
                from query in Query.GetActividadEconomicaPrincipales()
                orderby query.Codigo
                select query
                ).ToList<ActividadEconomicaPrincipal>();
        }
    }
}