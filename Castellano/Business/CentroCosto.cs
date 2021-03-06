using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CentroCosto
	{
		public string NombreSigla
		{
			get
			{
				return string.IsNullOrEmpty(this.Sigla) ? string.Format("[______]{0}", this.Nombre) : string.Format("[{0}]{1}", this.Sigla.PadLeft(6, '_'), this.Nombre);
			}
		}

        public string NombreSiglaContable
        {
            get
            {
                if (string.IsNullOrEmpty(this.CodigoContabilidad))
                {
                    return this.NombreSigla;
                }
                else
                {
                    return string.IsNullOrEmpty(this.Sigla) ? string.Format("[______]{0}", this.Nombre) : string.Format("[{0}]{1}", this.CodigoContabilidad.PadLeft(6, '_'), this.Nombre);
                }
            }
        }

		public static int Count(Empresa empresa)
		{
			return Query.GetCentroCostos(empresa).Count<CentroCosto>();
		}

		public static CentroCosto Get(Guid empresaId, Guid id)
		{
			return Query.GetCentroCostos().SingleOrDefault<CentroCosto>(x => x.EmpresaId == empresaId && x.Id == id);
		}

		public static List<CentroCosto> GetAll()
		{
			return
				(
				from query in Query.GetCentroCostos()
				orderby query.Nombre
				select query
				).ToList<CentroCosto>();
		}

		public static List<CentroCosto> GetAll(Empresa empresa)
		{
			return
				(
				from query in Query.GetCentroCostos(empresa)
				orderby query.Nombre
				select query
				).ToList<CentroCosto>();
		}
	}
}