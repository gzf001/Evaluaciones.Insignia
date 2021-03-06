using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CajaPrevisionalExRegimen
	{
		public static CajaPrevisionalExRegimen Canaempu1
		{
			get
			{
				return CajaPrevisionalExRegimen.Get(102);
			}
		}

		public static CajaPrevisionalExRegimen Canaempu2
		{
			get
			{
				return CajaPrevisionalExRegimen.Get(103);
			}
		}

		public static CajaPrevisionalExRegimen Empart
		{
			get
			{
				return CajaPrevisionalExRegimen.Get(101);
			}
		}

		public static CajaPrevisionalExRegimen SSS
		{
			get
			{
				return CajaPrevisionalExRegimen.Get(902);
			}
		}

		public static CajaPrevisionalExRegimen CajaMarinaMercante
		{
			get
			{
				return CajaPrevisionalExRegimen.Get(903);
			}
		}

		public static CajaPrevisionalExRegimen Get(Int32 codigo)
		{
			return Query.GetCajaPrevisionalExRegimenes().SingleOrDefault<CajaPrevisionalExRegimen>(x => x.Codigo == codigo);
		}

		public static List<CajaPrevisionalExRegimen> GetAll()
		{
			return
				(
				from query in Query.GetCajaPrevisionalExRegimenes()
				select query
				).ToList<CajaPrevisionalExRegimen>();
		}
	}
}