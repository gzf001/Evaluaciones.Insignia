using System;
using System.Linq;
namespace Castellano
{
	public partial class Contacto
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Contacto contacto = context.Contactos.SingleOrDefault<Contacto>(x => x == this);

			if (contacto == null)
			{
				contacto = new Contacto
				{
					Id = this.Id
				};

				context.Contactos.InsertOnSubmit(contacto);
			}

			contacto.ProveedorId = this.ProveedorId;
			contacto.Nombre = this.Nombre;
			contacto.Cargo = this.Cargo;
			contacto.TelefonoNumero = this.TelefonoNumero == default(Int32) ? null : this.TelefonoNumero;
			contacto.CelularNumero = this.CelularNumero == default(Int32) ? null : this.CelularNumero;
			contacto.Email = this.Email;
			contacto.Observacion = this.Observacion;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Contacto contacto = context.Contactos.SingleOrDefault<Contacto>(x => x == this);

			if (contacto != null)
			{
				context.Contactos.DeleteOnSubmit(contacto);
			}
			PostDelete(context);
		}
	}
}