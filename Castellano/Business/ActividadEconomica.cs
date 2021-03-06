using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class ActividadEconomica
    {
        public static List<ActividadEconomica> GetAll()
        {
            return
                (
                from query in Query.GetActividadEconomicas()
                select query
                ).ToList<ActividadEconomica>();
        }

        public static List<ActividadEconomica> GetAll(Castellano.SectorActividadEconomica sectorActividadEconomica)
        {
            return
                (
                from query in Query.GetActividadEconomicas(sectorActividadEconomica)
                orderby query.Codigo
                select query
                ).ToList<ActividadEconomica>();
        }
    }
}