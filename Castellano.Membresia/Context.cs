using System;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using FluentLinqToSql;
namespace Castellano.Membresia
{
	public partial class Context : Castellano.Context
	{
		private static readonly MappingSource mappingSource;
		private static Context instancia;

		#region Singleton
		public new static Context Instancia
		{
			get
			{
				if (HostingEnvironment.IsHosted)
				{
					if (HttpContext.Current.Items["Membresia_Context"] == null)
					{
						HttpContext.Current.Items["Membresia_Context"] = new Context();
					}

					return (Context)HttpContext.Current.Items["Membresia_Context"];
				}
				else
				{
					if (instancia == null) instancia = new Context { DeferredLoadingEnabled = true };

					return instancia;
				}
			}
		}
		#endregion

		static Context()
		{
			mappingSource = new FluentMappingSource("Castellano")
				.AddFromAssemblyContaining<Castellano.Context>()
				.AddFromAssemblyContaining<Castellano.Membresia.Context>()
				.CreateMappingSource();

			instancia = new Context
			{
				DeferredLoadingEnabled = true
			};
		}

		public Context() : base(mappingSource) { }

		public Context(MappingSource mappingSource) : base(mappingSource) { }

		public override void SubmitChanges(ConflictMode failureMode)
		{
			base.SubmitChanges(failureMode);

			if (HostingEnvironment.IsHosted) HttpContext.Current.Items["Membresia_Context"] = null;
			else Context.instancia = null;
		}

		#region Tables
		public Table<Castellano.Membresia.Accion> Acciones
		{
			get { return this.GetTable<Castellano.Membresia.Accion>(); }
		}

		public Table<Castellano.Membresia.Aplicacion> Aplicaciones
		{
			get { return this.GetTable<Castellano.Membresia.Aplicacion>(); }
		}

		public Table<Castellano.Membresia.AplicacionPerfil> AplicacionPerfiles
		{
			get { return this.GetTable<Castellano.Membresia.AplicacionPerfil>(); }
		}

		public Table<Castellano.Membresia.Auditoria> Auditorias
		{
			get { return this.GetTable<Castellano.Membresia.Auditoria>(); }
		}

		public Table<Castellano.Membresia.CentroCostoAplicacion> CentroCostoAplicaciones
		{
			get { return this.GetTable<Castellano.Membresia.CentroCostoAplicacion>(); }
		}

		public Table<Castellano.Membresia.EmpresaAplicacion> EmpresaAplicaciones
		{
			get { return this.GetTable<Castellano.Membresia.EmpresaAplicacion>(); }
		}

		public Table<Castellano.Membresia.Menu> Menus
		{
			get { return this.GetTable<Castellano.Membresia.Menu>(); }
		}

		public Table<Castellano.Membresia.MenuItem> MenuItemes
		{
			get { return this.GetTable<Castellano.Membresia.MenuItem>(); }
		}

		public Table<Castellano.Membresia.MenuItemAccion> MenuItemAcciones
		{
			get { return this.GetTable<Castellano.Membresia.MenuItemAccion>(); }
		}

		public Table<Castellano.Membresia.Perfil> Perfiles
		{
			get { return this.GetTable<Castellano.Membresia.Perfil>(); }
		}

		public Table<Castellano.Membresia.PerfilUsuario> PerfilUsuarios
		{
			get { return this.GetTable<Castellano.Membresia.PerfilUsuario>(); }
		}

		public Table<Castellano.Membresia.Rol> Roles
		{
			get { return this.GetTable<Castellano.Membresia.Rol>(); }
		}

		public Table<Castellano.Membresia.RolAccion> RolAcciones
		{
			get { return this.GetTable<Castellano.Membresia.RolAccion>(); }
		}

		public Table<Castellano.Membresia.RolPersona> RolPersonas
		{
			get { return this.GetTable<Castellano.Membresia.RolPersona>(); }
		}

		public Table<Castellano.Membresia.RolPersonaCentroCosto> RolPersonaCentroCostos
		{
			get { return this.GetTable<Castellano.Membresia.RolPersonaCentroCosto>(); }
		}

		public Table<Castellano.Membresia.RolPersonaEmpresa> RolPersonaEmpresas
		{
			get { return this.GetTable<Castellano.Membresia.RolPersonaEmpresa>(); }
		}

		public Table<Castellano.Membresia.Suscripcion> Suscripciones
		{
			get { return this.GetTable<Castellano.Membresia.Suscripcion>(); }
		}

		public Table<Castellano.Membresia.Usuario> Usuarios
		{
			get { return this.GetTable<Castellano.Membresia.Usuario>(); }
		}
		#endregion

		#region Views
		#endregion

		#region StoredProcedures
		public int SetRolByPersona(Guid personaId)
		{
            string comando = string.Format("EXEC Membresia.SetRolByPersona @PersonaId = '{0}'", personaId);
			
            return this.ExecuteCommand(comando);
		}
		#endregion

		#region Functions
		#endregion

		#region Configuracion
		public class AccionConfiguration : Mapping<Castellano.Membresia.Accion>
		{
			public AccionConfiguration()
			{
				this.Named("Membresia.Accion");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class AplicacionConfiguration : Mapping<Castellano.Membresia.Aplicacion>
		{
			public AplicacionConfiguration()
			{
				this.Named("Membresia.Aplicacion");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Nullable<Guid>>(x => x.MenuId).Named("MenuId").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.MenuItemId).Named("MenuItemId").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Clave).Named("Clave").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Byte>(x => x.Orden).Named("Orden").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Membresia.MenuItem>(x => x.Inicio).ThisKey("Id,MenuId,MenuItemId").OtherKey("AplicacionId,MenuId,Id").Storage("inicio");
			}
		}

		public class AplicacionPerfilConfiguration : Mapping<Castellano.Membresia.AplicacionPerfil>
		{
			public AplicacionPerfilConfiguration()
			{
				this.Named("Membresia.AplicacionPerfil");

				this.Map<Guid>(x => x.AplicacionId).Named("AplicacionId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.PerfilId).Named("PerfilId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.Membresia.Aplicacion>(x => x.Aplicacion).ThisKey("AplicacionId").OtherKey("Id").Storage("aplicacion");
				this.HasOne<Castellano.Membresia.Perfil>(x => x.Perfil).ThisKey("PerfilId").OtherKey("Id").Storage("perfil");
			}
		}

		public class AuditoriaConfiguration : Mapping<Castellano.Membresia.Auditoria>
		{
			public AuditoriaConfiguration()
			{
				this.Named("Membresia.Auditoria");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.UsuarioId).Named("UsuarioId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.AplicacionId).Named("AplicacionId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.MenuId).Named("MenuId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.MenuItemId).Named("MenuItemId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Actividad).Named("Actividad").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<DateTime>(x => x.Fecha).Named("Fecha").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Membresia.Aplicacion>(x => x.Aplicacion).ThisKey("AplicacionId").OtherKey("Id").Storage("aplicacion");
				this.HasOne<Castellano.Membresia.MenuItem>(x => x.MenuItem).ThisKey("AplicacionId,MenuId,MenuItemId").OtherKey("AplicacionId,MenuId,Id").Storage("menuItem");
				this.HasOne<Castellano.Membresia.Usuario>(x => x.Usuario).ThisKey("UsuarioId").OtherKey("Id").Storage("usuario");
			}
		}

		public class CentroCostoAplicacionConfiguration : Mapping<Castellano.Membresia.CentroCostoAplicacion>
		{
			public CentroCostoAplicacionConfiguration()
			{
				this.Named("Membresia.CentroCostoAplicacion");

				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.CentroCostoId).Named("CentroCostoId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.AplicacionId).Named("AplicacionId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.Membresia.Aplicacion>(x => x.Aplicacion).ThisKey("AplicacionId").OtherKey("Id").Storage("aplicacion");
				this.HasOne<Castellano.CentroCosto>(x => x.CentroCosto).ThisKey("EmpresaId,CentroCostoId").OtherKey("EmpresaId,Id").Storage("centroCosto");
				this.HasOne<Castellano.Membresia.EmpresaAplicacion>(x => x.EmpresaAplicacion).ThisKey("EmpresaId,AplicacionId").OtherKey("EmpresaId,AplicacionId").Storage("empresaAplicacion");
			}
		}

		public class EmpresaAplicacionConfiguration : Mapping<Castellano.Membresia.EmpresaAplicacion>
		{
			public EmpresaAplicacionConfiguration()
			{
				this.Named("Membresia.EmpresaAplicacion");

				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.AplicacionId).Named("AplicacionId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.Membresia.Aplicacion>(x => x.Aplicacion).ThisKey("AplicacionId").OtherKey("Id").Storage("aplicacion");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
			}
		}

		public class MenuConfiguration : Mapping<Castellano.Membresia.Menu>
		{
			public MenuConfiguration()
			{
				this.Named("Membresia.Menu");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Clave).Named("Clave").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class MenuItemConfiguration : Mapping<Castellano.Membresia.MenuItem>
		{
			public MenuItemConfiguration()
			{
				this.Named("Membresia.MenuItem");

				this.Map<Guid>(x => x.AplicacionId).Named("AplicacionId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.MenuId).Named("MenuId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Nullable<Guid>>(x => x.MenuItemId).Named("MenuItemId").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Informacion).Named("Informacion").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Icono).Named("Icono").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Url).Named("Url").UpdateCheck(UpdateCheck.Never);
				this.Map<Boolean>(x => x.Visible).Named("Visible").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.MuestraMenus).Named("MuestraMenus").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Int32>(x => x.Orden).Named("Orden").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Membresia.Aplicacion>(x => x.Aplicacion).ThisKey("AplicacionId").OtherKey("Id").Storage("aplicacion");
				this.HasOne<Castellano.Membresia.Menu>(x => x.Menu).ThisKey("MenuId").OtherKey("Id").Storage("menu");
				this.HasOne<Castellano.Membresia.MenuItem>(x => x.Padre).ThisKey("AplicacionId,MenuId,MenuItemId").OtherKey("AplicacionId,MenuId,Id").Storage("padre");
			}
		}

		public class MenuItemAccionConfiguration : Mapping<Castellano.Membresia.MenuItemAccion>
		{
			public MenuItemAccionConfiguration()
			{
				this.Named("Membresia.MenuItemAccion");

				this.Map<Guid>(x => x.AplicacionId).Named("AplicacionId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.MenuId).Named("MenuId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.MenuItemId).Named("MenuItemId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.AccionCodigo).Named("AccionCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.Membresia.Accion>(x => x.Accion).ThisKey("AccionCodigo").OtherKey("Codigo").Storage("accion");
				this.HasOne<Castellano.Membresia.MenuItem>(x => x.MenuItem).ThisKey("AplicacionId,MenuId,MenuItemId").OtherKey("AplicacionId,MenuId,Id").Storage("menuItem");
			}
		}

		public class PerfilConfiguration : Mapping<Castellano.Membresia.Perfil>
		{
			public PerfilConfiguration()
			{
				this.Named("Membresia.Perfil");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Clave).Named("Clave").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class PerfilUsuarioConfiguration : Mapping<Castellano.Membresia.PerfilUsuario>
		{
			public PerfilUsuarioConfiguration()
			{
				this.Named("Membresia.PerfilUsuario");

				this.Map<Guid>(x => x.PerfilId).Named("PerfilId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.UsuarioId).Named("UsuarioId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Valor).Named("Valor").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Membresia.Perfil>(x => x.Perfil).ThisKey("PerfilId").OtherKey("Id").Storage("perfil");
				this.HasOne<Castellano.Membresia.Usuario>(x => x.Usuario).ThisKey("UsuarioId").OtherKey("Id").Storage("usuario");
			}
		}

		public class RolConfiguration : Mapping<Castellano.Membresia.Rol>
		{
			public RolConfiguration()
			{
				this.Named("Membresia.Rol");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.AmbitoCodigo).Named("AmbitoCodigo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Clave).Named("Clave").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Ambito>(x => x.Ambito).ThisKey("AmbitoCodigo").OtherKey("Codigo").Storage("ambito");
			}
		}

		public class RolAccionConfiguration : Mapping<Castellano.Membresia.RolAccion>
		{
			public RolAccionConfiguration()
			{
				this.Named("Membresia.RolAccion");

				this.Map<Guid>(x => x.RolId).Named("RolId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.AplicacionId).Named("AplicacionId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.MenuId).Named("MenuId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.MenuItemId).Named("MenuItemId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.AccionCodigo).Named("AccionCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.Membresia.MenuItemAccion>(x => x.MenuItemAccion).ThisKey("AplicacionId,MenuId,MenuItemId,AccionCodigo").OtherKey("AplicacionId,MenuId,MenuItemId,AccionCodigo").Storage("menuItemAccion");
				this.HasOne<Castellano.Membresia.Rol>(x => x.Rol).ThisKey("RolId").OtherKey("Id").Storage("rol");
			}
		}

		public class RolPersonaConfiguration : Mapping<Castellano.Membresia.RolPersona>
		{
			public RolPersonaConfiguration()
			{
				this.Named("Membresia.RolPersona");

				this.Map<Guid>(x => x.RolId).Named("RolId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.PersonaId).Named("PersonaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.Persona>(x => x.Persona).ThisKey("PersonaId").OtherKey("Id").Storage("persona");
				this.HasOne<Castellano.Membresia.Rol>(x => x.Rol).ThisKey("RolId").OtherKey("Id").Storage("rol");
			}
		}

		public class RolPersonaCentroCostoConfiguration : Mapping<Castellano.Membresia.RolPersonaCentroCosto>
		{
			public RolPersonaCentroCostoConfiguration()
			{
				this.Named("Membresia.RolPersonaCentroCosto");

				this.Map<Guid>(x => x.RolId).Named("RolId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.PersonaId).Named("PersonaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.CentroCostoId).Named("CentroCostoId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.CentroCosto>(x => x.CentroCosto).ThisKey("EmpresaId,CentroCostoId").OtherKey("EmpresaId,Id").Storage("centroCosto");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
				this.HasOne<Castellano.Persona>(x => x.Persona).ThisKey("PersonaId").OtherKey("Id").Storage("persona");
				this.HasOne<Castellano.Membresia.Rol>(x => x.Rol).ThisKey("RolId").OtherKey("Id").Storage("rol");
			}
		}

		public class RolPersonaEmpresaConfiguration : Mapping<Castellano.Membresia.RolPersonaEmpresa>
		{
			public RolPersonaEmpresaConfiguration()
			{
				this.Named("Membresia.RolPersonaEmpresa");

				this.Map<Guid>(x => x.RolId).Named("RolId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.PersonaId).Named("PersonaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
				this.HasOne<Castellano.Persona>(x => x.Persona).ThisKey("PersonaId").OtherKey("Id").Storage("persona");
				this.HasOne<Castellano.Membresia.Rol>(x => x.Rol).ThisKey("RolId").OtherKey("Id").Storage("rol");
			}
		}

		public class SuscripcionConfiguration : Mapping<Castellano.Membresia.Suscripcion>
		{
			public SuscripcionConfiguration()
			{
				this.Named("Membresia.Suscripcion");

				this.Map<Guid>(x => x.AplicacionId).Named("AplicacionId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.UsuarioId).Named("UsuarioId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.URI).Named("URI").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Membresia.Aplicacion>(x => x.Aplicacion).ThisKey("AplicacionId").OtherKey("Id").Storage("aplicacion");
				this.HasOne<Castellano.Membresia.Usuario>(x => x.Usuario).ThisKey("UsuarioId").OtherKey("Id").Storage("usuario");
			}
		}

		public class UsuarioConfiguration : Mapping<Castellano.Membresia.Usuario>
		{
			public UsuarioConfiguration()
			{
				this.Named("Membresia.Usuario");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Password).Named("Password").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Aprobado).Named("Aprobado").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Bloqueado).Named("Bloqueado").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<DateTime>(x => x.Creacion).Named("Creacion").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<DateTime>(x => x.UltimaActividad).Named("UltimaActividad").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<DateTime>(x => x.UltimoAcceso).Named("UltimoAcceso").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<DateTime>>(x => x.UltimoCambioPassword).Named("UltimoCambioPassword").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<DateTime>>(x => x.UltimoDesbloqueo).Named("UltimoDesbloqueo").UpdateCheck(UpdateCheck.Never);
				this.Map<Int16>(x => x.NumeroIntentosFallidos).Named("NumeroIntentosFallidos").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<DateTime>>(x => x.FechaIntentoFallido).Named("FechaIntentoFallido").UpdateCheck(UpdateCheck.Never);
				this.Map<Boolean>(x => x.AperturaPeriodoRemuneracion).Named("AperturaPeriodoRemuneracion").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Persona>(x => x.Persona).ThisKey("Id").OtherKey("Id").Storage("persona");
			}
		}
		#endregion
	}
}