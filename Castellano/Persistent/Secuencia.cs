using System;
using System.Linq;
namespace Castellano
{
	public partial class Secuencia
	{
		public void Save(Context context)
		{
			Secuencia secuencia = context.Secuencias.SingleOrDefault<Secuencia>(x => x == this);

			if (secuencia == null)
			{
				secuencia = new Secuencia
				{
					Clave = this.Clave
				};

				context.Secuencias.InsertOnSubmit(secuencia);
			}

			secuencia.Numero = this.Numero;
		}

		public void Delete(Context context)
		{
			Secuencia secuencia = context.Secuencias.SingleOrDefault<Secuencia>(x => x == this);

			if (secuencia != null)
			{
				context.Secuencias.DeleteOnSubmit(secuencia);
			}
		}
	}
}