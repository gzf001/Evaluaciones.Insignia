using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Ambito
	{
		public static Ambito Aplicacion { get { return Get(1); } }

		public static Ambito Empresa { get { return Get(2); } }

		public static Ambito CentroCosto { get { return Get(3); } }

		public static Ambito Get(Int32 codigo)
		{
			return Query.GetAmbitos().SingleOrDefault<Ambito>(x => x.Codigo == codigo);
		}

		public static List<Ambito> GetAll()
		{
			return
				(
				from query in Query.GetAmbitos()
				select query
				).ToList<Ambito>();
		}
	}
}