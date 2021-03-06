using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TramoAsignacionFamiliar
	{
		public static TramoAsignacionFamiliar A
		{
			get
			{
				return TramoAsignacionFamiliar.Get(1);
			}
		}

		public static TramoAsignacionFamiliar B
		{
			get
			{
				return TramoAsignacionFamiliar.Get(2);
			}
		}

		public static TramoAsignacionFamiliar C
		{
			get
			{
				return TramoAsignacionFamiliar.Get(3);
			}
		}

		public static TramoAsignacionFamiliar D
		{
			get
			{
				return TramoAsignacionFamiliar.Get(4);
			}
		}

		public static TramoAsignacionFamiliar Get(int codigo)
		{
			return Query.GetTramoAsignacionFamiliares().SingleOrDefault<TramoAsignacionFamiliar>(x => x.Codigo == codigo);
		}

		public static TramoAsignacionFamiliar Get(string tramo)
		{
			return Query.GetTramoAsignacionFamiliares().SingleOrDefault<TramoAsignacionFamiliar>(x => x.Nombre.ToLower() == tramo.ToLower());
		}

		public static List<TramoAsignacionFamiliar> GetAll()
		{
			return
				(
				from query in Query.GetTramoAsignacionFamiliares()
				select query
				).ToList<TramoAsignacionFamiliar>();
		}
	}
}