using System;
using System.Linq;
namespace Castellano
{
	public partial class Proveedor
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Proveedor proveedor = context.Proveedores.SingleOrDefault<Proveedor>(x => x == this);

			if (proveedor == null)
			{
				proveedor = new Proveedor
				{
					Id = this.Id
				};

				context.Proveedores.InsertOnSubmit(proveedor);
			}

			proveedor.RutCuerpo = this.RutCuerpo;
			proveedor.RutDigito = this.RutDigito;
			proveedor.RazonSocial = this.RazonSocial;
			proveedor.NombreComercial = this.NombreComercial;
			proveedor.TipoCuentaCodigo = this.TipoCuentaCodigo == default(Int32) ? null : this.TipoCuentaCodigo;
			proveedor.NumeroCuenta = this.NumeroCuenta;
			proveedor.RegionCodigo = this.RegionCodigo == default(Int16) ? null : this.RegionCodigo;
			proveedor.CiudadCodigo = this.CiudadCodigo == default(Int16) ? null : this.CiudadCodigo;
			proveedor.ComunaCodigo = this.ComunaCodigo == default(Int16) ? null : this.ComunaCodigo;
			proveedor.Direccion = this.Direccion;
			proveedor.Email = this.Email;
			proveedor.PaginaWeb = this.PaginaWeb;
			proveedor.Telefono1 = this.Telefono1 == default(Int64) ? null : this.Telefono1;
			proveedor.Telefono2 = this.Telefono2 == default(Int64) ? null : this.Telefono2;
			proveedor.Fax = this.Fax == default(Int32) ? null : this.Fax;
			proveedor.Celular = this.Celular == default(Int32) ? null : this.Celular;
			proveedor.Eliminado = this.Eliminado;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Proveedor proveedor = context.Proveedores.SingleOrDefault<Proveedor>(x => x == this);

			if (proveedor != null)
			{
				context.Proveedores.DeleteOnSubmit(proveedor);
			}
			PostDelete(context);
		}
	}
}