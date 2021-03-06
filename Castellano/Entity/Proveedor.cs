using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Proveedor : IEquatable<Proveedor>
	{
		public Proveedor()
		{
			this.tipoCuenta = default(EntityRef<Castellano.TipoCuenta>);
		}

		public Guid Id { get; set; }

		public String Rut { get; set; }

		public Int32 RutCuerpo { get; set; }

		public Char RutDigito { get; set; }

		public String RazonSocial { get; set; }

		public String NombreComercial { get; set; }

		public Nullable<Int32> TipoCuentaCodigo { get; set; }

		public String NumeroCuenta { get; set; }

		public Nullable<Int16> RegionCodigo { get; set; }

		public Nullable<Int16> CiudadCodigo { get; set; }

		public Nullable<Int16> ComunaCodigo { get; set; }

		public String Direccion { get; set; }

		public String Email { get; set; }

		public String PaginaWeb { get; set; }

		public Nullable<Int64> Telefono1 { get; set; }

		public Nullable<Int64> Telefono2 { get; set; }

		public Nullable<Int32> Fax { get; set; }

		public Nullable<Int32> Celular { get; set; }

		public Boolean Eliminado { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.TipoCuenta> tipoCuenta;
		public Castellano.TipoCuenta TipoCuenta
		{
			get { return this.tipoCuenta.Entity; }
			set { this.tipoCuenta.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Proveedores.Attach(this);
		}

		public bool Equals(Proveedor other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Proveedor)) return false;
			return Equals((Proveedor)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}