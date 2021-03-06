using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoMoneda
	{
		public static TipoMoneda Peso
		{
			get
			{
				return Get(1);
			}
		}

		public static TipoMoneda UF
		{
			get
			{
				return Get(2);
			}
		}

		public static TipoMoneda UTM
		{
			get
			{

				return Get(3);
			}
		}

		public static TipoMoneda RemuneracionImponible
		{
			get
			{
				return Get(4);
			}
		}

		public static TipoMoneda SueldoBase
		{
			get
			{
				return Get(5);
			}
		}

		public static TipoMoneda RemuneracionBasicaMinimaNacional
		{
			get
			{
				return Get(6);
			}
		}

		public static TipoMoneda SueldoBaseSegunCategoria
		{
			get
			{
				return Get(7);
			}
		}

		public static TipoMoneda SueldoBaseMasAtencionPrimaria
		{
			get
			{
				return Get(8);
			}
		}

		public static TipoMoneda SueldoBaseMunicipal
		{
			get
			{
				return Get(9);
			}
		}

		public static TipoMoneda SueldoBaseMunicipalMasAsignacionMunicipal
		{
			get
			{
				return Get(10);
			}
		}

		public static TipoMoneda Get(int codigo)
		{
			return Query.GetTipoMonedas().SingleOrDefault<TipoMoneda>(x => x.Codigo == codigo);
		}

		public static List<TipoMoneda> GetAll()
		{
			return
				(
				from query in Query.GetTipoMonedas()
				select query
				).ToList<TipoMoneda>();
		}

		public static List<TipoMoneda> GetAll(TipoPrevision tipoPrevision)
		{
			return
				(
				from query in Query.GetTipoMonedas(tipoPrevision)
				select query
				).ToList<TipoMoneda>();
		}
	}
}