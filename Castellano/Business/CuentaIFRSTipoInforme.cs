using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CuentaIFRSTipoInforme
	{
        public static CuentaIFRSTipoInforme Get(int codigo)
        {
            return Query.GetCuentaIFRSTipoInformes().SingleOrDefault<CuentaIFRSTipoInforme>(x => x.Codigo == codigo);
        }

        public static CuentaIFRSTipoInforme ESFinancieraClasificado
        {
            get { return CuentaIFRSTipoInforme.Get(1); }
        }

        public static CuentaIFRSTipoInforme EResultadosporFuncion
        {
            get { return CuentaIFRSTipoInforme.Get(2); }
        }

        public static CuentaIFRSTipoInforme EResultadosporNaturaleza
        {
            get { return CuentaIFRSTipoInforme.Get(3); }
        }

        public static List<CuentaIFRSTipoInforme> GetAll()
		{
			return
				(
				from query in Query.GetCuentaIFRSTipoInformes()
				select query
				).ToList<CuentaIFRSTipoInforme>();
		}
	}
}