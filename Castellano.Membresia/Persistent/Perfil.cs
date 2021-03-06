using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class Perfil
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Perfil perfil = context.Perfiles.SingleOrDefault<Perfil>(x => x == this);

			if (perfil == null)
			{
				perfil = new Perfil
				{
					Id = this.Id
				};

				context.Perfiles.InsertOnSubmit(perfil);
			}

			perfil.Nombre = this.Nombre;
			perfil.Clave = this.Clave;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Perfil perfil = context.Perfiles.SingleOrDefault<Perfil>(x => x == this);

			if (perfil != null)
			{
				context.Perfiles.DeleteOnSubmit(perfil);
			}
			PostDelete(context);
		}
	}
}