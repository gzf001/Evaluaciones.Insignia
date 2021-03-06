using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class Calendario
    {
        public static int Count(DateTime inicio, DateTime termino, bool laboral)
        {
            if (laboral)
            {
                return Castellano.Context.Instancia.Calendarios.Where<Castellano.Calendario>(x => (x.Fecha >= inicio && x.Fecha <= termino) && x.Dia.Laboral).Count<Castellano.Calendario>();
            }
            else
            {
                return Castellano.Context.Instancia.Calendarios.Where<Castellano.Calendario>(x => x.Fecha >= inicio && x.Fecha <= termino).Count<Castellano.Calendario>();
            }
        }

        public static bool Exists(Semana semana, Dia dia)
        {
            return Query.GetCalendarios(semana).Any<Calendario>(x => x.Dia == dia);
        }

        public static Calendario First(Semana semana)
        {
            return Query.GetCalendarios(semana).FirstOrDefault<Calendario>();
        }

        public static Calendario Get(DateTime fecha)
        {
            return Query.GetCalendarios().SingleOrDefault<Calendario>(x => x.Fecha.Year == fecha.Year && x.Fecha.Month == fecha.Month && x.Fecha.Day == fecha.Day);
        }

        public static Calendario Get(Semana semana, Dia dia)
        {
            return Query.GetCalendarios(semana).SingleOrDefault<Calendario>(x => x.Dia == dia);
        }

        public static List<Calendario> GetAll()
        {
            return
                (
                from query in Query.GetCalendarios()
                orderby query.Fecha
                select query
                ).ToList<Calendario>();
        }

        public static List<Calendario> GetAll(Ano ano)
        {
            return
                (
                from query in Query.GetCalendarios(ano)
                orderby query.Fecha
                select query
                ).ToList<Calendario>();
        }

        public static List<Calendario> GetAll(AnoMes anoMes)
        {
            return
                (
                from query in Query.GetCalendarios(anoMes)
                orderby query.Fecha
                select query
                ).ToList<Calendario>();
        }

        public static List<Calendario> GetAll(AnoMes anoMes, bool laboral)
        {
            return
                (
                from query in Query.GetCalendarios(anoMes, laboral)
                orderby query.Fecha
                select query
                ).ToList<Calendario>();
        }

        public static List<Calendario> GetAll(DateTime inicio, DateTime termino)
        {
            return
                (
                from query in Query.GetCalendarios(inicio, termino)
                orderby query.Fecha
                select query
                ).ToList<Calendario>();
        }

        public static List<Calendario> GetAll(Semana semana)
        {
            return
                (
                from query in Query.GetCalendarios(semana)
                orderby query.Fecha
                select query
                ).ToList<Calendario>();
        }

        public static Calendario Last(AnoMes anoMes)
        {
            return Calendario.GetAll(anoMes).OrderByDescending(x => x.Fecha).First<Calendario>();
        }

        public static Calendario PrimerDiaHabil(AnoMes anoMes)
        {
            return Calendario.GetAll(anoMes).Where<Calendario>(x => !Query.GetFeriados(anoMes.Ano).Select<Castellano.Feriado, Castellano.Calendario>(y => y.Calendario).Contains<Calendario>(x)).OrderBy(x => x.Fecha).First<Calendario>();
        }
    }
}