using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoCargaFamiliar
	{
		public static TipoCargaFamiliar Simple
		{
			get
			{
				return TipoCargaFamiliar.Get(1);
			}
		}

		public static TipoCargaFamiliar Invalida
		{
			get
			{
				return TipoCargaFamiliar.Get(2);
			}
		}

		public static TipoCargaFamiliar Maternal
		{
			get
			{
				return TipoCargaFamiliar.Get(3);
			}
		}

		public static TipoCargaFamiliar Get(int codigo)
		{
			return Query.GetTipoCargaFamiliares().SingleOrDefault<TipoCargaFamiliar>(x => x.Codigo == codigo);
		}

		public static List<TipoCargaFamiliar> GetAll()
		{
			return
				(
				from query in Query.GetTipoCargaFamiliares()
				select query
				).ToList<TipoCargaFamiliar>();
		}
	}
}