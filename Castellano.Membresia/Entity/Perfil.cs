using System;
using System.Data.Linq;
namespace Castellano.Membresia
{
	[Serializable]
	public partial class Perfil : IEquatable<Perfil>
	{
		public Perfil()
		{
			this.Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }

		public String Nombre { get; set; }

		public String Clave { get; set; }

		public void Attach()
		{
			Context.Instancia.Perfiles.Attach(this);
		}

		public bool Equals(Perfil other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Perfil)) return false;
			return Equals((Perfil)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}