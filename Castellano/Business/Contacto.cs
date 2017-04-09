using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Contacto
	{
		public static List<Contacto> GetAll()
		{
			return
				(
				from query in Query.GetContactos()
				select query
				).ToList<Contacto>();
		}
    }
}