using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class IPC : IEquatable<IPC>
	{
		public IPC()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
		}

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Decimal Variacion { get; set; }

		public Decimal Puntaje { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.IPCes.Attach(this);
		}

		public bool Equals(IPC other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(IPC)) return false;
			return Equals((IPC)obj);
		}

		public override int GetHashCode()
		{
			return this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode();
		}
	}
}