using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class Auditoria
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Auditoria auditoria = context.Auditorias.SingleOrDefault<Auditoria>(x => x == this);

			if (auditoria == null)
			{
				auditoria = new Auditoria
				{
					Id = this.Id,
					UsuarioId = this.UsuarioId,
					AplicacionId = this.AplicacionId,
					MenuId = this.MenuId,
					MenuItemId = this.MenuItemId
				};

				context.Auditorias.InsertOnSubmit(auditoria);
			}

			auditoria.Actividad = this.Actividad;
			auditoria.Fecha = this.Fecha;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Auditoria auditoria = context.Auditorias.SingleOrDefault<Auditoria>(x => x == this);

			if (auditoria != null)
			{
				context.Auditorias.DeleteOnSubmit(auditoria);
			}
			PostDelete(context);
		}
	}
}