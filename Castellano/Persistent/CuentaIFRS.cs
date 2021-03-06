using System;
using System.Linq;
namespace Castellano
{
	public partial class CuentaIFRS
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			CuentaIFRS cuentaIFRS = context.CuentaIFRSes.SingleOrDefault<CuentaIFRS>(x => x == this);

			if (cuentaIFRS == null)
			{
				cuentaIFRS = new CuentaIFRS
				{
					Id = this.Id
				};

				context.CuentaIFRSes.InsertOnSubmit(cuentaIFRS);
			}

			cuentaIFRS.AnoNumero = this.AnoNumero;
			cuentaIFRS.Descripcion = this.Descripcion;
			cuentaIFRS.EmpresaId = this.EmpresaId;
			cuentaIFRS.CuentaTipoCodigo = this.CuentaTipoCodigo;
			cuentaIFRS.CuentaSubTipoCodigo = this.CuentaSubTipoCodigo;
			cuentaIFRS.CuentaClasificacionCodigo = this.CuentaClasificacionCodigo;
			cuentaIFRS.Codigo = this.Codigo;
			cuentaIFRS.Habilitado = this.Habilitado;
			cuentaIFRS.TipoInforme = this.TipoInforme;
			cuentaIFRS.Clasificado = this.Clasificado == default(Boolean) ? null : this.Clasificado;
			cuentaIFRS.Funcion = this.Funcion == default(Boolean) ? null : this.Funcion;
			cuentaIFRS.Naturaleza = this.Naturaleza == default(Boolean) ? null : this.Naturaleza;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			CuentaIFRS cuentaIFRS = context.CuentaIFRSes.SingleOrDefault<CuentaIFRS>(x => x == this);

			if (cuentaIFRS != null)
			{
				context.CuentaIFRSes.DeleteOnSubmit(cuentaIFRS);
			}
			PostDelete(context);
		}
	}
}