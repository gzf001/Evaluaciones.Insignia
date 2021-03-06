using System;
using System.Linq;
namespace Castellano
{
	public partial class SecuenciaEmpresa
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			SecuenciaEmpresa secuenciaEmpresa = context.SecuenciaEmpresas.SingleOrDefault<SecuenciaEmpresa>(x => x == this);

			if (secuenciaEmpresa == null)
			{
				secuenciaEmpresa = new SecuenciaEmpresa
				{
					EmpresaId = this.EmpresaId,
					Clave = this.Clave
				};

				context.SecuenciaEmpresas.InsertOnSubmit(secuenciaEmpresa);
			}

			secuenciaEmpresa.Numero = this.Numero;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			SecuenciaEmpresa secuenciaEmpresa = context.SecuenciaEmpresas.SingleOrDefault<SecuenciaEmpresa>(x => x == this);

			if (secuenciaEmpresa != null)
			{
				context.SecuenciaEmpresas.DeleteOnSubmit(secuenciaEmpresa);
			}
			PostDelete(context);
		}
	}
}