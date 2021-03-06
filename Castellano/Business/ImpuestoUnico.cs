using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class ImpuestoUnico
	{
		public static List<ImpuestoUnico> GetAll()
		{
			return
				(
				from query in Query.GetImpuestoUnicos()
				select query
				).ToList<ImpuestoUnico>();
		}

        public static List<ImpuestoUnico> GetAll(Castellano.AnoMes anoMes)
        {
            return
                 (
                 from query in Query.GetImpuestoUnicos(anoMes)
                 orderby query.Desde
                 select query
                 ).ToList<ImpuestoUnico>();
        }
    }
}