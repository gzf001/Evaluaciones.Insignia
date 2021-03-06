using System;
using System.Linq;
namespace Castellano
{
	public partial class Empresa
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Empresa empresa = context.Empresas.SingleOrDefault<Empresa>(x => x == this);

			if (empresa == null)
			{
				empresa = new Empresa
				{
					Id = this.Id
				};

				context.Empresas.InsertOnSubmit(empresa);
			}

			empresa.RutCuerpo = this.RutCuerpo;
            empresa.RutDigito = char.ToUpper(this.RutDigito);
			empresa.RazonSocial = this.RazonSocial;
			empresa.RegionCodigo = this.RegionCodigo == default(Int16) ? null : this.RegionCodigo;
			empresa.CiudadCodigo = this.CiudadCodigo == default(Int16) ? null : this.CiudadCodigo;
			empresa.ComunaCodigo = this.ComunaCodigo == default(Int16) ? null : this.ComunaCodigo;
			empresa.TipoAdministracionCodigo = this.TipoAdministracionCodigo;
			empresa.ActividadEconomicaPrincipalCodigo = this.ActividadEconomicaPrincipalCodigo == default(Int32) ? null : this.ActividadEconomicaPrincipalCodigo;
			empresa.SectorActividadEconomicaCodigo = this.SectorActividadEconomicaCodigo == default(Int32) ? null : this.SectorActividadEconomicaCodigo;
			empresa.ActividadEconomicaCodigo = this.ActividadEconomicaCodigo == default(Int32) ? null : this.ActividadEconomicaCodigo;
			empresa.Giro = this.Giro;
			empresa.Direccion = this.Direccion;
			empresa.Email = this.Email;
			empresa.PaginaWeb = this.PaginaWeb;
			empresa.Telefono1 = this.Telefono1 == default(Int32) ? null : this.Telefono1;
			empresa.Telefono2 = this.Telefono2 == default(Int32) ? null : this.Telefono2;
			empresa.Fax = this.Fax == default(Int32) ? null : this.Fax;
			empresa.Celular = this.Celular == default(Int32) ? null : this.Celular;
			empresa.AdministradorId = this.AdministradorId == default(Guid) ? null : this.AdministradorId;
			empresa.GerenteRRHHId = this.GerenteRRHHId == default(Guid) ? null : this.GerenteRRHHId;
			empresa.Bloqueada = this.Bloqueada;
			empresa.RutaReporte = this.RutaReporte;
			empresa.PieFirmaLiquidacion = this.PieFirmaLiquidacion;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Empresa empresa = context.Empresas.SingleOrDefault<Empresa>(x => x == this);

			if (empresa != null)
			{
				context.Empresas.DeleteOnSubmit(empresa);
			}
			PostDelete(context);
		}
	}
}