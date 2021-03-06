using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoAFC
	{
		public static TipoAFC PlazoFijo
		{
			get
			{
				return TipoAFC.Get(1);
			}
		}

		public static TipoAFC Indefinido
		{
			get
			{
				return TipoAFC.Get(2);
			}
		}

        public static TipoAFC OnceAniosContrato
        {
            get
            {
                return TipoAFC.Get(3);
            }
        }

		public static TipoAFC Get(int codigo)
		{
			return Query.GetTipoAFCes().SingleOrDefault<TipoAFC>(x => x.Codigo == codigo);
		}

		public static List<TipoAFC> GetAll()
		{
			return
				(
				from query in Query.GetTipoAFCes()
				select query
				).ToList<TipoAFC>();
		}
	}
}