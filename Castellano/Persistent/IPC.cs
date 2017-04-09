using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
	public partial class IPC
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			IPC IPC = context.IPCes.SingleOrDefault<IPC>(x => x == this);

			if (IPC == null)
			{
				IPC = new IPC
				{
					AnoNumero = this.AnoNumero,
					MesNumero = this.MesNumero
				};

				context.IPCes.InsertOnSubmit(IPC);
			}

			IPC.Variacion = this.Variacion;
			IPC.Puntaje = this.Puntaje;

			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			IPC IPC = context.IPCes.SingleOrDefault<IPC>(x => x == this);

			if (IPC != null)
			{
				context.IPCes.DeleteOnSubmit(IPC);
			}

			PostDelete(context);
		}
	}
}
