using System;
using System.Linq;
namespace Castellano
{
	public partial class Cliente
	{
		partial void PreSave(Context context);
		partial void PostSave(Context context);
		partial void PreDelete(Context context);
		partial void PostDelete(Context context);

		public void Save(Context context)
		{
			PreSave(context);
			Cliente cliente = context.Clientes.SingleOrDefault<Cliente>(x => x == this);

			if (cliente == null)
			{
				cliente = new Cliente
				{
					Id = this.Id,
					EmpresaId = this.EmpresaId
				};

				context.Clientes.InsertOnSubmit(cliente);
			}

			cliente.RutCuerpo = this.RutCuerpo;
			cliente.RutDigito = this.RutDigito;
			cliente.Nombre = this.Nombre;
			cliente.Email = this.Email;
			cliente.RegionCodigo = this.RegionCodigo == default(Int16) ? null : this.RegionCodigo;
			cliente.CiudadCodigo = this.CiudadCodigo == default(Int16) ? null : this.CiudadCodigo;
			cliente.ComunaCodigo = this.ComunaCodigo == default(Int16) ? null : this.ComunaCodigo;
			cliente.Direccion = this.Direccion;
			cliente.Telefono = this.Telefono == default(Int64) ? null : this.Telefono;
			cliente.Celular = this.Celular == default(Int64) ? null : this.Celular;
			PostSave(context);
		}

		public void Delete(Context context)
		{
			PreDelete(context);
			Cliente cliente = context.Clientes.SingleOrDefault<Cliente>(x => x == this);

			if (cliente != null)
			{
				context.Clientes.DeleteOnSubmit(cliente);
			}
			PostDelete(context);
		}
	}
}