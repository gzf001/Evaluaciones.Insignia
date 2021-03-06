using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Empresa
	{
        public static Empresa Nunoa
        {
            get
            {
                return Empresa.Get(new Guid("94C8DCC8-7668-42DC-A0F7-6D22128E7726"));
            }
        }

        public static Empresa Buin
        {
            get
            {
                return Empresa.Get(new Guid("0989987A-C29E-44AD-9840-30087F9DCA55"));
            }
        }

        public static Empresa Conchali
        {
            get
            {
                return Empresa.Get(new Guid("B11ACDB0-6505-4D62-96C0-45B179427749"));
            }
        }

		public static Empresa Get(Guid id)
		{
			return Query.GetEmpresas().SingleOrDefault<Empresa>(x => x.Id == id);
		}

		public static List<Empresa> GetAll()
		{
			return
				(
				from query in Query.GetEmpresas()
				orderby query.RazonSocial
				select query
				).ToList<Empresa>();
		}

		public static void Load(Empresa empresa)
		{
			empresa = Context.Instancia.Empresas.SingleOrDefault<Empresa>(x=>x == empresa);
		}
    }
}