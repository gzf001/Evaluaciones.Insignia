using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class Suscripcion
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Suscripcion suscripcion = context.Suscripciones.SingleOrDefault<Suscripcion>(x => x == this);

			if (suscripcion == null)
			{
				suscripcion = new Suscripcion
				{
					AplicacionId = this.AplicacionId,
					UsuarioId = this.UsuarioId,
					Id = this.Id
				};

				context.Suscripciones.InsertOnSubmit(suscripcion);
			}

			suscripcion.URI = this.URI;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Suscripcion suscripcion = context.Suscripciones.SingleOrDefault<Suscripcion>(x => x == this);

			if (suscripcion != null)
			{
				context.Suscripciones.DeleteOnSubmit(suscripcion);
			}
			PostDelete(context);
		}
	}
}