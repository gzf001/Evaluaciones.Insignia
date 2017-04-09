using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TipoAtencionMedica : IEquatable<TipoAtencionMedica>
	{
		public TipoAtencionMedica()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.TipoAtencionMedicas.Attach(this);
		}

		public bool Equals(TipoAtencionMedica other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TipoAtencionMedica)) return false;
			return Equals((TipoAtencionMedica)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}