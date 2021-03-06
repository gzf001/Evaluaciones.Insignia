using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class InstitucionSaludAnoMes
	{
		public static InstitucionSaludAnoMes Get(InstitucionSalud institucionSalud, AnoMes anoMes)
		{
			return Query.GetInstitucionSaludAnoMeses().SingleOrDefault<InstitucionSaludAnoMes>(x => x.InstitucionSalud == institucionSalud && x.AnoMes == anoMes);
		}

		public static InstitucionSaludAnoMes Get(int institucionSaludCodigo, int anoNumero, int mesNumero)
		{
			return Query.GetInstitucionSaludAnoMeses().SingleOrDefault<InstitucionSaludAnoMes>(x => x.InstitucionSaludCodigo == institucionSaludCodigo && x.AnoNumero == anoNumero && x.MesNumero == mesNumero);
		}

		public static List<InstitucionSaludAnoMes> GetAll()
		{
			return
				(
				from query in Query.GetInstitucionSaludAnoMeses()
				select query
				).ToList<InstitucionSaludAnoMes>();
		}

		public static List<InstitucionSaludAnoMes> GetAll(AnoMes anoMes)
		{
			return
				(
					from query in Query.GetInstitucionSaludAnoMeses(anoMes)
					orderby query.InstitucionSalud.Nombre
					select query
				).ToList<InstitucionSaludAnoMes>();
		}
	}
}