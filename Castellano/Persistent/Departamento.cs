using System;
using System.Linq;
namespace Castellano
{
	public partial class Departamento
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Departamento departamento = context.Departamentos.SingleOrDefault<Departamento>(x => x == this);

			if (departamento == null)
			{
				departamento = new Departamento
				{
					EmpresaId = this.EmpresaId,
					UnidadId = this.UnidadId,
					Id = this.Id
				};

				context.Departamentos.InsertOnSubmit(departamento);
			}

			departamento.AdministradorId = this.AdministradorId == default(Guid) ? null : this.AdministradorId;
			departamento.Nombre = this.Nombre;
			departamento.Codigo = this.Codigo == default(Int32) ? null : this.Codigo;
			departamento.Clave = this.Clave;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Departamento departamento = context.Departamentos.SingleOrDefault<Departamento>(x => x == this);

			if (departamento != null)
			{
				context.Departamentos.DeleteOnSubmit(departamento);
			}
			PostDelete(context);
		}
	}
}