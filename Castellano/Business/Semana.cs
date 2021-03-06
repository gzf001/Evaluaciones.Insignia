using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Semana
    {
        public static int Count(AnoMes anioMes)
        {
            return Query.GetSemanas(anioMes).Count<Semana>();
        }

		public static int Count(DateTime inicio, DateTime termino)
		{
			return Query.GetSemanas(inicio, termino).Count<Semana>();
		}

		public string Nombre
		{
			get
			{
				return string.Format("Semana número {0} ({1} al {2} de {3})", this.Numero, this.Inicio.Day, this.Termino.Day, this.AnoMes.Mes.Nombre);
			}
		}

		public static Semana Get(Int32 anoNumero, Int32 mesNumro, Int32 numero)
		{
			return Query.GetSemanas().SingleOrDefault<Semana>(x => x.AnoNumero == anoNumero && x.MesNumro == mesNumro && x.Numero == numero);
		}

		public static List<Semana> GetAll()
		{
			return
				(
				from query in Query.GetSemanas()
				select query
				).ToList<Semana>();
		}

        public static List<Semana> GetAll(AnoMes anoMes)
        {
            return
                (
                from query in Query.GetSemanas(anoMes)
                orderby query.Numero
                select query
                ).ToList<Semana>();
        }

		public static List<Semana> GetAll(DateTime desde, DateTime hasta)
		{
			return
				(
				from query in Query.GetSemanas(desde, hasta)
				orderby query.Inicio
				select query
				).ToList<Semana>();
		}
    }
}