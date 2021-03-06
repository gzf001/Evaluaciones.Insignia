using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class InstitucionValorSeguro
	{
		public static InstitucionValorSeguro Capital
		{
			get
			{
				return InstitucionValorSeguro.Get(1, 33);
			}
		}

		public static InstitucionValorSeguro Cuprum
		{
			get
			{
				return InstitucionValorSeguro.Get(1, 3);
			}
		}

		public static InstitucionValorSeguro Habitat
		{
			get
			{
				return InstitucionValorSeguro.Get(1, 5);
			}
		}

		public static InstitucionValorSeguro Modelo
		{
			get
			{
				return InstitucionValorSeguro.Get(1, 34);
			}
		}

		public static InstitucionValorSeguro PlanVital
		{
			get
			{
				return InstitucionValorSeguro.Get(1, 29);
			}
		}

		public static InstitucionValorSeguro Provida
		{
			get
			{
				return InstitucionValorSeguro.Get(1, 8);
			}
		}

		public static InstitucionValorSeguro SantaMaria
		{
			get
			{
				return InstitucionValorSeguro.Get(1, 100);
			}
		}

		public static InstitucionValorSeguro SummBansander
		{
			get
			{
				return InstitucionValorSeguro.Get(1, 101);
			}
		}

        public static InstitucionValorSeguro BancoBCI
        {
            get
            {
                return InstitucionValorSeguro.Get(4, 326);
            }
        }

        public static InstitucionValorSeguro IPS
        {
            get
            {
                return InstitucionValorSeguro.Get(6, 1);
            }
        }

		public static InstitucionValorSeguro Get(int tipoInstitucionValorSeguroCodigo, int codigo)
		{
			return Query.GetInstitucionValorSeguros().SingleOrDefault<InstitucionValorSeguro>(x => x.TipoInstitucionValorSeguroCodigo == tipoInstitucionValorSeguroCodigo && x.Codigo == codigo);
		}

		public static List<InstitucionValorSeguro> GetAll()
		{
			return
				(
				from query in Query.GetInstitucionValorSeguros()
				select query
				).ToList<InstitucionValorSeguro>();
		}

		public static List<InstitucionValorSeguro> GetAll(TipoInstitucionValorSeguro tipoInstitucionValorSeguro)
		{
			return
				(
				from query in Query.GetInstitucionValorSeguros()
				where query.TipoInstitucionValorSeguro == tipoInstitucionValorSeguro
				select query
				).ToList<InstitucionValorSeguro>();
		}
	}
}