using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class SecuenciaEmpresa
    {
        public static SecuenciaEmpresa Get(Castellano.Empresa empresa, Type type)
        {
            return Query.GetSecuenciaEmpresas(empresa).SingleOrDefault<SecuenciaEmpresa>(x => x.Clave == type.ToString());
        }

        public static List<SecuenciaEmpresa> GetAll()
        {
            return
                (
                from query in Query.GetSecuenciaEmpresas()
                select query
                ).ToList<SecuenciaEmpresa>();
        }

        public static int NextVal(Castellano.Empresa empresa, Type type)
        {
            Castellano.SecuenciaEmpresa secuenciaEmpresa = SecuenciaEmpresa.Get(empresa, type);

            using (Context context = new Context())
            {
                if (secuenciaEmpresa == null)
                {
                    secuenciaEmpresa = new SecuenciaEmpresa
                    {
                        EmpresaId = empresa.Id,
                        Clave = type.ToString()
                    };
                }

                secuenciaEmpresa.Numero = secuenciaEmpresa.Numero + 1;
                secuenciaEmpresa.Save(context);

                context.SubmitChanges();
            }

            return secuenciaEmpresa.Numero;
        }

        public static int PreviousVal(Castellano.Empresa empresa, Type type)
        {
            Castellano.SecuenciaEmpresa secuenciaEmpresa = SecuenciaEmpresa.Get(empresa, type);

            using (Context context = new Context())
            {
                if (secuenciaEmpresa == null)
                {
                    secuenciaEmpresa = new SecuenciaEmpresa
                    {
                        EmpresaId = empresa.Id,
                        Clave = type.ToString()
                    };
                }

                secuenciaEmpresa.Numero = secuenciaEmpresa.Numero - 1;
                secuenciaEmpresa.Save(context);

                context.SubmitChanges();
            }

            return secuenciaEmpresa.Numero;
        }
    }
}