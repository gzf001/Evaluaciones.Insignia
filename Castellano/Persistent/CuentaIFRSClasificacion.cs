using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
    public partial class CuentaIFRSClasificacion
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
            CuentaIFRSClasificacion cuentaIFRSClasificacion = context.CuentaIFRSClasificaciones.SingleOrDefault<CuentaIFRSClasificacion>(x => x == this);

            if (cuentaIFRSClasificacion == null)
			{
                cuentaIFRSClasificacion = new CuentaIFRSClasificacion
				{
                    CuentaTipoCodigo = this.CuentaTipoCodigo,
                    CuentaSubTipoCodigo = this.CuentaSubTipoCodigo,
                    Codigo = this.Codigo,
                    Nombre = this.Nombre
				};

                context.CuentaIFRSClasificaciones.InsertOnSubmit(cuentaIFRSClasificacion);
			}

			PostSave(context);
		}
	}
}
