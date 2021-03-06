using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoPrevision
	{
		public static TipoPrevision AFP
		{
			get
			{
				return TipoPrevision.Get(1);
			}
		}

		public static TipoPrevision Salud
		{
			get
			{
				return TipoPrevision.Get(2);
			}
		}

		public static TipoPrevision AUGE
		{
			get
			{
				return TipoPrevision.Get(3);
			}
		}

		public static TipoPrevision APVI1
		{
			get
			{
				return TipoPrevision.Get(4);
			}
		}

		public static TipoPrevision APVI2
		{
			get
			{
				return TipoPrevision.Get(5);
			}
		}

		public static TipoPrevision AhorroVoluntario
		{
			get
			{
				return TipoPrevision.Get(6);
			}
		}

		public static TipoPrevision APVC
		{
			get
			{
				return TipoPrevision.Get(7);
			}
		}

		public static TipoPrevision AhorroAfiliadoVoluntario
		{
			get
			{
				return TipoPrevision.Get(8);
			}
		}

		public static TipoPrevision CotizacionAfiliadoVoluntario
		{
			get
			{
				return TipoPrevision.Get(9);
			}
		}

		public static TipoPrevision Get(int codigo)
		{
			return Query.GetTipoPrevisiones().SingleOrDefault<TipoPrevision>(x => x.Codigo == codigo);
		}

		public static List<TipoPrevision> GetAll()
		{
			return
				(
				from query in Query.GetTipoPrevisiones()
				select query
				).ToList<TipoPrevision>();
		}
	}
}