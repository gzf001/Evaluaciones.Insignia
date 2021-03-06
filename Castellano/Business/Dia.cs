using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Dia
	{
		public static Dia Lunes
		{
			get
			{
				return Dia.Get(1);
			}
		}

		public static Dia Martes
		{
			get
			{
				return Dia.Get(2);
			}
		}

		public static Dia Miercoles
		{
			get
			{
				return Dia.Get(3);
			}
		}

		public static Dia Jueves
		{
			get
			{
				return Dia.Get(4);
			}
		}

		public static Dia Viernes
		{
			get
			{
				return Dia.Get(5);
			}
		}

		public static Dia Sabado
		{
			get
			{
				return Dia.Get(6);
			}
		}

		public static Dia Domingo
		{
			get
			{
				return Dia.Get(7);
			}
		}

		public static Dia Get(Int16 numero)
		{
			return Query.GetDias().SingleOrDefault<Dia>(x => x.Numero == numero);
		}

		public static Dia Get(DayOfWeek dayOfWeek)
		{
			switch (dayOfWeek)
			{
				case DayOfWeek.Monday: return Lunes;
				case DayOfWeek.Tuesday: return Martes;
				case DayOfWeek.Wednesday: return Miercoles;
				case DayOfWeek.Thursday: return Jueves;
				case DayOfWeek.Friday: return Viernes;
				case DayOfWeek.Saturday: return Sabado;
				case DayOfWeek.Sunday: return Domingo;
				default: return null;
			}
		}

		public static List<Dia> GetAll()
		{
			return
				(
				from query in Query.GetDias()
				select query
				).ToList<Dia>();
		}

		public static List<Dia> GetAll(bool laboral)
		{
			return
				(
				from query in Query.GetDias(laboral)
				orderby query.Numero
				select query
				).ToList<Dia>();
		}
	}
}