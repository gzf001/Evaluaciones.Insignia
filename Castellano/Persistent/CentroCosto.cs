using System;
using System.Linq;
namespace Castellano
{
	public partial class CentroCosto
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			CentroCosto centroCosto = context.CentroCostos.SingleOrDefault<CentroCosto>(x => x == this);

			if (centroCosto == null)
			{
				centroCosto = new CentroCosto
				{
					EmpresaId = this.EmpresaId,
					Id = this.Id
				};

				context.CentroCostos.InsertOnSubmit(centroCosto);
			}

			centroCosto.AdministradorId = this.AdministradorId == default(Guid) ? null : this.AdministradorId;
			centroCosto.Nombre = this.Nombre;
			centroCosto.Sigla = this.Sigla;
			centroCosto.AreaGeograficaCodigo = this.AreaGeograficaCodigo;
			centroCosto.TipoEstablecimientoSaludCodigo = this.TipoEstablecimientoSaludCodigo == default(Int32) ? null : this.TipoEstablecimientoSaludCodigo;
			centroCosto.RegionCodigo = this.RegionCodigo == default(Int16) ? null : this.RegionCodigo;
			centroCosto.CiudadCodigo = this.CiudadCodigo == default(Int16) ? null : this.CiudadCodigo;
			centroCosto.ComunaCodigo = this.ComunaCodigo == default(Int16) ? null : this.ComunaCodigo;
			centroCosto.Email = this.Email;
			centroCosto.Direccion = this.Direccion;
			centroCosto.Telefono1 = this.Telefono1 == default(Int32) ? null : this.Telefono1;
			centroCosto.Telefono2 = this.Telefono2 == default(Int32) ? null : this.Telefono2;
			centroCosto.Fax = this.Fax == default(Int32) ? null : this.Fax;
			centroCosto.Celular = this.Celular == default(Int32) ? null : this.Celular;
			centroCosto.CodigoContabilidad = this.CodigoContabilidad;
			centroCosto.LibroRemuneraciones = this.LibroRemuneraciones;
			centroCosto.RutaReporte = this.RutaReporte;
			centroCosto.DepartamentoId = this.DepartamentoId == default(Guid) ? null : this.DepartamentoId;
			centroCosto.UnidadId = this.UnidadId == default(Guid) ? null : this.UnidadId;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			CentroCosto centroCosto = context.CentroCostos.SingleOrDefault<CentroCosto>(x => x == this);

			if (centroCosto != null)
			{
				context.CentroCostos.DeleteOnSubmit(centroCosto);
			}
			PostDelete(context);
		}
	}
}