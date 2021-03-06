using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class Perfil
	{
		public static bool Exists(Aplicacion aplicacion, Perfil perfil)
		{
			return Query.GetAplicacionPerfiles().Any<AplicacionPerfil>(x => x.Aplicacion == aplicacion && x.Perfil == perfil);
		}

		public static bool RequireProfile(Aplicacion aplicacion, PerfilType perfilType)
		{
			if (aplicacion == null) return false;

			Perfil perfil = Perfil.Get(perfilType);

			return AplicacionPerfil.Exists(aplicacion, perfil);
		}

		public static Perfil Get(Guid id)
		{
			return Query.GetPerfiles().SingleOrDefault<Perfil>(x => x.Id == id);
		}

		public static Perfil Get(PerfilType perfilType)
		{
			switch (perfilType)
			{
				case PerfilType.Aplicacion: return Query.GetPerfiles().Single<Perfil>(x => x.Clave == "aplicacion");
				case PerfilType.Empresa: return Query.GetPerfiles().Single<Perfil>(x => x.Clave == "empresa");
				case PerfilType.Sostenedor: return Query.GetPerfiles().Single<Perfil>(x => x.Clave == "sostenedor");
				case PerfilType.CentroCosto: return Query.GetPerfiles().Single<Perfil>(x => x.Clave == "centro_costo");
				case PerfilType.Establecimiento: return Query.GetPerfiles().Single<Perfil>(x => x.Clave == "establecimiento");
				case PerfilType.Ano: return Query.GetPerfiles().Single<Perfil>(x => x.Clave == "ano");
				case PerfilType.AnoMes : return Query.GetPerfiles().Single<Perfil>(x=>x.Clave == "ano_mes");
				case PerfilType.PeriodoRemuneracion: return Query.GetPerfiles().Single<Perfil>(x => x.Clave == "periodo_remuneracion");
                case PerfilType.PeriodoTributario: return Query.GetPerfiles().Single<Perfil>(x => x.Clave == "periodo_tributario");
				default: return null;
			}
		}

		public static List<Perfil> GetAll()
		{
			return
				(
				from query in Query.GetPerfiles()
				orderby query.Nombre
				select query
				).ToList<Perfil>();
		}

		public static List<Perfil> GetAll(Aplicacion aplicacion)
		{
			return
				(
				from query in Query.GetPerfiles(aplicacion)
				orderby query.Nombre
				select query
				).ToList<Perfil>();
		}

		#region Aplicacion
		public static Aplicacion GetAplicacion(Usuario usuario)
		{
			Perfil perfil = Get(PerfilType.Aplicacion);

			PerfilUsuario perfilUsuario = PerfilUsuario.Get(perfil, usuario);

			if (perfilUsuario == null)
			{
				return null;
			}
			else
			{
				return Aplicacion.Get(new Guid(perfilUsuario.Valor));
			}
		}

		public static void SetAplicacion(Usuario usuario, Aplicacion aplicacion)
		{
			Perfil perfil = Get(PerfilType.Aplicacion);

			using (Context context = new Context())
			{
				PerfilUsuario perfilUsuario = PerfilUsuario.Get(perfil, usuario);

				if (aplicacion == null)
				{
					if (perfilUsuario != null) perfilUsuario.Delete(context);
				}
				else
				{
					perfilUsuario = new PerfilUsuario
					{
						PerfilId = perfil.Id,
						UsuarioId = usuario.Id,
						Valor = aplicacion.Id.ToString()
					};

					perfilUsuario.Save(context);
				}

				context.SubmitChanges();
			}
		}
		#endregion

		#region Empresa
		public static Castellano.Empresa GetEmpresa(Usuario usuario)
		{
			Perfil perfil = Get(PerfilType.Empresa);

			PerfilUsuario perfilUsuario = PerfilUsuario.Get(perfil, usuario);

			if (perfilUsuario == null)
			{
				return null;
			}
			else
			{
				Castellano.Empresa empresa = Castellano.Empresa.Get(new Guid(perfilUsuario.Valor));

				if (empresa.Bloqueada)
				{
					throw new Exception("La empresa esta bloqueada");
				}

				return empresa;
			}
		}

		public static void SetEmpresa(Usuario usuario, Castellano.Empresa empresa)
		{
			Perfil perfil = Get(PerfilType.Empresa);

			using (Context context = new Context())
			{
				PerfilUsuario perfilUsuario = PerfilUsuario.Get(perfil, usuario);

				if (empresa == null)
				{
					if (perfilUsuario != null) perfilUsuario.Delete(context);
				}
				else
				{
					perfilUsuario = new PerfilUsuario
					{
						PerfilId = perfil.Id,
						UsuarioId = usuario.Id,
						Valor = empresa.Id.ToString()
					};

					perfilUsuario.Save(context);
				}

				context.SubmitChanges();
			}
		}
		#endregion

		#region Centro de costos
		public static Castellano.CentroCosto GetCentroCosto(Usuario usuario)
		{
			try
			{
				Perfil perfil = Get(PerfilType.CentroCosto);

				PerfilUsuario perfilUsuario = PerfilUsuario.Get(perfil, usuario);

				if (perfilUsuario == null)
				{
					return null;
				}
				else
				{
					return Castellano.CentroCosto.Get(GetEmpresa(usuario).Id, new Guid(perfilUsuario.Valor));
				}
			}
			catch
			{
			}

			return null;
		}

		public static void SetCentroCosto(Usuario usuario, Castellano.CentroCosto centroCosto)
		{
			Perfil perfil = Get(PerfilType.CentroCosto);

			using (Context context = new Context())
			{
				PerfilUsuario perfilUsuario = PerfilUsuario.Get(perfil, usuario);

				if (centroCosto == null)
				{
					if (perfilUsuario != null) perfilUsuario.Delete(context);
				}
				else
				{
					perfilUsuario = new PerfilUsuario
					{
						PerfilId = perfil.Id,
						UsuarioId = usuario.Id,
						Valor = centroCosto.Id.ToString()
					};

					perfilUsuario.Save(context);
				}

				context.SubmitChanges();
			}
		}
		#endregion

		#region Año
		public static Ano GetAno(Usuario usuario)
		{
			Perfil perfil = Get(PerfilType.Ano);

			PerfilUsuario perfilUsuario = PerfilUsuario.Get(perfil, usuario);

			if (perfilUsuario == null) return null;
			else return Ano.Get(int.Parse(perfilUsuario.Valor));
		}

		public static void SetAno(Usuario usuario, Ano ano)
		{
			Perfil perfil = Get(PerfilType.Ano);

			using (Context context = new Context())
			{
				PerfilUsuario perfilUsuario = PerfilUsuario.Get(perfil, usuario);

				if (ano == null)
				{
					if (perfilUsuario != null) perfilUsuario.Delete(context);
				}
				else
				{
					perfilUsuario = new PerfilUsuario
					{
						PerfilId = perfil.Id,
						UsuarioId = usuario.Id,
						Valor = ano.Numero.ToString()
					};

					perfilUsuario.Save(context);
				}

				context.SubmitChanges();
			}
		}
		#endregion
	}
}