using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class RegimenPrevisional
	{
		public static RegimenPrevisional Activo
		{
			get
			{
				return RegimenPrevisional.Get(1);
			}
		}

		public static RegimenPrevisional PensionadoCotiza
		{
			get
			{
				return RegimenPrevisional.Get(2);
			}
		}

		public static RegimenPrevisional PensionadoNoCotiza
		{
			get
			{
				return RegimenPrevisional.Get(3);
			}
		}

		public static RegimenPrevisional ActivoMayor65
		{
			get
			{
				return RegimenPrevisional.Get(4);
			}
		}

		public static RegimenPrevisional Get(Int32 codigo)
		{
			return Query.GetRegimenPrevisionales().SingleOrDefault<RegimenPrevisional>(x => x.Codigo == codigo);
		}

		public static List<RegimenPrevisional> GetAll()
		{
			return
				(
				from query in Query.GetRegimenPrevisionales()
				select query
				).ToList<RegimenPrevisional>();
		}
	}
}