using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class RegimenPrevisional : IEquatable<RegimenPrevisional>
	{
		public RegimenPrevisional()
		{
		}

		public Int32 Codigo { get; set; }

		public String Nombre { get; set; }

		public void Attach()
		{
			Context.Instancia.RegimenPrevisionales.Attach(this);
		}

		public bool Equals(RegimenPrevisional other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(RegimenPrevisional)) return false;
			return Equals((RegimenPrevisional)obj);
		}

		public override int GetHashCode()
		{
			return this.Codigo.GetHashCode();
		}
	}
}