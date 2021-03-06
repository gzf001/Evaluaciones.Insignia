using System;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class Usuario
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Usuario usuario = context.Usuarios.SingleOrDefault<Usuario>(x => x == this);

			if (usuario == null)
			{
				usuario = new Usuario
				{
					Id = this.Id
				};

				context.Usuarios.InsertOnSubmit(usuario);
			}

			usuario.Password = this.Password;
			usuario.Aprobado = this.Aprobado;
			usuario.Bloqueado = this.Bloqueado;
			usuario.Creacion = this.Creacion;
			usuario.UltimaActividad = this.UltimaActividad;
			usuario.UltimoAcceso = this.UltimoAcceso;
			usuario.UltimoCambioPassword = this.UltimoCambioPassword == default(DateTime) ? null : this.UltimoCambioPassword;
			usuario.UltimoDesbloqueo = this.UltimoDesbloqueo == default(DateTime) ? null : this.UltimoDesbloqueo;
			usuario.NumeroIntentosFallidos = this.NumeroIntentosFallidos;
			usuario.FechaIntentoFallido = this.FechaIntentoFallido == default(DateTime) ? null : this.FechaIntentoFallido;
			usuario.AperturaPeriodoRemuneracion = this.AperturaPeriodoRemuneracion;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Usuario usuario = context.Usuarios.SingleOrDefault<Usuario>(x => x == this);

			if (usuario != null)
			{
				context.Usuarios.DeleteOnSubmit(usuario);
			}
			PostDelete(context);
		}
	}
}