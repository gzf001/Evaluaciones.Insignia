using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
	public partial class AFPAnoMes
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			AFPAnoMes afpAnoMes = context.AFPAnoMeses.SingleOrDefault<AFPAnoMes>(x => x == this);

			if (afpAnoMes == null)
			{
				afpAnoMes = new AFPAnoMes
				{
					TipoInstitucionValorSeguroCodigo = this.TipoInstitucionValorSeguroCodigo,
					InstitucionValorSeguroCodigo = this.InstitucionValorSeguroCodigo,
					AnoNumero = this.AnoNumero,
					MesNumero = this.MesNumero
				};

				context.AFPAnoMeses.InsertOnSubmit(afpAnoMes);
			}

			afpAnoMes.Cotizacion = this.Cotizacion;
			
			PostSave(context);
		}
	}
}
