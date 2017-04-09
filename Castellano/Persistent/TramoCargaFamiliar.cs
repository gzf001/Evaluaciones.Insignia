using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
	public partial class TramoCargaFamiliar
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			TramoCargaFamiliar tramoCargaFamiliar = context.TramoCargaFamiliares.SingleOrDefault<TramoCargaFamiliar>(x => x == this);

			if (tramoCargaFamiliar == null)
			{
				tramoCargaFamiliar = new TramoCargaFamiliar
				{
					AnoNumero = this.AnoNumero,
					MesNumero = this.MesNumero,
					TipoCargaFamiliarCodigo = this.TipoCargaFamiliarCodigo ,
					TramoAsignacionFamiliarCodigo = this.TramoAsignacionFamiliarCodigo
				};

				context.TramoCargaFamiliares.InsertOnSubmit(tramoCargaFamiliar);
			}

			tramoCargaFamiliar.Inicio = this.Inicio;

			if (this.Termino == default(int) || !this.Termino.HasValue)
			{
				tramoCargaFamiliar.Termino = null;
			}
			else
			{
				tramoCargaFamiliar.Termino = this.Termino.Value;
			}
			
			tramoCargaFamiliar.Valor = this.Valor;

			PostSave(context);
		}
	}
}
