using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class SecuenciaCentroCosto
	{
        public static SecuenciaCentroCosto Get(Castellano.Empresa empresa, CentroCosto centroCosto, String clave)
		{
            return Query.GetSecuenciaCentroCostos(empresa).SingleOrDefault<SecuenciaCentroCosto>(x => x.CentroCosto == centroCosto && x.Clave == clave);
		}

		public static List<SecuenciaCentroCosto> GetAll()
		{
			return
				(
				from query in Query.GetSecuenciaCentroCostos()
				select query
				).ToList<SecuenciaCentroCosto>();
		}

        public static int NextVal(Castellano.Empresa empresa, CentroCosto centroCosto, Type type)
        {
            Castellano.SecuenciaCentroCosto secuenciaCentroCosto = SecuenciaCentroCosto.Get(empresa, centroCosto, type.ToString());

            using (Context context = new Context())
            {
                if (secuenciaCentroCosto == null)
                {
                    secuenciaCentroCosto = new SecuenciaCentroCosto
                    {
                        EmpresaId = empresa.Id,
                        CentroCostoId = centroCosto.Id,
                        Clave = type.ToString()
                    };
                }

                secuenciaCentroCosto.Numero = secuenciaCentroCosto.Numero + 1;
                secuenciaCentroCosto.Save(context);

                context.SubmitChanges();
            }

            return secuenciaCentroCosto.Numero;
        }
	}
}