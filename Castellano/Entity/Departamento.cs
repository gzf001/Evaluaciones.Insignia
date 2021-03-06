using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Departamento : IEquatable<Departamento>
	{
		public Departamento()
		{
			this.Id = Guid.NewGuid();
			this.administrador = default(EntityRef<Castellano.Persona>);
			this.unidad = default(EntityRef<Castellano.Unidad>);
		}

		public Guid EmpresaId { get; set; }

		public Guid UnidadId { get; set; }

		public Guid Id { get; set; }

		public Nullable<Guid> AdministradorId { get; set; }

		public String Nombre { get; set; }

		public Nullable<Int32> Codigo { get; set; }

		public String Clave { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Persona> administrador;
		public Castellano.Persona Administrador
		{
			get { return this.administrador.Entity; }
			set { this.administrador.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Unidad> unidad;
		public Castellano.Unidad Unidad
		{
			get { return this.unidad.Entity; }
			set { this.unidad.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Departamentos.Attach(this);
		}

		public bool Equals(Departamento other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.EmpresaId.Equals(EmpresaId) && other.UnidadId.Equals(UnidadId) && other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Departamento)) return false;
			return Equals((Departamento)obj);
		}

		public override int GetHashCode()
		{
			return this.EmpresaId.GetHashCode() ^ this.UnidadId.GetHashCode() ^ this.Id.GetHashCode();
		}
	}
}