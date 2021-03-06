using System;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class Suscripcion : IEquatable<Suscripcion>
	{
		public Suscripcion()
		{
			this.Id = Guid.NewGuid();
			this.aplicacion = default(EntityRef<Castellano.Membresia.Aplicacion>);
			this.usuario = default(EntityRef<Castellano.Membresia.Usuario>);
		}

		public Guid AplicacionId { get; set; }

		public Guid UsuarioId { get; set; }

		public Guid Id { get; set; }

		public String URI { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Aplicacion> aplicacion;
		public Castellano.Membresia.Aplicacion Aplicacion
		{
			get { return this.aplicacion.Entity; }
			set { this.aplicacion.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Usuario> usuario;
		public Castellano.Membresia.Usuario Usuario
		{
			get { return this.usuario.Entity; }
			set { this.usuario.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Suscripciones.Attach(this);
		}

		public bool Equals(Suscripcion other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AplicacionId.Equals(AplicacionId) && other.UsuarioId.Equals(UsuarioId) && other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Suscripcion)) return false;
			return Equals((Suscripcion)obj);
		}

		public override int GetHashCode()
		{
			return this.AplicacionId.GetHashCode() ^ this.UsuarioId.GetHashCode() ^ this.Id.GetHashCode();
		}
	}
}