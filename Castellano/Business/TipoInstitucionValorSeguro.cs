using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoInstitucionValorSeguro
	{
		public static TipoInstitucionValorSeguro AFP
		{
			get
			{
				return Castellano.TipoInstitucionValorSeguro.Get(1);
			}
		}

		public static TipoInstitucionValorSeguro CiaSeguroVida
		{
			get
			{
				return Castellano.TipoInstitucionValorSeguro.Get(2);
			}
		}

		public static TipoInstitucionValorSeguro FondoMutuo
		{
			get
			{
				return Castellano.TipoInstitucionValorSeguro.Get(3);
			}
		}

		public static TipoInstitucionValorSeguro Banco
		{
			get
			{
				return Castellano.TipoInstitucionValorSeguro.Get(4);
			}
		}

		public static TipoInstitucionValorSeguro AdminFondoVivienda
		{
			get
			{
				return Castellano.TipoInstitucionValorSeguro.Get(5);
			}
		}

        public static TipoInstitucionValorSeguro IPS
        {
            get
            {
                return Castellano.TipoInstitucionValorSeguro.Get(6);
            }
        }

		public static TipoInstitucionValorSeguro Get(int codigo)
		{
			return Query.GetTipoInstitucionValorSeguros().SingleOrDefault<TipoInstitucionValorSeguro>(x => x.Codigo == codigo);
		}

		public static List<TipoInstitucionValorSeguro> GetAll()
		{
			return
				(
				from query in Query.GetTipoInstitucionValorSeguros()
				select query
				).ToList<TipoInstitucionValorSeguro>();
		}

		public static List<TipoInstitucionValorSeguro> GetAll(TipoAhorro tipoAhorro)
		{
			return
				(
				from query in Query.GetTipoInstitucionValorSeguros(tipoAhorro)
				orderby query.Codigo
				select query
				).ToList<TipoInstitucionValorSeguro>();
		}
	}
}