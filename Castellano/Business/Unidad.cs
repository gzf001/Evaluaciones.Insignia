using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Unidad
	{
		public static Unidad Get(Guid empresaId, Guid id)
		{
			return Query.GetUnidades().SingleOrDefault<Unidad>(x => x.EmpresaId == empresaId && x.Id == id);
		}

		public static List<Unidad> GetAll()
		{
			return
				(
				from query in Query.GetUnidades()
				select query
				).ToList<Unidad>();
		}

		public static List<Unidad> GetAll(Empresa empresa)
		{
			return
				(
				from query in Query.GetUnidades(empresa)
				orderby query.Nombre
				select query
				).ToList<Unidad>();
		}

        public static class Buin
        {
            public static Unidad CMDS_Buin
            {
                get
                {
                    return Castellano.Unidad.Get(Castellano.Empresa.Buin.Id, new Guid("0A7DBB4E-4449-4B40-89EC-AAB5F7977F39"));
                }
            }
        }

        public static class Conchali
        {
            public static Unidad CMDS_Conchali
            {
                get
                {
                    return Castellano.Unidad.Get(Castellano.Empresa.Conchali.Id, new Guid("26605CD7-2729-4F37-912B-7127064BF914"));
                }
            }
        }
	}
}