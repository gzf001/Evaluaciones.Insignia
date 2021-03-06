using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano.Membresia
{
	public partial class RolPersonaCentroCosto
	{
		public static bool Exists(Rol rol, Persona persona)
		{
			return Query.GetRolPersonaCentroCostos().Any<RolPersonaCentroCosto>(x => x.Rol == rol && x.Persona == persona);
		}

		public static bool Exists(Rol rol, Persona persona, Castellano.CentroCosto centroCosto)
		{
			return Query.GetRolPersonaCentroCostos().Any<RolPersonaCentroCosto>(x => x.Rol == rol && x.Persona == persona && x.CentroCosto == centroCosto);
		}

		public static RolPersonaCentroCosto Get(Guid rolId, Guid personaId, Guid empresaId, Guid centroCostoId)
		{
			return Query.GetRolPersonaCentroCostos().SingleOrDefault<RolPersonaCentroCosto>(x => x.RolId == rolId && x.PersonaId == personaId && x.EmpresaId == empresaId && x.CentroCostoId == centroCostoId);
		}

		public static RolPersonaCentroCosto Get(Rol rol, Persona persona, Castellano.CentroCosto centroCosto)
		{
			return Query.GetRolPersonaCentroCostos().SingleOrDefault<RolPersonaCentroCosto>(x => x.Rol == rol && x.Persona == persona && x.CentroCosto == centroCosto);
		}

		public static List<RolPersonaCentroCosto> GetAll()
		{
			return
				(
				from query in Query.GetRolPersonaCentroCostos()
				select query
				).ToList<RolPersonaCentroCosto>();
		}

		public static List<RolPersonaCentroCosto> GetAll(Persona persona, Castellano.Empresa empresa)
		{
			return
				(
				from query in Query.GetRolPersonaCentroCostos(persona, empresa)
				select query
				).ToList<RolPersonaCentroCosto>();
		}
	}
}