using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class InstitucionValorSeguroTipoAhorro
	{
		public static List<InstitucionValorSeguroTipoAhorro> GetAll()
		{
			return
				(
				from query in Query.GetInstitucionValorSeguroTipoAhorros()
				select query
				).ToList<InstitucionValorSeguroTipoAhorro>();
		}

		public static List<InstitucionValorSeguroTipoAhorro> GetAll(TipoInstitucionValorSeguro tipoInstitucionValorSeguro, TipoAhorro tipoAhorro)
		{
			return
				(
				from query in Query.GetInstitucionValorSeguroTipoAhorros(tipoInstitucionValorSeguro, tipoAhorro)
				orderby query.InstitucionValorSeguroCodigo
				select query
				).ToList<InstitucionValorSeguroTipoAhorro>();
		}
	}
}