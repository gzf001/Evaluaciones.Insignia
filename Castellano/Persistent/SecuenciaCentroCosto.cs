using System;
using System.Linq;
namespace Castellano
{
	public partial class SecuenciaCentroCosto
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			SecuenciaCentroCosto secuenciaCentroCosto = context.SecuenciaCentroCostos.SingleOrDefault<SecuenciaCentroCosto>(x => x == this);

			if (secuenciaCentroCosto == null)
			{
				secuenciaCentroCosto = new SecuenciaCentroCosto
				{
					EmpresaId = this.EmpresaId,
					CentroCostoId = this.CentroCostoId,
					Clave = this.Clave
				};

				context.SecuenciaCentroCostos.InsertOnSubmit(secuenciaCentroCosto);
			}

			secuenciaCentroCosto.Numero = this.Numero;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			SecuenciaCentroCosto secuenciaCentroCosto = context.SecuenciaCentroCostos.SingleOrDefault<SecuenciaCentroCosto>(x => x == this);

			if (secuenciaCentroCosto != null)
			{
				context.SecuenciaCentroCostos.DeleteOnSubmit(secuenciaCentroCosto);
			}
			PostDelete(context);
		}
	}
}