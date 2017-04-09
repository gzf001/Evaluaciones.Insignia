using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
	public partial class MonedaDiaria
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			MonedaDiaria monedaDiaria = context.MonedaDiarias.SingleOrDefault<MonedaDiaria>(x => x == this);

			if (monedaDiaria == null)
			{
				monedaDiaria = new MonedaDiaria
				{
					TipoMonedaCodigo = this.TipoMonedaCodigo,
					CalendarioFecha = this.CalendarioFecha
				};

				context.MonedaDiarias.InsertOnSubmit(monedaDiaria);
			}


			monedaDiaria.Valor = this.Valor;

			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			MonedaDiaria monedaDiaria = context.MonedaDiarias.SingleOrDefault<MonedaDiaria>(x => x == this);

			if (monedaDiaria != null)
			{
				context.MonedaDiarias.DeleteOnSubmit(monedaDiaria);
			}

			PostDelete(context);
		}
	}
}
