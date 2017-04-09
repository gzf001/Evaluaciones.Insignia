using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class EstadoCivil
	{
		public static EstadoCivil Soltero
		{
			get
			{
				return EstadoCivil.Get(1);
			}
		}

		public static EstadoCivil Casado
		{
			get
			{
				return EstadoCivil.Get(2);
			}
		}

		public static EstadoCivil Viudo
		{
			get
			{
				return EstadoCivil.Get(3);
			}
		}

		public static EstadoCivil Get(Int16 codigo)
		{
			return Query.GetEstadoCiviles().SingleOrDefault<EstadoCivil>(x => x.Codigo == codigo);
		}

		public static List<EstadoCivil> GetAll()
		{
			return
				(
				from query in Query.GetEstadoCiviles()
				select query
				).ToList<EstadoCivil>();
		}
	}
}