using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class RolPersona
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			RolPersona rolPersona = context.RolPersonas.SingleOrDefault<RolPersona>(x => x == this);

			if (rolPersona == null)
			{
				rolPersona = new RolPersona
				{
					RolId = this.RolId,
					PersonaId = this.PersonaId
				};

				context.RolPersonas.InsertOnSubmit(rolPersona);
			}

			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			RolPersona rolPersona = context.RolPersonas.SingleOrDefault<RolPersona>(x => x == this);

			if (rolPersona != null)
			{
				context.RolPersonas.DeleteOnSubmit(rolPersona);
			}
			PostDelete(context);
		}
	}
}