using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class RolAccion
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			RolAccion rolAccion = context.RolAcciones.SingleOrDefault<RolAccion>(x => x == this);

			if (rolAccion == null)
			{
				rolAccion = new RolAccion
				{
					RolId = this.RolId,
					AplicacionId = this.AplicacionId,
					MenuId = this.MenuId,
					MenuItemId = this.MenuItemId,
					AccionCodigo = this.AccionCodigo
				};

				context.RolAcciones.InsertOnSubmit(rolAccion);
			}

			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			RolAccion rolAccion = context.RolAcciones.SingleOrDefault<RolAccion>(x => x == this);

			if (rolAccion != null)
			{
				context.RolAcciones.DeleteOnSubmit(rolAccion);
			}
			PostDelete(context);
		}
	}
}