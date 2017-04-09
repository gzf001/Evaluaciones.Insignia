using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
	public partial class AFCAnoMes
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			AFCAnoMes afcAnoMes = context.AFCAnoMeses.SingleOrDefault<AFCAnoMes>(x => x == this);

			if (afcAnoMes == null)
			{
				afcAnoMes = new AFCAnoMes
				{
					AnoNumero = this.AnoNumero,
					MesNumero = this.MesNumero,
					TipoAFCCodigo = this.TipoAFCCodigo
				};

				context.AFCAnoMeses.InsertOnSubmit(afcAnoMes);
			}

			afcAnoMes.Empleador = this.Empleador;
			afcAnoMes.Trabajador = this.Trabajador;

			PostSave(context);
		}
	}
}
