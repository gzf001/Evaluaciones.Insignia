using System;
using System.Linq;
namespace Castellano
{
	public partial class ConfiguracionContable
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			ConfiguracionContable configuracionContable = context.ConfiguracionContables.SingleOrDefault<ConfiguracionContable>(x => x == this);

			if (configuracionContable == null)
			{
				configuracionContable = new ConfiguracionContable
				{
					EmpresaId = this.EmpresaId,
					AnoNumero = this.AnoNumero
				};

				context.ConfiguracionContables.InsertOnSubmit(configuracionContable);
			}

			configuracionContable.NivelesCuenta = this.NivelesCuenta;
			configuracionContable.SecretarioId = this.SecretarioId == default(Guid) ? null : this.SecretarioId;
			configuracionContable.ContadorId = this.ContadorId == default(Guid) ? null : this.ContadorId;
			configuracionContable.DirectorEducacionId = this.DirectorEducacionId == default(Guid) ? null : this.DirectorEducacionId;
			configuracionContable.DirectorSaludId = this.DirectorSaludId == default(Guid) ? null : this.DirectorSaludId;
			configuracionContable.ControlComprobante = this.ControlComprobante;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			ConfiguracionContable configuracionContable = context.ConfiguracionContables.SingleOrDefault<ConfiguracionContable>(x => x == this);

			if (configuracionContable != null)
			{
				context.ConfiguracionContables.DeleteOnSubmit(configuracionContable);
			}
			PostDelete(context);
		}
	}
}