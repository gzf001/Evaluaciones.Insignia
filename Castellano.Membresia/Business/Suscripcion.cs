using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class Suscripcion
	{
		public static List<Suscripcion> GetAll()
		{
			return
				(
				from query in Query.GetSuscripciones()
				select query
				).ToList<Suscripcion>();
		}

        public static List<Suscripcion> GetAll(Castellano.Membresia.Aplicacion aplicacion)
        {
            return
                (
                from query in Query.GetSuscripciones(aplicacion)
                select query
                ).ToList<Suscripcion>();
        }

        public static List<Suscripcion> GetAll(Castellano.Membresia.Aplicacion aplicacion, Castellano.Membresia.Usuario usuario)
        {
            return
                (
                from query in Query.GetSuscripciones(aplicacion, usuario)
                select query
                ).ToList<Suscripcion>();
        }
    }
}