using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class RolPersonaEmpresa
	{
		public static bool Exists(Rol rol, Castellano.Persona persona, Castellano.Empresa empresa)
		{
			return Query.GetRolPersonaEmpresas(persona, empresa).Any<RolPersonaEmpresa>(x => x.Rol == rol);
		}

		public static RolPersonaEmpresa Get(Guid rolId, Guid personaId, Guid empresaId)
		{
			return Query.GetRolPersonaEmpresas().SingleOrDefault<RolPersonaEmpresa>(x => x.RolId == rolId && x.PersonaId == personaId && x.EmpresaId == empresaId);
		}

		public static RolPersonaEmpresa Get(Rol rol, Persona persona, Castellano.Empresa empresa)
		{
			return Query.GetRolPersonaEmpresas().SingleOrDefault<RolPersonaEmpresa>(x => x.Rol == rol && x.Persona == persona && x.Empresa == empresa);
		}

		public static List<RolPersonaEmpresa> GetAll()
		{
			return
				(
				from query in Query.GetRolPersonaEmpresas()
				select query
				).ToList<RolPersonaEmpresa>();
		}

		public static List<RolPersonaEmpresa> GetAll(Persona persona, Castellano.Empresa empresa)
		{
			return
				(
				from query in Query.GetRolPersonaEmpresas(persona, empresa)
				select query
				).ToList<RolPersonaEmpresa>();
		}
	}
}