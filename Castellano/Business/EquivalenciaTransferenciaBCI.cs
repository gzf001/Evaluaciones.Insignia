using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class EquivalenciaTransferenciaBCI
    {
        public static EquivalenciaTransferenciaBCI Get(Castellano.InstitucionValorSeguro banco)
        {
            return Query.GetEquivalenciaTransferenciaBCIs(banco).SingleOrDefault<Castellano.EquivalenciaTransferenciaBCI>();
        }

        public static List<EquivalenciaTransferenciaBCI> GetAll()
        {
            return
                (
                from query in Query.GetEquivalenciaTransferenciaBCIs()
                select query
                ).ToList<EquivalenciaTransferenciaBCI>();
        }
    }
}