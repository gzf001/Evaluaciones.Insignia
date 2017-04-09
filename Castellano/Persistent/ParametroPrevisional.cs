using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
	public partial class ParametroPrevisional
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			ParametroPrevisional parametroPrevisional = context.ParametroPrevisionales.SingleOrDefault<ParametroPrevisional>(x => x == this);

			if (parametroPrevisional == null)
			{
				parametroPrevisional = new ParametroPrevisional
				{
					AnoNumero = this.AnoNumero,
					MesNumero = this.MesNumero
				};

				context.ParametroPrevisionales.InsertOnSubmit(parametroPrevisional);
			}

			parametroPrevisional.MaximoImponibleAFP = this.MaximoImponibleAFP;
			parametroPrevisional.MaximoImponilbeRegimenAntiguo = this.MaximoImponilbeRegimenAntiguo;
			parametroPrevisional.MaximoImponibleAFC = this.MaximoImponibleAFC;
			parametroPrevisional.TopeCotizacionSalud = this.TopeCotizacionSalud;
			parametroPrevisional.TopeCotizacionRegimenAntiguo = this.TopeCotizacionRegimenAntiguo;
			parametroPrevisional.SIS = this.SIS;

			PostSave(context);
		}
	}
}
