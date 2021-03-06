using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Persona
	{
		public int? Edad
		{
			get
			{
				Persona persona = Persona.Get(this.Id);

				if (persona != null)
				{
					try
					{
						if (persona.FechaNacimiento.HasValue)
						{
							return  persona.FechaNacimiento.Value.Month > DateTime.Today.Month ? DateTime.Today.Year - (persona.FechaNacimiento.Value.Year - 1) : (DateTime.Today.Month.Equals(persona.FechaNacimiento.Value.Month) && persona.FechaNacimiento.Value.Day > DateTime.Today.Day) ? DateTime.Today.Year - (persona.FechaNacimiento.Value.Year - 1) : DateTime.Today.Year - (persona.FechaNacimiento.Value.Year);
						}
						else 
						{
							return null;
						}
					}
					catch
					{
						return null;
					}
				}
				else
				{
					return null;
				}
			}
		}

		public static Persona Get(Guid id)
		{
			return Query.GetPersonas().SingleOrDefault<Persona>(x => x.Id == id);
		}

		public static Persona Get(int cuerpo, char digito)
		{
			return Query.GetPersonas().SingleOrDefault<Persona>(x => x.RunCuerpo == cuerpo && x.RunDigito.ToString().ToLower() == digito.ToString().ToLower());
		}

		public static List<Persona> GetAll()
		{
			return
				(
				from query in Query.GetPersonas()
				orderby query.Nombre
				select query
				).ToList<Persona>();
		}

		public static List<Persona> GetAll(FindType findType, string filter)
		{
			if (string.IsNullOrEmpty(filter)) return new List<Persona>();

			return
				(
				from query in Query.GetPersonas(findType, filter)
				orderby query.Nombre
				select query
				).ToList<Persona>();
		}

		public static List<Persona> GetAll(int cuerpo, char digito)
		{
			return
				(
				from query in Query.GetPersonas(cuerpo, digito)
				orderby query.Nombre
				select query
				).ToList<Persona>();
		}
	}
}