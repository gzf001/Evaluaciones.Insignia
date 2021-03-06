using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Unidad : IEquatable<Unidad>
	{
		public Unidad()
		{
			this.Id = Guid.NewGuid();
			this.administrador = default(EntityRef<Castellano.Persona>);
			this.empresa = default(EntityRef<Castellano.Empresa>);
		}

		public Guid EmpresaId { get; set; }

		public Guid Id { get; set; }

		public Nullable<Guid> AdministradorId { get; set; }

		public String Nombre { get; set; }

		public String Descripcion { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Persona> administrador;
		public Castellano.Persona Administrador
		{
			get { return this.administrador.Entity; }
			set { this.administrador.Entity = value; }
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
			Context.Instancia.Unidades.Attach(this);
		}

		public bool Equals(Unidad other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.EmpresaId.Equals(EmpresaId) && other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Unidad)) return false;
			return Equals((Unidad)obj);
		}

		public override int GetHashCode()
		{
			return this.EmpresaId.GetHashCode() ^ this.Id.GetHashCode();
		}
	}
}