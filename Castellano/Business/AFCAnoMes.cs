using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class AFCAnoMes
	{
		public static AFCAnoMes Get(Ano ano, Mes mes, TipoAFC tipoAFC)
		{
			return Query.GetAFCAnoMeses().SingleOrDefault<AFCAnoMes>(x => x.AnoMes.Ano == ano && x.AnoMes.Mes == mes && x.TipoAFC == tipoAFC);
		}

		public static List<AFCAnoMes> GetAll()
		{
			return
				(
				from query in Query.GetAFCAnoMeses()
				select query
				).ToList<AFCAnoMes>();
		}

		public static List<AFCAnoMes> GetAll(Ano ano, Mes mes)
		{
			return
				(
				from query in Query.GetAFCAnoMeses(ano, mes)
				select query
				).ToList<AFCAnoMes>();
		}

        public static List<AFCAnoMes> GetAll(AnoMes anoMes)
        {
            return
                (
                from query in Query.GetAFCAnoMeses(anoMes)
                select query
                ).ToList<AFCAnoMes>();
        }
    }
}