using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class RolPersonaCentroCosto
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			RolPersonaCentroCosto rolPersonaCentroCosto = context.RolPersonaCentroCostos.SingleOrDefault<RolPersonaCentroCosto>(x => x == this);

			if (rolPersonaCentroCosto == null)
			{
				rolPersonaCentroCosto = new RolPersonaCentroCosto
				{
					RolId = this.RolId,
					PersonaId = this.PersonaId,
					EmpresaId = this.EmpresaId,
					CentroCostoId = this.CentroCostoId
				};

				context.RolPersonaCentroCostos.InsertOnSubmit(rolPersonaCentroCosto);
			}

			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			RolPersonaCentroCosto rolPersonaCentroCosto = context.RolPersonaCentroCostos.SingleOrDefault<RolPersonaCentroCosto>(x => x == this);

			if (rolPersonaCentroCosto != null)
			{
				context.RolPersonaCentroCostos.DeleteOnSubmit(rolPersonaCentroCosto);
			}
			PostDelete(context);
		}
	}
}