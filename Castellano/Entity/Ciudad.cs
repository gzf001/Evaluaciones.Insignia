using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Ciudad : IEquatable<Ciudad>
	{
		public Ciudad()
		{
			this.region = default(EntityRef<Castellano.Region>);
		}

		public Int16 RegionCodigo { get; set; }

		public Int16 Codigo { get; set; }

		public String Nombre { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Region> region;
		public Castellano.Region Region
		{
			get { return this.region.Entity; }
			set { this.region.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.Ciudades.Attach(this);
		}

		public bool Equals(Ciudad other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.RegionCodigo.Equals(RegionCodigo) && other.Codigo.Equals(Codigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Ciudad)) return false;
			return Equals((Ciudad)obj);
		}

		public override int GetHashCode()
		{
			return this.RegionCodigo.GetHashCode() ^ this.Codigo.GetHashCode();
		}
	}
}