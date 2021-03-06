using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoAhorro
	{
		public static TipoAhorro APVI1
		{
			get
			{
				return Castellano.TipoAhorro.Get(1);
			}
		}

		public static TipoAhorro APVI2
		{
			get
			{
				return Castellano.TipoAhorro.Get(2);
			}
		}

		public static TipoAhorro Cuenta2
		{
			get
			{
				return Castellano.TipoAhorro.Get(3);
			}
		}

		public static TipoAhorro APVC
		{
			get
			{
				return Castellano.TipoAhorro.Get(4);
			}
		}

		public static TipoAhorro Get(int codigo)
		{
			return Query.GetTipoAhorros().SingleOrDefault<TipoAhorro>(x => x.Codigo == codigo);
		}

		public static List<TipoAhorro> GetAll()
		{
			return
				(
				from query in Query.GetTipoAhorros()
				select query
				).ToList<TipoAhorro>();
		}
	}
}