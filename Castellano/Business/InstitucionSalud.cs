using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class InstitucionSalud
	{
		public static InstitucionSalud FONASA
		{
			get
			{
				return InstitucionSalud.Get(7);
			}
		}

		public static InstitucionSalud Banmedica
		{
			get
			{
				return InstitucionSalud.Get(1);
			}
		}

		public static InstitucionSalud Consalud
		{
			get
			{
				return InstitucionSalud.Get(2);
			}
		}

		public static InstitucionSalud VidaTres
		{
			get
			{
				return InstitucionSalud.Get(3);
			}
		}

		public static InstitucionSalud Colmena
		{
			get
			{
				return InstitucionSalud.Get(4);
			}
		}

		public static InstitucionSalud CruzBlanca
		{
			get
			{
				return InstitucionSalud.Get(5);
			}
		}

		public static InstitucionSalud Chuquicamata
		{
			get
			{
				return InstitucionSalud.Get(9);
			}
		}

		public static InstitucionSalud Ferrosalud
		{
			get
			{
				return InstitucionSalud.Get(10);
			}
		}

		public static InstitucionSalud FUSAT
		{
			get
			{
				return InstitucionSalud.Get(11);
			}
		}

		public static InstitucionSalud BancoEstado
		{
			get
			{
				return InstitucionSalud.Get(12);
			}
		}

		public static InstitucionSalud MasVida
		{
			get
			{
				return InstitucionSalud.Get(17);
			}
		}

		public static InstitucionSalud RioBlanco
		{
			get
			{
				return InstitucionSalud.Get(20);
			}
		}

		public static InstitucionSalud SanLorenzo
		{
			get
			{
				return InstitucionSalud.Get(21);
			}
		}

		public static InstitucionSalud CruzDelNorte
		{
			get
			{
				return InstitucionSalud.Get(25);
			}
		}
		
		public static InstitucionSalud Get(Int32 codigo)
		{
			return Query.GetInstitucionSaludes().SingleOrDefault<InstitucionSalud>(x => x.Codigo == codigo);
		}

		public static List<InstitucionSalud> GetAll()
		{
			return
				(
				from query in Query.GetInstitucionSaludes()
				orderby query.Nombre 
				select query
				).ToList<InstitucionSalud>();
		}

		public static List<InstitucionSalud> GetAll(bool isapre)
		{
			return
				(
				from query in Query.GetInstitucionSaludes(isapre)
				orderby query.Nombre 
				select query
				).ToList<InstitucionSalud>();
		}
	}
}