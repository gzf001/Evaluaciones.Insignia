using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Departamento
	{
		public static Departamento Get(Guid empresaId, Guid unidadId, Guid id)
		{
			return Query.GetDepartamentos().SingleOrDefault<Departamento>(x => x.EmpresaId == empresaId && x.UnidadId == unidadId && x.Id == id);
		}

		public static List<Departamento> GetAll()
		{
			return
				(
				from query in Query.GetDepartamentos()
				select query
				).ToList<Departamento>();
		}

        public static List<Departamento> GetAll(Empresa empresa)
        {
            return
                 (
                 from query in Query.GetDepartamentos(empresa)
                 orderby query.Nombre
                 select query
                 ).ToList<Departamento>();
        }

		public static List<Departamento> GetAll(Unidad unidad)
		{
			return
				(
				from query in Query.GetDepartamentos(unidad)
				orderby query.Nombre
				select query
				).ToList<Departamento>();
		}

        public static class Nunoa
        {
            public static Departamento Educacion
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("94C8DCC8-7668-42DC-A0F7-6D22128E7726"), new Guid("787FFF15-0D54-4029-B747-0CE7FEE96EDB"), new Guid("FE0206AB-1675-4A22-90FA-E9DA0A822EF7"));
                }
            }

            public static Departamento Salud
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("94C8DCC8-7668-42DC-A0F7-6D22128E7726"), new Guid("787FFF15-0D54-4029-B747-0CE7FEE96EDB"), new Guid("F8F9D536-89EC-4A9F-95BD-E57FEFA9CC65"));
                }
            }
        }

        public static class Buin
        {
            public static Departamento Educacion
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("0989987A-C29E-44AD-9840-30087F9DCA55"), new Guid("0A7DBB4E-4449-4B40-89EC-AAB5F7977F39"), new Guid("4A499F8C-02FA-4C74-9569-636C0E5DB4DE"));
                }
            }

            public static Departamento Salud
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("0989987A-C29E-44AD-9840-30087F9DCA55"), new Guid("0A7DBB4E-4449-4B40-89EC-AAB5F7977F39"), new Guid("5FD0E799-FB10-49C5-B788-76D8AF68F316"));
                }
            }

            public static Departamento Administracion
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("0989987A-C29E-44AD-9840-30087F9DCA55"), new Guid("0A7DBB4E-4449-4B40-89EC-AAB5F7977F39"), new Guid("E9342BE5-5EF3-4DBD-8C34-7780663424D4"));
                }
            }
        }

        public static class Conchali
        {
            public static Departamento Administracion
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("B11ACDB0-6505-4D62-96C0-45B179427749"), new Guid("26605CD7-2729-4F37-912B-7127064BF914"), new Guid("AF62E8FE-5745-4510-9D8C-0AFE0C89E2C5"));
                }
            }

            public static Departamento Educacion
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("B11ACDB0-6505-4D62-96C0-45B179427749"), new Guid("26605CD7-2729-4F37-912B-7127064BF914"), new Guid("33805A44-E961-4CB4-9750-6A8A532946C7"));
                }
            }

            public static Departamento Salud
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("B11ACDB0-6505-4D62-96C0-45B179427749"), new Guid("26605CD7-2729-4F37-912B-7127064BF914"), new Guid("FFF2B9E8-A328-464B-9889-6C28873EE43F"));
                }
            }

            public static Departamento Menores
            {
                get
                {
                    return Castellano.Departamento.Get(new Guid("B11ACDB0-6505-4D62-96C0-45B179427749"), new Guid("26605CD7-2729-4F37-912B-7127064BF914"), new Guid("AFABB07B-2C46-4797-B4A2-79408B42348E"));
                }
            }

        }
    }
}