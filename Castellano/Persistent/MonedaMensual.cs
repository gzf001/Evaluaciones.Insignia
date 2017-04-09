using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
	public partial class MonedaMensual
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			MonedaMensual monedaMensual = context.MonedaMensuales.SingleOrDefault<MonedaMensual>(x => x == this);

			if (monedaMensual == null)
			{
				monedaMensual = new MonedaMensual
				{
					AnoNumero = this.AnoNumero,
					MesNumero = this.MesNumero,
					TipoMonedaCodigo = this.TipoMonedaCodigo,
					Valor = this.Valor
				};

				context.MonedaMensuales.InsertOnSubmit(monedaMensual);
			}

			monedaMensual.Valor = this.Valor;

			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			MonedaMensual monedaMensual = context.MonedaMensuales.SingleOrDefault<MonedaMensual>(x => x == this);

			if (monedaMensual != null)
			{
				context.MonedaMensuales.DeleteOnSubmit(monedaMensual);
			}

			PostDelete(context);
		}
	}
}
