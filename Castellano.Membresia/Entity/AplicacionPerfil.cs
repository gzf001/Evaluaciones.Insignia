using System;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class AplicacionPerfil : IEquatable<AplicacionPerfil>
	{
		public AplicacionPerfil()
		{
			this.aplicacion = default(EntityRef<Castellano.Membresia.Aplicacion>);
			this.perfil = default(EntityRef<Castellano.Membresia.Perfil>);
		}

		public Guid AplicacionId { get; set; }

		public Guid PerfilId { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Aplicacion> aplicacion;
		public Castellano.Membresia.Aplicacion Aplicacion
		{
			get { return this.aplicacion.Entity; }
			set { this.aplicacion.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Membresia.Perfil> perfil;
		public Castellano.Membresia.Perfil Perfil
		{
			get { return this.perfil.Entity; }
			set { this.perfil.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.AplicacionPerfiles.Attach(this);
		}

		public bool Equals(AplicacionPerfil other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AplicacionId.Equals(AplicacionId) && other.PerfilId.Equals(PerfilId);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(AplicacionPerfil)) return false;
			return Equals((AplicacionPerfil)obj);
		}

		public override int GetHashCode()
		{
			return this.AplicacionId.GetHashCode() ^ this.PerfilId.GetHashCode();
		}
	}
}