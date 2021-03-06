using System;
using System.Linq;
namespace Castellano
{
	public partial class Unidad
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Unidad unidad = context.Unidades.SingleOrDefault<Unidad>(x => x == this);

			if (unidad == null)
			{
				unidad = new Unidad
				{
					EmpresaId = this.EmpresaId,
					Id = this.Id
				};

				context.Unidades.InsertOnSubmit(unidad);
			}

			unidad.AdministradorId = this.AdministradorId == default(Guid) ? null : this.AdministradorId;
			unidad.Nombre = this.Nombre;
			unidad.Descripcion = this.Descripcion;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Unidad unidad = context.Unidades.SingleOrDefault<Unidad>(x => x == this);

			if (unidad != null)
			{
				context.Unidades.DeleteOnSubmit(unidad);
			}
			PostDelete(context);
		}
	}
}