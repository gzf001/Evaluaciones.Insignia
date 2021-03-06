using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Mes
	{
		public static Mes Enero
		{
			get
			{
				return Mes.Get(1);
			}
		}

		public static Mes Febrero
		{
			get
			{
				return Mes.Get(2);
			}
		}

		public static Mes Marzo
		{
			get
			{
				return Mes.Get(3);
			}
		}

		public static Mes Abril
		{
			get
			{
				return Mes.Get(4);
			}
		}

		public static Mes Mayo
		{
			get
			{
				return Mes.Get(5);
			}
		}

		public static Mes Junio
		{
			get
			{
				return Mes.Get(6);
			}
		}

		public static Mes Julio
		{
			get
			{
				return Mes.Get(7);
			}
		}

		public static Mes Agosto
		{
			get
			{
				return Mes.Get(8);
			}
		}

		public static Mes Septiembre
		{
			get
			{
				return Mes.Get(9);
			}
		}

		public static Mes Octubre
		{
			get
			{
				return Mes.Get(10);
			}
		}

		public static Mes Noviembre
		{
			get
			{
				return Mes.Get(11);
			}
		}

		public static Mes Diciembre
		{
			get
			{
				return Mes.Get(12);
			}
		}

		public static Mes Get(Int32 numero)
		{
			return Query.GetMeses().SingleOrDefault<Mes>(x => x.Numero == numero);
		}

		public static Mes Get(string nombre)
		{
			return Query.GetMeses().SingleOrDefault<Mes>(x => x.Nombre.ToLower() == nombre.ToLower());
		}

		public static List<Mes> GetAll()
		{
			return
				(
				from query in Query.GetMeses()
				select query
				).ToList<Mes>();
		}

		public static List<Mes> GetAll(DateTime desde, DateTime hasta)
		{
			return
				(
				from query in Query.GetMeses(desde, hasta)
				select query
				).ToList<Mes>();
		}
	}
}