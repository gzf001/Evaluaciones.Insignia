using System;
using System.Data.Linq;
namespace Castellano
{
	[Serializable]
	public partial class ConfiguracionContable : IEquatable<ConfiguracionContable>
	{
		public ConfiguracionContable()
		{
			this.ano = default(EntityRef<Castellano.Ano>);
			this.contador = default(EntityRef<Castellano.Persona>);
			this.directorEducacion = default(EntityRef<Castellano.Persona>);
			this.directorSalud = default(EntityRef<Castellano.Persona>);
			this.empresa = default(EntityRef<Castellano.Empresa>);
			this.secretario = default(EntityRef<Castellano.Persona>);
		}

		public Guid EmpresaId { get; set; }

		public Int32 AnoNumero { get; set; }

		public Int32 NivelesCuenta { get; set; }

		public Nullable<Guid> SecretarioId { get; set; }

		public Nullable<Guid> ContadorId { get; set; }

		public Nullable<Guid> DirectorEducacionId { get; set; }

		public Nullable<Guid> DirectorSaludId { get; set; }

		public Boolean ControlComprobante { get; set; }

		[NonSerialized]
		private EntityRef<Castellano.Ano> ano;
		public Castellano.Ano Ano
		{
			get { return this.ano.Entity; }
			set { this.ano.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Persona> contador;
		public Castellano.Persona Contador
		{
			get { return this.contador.Entity; }
			set { this.contador.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Persona> directorEducacion;
		public Castellano.Persona DirectorEducacion
		{
			get { return this.directorEducacion.Entity; }
			set { this.directorEducacion.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Persona> directorSalud;
		public Castellano.Persona DirectorSalud
		{
			get { return this.directorSalud.Entity; }
			set { this.directorSalud.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Empresa> empresa;
		public Castellano.Empresa Empresa
		{
			get { return this.empresa.Entity; }
			set { this.empresa.Entity = value; }
		}

		[NonSerialized]
		private EntityRef<Castellano.Persona> secretario;
		public Castellano.Persona Secretario
		{
			get { return this.secretario.Entity; }
			set { this.secretario.Entity = value; }
		}

		public void Attach()
		{
			Context.Instancia.ConfiguracionContables.Attach(this);
		}

		public bool Equals(ConfiguracionContable other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.EmpresaId.Equals(EmpresaId) && other.AnoNumero.Equals(AnoNumero);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(ConfiguracionContable)) return false;
			return Equals((ConfiguracionContable)obj);
		}

		public override int GetHashCode()
		{
			return this.EmpresaId.GetHashCode() ^ this.AnoNumero.GetHashCode();
		}
	}
}