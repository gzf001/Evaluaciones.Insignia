using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Secuencia
	{
		public static Secuencia Get(String clave)
		{
			return Query.GetSecuencias().SingleOrDefault<Secuencia>(x => x.Clave == clave);
		}

		public static List<Secuencia> GetAll()
		{
			return
				(
				from query in Query.GetSecuencias()
				select query
				).ToList<Secuencia>();
		}

		public static int NextVal(Type type)
		{
			Secuencia secuencia = Secuencia.Get(type.ToString());

			using (Context context = new Context())
			{
				if (secuencia == null)
				{
					secuencia = new Secuencia
					{
						Clave = type.ToString()
					};
				}

				secuencia.Numero = secuencia.Numero + 1;
				secuencia.Save(context);

				context.SubmitChanges();
			}

			return secuencia.Numero;
		}

        public static void PeviousVal(Type type)
        {
            Secuencia secuencia = Secuencia.Get(type.ToString());

            if (secuencia != null)
            {
                using (Context context = new Context())
                {              
                    secuencia.Numero = secuencia.Numero - 1;
                    secuencia.Save(context);

                    context.SubmitChanges();
                }
            }
        }
	}
}