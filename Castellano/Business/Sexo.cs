using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Sexo
	{
		public static Sexo Masculino
		{
			get { return Get(1); }
		}

		public static Sexo Femenino
		{
			get { return Get(2); }
		}

		public static Sexo Get(Int16 codigo)
		{
			return Query.GetSexos().SingleOrDefault<Sexo>(x => x.Codigo == codigo);
		}

		public static List<Sexo> GetAll()
		{
			return
				(
				from query in Query.GetSexos()
				select query
				).ToList<Sexo>();
		}
	}
}