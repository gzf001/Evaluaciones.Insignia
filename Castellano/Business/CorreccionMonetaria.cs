using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CorreccionMonetaria
    {
        public static decimal GetFactor(AnoMes anoMes)
        {
            Castellano.CorreccionMonetaria correccionMonetaria = Castellano.Context.Instancia.CorreccionMonetarias.SingleOrDefault<Castellano.CorreccionMonetaria>(x => x.AnoMes.Equals(anoMes));

            return correccionMonetaria == null ? 0 : 1 + (correccionMonetaria.Factor / 100);
        }

        public static List<CorreccionMonetaria> GetAll()
        {
            return
                (
                from query in Query.GetCorreccionMonetarias()
                select query
                ).ToList<CorreccionMonetaria>();
        }

        public static List<CorreccionMonetaria> GetAll(Castellano.Ano anio)
        {
            return
                (
                from query in Query.GetCorreccionMonetarias(anio)
                orderby query.MesNumero
                select query
                ).ToList<CorreccionMonetaria>();
        }
    }
}