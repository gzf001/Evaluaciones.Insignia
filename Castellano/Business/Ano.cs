using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class Ano
    {
        public static Ano Get(Int32 numero)
        {
            return Query.GetAnos().SingleOrDefault<Ano>(x => x.Numero == numero);
        }

        public static List<Ano> GetAll()
        {
            return
                (
                from query in Query.GetAnos()
                select query
                ).ToList<Ano>();
        }

        public static List<Ano> GetAll(bool activo)
        {
            return
                (
                from query in Query.GetAnos(activo)
                select query
                ).ToList<Ano>();
        }

        public static List<Ano> GetAll(bool activo, int numeroAnios)
        {
            List<Ano> anios = Query.GetAnos(activo).ToList<Ano>();

            return anios.GetRange(anios.Count - numeroAnios, numeroAnios);
        }

        public static void CopiarAnterior(Ano ano)
        {
            using (Castellano.Context context = new Context())
            {
                Ano anoAnterior = Ano.Get(ano.Numero - 1);

                if (anoAnterior == null)
                {
                    throw new Exception("No se ha declarado un año anterior al que ha seleccionado");
                }

                foreach (Castellano.Feriado feriado in Castellano.Feriado.GetAll(anoAnterior))
                {
                    Castellano.Feriado nuevoFeriado = new Castellano.Feriado
                    {
                        Fecha = feriado.Fecha.Date.AddYears(1),
                        Nombre = feriado.Nombre
                    };

                    nuevoFeriado.Save(context);
                }

                context.SubmitChanges();
            }
        }
    }
}