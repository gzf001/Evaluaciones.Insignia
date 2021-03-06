using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TramoCargaFamiliar
	{
		public static TramoCargaFamiliar Get(Ano ano, Mes mes, TipoCargaFamiliar tipoCargaFamiliar, TramoAsignacionFamiliar tramo)
		{
			return Query.GetTramoCargaFamiliares(ano, mes, tipoCargaFamiliar).SingleOrDefault<TramoCargaFamiliar>(x => x.TramoAsignacionFamiliar == tramo);
		}

		public static List<TramoCargaFamiliar> GetAll()
		{
			return
				(
				from query in Query.GetTramoCargaFamiliares()
				select query
				).ToList<TramoCargaFamiliar>();
		}

		public static List<TramoCargaFamiliar> GetAll(Ano ano, Mes mes, TipoCargaFamiliar tipoCargaFamiliar)
		{
			return
				(
				from query in Query.GetTramoCargaFamiliares(ano, mes, tipoCargaFamiliar)
				select query
				).ToList<TramoCargaFamiliar>();
		}

		public static List<TramoCargaFamiliar> GetAll(AnoMes anoMes)
		{
			return
				(
				from query in Query.GetTramoCargaFamiliares(anoMes)
				select query
				).ToList<TramoCargaFamiliar>();
		}
	}
}