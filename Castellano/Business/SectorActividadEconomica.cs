using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class SectorActividadEconomica
    {
        public static List<SectorActividadEconomica> GetAll()
        {
            return
                (
                from query in Query.GetSectorActividadEconomicas()
                select query
                ).ToList<SectorActividadEconomica>();
        }

        public static List<SectorActividadEconomica> GetAll(Castellano.ActividadEconomicaPrincipal actividadEconomicaPrincipal)
        {
            return
                (
                from query in Query.GetSectorActividadEconomicas()
                where query.ActividadEconomicaPrincipal == actividadEconomicaPrincipal
                orderby query.Codigo
                select query
                ).ToList<SectorActividadEconomica>();
        }
    }
}