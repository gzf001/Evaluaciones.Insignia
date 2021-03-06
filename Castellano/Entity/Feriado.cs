using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class Feriado : IEquatable<Feriado>
	{
		public Feriado()
		{
			this.Id = Guid.NewGuid();
			this.calendario = default(EntityRef<Castellano.Calendario>);
			this.centroCosto = default(EntityRef<Castellano.CentroCosto>);
			this.empresa = default(EntityRef<Castellano.Empresa>);
		}

		public Guid Id { get; set; }

		public Nullable<Guid> EmpresaId { get; set; }

		public Nullable<Guid> CentroCostoId { get; set; }

		public DateTime Fecha { get; set; }

		public String Nombre { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Calendario> calendario;
		public Castellano.Calendario Calendario
		{
			get { return this.calendario.Entity; }
			set { this.calendario.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.CentroCosto> centroCosto;
		public Castellano.CentroCosto CentroCosto
		{
			get { return this.centroCosto.Entity; }
			set { this.centroCosto.Entity = value; }
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
			Context.Instancia.Feriados.Attach(this);
		}

		public bool Equals(Feriado other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Feriado)) return false;
			return Equals((Feriado)obj);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
	}
}