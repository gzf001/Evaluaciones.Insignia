using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class FormaPago
	{
		public static FormaPago Efectivo
		{
			get
			{
				return FormaPago.Get(1);
			}
		}

		public static FormaPago Cheque
		{
			get
			{
				return FormaPago.Get(2);
			}
		}
		
		public static FormaPago TransferenciaBancaria
		{
			get
			{
				return FormaPago.Get(3);
			}
		}

        public static FormaPago ValeVista
        {
            get
            {
                return FormaPago.Get(4);
            }
        }

		public static FormaPago Get(Int32 codigo)
		{
			return Query.GetFormaPagos().SingleOrDefault<FormaPago>(x => x.Codigo == codigo);
		}

		public static List<FormaPago> GetAll()
		{
			return
				(
				from query in Query.GetFormaPagos()
				select query
				).ToList<FormaPago>();
		}
	}
}