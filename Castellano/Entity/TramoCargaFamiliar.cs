using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class TramoCargaFamiliar : IEquatable<TramoCargaFamiliar>
	{
		public TramoCargaFamiliar()
		{
			this.anoMes = default(EntityRef<Castellano.AnoMes>);
			this.tipoCargaFamiliar = default(EntityRef<Castellano.TipoCargaFamiliar>);
			this.tramoAsignacionFamiliar = default(EntityRef<Castellano.TramoAsignacionFamiliar>);
		}

		public Int32 AnoNumero { get; set; }

		public Int32 MesNumero { get; set; }

		public Int32 TipoCargaFamiliarCodigo { get; set; }

		public Int32 TramoAsignacionFamiliarCodigo { get; set; }

		public Int32 Inicio { get; set; }

		public Nullable<Int32> Termino { get; set; }

		public Int32 Valor { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.AnoMes> anoMes;
		public Castellano.AnoMes AnoMes
		{
			get { return this.anoMes.Entity; }
			set { this.anoMes.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.TipoCargaFamiliar> tipoCargaFamiliar;
		public Castellano.TipoCargaFamiliar TipoCargaFamiliar
		{
			get { return this.tipoCargaFamiliar.Entity; }
			set { this.tipoCargaFamiliar.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.TramoAsignacionFamiliar> tramoAsignacionFamiliar;
		public Castellano.TramoAsignacionFamiliar TramoAsignacionFamiliar
		{
			get { return this.tramoAsignacionFamiliar.Entity; }
			set { this.tramoAsignacionFamiliar.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.TramoCargaFamiliares.Attach(this);
		}

		public bool Equals(TramoCargaFamiliar other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.AnoNumero.Equals(AnoNumero) && other.MesNumero.Equals(MesNumero) && other.TipoCargaFamiliarCodigo.Equals(TipoCargaFamiliarCodigo) && other.TramoAsignacionFamiliarCodigo.Equals(TramoAsignacionFamiliarCodigo);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(TramoCargaFamiliar)) return false;
			return Equals((TramoCargaFamiliar)obj);
		}

		public override int GetHashCode()
		{
			return this.AnoNumero.GetHashCode() ^ this.MesNumero.GetHashCode() ^ this.TipoCargaFamiliarCodigo.GetHashCode() ^ this.TramoAsignacionFamiliarCodigo.GetHashCode();
		}
	}
}