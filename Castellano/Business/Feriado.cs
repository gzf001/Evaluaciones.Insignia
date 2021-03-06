using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class Feriado
    {
        public static int Count(Ano ano)
        {
            return Query.GetFeriados(ano).Count<Feriado>();
        }

        public static int Count(Castellano.CentroCosto centroCosto, DateTime inicio, DateTime termino)
        {
            IEnumerable<Castellano.Feriado> feriados = Castellano.Context.Instancia.Feriados.Where<Castellano.Feriado>(x => x.Fecha >= inicio && x.Fecha <= termino);

            int? numeroFeriadosCentroCosto = feriados.Where<Castellano.Feriado>(x => x.CentroCostoId.HasValue && x.CentroCosto.Equals(centroCosto)).Count<Castellano.Feriado>();

            int? numeroFeriadosEmpresa = feriados.Where<Castellano.Feriado>(x => x.EmpresaId.HasValue && x.Empresa.Equals(centroCosto.Empresa) && x.CentroCosto == null).Count<Castellano.Feriado>();

            int? numeroFeriadosNacionales = feriados.Where<Castellano.Feriado>(x => !x.EmpresaId.HasValue && !x.CentroCostoId.HasValue).Count<Castellano.Feriado>();

            return (numeroFeriadosCentroCosto.HasValue ? numeroFeriadosCentroCosto.Value : 0) + (numeroFeriadosEmpresa.HasValue ? numeroFeriadosEmpresa.Value : 0) + (numeroFeriadosNacionales.HasValue ? numeroFeriadosNacionales.Value : 0);
        }

        public static bool Exists(CentroCosto centroCosto, Ano anio, Calendario calendario)
        {
            if (calendario != null && !calendario.AnoMes.Ano.Equals(anio))
            {
                anio = calendario.AnoMes.Ano;
            }

            return Query.GetFeriados(centroCosto, anio).Any<Feriado>(x => x.Calendario == calendario);
        }

        public static Feriado Get(Guid id)
        {
            return Query.GetFeriados().SingleOrDefault<Feriado>(x => x.Id == id);
        }

        public static List<Feriado> GetAll()
        {
            return
                (
                from query in Query.GetFeriados()
                select query
                ).ToList<Feriado>();
        }

        public static List<Feriado> GetAll(Ano ano)
        {
            return
                (
                from query in Query.GetFeriados(ano)
                orderby query.Fecha
                select query
                ).ToList<Feriado>();
        }

        public static List<Feriado> GetAll(CentroCosto centroCosto, Ano ano)
        {
            return
                (
                from query in Query.GetFeriados(centroCosto, ano)
                orderby query.Fecha
                select query
                ).ToList<Feriado>();
        }
    }
}