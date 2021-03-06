using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Contacto : IEquatable<Contacto>
	{
		public Contacto()
		{
			this.Id = Guid.NewGuid();
			this.proveedor = default(EntityRef<Castellano.Proveedor>);
		}

		public Guid Id { get; set; }

		public Guid ProveedorId { get; set; }

		public String Nombre { get; set; }

		public String Cargo { get; set; }

		public Nullable<Int32> TelefonoNumero { get; set; }

		public Nullable<Int32> CelularNumero { get; set; }

		public String Email { get; set; }

		public String Observacion { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Proveedor> proveedor;
		public Castellano.Proveedor Proveedor
		{
			get { return this.proveedor.Entity; }
			set { this.proveedor.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Contactos.Attach(this);
		}

		public bool Equals(Contacto other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Contacto)) return false;
			return Equals((Contacto)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}