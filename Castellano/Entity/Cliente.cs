using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Cliente : IEquatable<Cliente>
	{
		public Cliente()
		{
			this.Id = Guid.NewGuid();
			this.comuna = default(EntityRef<Castellano.Comuna>);
			this.empresa = default(EntityRef<Castellano.Empresa>);
		}

		public Guid Id { get; set; }

		public Guid EmpresaId { get; set; }

		public String Rut { get; set; }

		public Int32 RutCuerpo { get; set; }

		public Char RutDigito { get; set; }

		public String Nombre { get; set; }

		public String Email { get; set; }

		public Nullable<Int16> RegionCodigo { get; set; }

		public Nullable<Int16> CiudadCodigo { get; set; }

		public Nullable<Int16> ComunaCodigo { get; set; }

		public String Direccion { get; set; }

		public Nullable<Int64> Telefono { get; set; }

		public Nullable<Int64> Celular { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Comuna> comuna;
		public Castellano.Comuna Comuna
		{
			get { return this.comuna.Entity; }
			set { this.comuna.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Empresa> empresa;
		public Castellano.Empresa Empresa
		{
			get { return this.empresa.Entity; }
			set { this.empresa.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Clientes.Attach(this);
		}

		public bool Equals(Cliente other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id) && other.EmpresaId.Equals(EmpresaId);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Cliente)) return false;
			return Equals((Cliente)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode() ^ this.EmpresaId.GetHashCode();
		}
	}
}