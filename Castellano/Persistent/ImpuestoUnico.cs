using System;
using System.Linq;
namespace Castellano
{
	public partial class ImpuestoUnico
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			ImpuestoUnico impuestoUnico = context.ImpuestoUnicos.SingleOrDefault<ImpuestoUnico>(x => x == this);

			if (impuestoUnico == null)
			{
				impuestoUnico = new ImpuestoUnico
				{
					Id = this.Id,
					AnoNumero = this.AnoNumero,
					MesNumero = this.MesNumero
				};

				context.ImpuestoUnicos.InsertOnSubmit(impuestoUnico);
			}

			impuestoUnico.Desde = this.Desde;
			impuestoUnico.Hasta = this.Hasta == default(Decimal) ? null : this.Hasta;
			impuestoUnico.Rebaja = this.Rebaja;
			impuestoUnico.Factor = this.Factor;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			ImpuestoUnico impuestoUnico = context.ImpuestoUnicos.SingleOrDefault<ImpuestoUnico>(x => x == this);

			if (impuestoUnico != null)
			{
				context.ImpuestoUnicos.DeleteOnSubmit(impuestoUnico);
			}
			PostDelete(context);
		}
	}
}