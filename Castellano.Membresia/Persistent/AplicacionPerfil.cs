using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class AplicacionPerfil
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			AplicacionPerfil aplicacionPerfil = context.AplicacionPerfiles.SingleOrDefault<AplicacionPerfil>(x => x == this);

			if (aplicacionPerfil == null)
			{
				aplicacionPerfil = new AplicacionPerfil
				{
					AplicacionId = this.AplicacionId,
					PerfilId = this.PerfilId
				};

				context.AplicacionPerfiles.InsertOnSubmit(aplicacionPerfil);
			}

			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			AplicacionPerfil aplicacionPerfil = context.AplicacionPerfiles.SingleOrDefault<AplicacionPerfil>(x => x == this);

			if (aplicacionPerfil != null)
			{
				context.AplicacionPerfiles.DeleteOnSubmit(aplicacionPerfil);
			}
			PostDelete(context);
		}
	}
}