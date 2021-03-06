using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class EmpresaAplicacion
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			EmpresaAplicacion empresaAplicacion = context.EmpresaAplicaciones.SingleOrDefault<EmpresaAplicacion>(x => x == this);

			if (empresaAplicacion == null)
			{
				empresaAplicacion = new EmpresaAplicacion
				{
					EmpresaId = this.EmpresaId,
					AplicacionId = this.AplicacionId
				};

				context.EmpresaAplicaciones.InsertOnSubmit(empresaAplicacion);
			}

			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			EmpresaAplicacion empresaAplicacion = context.EmpresaAplicaciones.SingleOrDefault<EmpresaAplicacion>(x => x == this);

			if (empresaAplicacion != null)
			{
				context.EmpresaAplicaciones.DeleteOnSubmit(empresaAplicacion);
			}
			PostDelete(context);
		}
	}
}