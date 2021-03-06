using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoCuenta
	{
        public static TipoCuenta CuentaAhorro
        {
            get
            {
                return Castellano.TipoCuenta.Get(1);
            }
        }

        public static TipoCuenta CuentaCorriente
        {
            get
            {
                return Castellano.TipoCuenta.Get(2);
            }
        }

        public static TipoCuenta CuentaVista
        {
            get
            {
                return Castellano.TipoCuenta.Get(3);
            }
        }

        public static TipoCuenta ChequeraElectronica
        {
            get
            {
                return Castellano.TipoCuenta.Get(4);
            }
        }

        public static TipoCuenta CuentaRut
        {
            get
            {
                return Castellano.TipoCuenta.Get(5);
            }
        }

		public static TipoCuenta Get(Int32 codigo)
		{
			return Query.GetTipoCuentas().SingleOrDefault<TipoCuenta>(x => x.Codigo == codigo);
		}

		public static List<TipoCuenta> GetAll()
		{
			return
				(
				from query in Query.GetTipoCuentas()
				select query
				).ToList<TipoCuenta>();
		}
	}
}