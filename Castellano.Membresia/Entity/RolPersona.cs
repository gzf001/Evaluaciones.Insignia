using System;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class RolPersona : IEquatable<RolPersona>
	{
		public RolPersona()
		{
			this.persona = default(EntityRef<Castellano.Persona>);
			this.rol = default(EntityRef<Castellano.Membresia.Rol>);
		}

		public Guid RolId { get; set; }

		public Guid PersonaId { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Persona> persona;
		public Castellano.Persona Persona
		{
			get { return this.persona.Entity; }
			set { this.persona.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Rol> rol;
		public Castellano.Membresia.Rol Rol
		{
			get { return this.rol.Entity; }
			set { this.rol.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.RolPersonas.Attach(this);
		}

		public bool Equals(RolPersona other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.RolId.Equals(RolId) && other.PersonaId.Equals(PersonaId);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(RolPersona)) return false;
			return Equals((RolPersona)obj);
		}

		public override int GetHashCode()
		{
			return this.RolId.GetHashCode() ^ this.PersonaId.GetHashCode();
		}
	}
}