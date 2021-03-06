using System;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class PerfilUsuario : IEquatable<PerfilUsuario>
	{
		public PerfilUsuario()
		{
			this.perfil = default(EntityRef<Castellano.Membresia.Perfil>);
			this.usuario = default(EntityRef<Castellano.Membresia.Usuario>);
		}

		public Guid PerfilId { get; set; }

		public Guid UsuarioId { get; set; }

		public String Valor { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Perfil> perfil;
		public Castellano.Membresia.Perfil Perfil
		{
			get { return this.perfil.Entity; }
			set { this.perfil.Entity = value; }
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
			Context.Instancia.PerfilUsuarios.Attach(this);
		}

		public bool Equals(PerfilUsuario other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.PerfilId.Equals(PerfilId) && other.UsuarioId.Equals(UsuarioId);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(PerfilUsuario)) return false;
			return Equals((PerfilUsuario)obj);
		}

		public override int GetHashCode()
		{
			return this.PerfilId.GetHashCode() ^ this.UsuarioId.GetHashCode();
		}
	}
}