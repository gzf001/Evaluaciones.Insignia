using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Parentesco
	{
		public static Parentesco Hijo
		{
			get
			{
				return Parentesco.Get(1);
			}
		}

		public static Parentesco Padre
		{
			get
			{
				return Parentesco.Get(2);
			}
		}

		public static Parentesco Madre
		{
			get
			{
				return Parentesco.Get(3);
			}
		}

		public static Parentesco Conyuge
		{
			get
			{
				return Parentesco.Get(4);
			}
		}

		public static Parentesco Hermano
		{
			get
			{
				return Parentesco.Get(5);
			}
		}

		public static Parentesco Tio
		{
			get
			{
				return Parentesco.Get(6);
			}
		}

		public static Parentesco Abuelo
		{
			get
			{
				return Parentesco.Get(7);
			}
		}

		public static Parentesco Nieto
		{
			get
			{
				return Parentesco.Get(8);
			}
		}

		public static Parentesco Otros
		{
			get
			{
				return Parentesco.Get(9);
			}
		}

		public static Parentesco Get(Int32 codigo)
		{
			return Query.GetParentescos().SingleOrDefault<Parentesco>(x => x.Codigo == codigo);
		}

		public static List<Parentesco> GetAll()
		{
			return
				(
				from query in Query.GetParentescos()
				select query
				).ToList<Parentesco>();
		}
	}
}