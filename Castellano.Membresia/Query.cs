using System;
using System.Linq;
namespace Castellano.Membresia
{
    internal static class Query
    {
        #region Auditoria
        internal static IQueryable<Auditoria> GetAuditorias()
        {
            return
                from auditoria in Context.Instancia.Auditorias
                select auditoria;
        }

        internal static IQueryable<Auditoria> GetAuditorias(Persona persona, DateTime fecha)
        {
            return
                from auditoria in GetAuditorias()
                where auditoria.Usuario.Persona == persona && auditoria.Fecha.Date == fecha
                select auditoria;
        }
        #endregion

        #region Accion
        internal static IQueryable<Accion> GetAcciones()
        {
            return
                from accion in Context.Instancia.Acciones
                select accion;
        }

        internal static IQueryable<Accion> GetAcciones(MenuItem menuItem)
        {
            return
                from accion in GetAcciones()
                where (GetMenuItemAcciones(menuItem).Select<MenuItemAccion, Accion>(x => x.Accion).Contains<Accion>(accion))
                select accion;
        }
        #endregion

        #region Aplicacion
        internal static IQueryable<Aplicacion> GetAplicaciones()
        {
            return
                from aplicacion in Context.Instancia.Aplicaciones
                select aplicacion;
        }

        internal static IQueryable<Aplicacion> GetAplicaciones(Castellano.CentroCosto centroCosto)
        {
            return
                from centroCostoAplicacion in GetCentroCostoAplicaciones(centroCosto)
                select centroCostoAplicacion.Aplicacion;
        }

        internal static IQueryable<Aplicacion> GetAplicaciones(Castellano.Empresa empresa)
        {
            return
                from empresaAplicacion in GetEmpresaAplicaciones(empresa)
                select empresaAplicacion.Aplicacion;
        }

        internal static IQueryable<Aplicacion> GetAplicaciones(MenuItem menuItem)
        {
            return
                (
                from query in GetMenuItemes()
                where query == menuItem
                select query.Aplicacion
                );
        }

        internal static IQueryable<Aplicacion> GetAplicaciones(Persona persona)
        {
            return
                from aplicacion in GetAplicaciones()
                where
                (
                from rol in GetRolPersonas(persona).Select<RolPersona, Rol>(x => x.Rol)
                    .Union<Rol>(GetRolPersonaCentroCostos(persona).Select<RolPersonaCentroCosto, Rol>(x => x.Rol))
                    .Union<Rol>(GetRolPersonaEmpresas(persona).Select<RolPersonaEmpresa, Rol>(x => x.Rol))
                join rolAccion in GetRolAcciones() on rol equals rolAccion.Rol
                select rolAccion.MenuItemAccion.MenuItem.Aplicacion
                ).Contains<Aplicacion>(aplicacion)
                select aplicacion;
        }
        #endregion

        #region AplicacionPerfil
        internal static IQueryable<AplicacionPerfil> GetAplicacionPerfiles()
        {
            return
                from aplicacionPerfil in Context.Instancia.AplicacionPerfiles
                select aplicacionPerfil;
        }

        internal static IQueryable<AplicacionPerfil> GetAplicacionPerfiles(Aplicacion aplicacion)
        {
            return
                from aplicacionPerfil in GetAplicacionPerfiles()
                where (aplicacionPerfil.Aplicacion == aplicacion)
                select aplicacionPerfil;
        }
        #endregion

        #region CentroCosto
        internal static IQueryable<Castellano.CentroCosto> GetCentroCostos()
        {
            return
                from centroCostos in Context.Instancia.CentroCostos
                select centroCostos;
        }

        internal static IQueryable<Castellano.CentroCosto> GetCentroCostos(Persona persona, Castellano.Empresa empresa, Aplicacion aplicacion)
        {
            Castellano.Membresia.Rol apoderado = Castellano.Membresia.Rol.Apoderado;

            if (aplicacion.Clave == "apoderados")
            {
                return
                    from centroCosto in GetCentroCostos()
                    join rpc in GetRolPersonaCentroCostos(persona) on centroCosto equals rpc.CentroCosto
                    where rpc.Rol == apoderado &&
                    centroCosto.Empresa == empresa
                    && GetRolAcciones(aplicacion).Where<RolAccion>(x => x.Rol.Equals(apoderado)).Any<RolAccion>()
                    && GetCentroCostoAplicaciones(empresa, aplicacion).Select<CentroCostoAplicacion, Castellano.CentroCosto>(x => x.CentroCosto).Contains<Castellano.CentroCosto>(centroCosto)
                    &&
                    (
                    from item in
                        (from rolPersona in GetRolPersonas(persona) select rolPersona.Rol)
                        .Union<Rol>(from rolPersonaEmpresa in GetRolPersonaEmpresas(persona) where (rolPersonaEmpresa.Empresa == centroCosto.Empresa) select rolPersonaEmpresa.Rol)
                        .Union<Rol>(from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona) where (rolPersonaCentroCosto.CentroCosto == centroCosto) select rolPersonaCentroCosto.Rol)
                    select item
                    ).Any<Rol>()
                    select centroCosto;
            }
            else
            {
                if (Castellano.Membresia.RolPersonaCentroCosto.Exists(apoderado, persona))
                {
                    System.Collections.Generic.List<Castellano.CentroCosto> centrosCosto_apoderado = Castellano.Membresia.RolPersonaCentroCosto.GetAll(persona, empresa).Where<Castellano.Membresia.RolPersonaCentroCosto>(x => x.Rol.Clave == "apoderado" || x.Rol.Clave == "apoderado_academico" || x.Rol.Clave == "apoderado_delegado" || x.Rol.Clave == "apoderado_financiero").Select<Castellano.Membresia.RolPersonaCentroCosto, Castellano.CentroCosto>(x => x.CentroCosto).ToList<Castellano.CentroCosto>();
                    System.Collections.Generic.List<Castellano.CentroCosto> centrosCosto_acceso = Castellano.Membresia.RolPersonaCentroCosto.GetAll(persona, empresa).Where<Castellano.Membresia.RolPersonaCentroCosto>(x => x.Rol.Clave != "apoderado" && x.Rol.Clave != "apoderado_academico" && x.Rol.Clave != "apoderado_delegado" && x.Rol.Clave != "apoderado_financiero").Select<Castellano.Membresia.RolPersonaCentroCosto, Castellano.CentroCosto>(x => x.CentroCosto).ToList<Castellano.CentroCosto>();

                    if ((from cc_apoderado in centrosCosto_apoderado
                         join cc_acceso in centrosCosto_acceso on cc_apoderado equals cc_acceso
                         select cc_apoderado).Any())
                    {
                        return
                           from centroCosto in GetCentroCostos()
                           where centroCosto.Empresa == empresa
                           && GetRolAcciones(aplicacion).Any<RolAccion>()
                           && GetCentroCostoAplicaciones(empresa, aplicacion).Select<CentroCostoAplicacion, Castellano.CentroCosto>(x => x.CentroCosto).Contains<Castellano.CentroCosto>(centroCosto)
                           &&
                           (
                           from rol in
                               (from rolPersona in GetRolPersonas(persona) select rolPersona.Rol)
                               .Union<Rol>(from rolPersonaEmpresa in GetRolPersonaEmpresas(persona) where (rolPersonaEmpresa.Empresa == centroCosto.Empresa) select rolPersonaEmpresa.Rol)
                               .Union<Rol>(from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona) where (rolPersonaCentroCosto.CentroCosto == centroCosto) select rolPersonaCentroCosto.Rol)
                           select rol
                           ).Any<Rol>()
                           select centroCosto;
                    }
                    else
                    {
                        return
                           from centroCosto in GetCentroCostos()
                           join rpc in GetRolPersonaCentroCostos(persona) on centroCosto equals rpc.CentroCosto
                           where centroCosto.Empresa == empresa
                           && !GetRolPersonaCentroCostos(persona, empresa, apoderado).Select<Castellano.Membresia.RolPersonaCentroCosto, Castellano.CentroCosto>(x => x.CentroCosto).Contains<Castellano.CentroCosto>(centroCosto)
                           && GetRolAcciones(aplicacion).Any<RolAccion>()
                           && GetCentroCostoAplicaciones(empresa, aplicacion).Select<CentroCostoAplicacion, Castellano.CentroCosto>(x => x.CentroCosto).Contains<Castellano.CentroCosto>(centroCosto)
                           &&
                           (
                           from rol in
                               (from rolPersona in GetRolPersonas(persona) select rolPersona.Rol)
                               .Union<Rol>(from rolPersonaEmpresa in GetRolPersonaEmpresas(persona) where (rolPersonaEmpresa.Empresa == centroCosto.Empresa) select rolPersonaEmpresa.Rol)
                               .Union<Rol>(from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona) where (rolPersonaCentroCosto.CentroCosto == centroCosto) select rolPersonaCentroCosto.Rol)
                           select rol
                           ).Any<Rol>()
                           select centroCosto;
                    }
                }
                else
                {
                    return
                        from centroCosto in GetCentroCostos()
                        where centroCosto.Empresa == empresa
                        && GetRolAcciones(aplicacion).Any<RolAccion>()
                        && GetCentroCostoAplicaciones(empresa, aplicacion).Select<CentroCostoAplicacion, Castellano.CentroCosto>(x => x.CentroCosto).Contains<Castellano.CentroCosto>(centroCosto)
                        &&
                        (
                        from rol in
                            (from rolPersona in GetRolPersonas(persona) select rolPersona.Rol)
                            .Union<Rol>(from rolPersonaEmpresa in GetRolPersonaEmpresas(persona) where (rolPersonaEmpresa.Empresa == centroCosto.Empresa) select rolPersonaEmpresa.Rol)
                            .Union<Rol>(from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona) where (rolPersonaCentroCosto.CentroCosto == centroCosto) select rolPersonaCentroCosto.Rol)
                        select rol
                        ).Any<Rol>()
                        select centroCosto;
                }
            }
        }
        #endregion

        #region CentroCostoAplicacion
        internal static IQueryable<CentroCostoAplicacion> GetCentroCostoAplicaciones()
        {
            return
                from centroCostoAplicacion in Context.Instancia.CentroCostoAplicaciones
                select centroCostoAplicacion;
        }

        internal static IQueryable<CentroCostoAplicacion> GetCentroCostoAplicaciones(Castellano.CentroCosto centroCosto)
        {
            return
                from centroCostoAplicacion in GetCentroCostoAplicaciones()
                where centroCostoAplicacion.CentroCosto == centroCosto
                select centroCostoAplicacion;
        }

        internal static IQueryable<CentroCostoAplicacion> GetCentroCostoAplicaciones(Castellano.CentroCosto centroCosto, Aplicacion aplicacion)
        {
            return
                from centroCostoAplicacion in GetCentroCostoAplicaciones(centroCosto)
                where centroCostoAplicacion.Aplicacion == aplicacion
                select centroCostoAplicacion;
        }

        internal static IQueryable<CentroCostoAplicacion> GetCentroCostoAplicaciones(Castellano.Empresa empresa, Aplicacion aplicacion)
        {
            return
                from centroCostoAplicacion in GetCentroCostoAplicaciones()
                where centroCostoAplicacion.CentroCosto.Empresa == empresa &&
                      centroCostoAplicacion.Aplicacion == aplicacion
                select centroCostoAplicacion;
        }
        #endregion

        #region Empresa
        internal static IQueryable<Castellano.Empresa> GetEmpresas()
        {
            return
                from empresa in Context.Instancia.Empresas
                select empresa;
        }

        internal static IQueryable<Castellano.Empresa> GetEmpresas(Persona persona, Aplicacion aplicacion)
        {
            return
                from empresa in GetEmpresas()
                where GetEmpresaAplicaciones(aplicacion).Select<EmpresaAplicacion, Castellano.Empresa>(x => x.Empresa).Contains<Castellano.Empresa>(empresa) && !empresa.Bloqueada &&
                GetRolAcciones(aplicacion).Any<RolAccion>()
                &&
                (
                from rol in
                    (from rolPersona in GetRolPersonas(persona) select rolPersona.Rol)
                    .Union<Rol>(from rolPersonaEmpresa in GetRolPersonaEmpresas(persona) where (rolPersonaEmpresa.Empresa == empresa) select rolPersonaEmpresa.Rol)
                    .Union<Rol>(from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona) where (rolPersonaCentroCosto.Empresa == empresa) select rolPersonaCentroCosto.Rol)
                select rol
                ).Any<Rol>()
                select empresa;
        }

        internal static IQueryable<Castellano.Empresa> GetEmpresas(Rol rol)
        {
            return
               from empresa in GetEmpresas()
               where GetRolAcciones(rol).Any<RolAccion>()
               &&
               (
                   from rolPersonaEmpresas in GetRolPersonaEmpresas(rol)
                   select rolPersonaEmpresas.Empresa
               ).Contains<Castellano.Empresa>(empresa)
               select empresa;
        }
        #endregion

        #region EmpresaAplicacion
        internal static IQueryable<EmpresaAplicacion> GetEmpresaAplicaciones()
        {
            return
                from empresaAplicacion in Context.Instancia.EmpresaAplicaciones
                select empresaAplicacion;
        }

        internal static IQueryable<EmpresaAplicacion> GetEmpresaAplicaciones(Aplicacion aplicacion)
        {
            return
                from empresaAplicacion in GetEmpresaAplicaciones()
                where empresaAplicacion.Aplicacion == aplicacion
                select empresaAplicacion;
        }

        internal static IQueryable<EmpresaAplicacion> GetEmpresaAplicaciones(Castellano.Empresa empresa)
        {
            return
                from empresaAplicacion in GetEmpresaAplicaciones()
                where empresaAplicacion.Empresa == empresa
                select empresaAplicacion;
        }

        internal static IQueryable<EmpresaAplicacion> GetEmpresaAplicaciones(Castellano.Empresa empresa, Aplicacion aplicacion)
        {
            return
                from empresaAplicacion in GetEmpresaAplicaciones(empresa)
                where empresaAplicacion.Aplicacion == aplicacion
                select empresaAplicacion;
        }
        #endregion

        #region Menu
        internal static IQueryable<Menu> GetMenus()
        {
            return
                from menu in Context.Instancia.Menus
                select menu;
        }
        #endregion

        #region MenuItem
        internal static IQueryable<MenuItem> GetMenuItemes()
        {
            return
                from menuItem in Context.Instancia.MenuItemes
                select menuItem;
        }

        internal static IQueryable<MenuItem> GetMenuItemes(Menu menu)
        {
            return
                from menuItem in GetMenuItemes()
                where menuItem.Menu == menu
                select menuItem;
        }

        internal static IQueryable<MenuItem> GetMenuItemes(Menu menu, Aplicacion aplicacion)
        {
            return
                from menuItem in GetMenuItemes(menu)
                where menuItem.Aplicacion == aplicacion
                select menuItem;
        }

        internal static IQueryable<MenuItem> GetMenuItemes(Menu menu, Aplicacion aplicacion, Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Persona persona)
        {
            return
                from menuItem in GetMenuItemes(menu, aplicacion)
                where
                (
                    from rol in GetRolPersonas(persona).Select<RolPersona, Rol>(x => x.Rol)
                        .Union<Rol>(GetRolPersonaCentroCostos(persona).Select<RolPersonaCentroCosto, Rol>(x => x.Rol))
                        .Union<Rol>(GetRolPersonaEmpresas(persona).Select<RolPersonaEmpresa, Rol>(x => x.Rol))
                    join rolAccion in GetRolAcciones() on rol equals rolAccion.Rol
                    select rolAccion.MenuItemAccion.MenuItem
                ).Contains<MenuItem>(menuItem)
                select menuItem;

        }

        internal static IQueryable<MenuItem> GetMenuItemes(Menu menu, bool publico)
        {
            return
                from menuItem in GetMenuItemes(menu)
                select menuItem;
        }

        internal static IQueryable<MenuItem> GetMenuItemes(Persona persona)
        {
            return
                from menuItem in GetMenuItemes()
                where GetMenuItemAcciones(persona).Select<MenuItemAccion, MenuItem>(x => x.MenuItem).Contains<MenuItem>(menuItem)
                select menuItem;
        }
        #endregion

        #region MenuItemAccion
        internal static IQueryable<MenuItemAccion> GetMenuItemAcciones()
        {
            return
                from menuItemAccion in Context.Instancia.MenuItemAcciones
                select menuItemAccion;
        }

        internal static IQueryable<MenuItemAccion> GetMenuItemAcciones(MenuItem menuItem)
        {
            return
                from menuItemAccion in GetMenuItemAcciones()
                where menuItemAccion.MenuItem == menuItem
                select menuItemAccion;
        }

        internal static IQueryable<MenuItemAccion> GetMenuItemAcciones(Persona persona)
        {
            return
                from menuItemAccion in GetMenuItemAcciones()
                where (GetRolAcciones(persona).Select<RolAccion, MenuItemAccion>(x => x.MenuItemAccion).Contains<MenuItemAccion>(menuItemAccion))
                select menuItemAccion;
        }
        #endregion

        #region Perfil
        internal static IQueryable<Perfil> GetPerfiles()
        {
            return
                from perfil in Context.Instancia.Perfiles
                select perfil;
        }

        internal static IQueryable<Perfil> GetPerfiles(Aplicacion aplicacion)
        {
            return
                from aplicacionPerfil in GetAplicacionPerfiles()
                where aplicacionPerfil.Aplicacion == aplicacion
                select aplicacionPerfil.Perfil;
        }
        #endregion

        #region PerfilUsuario
        internal static IQueryable<PerfilUsuario> GetPerfilUsuarios()
        {
            return
                from perfilUsuario in Context.Instancia.PerfilUsuarios
                select perfilUsuario;
        }
        #endregion

        #region Rol
        internal static IQueryable<Rol> GetRoles()
        {
            return
                from rol in Context.Instancia.Roles
                select rol;
        }

        internal static IQueryable<Rol> GetRoles(Aplicacion aplicacion)
        {
            return
                from rol in GetRoles()
                where GetRolAcciones(aplicacion).Select<RolAccion, Rol>(x => x.Rol).Contains(rol)
                select rol;
        }

        internal static IQueryable<Rol> GetRoles(Castellano.Ambito ambito, Aplicacion aplicacion, bool showProtected)
        {
            return
                from rol in GetRoles(aplicacion)
                where GetRoles(ambito, showProtected).Contains<Rol>(rol)
                select rol;
        }

        internal static IQueryable<Rol> GetRoles(Castellano.Ambito ambito, bool showProtected)
        {
            switch (showProtected)
            {
                case true: return from rol in GetRoles() where rol.Ambito == ambito select rol;
                case false: return from rol in GetRoles() where rol.Ambito == ambito && rol.Clave == null select rol;
            }

            return null;
        }

        internal static IQueryable<Rol> GetRoles(Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Persona persona)
        {
            IQueryable<Rol> rolPersonas = GetRolPersonas(persona).Select<RolPersona, Rol>(x => x.Rol);
            IQueryable<Rol> rolPersonaCentroCostos = centroCosto == null ? GetRolPersonaCentroCostos(persona).Select<RolPersonaCentroCosto, Rol>(x => x.Rol) : GetRolPersonaCentroCostos(persona, centroCosto).Select<RolPersonaCentroCosto, Rol>(x => x.Rol);
            IQueryable<Rol> rolPersonaEmpresas = GetRolPersonaEmpresas(persona, empresa).Select<RolPersonaEmpresa, Rol>(x => x.Rol);

            return
                rolPersonas
                .Union<Rol>(rolPersonaCentroCostos)
                .Union<Rol>(rolPersonaEmpresas);
        }

        internal static IQueryable<Rol> GetRoles(Persona persona)
        {
            return
                from rol in GetRoles()
                where
                (
                GetRolPersonas(persona).Select<RolPersona, Rol>(x => x.Rol).Contains<Rol>(rol)
                ||
                GetRolPersonaCentroCostos(persona).Select<RolPersonaCentroCosto, Rol>(x => x.Rol).Contains<Rol>(rol)
                ||
                GetRolPersonaEmpresas(persona).Select<RolPersonaEmpresa, Rol>(x => x.Rol).Contains<Rol>(rol)
                )
                select rol;
        }

        internal static IQueryable<Rol> GetRoles(Persona persona, Aplicacion aplicacion)
        {
            return
                from rol in GetRoles(persona)
                where GetRolAcciones(aplicacion).Select<RolAccion, Rol>(x => x.Rol).Contains<Rol>(rol)
                select rol;
        }

        internal static IQueryable<Rol> GetRoles(Persona persona, Castellano.Empresa empresa)
        {
            return
                from rol in
                    (from rolPersona in GetRolPersonas(persona) select rolPersona.Rol)
                     .Union<Rol>(from rolPersonaEmpresa in GetRolPersonaEmpresas(persona) where (rolPersonaEmpresa.Empresa == empresa) select rolPersonaEmpresa.Rol)
                     .Union<Rol>(from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona) where (rolPersonaCentroCosto.Empresa == empresa) select rolPersonaCentroCosto.Rol)
                select rol;
        }
        #endregion

        #region RolAccion
        internal static IQueryable<RolAccion> GetRolAcciones()
        {
            return
                from rolAccion in Context.Instancia.RolAcciones
                select rolAccion;
        }

        internal static IQueryable<RolAccion> GetRolAcciones(Aplicacion aplicacion)
        {
            return
                from rolAccion in GetRolAcciones()
                where rolAccion.MenuItemAccion.MenuItem.Aplicacion == aplicacion
                select rolAccion;
        }

        internal static IQueryable<RolAccion> GetRolAcciones(Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Persona persona)
        {
            return
                from rolAccion in GetRolAcciones()
                where GetRoles(empresa, centroCosto, persona).Contains<Rol>(rolAccion.Rol)
                select rolAccion;
        }

        internal static IQueryable<RolAccion> GetRolAcciones(Castellano.Empresa empresa, Castellano.CentroCosto centroCosto, Persona persona, MenuItem menuItem)
        {
            return
                from rolAccion in GetRolAcciones(empresa, centroCosto, persona)
                where rolAccion.MenuItemAccion.MenuItem == menuItem
                select rolAccion;
        }

        internal static IQueryable<RolAccion> GetRolAcciones(Persona persona)
        {
            return
                from rolAccion in GetRolAcciones()
                where GetRoles(persona).Contains<Rol>(rolAccion.Rol)
                select rolAccion;
        }

        internal static IQueryable<RolAccion> GetRolAcciones(Rol rol)
        {
            return
                from rolAccion in GetRolAcciones()
                where rolAccion.Rol == rol
                select rolAccion;
        }
        #endregion

        #region RolPersona
        internal static IQueryable<RolPersona> GetRolPersonas()
        {
            return
                from rolPersona in Context.Instancia.RolPersonas
                select rolPersona;
        }

        internal static IQueryable<RolPersona> GetRolPersonas(Persona persona)
        {
            return
                from rolPersona in GetRolPersonas()
                where rolPersona.Persona == persona
                select rolPersona;
        }

        internal static IQueryable<RolPersona> GetRolPersonas(Persona persona, Aplicacion aplicacion)
        {
            return
                from rolPersona in GetRolPersonas(persona)
                where
                (
                from rol in GetRoles()
                join rolAccion in GetRolAcciones() on rol equals rolAccion.Rol
                where rolAccion.MenuItemAccion.MenuItem.Aplicacion == aplicacion
                select rol
                ).Contains<Rol>(rolPersona.Rol)
                select rolPersona;
        }
        #endregion

        #region RolPersonaCentroCosto
        internal static IQueryable<RolPersonaCentroCosto> GetRolPersonaCentroCostos()
        {
            return
                from rolPersonaCentroCosto in Context.Instancia.RolPersonaCentroCostos
                select rolPersonaCentroCosto;
        }

        internal static IQueryable<RolPersonaCentroCosto> GetRolPersonaCentroCostos(Persona persona)
        {
            return
                from rolPersonaCentroCosto in GetRolPersonaCentroCostos()
                where (rolPersonaCentroCosto.Persona == persona) &&
                      (!rolPersonaCentroCosto.CentroCosto.Empresa.Bloqueada)
                select rolPersonaCentroCosto;
        }

        internal static IQueryable<RolPersonaCentroCosto> GetRolPersonaCentroCostos(Persona persona, Aplicacion aplicacion, Castellano.CentroCosto centroCosto)
        {
            return
                from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona, centroCosto)
                where
                (
                from rol in GetRoles()
                join rolAccion in GetRolAcciones() on rol equals rolAccion.Rol
                where rolAccion.MenuItemAccion.MenuItem.Aplicacion == aplicacion
                select rol
                ).Contains<Rol>(rolPersonaCentroCosto.Rol)
                select rolPersonaCentroCosto;
        }

        internal static IQueryable<RolPersonaCentroCosto> GetRolPersonaCentroCostos(Persona persona, Castellano.CentroCosto centroCosto)
        {
            return
                from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona)
                where rolPersonaCentroCosto.CentroCosto == centroCosto
                select rolPersonaCentroCosto;
        }

        internal static IQueryable<RolPersonaCentroCosto> GetRolPersonaCentroCostos(Persona persona, Castellano.Empresa empresa)
        {
            return
                from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona)
                where rolPersonaCentroCosto.CentroCosto.Empresa == empresa
                select rolPersonaCentroCosto;
        }

        internal static IQueryable<RolPersonaCentroCosto> GetRolPersonaCentroCostos(Persona persona, Castellano.Empresa empresa, Rol rol)
        {
            return
                from rolPersonaCentroCosto in GetRolPersonaCentroCostos(persona, empresa)
                where rolPersonaCentroCosto.Rol == rol
                select rolPersonaCentroCosto;
        }
        #endregion

        #region RolPersonaEmpresa
        internal static IQueryable<RolPersonaEmpresa> GetRolPersonaEmpresas()
        {
            return
                from rolPersonaEmpresa in Context.Instancia.RolPersonaEmpresas
                select rolPersonaEmpresa;
        }

        internal static IQueryable<RolPersonaEmpresa> GetRolPersonaEmpresas(Persona persona)
        {
            return
                from rolPersonaEmpresa in GetRolPersonaEmpresas()
                where (rolPersonaEmpresa.Persona == persona) &&
                      (!rolPersonaEmpresa.Empresa.Bloqueada)
                select rolPersonaEmpresa;
        }

        internal static IQueryable<RolPersonaEmpresa> GetRolPersonaEmpresas(Persona persona, Castellano.Empresa empresa)
        {
            return
                from rolPersonaEmpresa in GetRolPersonaEmpresas(persona)
                where (rolPersonaEmpresa.Empresa == empresa)
                select rolPersonaEmpresa;
        }

        internal static IQueryable<RolPersonaEmpresa> GetRolPersonaEmpresas(Persona persona, Aplicacion aplicacion, Castellano.Empresa empresa)
        {
            return
                from rolPersonaEmpresa in GetRolPersonaEmpresas(persona, empresa)
                where
                (
                from rol in GetRoles()
                join rolAccion in GetRolAcciones() on rol equals rolAccion.Rol
                where rolAccion.MenuItemAccion.MenuItem.Aplicacion == aplicacion
                select rol
                ).Contains<Rol>(rolPersonaEmpresa.Rol)
                select rolPersonaEmpresa;
        }

        internal static IQueryable<RolPersonaEmpresa> GetRolPersonaEmpresas(Rol rol)
        {
            return
               from rolPersonaEmpresa in GetRolPersonaEmpresas()
               where rolPersonaEmpresa.Rol == rol
               select rolPersonaEmpresa;
        }
        #endregion

        #region Suscripcion
        internal static IQueryable<Suscripcion> GetSuscripciones()
        {
            return
                from suscripcion in Context.Instancia.Suscripciones
                select suscripcion;
        }

        internal static IQueryable<Suscripcion> GetSuscripciones(Aplicacion aplicacion)
        {
            return
               from suscripcion in GetSuscripciones()
               where suscripcion.Aplicacion == aplicacion
               select suscripcion;
        }

        internal static IQueryable<Suscripcion> GetSuscripciones(Aplicacion aplicacion, Usuario usuario)
        {
            return
               from suscripcion in GetSuscripciones(aplicacion)
               where suscripcion.Usuario == usuario
               select suscripcion;
        }
        #endregion

        #region Usuario
        internal static IQueryable<Usuario> GetUsuarios()
        {
            return
                from usuario in Context.Instancia.Usuarios
                select usuario;
        }

        internal static IQueryable<Usuario> GetUsuarios(FindType findType, string filter)
        {
            switch (findType)
            {
                case FindType.StartsWith: return from usuario in GetUsuarios() where (usuario.Persona.Nombre.StartsWith(filter)) select usuario;
                case FindType.Contains: return from usuario in GetUsuarios() where (usuario.Persona.Nombre.Contains(filter)) select usuario;
                case FindType.EndsWith: return from usuario in GetUsuarios() where (usuario.Persona.Nombre.EndsWith(filter)) select usuario;
                default: return from usuario in GetUsuarios() where (usuario.Persona.Nombre == filter) select usuario;
            }
        }
        #endregion
    }
}