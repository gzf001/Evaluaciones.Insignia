using System;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using FluentLinqToSql;
namespace Castellano
{
	public partial class Context : DataContext
	{
		protected static readonly string connectionString = ConfigurationManager.ConnectionStrings["Castellano"].ConnectionString;
		private static readonly MappingSource mappingSource;
		private static Context instancia;

		#region Singleton
		public static Context Instancia
		{
			get
			{
				if (HostingEnvironment.IsHosted)
				{
					if (HttpContext.Current.Items["Castellano_Context"] == null)
					{
						HttpContext.Current.Items["Castellano_Context"] = new Context();
					}

					return (Context)HttpContext.Current.Items["Castellano_Context"];
				}
				else
				{
					if (instancia == null) instancia = new Context { DeferredLoadingEnabled = true };

					return instancia;
				}
			}
		}
		#endregion

		static Context()
		{
			mappingSource = new FluentMappingSource("Castellano")
				.AddFromAssemblyContaining<Castellano.Context>()
				.CreateMappingSource();

			instancia = new Context
			{
				DeferredLoadingEnabled = true
			};
		}

		public Context() : base(connectionString, mappingSource) { }

		public Context(MappingSource mappingSource) : base(connectionString, mappingSource) { }

		public override void SubmitChanges(ConflictMode failureMode)
		{
			base.SubmitChanges(failureMode);

			if (HostingEnvironment.IsHosted) HttpContext.Current.Items["Castellano_Context"] = null;
			else Context.instancia = null;
		}

		#region Tables
		public Table<Castellano.ActividadEconomica> ActividadEconomicas
		{
			get { return this.GetTable<Castellano.ActividadEconomica>(); }
		}

		public Table<Castellano.ActividadEconomicaPrincipal> ActividadEconomicaPrincipales
		{
			get { return this.GetTable<Castellano.ActividadEconomicaPrincipal>(); }
		}

		public Table<Castellano.AFCAnoMes> AFCAnoMeses
		{
			get { return this.GetTable<Castellano.AFCAnoMes>(); }
		}

		public Table<Castellano.AFPAnoMes> AFPAnoMeses
		{
			get { return this.GetTable<Castellano.AFPAnoMes>(); }
		}

		public Table<Castellano.Ambito> Ambitos
		{
			get { return this.GetTable<Castellano.Ambito>(); }
		}

		public Table<Castellano.Ano> Anos
		{
			get { return this.GetTable<Castellano.Ano>(); }
		}

		public Table<Castellano.AnoMes> AnoMeses
		{
			get { return this.GetTable<Castellano.AnoMes>(); }
		}

		public Table<Castellano.AreaGeografica> AreaGeograficas
		{
			get { return this.GetTable<Castellano.AreaGeografica>(); }
		}

		public Table<Castellano.CajaCompensacion> CajaCompensaciones
		{
			get { return this.GetTable<Castellano.CajaCompensacion>(); }
		}

		public Table<Castellano.CajaPrevisionalExRegimen> CajaPrevisionalExRegimenes
		{
			get { return this.GetTable<Castellano.CajaPrevisionalExRegimen>(); }
		}

		public Table<Castellano.Calendario> Calendarios
		{
			get { return this.GetTable<Castellano.Calendario>(); }
		}

		public Table<Castellano.CentroCosto> CentroCostos
		{
			get { return this.GetTable<Castellano.CentroCosto>(); }
		}

		public Table<Castellano.Ciudad> Ciudades
		{
			get { return this.GetTable<Castellano.Ciudad>(); }
		}

		public Table<Castellano.Cliente> Clientes
		{
			get { return this.GetTable<Castellano.Cliente>(); }
		}

		public Table<Castellano.Comuna> Comunas
		{
			get { return this.GetTable<Castellano.Comuna>(); }
		}

		public Table<Castellano.ConfiguracionContable> ConfiguracionContables
		{
			get { return this.GetTable<Castellano.ConfiguracionContable>(); }
		}

		public Table<Castellano.Contacto> Contactos
		{
			get { return this.GetTable<Castellano.Contacto>(); }
		}

		public Table<Castellano.CorreccionMonetaria> CorreccionMonetarias
		{
			get { return this.GetTable<Castellano.CorreccionMonetaria>(); }
		}

		public Table<Castellano.CuentaIFRS> CuentaIFRSes
		{
			get { return this.GetTable<Castellano.CuentaIFRS>(); }
		}

		public Table<Castellano.CuentaIFRSClasificacion> CuentaIFRSClasificaciones
		{
			get { return this.GetTable<Castellano.CuentaIFRSClasificacion>(); }
		}

		public Table<Castellano.CuentaIFRSSubTipo> CuentaIFRSSubTipos
		{
			get { return this.GetTable<Castellano.CuentaIFRSSubTipo>(); }
		}

		public Table<Castellano.CuentaIFRSTipo> CuentaIFRSTipos
		{
			get { return this.GetTable<Castellano.CuentaIFRSTipo>(); }
		}

		public Table<Castellano.CuentaIFRSTipoInforme> CuentaIFRSTipoInformes
		{
			get { return this.GetTable<Castellano.CuentaIFRSTipoInforme>(); }
		}

		public Table<Castellano.Departamento> Departamentos
		{
			get { return this.GetTable<Castellano.Departamento>(); }
		}

		public Table<Castellano.Dia> Dias
		{
			get { return this.GetTable<Castellano.Dia>(); }
		}

		public Table<Castellano.Empresa> Empresas
		{
			get { return this.GetTable<Castellano.Empresa>(); }
		}

		public Table<Castellano.EquivalenciaTransferenciaBCI> EquivalenciaTransferenciaBCIs
		{
			get { return this.GetTable<Castellano.EquivalenciaTransferenciaBCI>(); }
		}

		public Table<Castellano.EstadoCivil> EstadoCiviles
		{
			get { return this.GetTable<Castellano.EstadoCivil>(); }
		}

		public Table<Castellano.Feriado> Feriados
		{
			get { return this.GetTable<Castellano.Feriado>(); }
		}

		public Table<Castellano.FormaPago> FormaPagos
		{
			get { return this.GetTable<Castellano.FormaPago>(); }
		}

		public Table<Castellano.ImpuestoUnico> ImpuestoUnicos
		{
			get { return this.GetTable<Castellano.ImpuestoUnico>(); }
		}

		public Table<Castellano.InstitucionSalud> InstitucionSaludes
		{
			get { return this.GetTable<Castellano.InstitucionSalud>(); }
		}

		public Table<Castellano.InstitucionSaludAnoMes> InstitucionSaludAnoMeses
		{
			get { return this.GetTable<Castellano.InstitucionSaludAnoMes>(); }
		}

		public Table<Castellano.InstitucionValorSeguro> InstitucionValorSeguros
		{
			get { return this.GetTable<Castellano.InstitucionValorSeguro>(); }
		}

		public Table<Castellano.InstitucionValorSeguroTipoAhorro> InstitucionValorSeguroTipoAhorros
		{
			get { return this.GetTable<Castellano.InstitucionValorSeguroTipoAhorro>(); }
		}

		public Table<Castellano.IPC> IPCes
		{
			get { return this.GetTable<Castellano.IPC>(); }
		}

		public Table<Castellano.Mes> Meses
		{
			get { return this.GetTable<Castellano.Mes>(); }
		}

		public Table<Castellano.Moneda> Monedas
		{
			get { return this.GetTable<Castellano.Moneda>(); }
		}

		public Table<Castellano.MonedaDiaria> MonedaDiarias
		{
			get { return this.GetTable<Castellano.MonedaDiaria>(); }
		}

		public Table<Castellano.MonedaMensual> MonedaMensuales
		{
			get { return this.GetTable<Castellano.MonedaMensual>(); }
		}

		public Table<Castellano.Mutual> Mutuales
		{
			get { return this.GetTable<Castellano.Mutual>(); }
		}

		public Table<Castellano.Nacionalidad> Nacionalidades
		{
			get { return this.GetTable<Castellano.Nacionalidad>(); }
		}

		public Table<Castellano.NivelEducacional> NivelEducacionales
		{
			get { return this.GetTable<Castellano.NivelEducacional>(); }
		}

		public Table<Castellano.ParametroPrevisional> ParametroPrevisionales
		{
			get { return this.GetTable<Castellano.ParametroPrevisional>(); }
		}

		public Table<Castellano.Parentesco> Parentescos
		{
			get { return this.GetTable<Castellano.Parentesco>(); }
		}

		public Table<Castellano.Persona> Personas
		{
			get { return this.GetTable<Castellano.Persona>(); }
		}

		public Table<Castellano.Proveedor> Proveedores
		{
			get { return this.GetTable<Castellano.Proveedor>(); }
		}

		public Table<Castellano.PuebloIndigena> PuebloIndigenas
		{
			get { return this.GetTable<Castellano.PuebloIndigena>(); }
		}

		public Table<Castellano.RegimenPrevisional> RegimenPrevisionales
		{
			get { return this.GetTable<Castellano.RegimenPrevisional>(); }
		}

		public Table<Castellano.Region> Regiones
		{
			get { return this.GetTable<Castellano.Region>(); }
		}

		public Table<Castellano.SectorActividadEconomica> SectorActividadEconomicas
		{
			get { return this.GetTable<Castellano.SectorActividadEconomica>(); }
		}

		public Table<Castellano.Secuencia> Secuencias
		{
			get { return this.GetTable<Castellano.Secuencia>(); }
		}

		public Table<Castellano.SecuenciaCentroCosto> SecuenciaCentroCostos
		{
			get { return this.GetTable<Castellano.SecuenciaCentroCosto>(); }
		}

		public Table<Castellano.SecuenciaEmpresa> SecuenciaEmpresas
		{
			get { return this.GetTable<Castellano.SecuenciaEmpresa>(); }
		}

		public Table<Castellano.Semana> Semanas
		{
			get { return this.GetTable<Castellano.Semana>(); }
		}

		public Table<Castellano.Sexo> Sexos
		{
			get { return this.GetTable<Castellano.Sexo>(); }
		}

		public Table<Castellano.SituacionLaboral> SituacionLaborales
		{
			get { return this.GetTable<Castellano.SituacionLaboral>(); }
		}

		public Table<Castellano.TipoAdministracion> TipoAdministraciones
		{
			get { return this.GetTable<Castellano.TipoAdministracion>(); }
		}

		public Table<Castellano.TipoAFC> TipoAFCes
		{
			get { return this.GetTable<Castellano.TipoAFC>(); }
		}

		public Table<Castellano.TipoAhorro> TipoAhorros
		{
			get { return this.GetTable<Castellano.TipoAhorro>(); }
		}

		public Table<Castellano.TipoAtencionMedica> TipoAtencionMedicas
		{
			get { return this.GetTable<Castellano.TipoAtencionMedica>(); }
		}

		public Table<Castellano.TipoCargaFamiliar> TipoCargaFamiliares
		{
			get { return this.GetTable<Castellano.TipoCargaFamiliar>(); }
		}

		public Table<Castellano.TipoCuenta> TipoCuentas
		{
			get { return this.GetTable<Castellano.TipoCuenta>(); }
		}

		public Table<Castellano.TipoEstablecimientoSalud> TipoEstablecimientoSaludes
		{
			get { return this.GetTable<Castellano.TipoEstablecimientoSalud>(); }
		}

		public Table<Castellano.TipoInstitucionValorSeguro> TipoInstitucionValorSeguros
		{
			get { return this.GetTable<Castellano.TipoInstitucionValorSeguro>(); }
		}

		public Table<Castellano.TipoMoneda> TipoMonedas
		{
			get { return this.GetTable<Castellano.TipoMoneda>(); }
		}

		public Table<Castellano.TipoMonedaLegislacionLaboral> TipoMonedaLegislacionLaborales
		{
			get { return this.GetTable<Castellano.TipoMonedaLegislacionLaboral>(); }
		}

		public Table<Castellano.TipoMonedaTipoPrevision> TipoMonedaTipoPrevisiones
		{
			get { return this.GetTable<Castellano.TipoMonedaTipoPrevision>(); }
		}

		public Table<Castellano.TipoPrevision> TipoPrevisiones
		{
			get { return this.GetTable<Castellano.TipoPrevision>(); }
		}

		public Table<Castellano.TipoSubministroAgua> TipoSubministroAguas
		{
			get { return this.GetTable<Castellano.TipoSubministroAgua>(); }
		}

		public Table<Castellano.TipoVivienda> TipoViviendas
		{
			get { return this.GetTable<Castellano.TipoVivienda>(); }
		}

		public Table<Castellano.TramoAsignacionFamiliar> TramoAsignacionFamiliares
		{
			get { return this.GetTable<Castellano.TramoAsignacionFamiliar>(); }
		}

		public Table<Castellano.TramoCargaFamiliar> TramoCargaFamiliares
		{
			get { return this.GetTable<Castellano.TramoCargaFamiliar>(); }
		}

		public Table<Castellano.Unidad> Unidades
		{
			get { return this.GetTable<Castellano.Unidad>(); }
		}
		#endregion

		#region Views
		#endregion

		#region StoredProcedures
		#endregion

		#region Functions
		public String FormatInt(Int32 Number)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), Number);

			return (String)result.ReturnValue;
		}

		public Nullable<Char> GetRunDigito(Int32 RunCuerpo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), RunCuerpo);

			return (Nullable<Char>)result.ReturnValue;
		}
		#endregion

		#region Configuracion
		public class ActividadEconomicaConfiguration : Mapping<Castellano.ActividadEconomica>
		{
			public ActividadEconomicaConfiguration()
			{
				this.Named("dbo.ActividadEconomica");

				this.Map<Int32>(x => x.ActividadEconomicaPrincipalCodigo).Named("ActividadEconomicaPrincipalCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.SectorActividadEconomicaCodigo).Named("SectorActividadEconomicaCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Descripcion).Named("Descripcion").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.SectorActividadEconomica>(x => x.SectorActividadEconomica).ThisKey("ActividadEconomicaPrincipalCodigo,SectorActividadEconomicaCodigo").OtherKey("ActividadEconomicaPrincipalCodigo,Codigo").Storage("sectorActividadEconomica");
			}
		}

		public class ActividadEconomicaPrincipalConfiguration : Mapping<Castellano.ActividadEconomicaPrincipal>
		{
			public ActividadEconomicaPrincipalConfiguration()
			{
				this.Named("dbo.ActividadEconomicaPrincipal");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Descripcion).Named("Descripcion").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class AFCAnoMesConfiguration : Mapping<Castellano.AFCAnoMes>
		{
			public AFCAnoMesConfiguration()
			{
				this.Named("dbo.AFCAnoMes");

				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.TipoAFCCodigo).Named("TipoAFCCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.Empleador).Named("Empleador").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.Trabajador).Named("Trabajador").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
				this.HasOne<Castellano.TipoAFC>(x => x.TipoAFC).ThisKey("TipoAFCCodigo").OtherKey("Codigo").Storage("tipoAFC");
			}
		}

		public class AFPAnoMesConfiguration : Mapping<Castellano.AFPAnoMes>
		{
			public AFPAnoMesConfiguration()
			{
				this.Named("dbo.AFPAnoMes");

				this.Map<Int32>(x => x.TipoInstitucionValorSeguroCodigo).Named("TipoInstitucionValorSeguroCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.InstitucionValorSeguroCodigo).Named("InstitucionValorSeguroCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.Cotizacion).Named("Cotizacion").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
				this.HasOne<Castellano.InstitucionValorSeguro>(x => x.InstitucionValorSeguro).ThisKey("TipoInstitucionValorSeguroCodigo,InstitucionValorSeguroCodigo").OtherKey("TipoInstitucionValorSeguroCodigo,Codigo").Storage("institucionValorSeguro");
			}
		}

		public class AmbitoConfiguration : Mapping<Castellano.Ambito>
		{
			public AmbitoConfiguration()
			{
				this.Named("dbo.Ambito");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class AnoConfiguration : Mapping<Castellano.Ano>
		{
			public AnoConfiguration()
			{
				this.Named("dbo.Ano");

				this.Map<Int32>(x => x.Numero).Named("Numero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Activo).Named("Activo").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class AnoMesConfiguration : Mapping<Castellano.AnoMes>
		{
			public AnoMesConfiguration()
			{
				this.Named("dbo.AnoMes");

				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<DateTime>(x => x.Inicio).Named("Inicio").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<DateTime>(x => x.Termino).Named("Termino").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Ano>(x => x.Ano).ThisKey("AnoNumero").OtherKey("Numero").Storage("ano");
				this.HasOne<Castellano.Mes>(x => x.Mes).ThisKey("MesNumero").OtherKey("Numero").Storage("mes");
			}
		}

		public class AreaGeograficaConfiguration : Mapping<Castellano.AreaGeografica>
		{
			public AreaGeograficaConfiguration()
			{
				this.Named("dbo.AreaGeografica");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class CajaCompensacionConfiguration : Mapping<Castellano.CajaCompensacion>
		{
			public CajaCompensacionConfiguration()
			{
				this.Named("dbo.CajaCompensacion");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class CajaPrevisionalExRegimenConfiguration : Mapping<Castellano.CajaPrevisionalExRegimen>
		{
			public CajaPrevisionalExRegimenConfiguration()
			{
				this.Named("dbo.CajaPrevisionalExRegimen");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.Cotizacion).Named("Cotizacion").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class CalendarioConfiguration : Mapping<Castellano.Calendario>
		{
			public CalendarioConfiguration()
			{
				this.Named("dbo.Calendario");

				this.Map<DateTime>(x => x.Fecha).Named("Fecha").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Int32>(x => x.SemanaNumero).Named("SemanaNumero").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Int16>(x => x.DiaNumero).Named("DiaNumero").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Festivo).Named("Festivo").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
				this.HasOne<Castellano.Dia>(x => x.Dia).ThisKey("DiaNumero").OtherKey("Numero").Storage("dia");
				this.HasOne<Castellano.Semana>(x => x.Semana).ThisKey("AnoNumero,MesNumero,SemanaNumero").OtherKey("AnoNumero,MesNumro,Numero").Storage("semana");
			}
		}

		public class CentroCostoConfiguration : Mapping<Castellano.CentroCosto>
		{
			public CentroCostoConfiguration()
			{
				this.Named("dbo.CentroCosto");

				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Nullable<Guid>>(x => x.AdministradorId).Named("AdministradorId").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Sigla).Named("Sigla").UpdateCheck(UpdateCheck.Never);
				this.Map<Int32>(x => x.AreaGeograficaCodigo).Named("AreaGeograficaCodigo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<Int32>>(x => x.TipoEstablecimientoSaludCodigo).Named("TipoEstablecimientoSaludCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.RegionCodigo).Named("RegionCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.CiudadCodigo).Named("CiudadCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.ComunaCodigo).Named("ComunaCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Email).Named("Email").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Direccion).Named("Direccion").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Telefono1).Named("Telefono1").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Telefono2).Named("Telefono2").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Fax).Named("Fax").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Celular).Named("Celular").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.CodigoContabilidad).Named("CodigoContabilidad").UpdateCheck(UpdateCheck.Never);
				this.Map<Boolean>(x => x.LibroRemuneraciones).Named("LibroRemuneraciones").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.RutaReporte).Named("RutaReporte").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.DepartamentoId).Named("DepartamentoId").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.UnidadId).Named("UnidadId").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Persona>(x => x.Administrador).ThisKey("AdministradorId").OtherKey("Id").Storage("administrador");
				this.HasOne<Castellano.AreaGeografica>(x => x.AreaGeografica).ThisKey("AreaGeograficaCodigo").OtherKey("Codigo").Storage("areaGeografica");
				this.HasOne<Castellano.Comuna>(x => x.Comuna).ThisKey("RegionCodigo,CiudadCodigo,ComunaCodigo").OtherKey("RegionCodigo,CiudadCodigo,Codigo").Storage("comuna");
				this.HasOne<Castellano.Departamento>(x => x.Departamento).ThisKey("EmpresaId,UnidadId,DepartamentoId").OtherKey("EmpresaId,UnidadId,Id").Storage("departamento");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
				this.HasOne<Castellano.TipoEstablecimientoSalud>(x => x.TipoEstablecimientoSalud).ThisKey("TipoEstablecimientoSaludCodigo").OtherKey("Codigo").Storage("tipoEstablecimientoSalud");
			}
		}

		public class CiudadConfiguration : Mapping<Castellano.Ciudad>
		{
			public CiudadConfiguration()
			{
				this.Named("dbo.Ciudad");

				this.Map<Int16>(x => x.RegionCodigo).Named("RegionCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int16>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Region>(x => x.Region).ThisKey("RegionCodigo").OtherKey("Codigo").Storage("region");
			}
		}

		public class ClienteConfiguration : Mapping<Castellano.Cliente>
		{
			public ClienteConfiguration()
			{
				this.Named("dbo.Cliente");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Rut).Named("Rut").UpdateCheck(UpdateCheck.Never).DbGenerated();
				this.Map<Int32>(x => x.RutCuerpo).Named("RutCuerpo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Char>(x => x.RutDigito).Named("RutDigito").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Email).Named("Email").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.RegionCodigo).Named("RegionCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.CiudadCodigo).Named("CiudadCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.ComunaCodigo).Named("ComunaCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Direccion).Named("Direccion").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int64>>(x => x.Telefono).Named("Telefono").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int64>>(x => x.Celular).Named("Celular").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Comuna>(x => x.Comuna).ThisKey("RegionCodigo,CiudadCodigo,ComunaCodigo").OtherKey("RegionCodigo,CiudadCodigo,Codigo").Storage("comuna");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
			}
		}

		public class ComunaConfiguration : Mapping<Castellano.Comuna>
		{
			public ComunaConfiguration()
			{
				this.Named("dbo.Comuna");

				this.Map<Int16>(x => x.RegionCodigo).Named("RegionCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int16>(x => x.CiudadCodigo).Named("CiudadCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int16>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Ciudad>(x => x.Ciudad).ThisKey("RegionCodigo,CiudadCodigo").OtherKey("RegionCodigo,Codigo").Storage("ciudad");
			}
		}

		public class ConfiguracionContableConfiguration : Mapping<Castellano.ConfiguracionContable>
		{
			public ConfiguracionContableConfiguration()
			{
				this.Named("dbo.ConfiguracionContable");

				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.NivelesCuenta).Named("NivelesCuenta").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<Guid>>(x => x.SecretarioId).Named("SecretarioId").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.ContadorId).Named("ContadorId").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.DirectorEducacionId).Named("DirectorEducacionId").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.DirectorSaludId).Named("DirectorSaludId").UpdateCheck(UpdateCheck.Never);
				this.Map<Boolean>(x => x.ControlComprobante).Named("ControlComprobante").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Ano>(x => x.Ano).ThisKey("AnoNumero").OtherKey("Numero").Storage("ano");
				this.HasOne<Castellano.Persona>(x => x.Contador).ThisKey("ContadorId").OtherKey("Id").Storage("contador");
				this.HasOne<Castellano.Persona>(x => x.DirectorEducacion).ThisKey("DirectorEducacionId").OtherKey("Id").Storage("directorEducacion");
				this.HasOne<Castellano.Persona>(x => x.DirectorSalud).ThisKey("DirectorSaludId").OtherKey("Id").Storage("directorSalud");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
				this.HasOne<Castellano.Persona>(x => x.Secretario).ThisKey("SecretarioId").OtherKey("Id").Storage("secretario");
			}
		}

		public class ContactoConfiguration : Mapping<Castellano.Contacto>
		{
			public ContactoConfiguration()
			{
				this.Named("dbo.Contacto");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.ProveedorId).Named("ProveedorId").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Cargo).Named("Cargo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.TelefonoNumero).Named("TelefonoNumero").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.CelularNumero).Named("CelularNumero").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Email).Named("Email").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Observacion).Named("Observacion").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Proveedor>(x => x.Proveedor).ThisKey("ProveedorId").OtherKey("Id").Storage("proveedor");
			}
		}

		public class CorreccionMonetariaConfiguration : Mapping<Castellano.CorreccionMonetaria>
		{
			public CorreccionMonetariaConfiguration()
			{
				this.Named("dbo.CorreccionMonetaria");

				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.Factor).Named("Factor").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
			}
		}

		public class CuentaIFRSConfiguration : Mapping<Castellano.CuentaIFRS>
		{
			public CuentaIFRSConfiguration()
			{
				this.Named("dbo.CuentaIFRS");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.CodigoCuenta).Named("CodigoCuenta").UpdateCheck(UpdateCheck.Never).DbGenerated();
				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Descripcion).Named("Descripcion").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.CuentaTipoCodigo).Named("CuentaTipoCodigo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.CuentaSubTipoCodigo).Named("CuentaSubTipoCodigo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.CuentaClasificacionCodigo).Named("CuentaClasificacionCodigo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Codigo).Named("Codigo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Habilitado).Named("Habilitado").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Int32>(x => x.TipoInforme).Named("TipoInforme").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<Boolean>>(x => x.Clasificado).Named("Clasificado").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Boolean>>(x => x.Funcion).Named("Funcion").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Boolean>>(x => x.Naturaleza).Named("Naturaleza").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Ano>(x => x.Ano).ThisKey("AnoNumero").OtherKey("Numero").Storage("ano");
				this.HasOne<Castellano.CuentaIFRSClasificacion>(x => x.CuentaIFRSClasificacion).ThisKey("CuentaTipoCodigo,CuentaSubTipoCodigo,CuentaClasificacionCodigo").OtherKey("CuentaTipoCodigo,CuentaSubTipoCodigo,Codigo").Storage("cuentaIFRSClasificacion");
				this.HasOne<Castellano.CuentaIFRSTipoInforme>(x => x.CuentaIFRSTipoInforme).ThisKey("TipoInforme").OtherKey("Codigo").Storage("cuentaIFRSTipoInforme");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
			}
		}

		public class CuentaIFRSClasificacionConfiguration : Mapping<Castellano.CuentaIFRSClasificacion>
		{
			public CuentaIFRSClasificacionConfiguration()
			{
				this.Named("dbo.CuentaIFRSClasificacion");

				this.Map<String>(x => x.CuentaTipoCodigo).Named("CuentaTipoCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.CuentaSubTipoCodigo).Named("CuentaSubTipoCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.CuentaIFRSSubTipo>(x => x.CuentaIFRSSubTipo).ThisKey("CuentaTipoCodigo,CuentaSubTipoCodigo").OtherKey("CuentaTipoCodigo,Codigo").Storage("cuentaIFRSSubTipo");
			}
		}

		public class CuentaIFRSSubTipoConfiguration : Mapping<Castellano.CuentaIFRSSubTipo>
		{
			public CuentaIFRSSubTipoConfiguration()
			{
				this.Named("dbo.CuentaIFRSSubTipo");

				this.Map<String>(x => x.CuentaTipoCodigo).Named("CuentaTipoCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Descripcion).Named("Descripcion").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.CuentaIFRSTipo>(x => x.CuentaIFRSTipo).ThisKey("CuentaTipoCodigo").OtherKey("Codigo").Storage("cuentaIFRSTipo");
			}
		}

		public class CuentaIFRSTipoConfiguration : Mapping<Castellano.CuentaIFRSTipo>
		{
			public CuentaIFRSTipoConfiguration()
			{
				this.Named("dbo.CuentaIFRSTipo");

				this.Map<String>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Int32>(x => x.TipoInforme).Named("TipoInforme").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.CuentaIFRSTipoInforme>(x => x.CuentaIFRSTipoInforme).ThisKey("TipoInforme").OtherKey("Codigo").Storage("cuentaIFRSTipoInforme");
			}
		}

		public class CuentaIFRSTipoInformeConfiguration : Mapping<Castellano.CuentaIFRSTipoInforme>
		{
			public CuentaIFRSTipoInformeConfiguration()
			{
				this.Named("dbo.CuentaIFRSTipoInforme");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Descripcion).Named("Descripcion").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class DepartamentoConfiguration : Mapping<Castellano.Departamento>
		{
			public DepartamentoConfiguration()
			{
				this.Named("dbo.Departamento");

				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.UnidadId).Named("UnidadId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Nullable<Guid>>(x => x.AdministradorId).Named("AdministradorId").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<Int32>>(x => x.Codigo).Named("Codigo").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Clave).Named("Clave").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Persona>(x => x.Administrador).ThisKey("AdministradorId").OtherKey("Id").Storage("administrador");
				this.HasOne<Castellano.Unidad>(x => x.Unidad).ThisKey("EmpresaId,UnidadId").OtherKey("EmpresaId,Id").Storage("unidad");
			}
		}

		public class DiaConfiguration : Mapping<Castellano.Dia>
		{
			public DiaConfiguration()
			{
				this.Named("dbo.Dia");

				this.Map<Int16>(x => x.Numero).Named("Numero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Laboral).Named("Laboral").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class EmpresaConfiguration : Mapping<Castellano.Empresa>
		{
			public EmpresaConfiguration()
			{
				this.Named("dbo.Empresa");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Rut).Named("Rut").UpdateCheck(UpdateCheck.Never).DbGenerated();
				this.Map<Int32>(x => x.RutCuerpo).Named("RutCuerpo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Char>(x => x.RutDigito).Named("RutDigito").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.RazonSocial).Named("RazonSocial").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<Int16>>(x => x.RegionCodigo).Named("RegionCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.CiudadCodigo).Named("CiudadCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.ComunaCodigo).Named("ComunaCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Int32>(x => x.TipoAdministracionCodigo).Named("TipoAdministracionCodigo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<Int32>>(x => x.ActividadEconomicaPrincipalCodigo).Named("ActividadEconomicaPrincipalCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.SectorActividadEconomicaCodigo).Named("SectorActividadEconomicaCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.ActividadEconomicaCodigo).Named("ActividadEconomicaCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Giro).Named("Giro").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Direccion).Named("Direccion").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Email).Named("Email").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.PaginaWeb).Named("PaginaWeb").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Telefono1).Named("Telefono1").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Telefono2).Named("Telefono2").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Fax).Named("Fax").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Celular).Named("Celular").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.AdministradorId).Named("AdministradorId").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.GerenteRRHHId).Named("GerenteRRHHId").UpdateCheck(UpdateCheck.Never);
				this.Map<Boolean>(x => x.Bloqueada).Named("Bloqueada").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.RutaReporte).Named("RutaReporte").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.PieFirmaLiquidacion).Named("PieFirmaLiquidacion").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.ActividadEconomica>(x => x.ActividadEconomica).ThisKey("ActividadEconomicaPrincipalCodigo,SectorActividadEconomicaCodigo,ActividadEconomicaCodigo").OtherKey("ActividadEconomicaPrincipalCodigo,SectorActividadEconomicaCodigo,Codigo").Storage("actividadEconomica");
				this.HasOne<Castellano.Persona>(x => x.Administrador).ThisKey("AdministradorId").OtherKey("Id").Storage("administrador");
				this.HasOne<Castellano.Comuna>(x => x.Comuna).ThisKey("RegionCodigo,CiudadCodigo,ComunaCodigo").OtherKey("RegionCodigo,CiudadCodigo,Codigo").Storage("comuna");
				this.HasOne<Castellano.Persona>(x => x.GerenteRRHH).ThisKey("GerenteRRHHId").OtherKey("Id").Storage("gerenteRRHH");
				this.HasOne<Castellano.TipoAdministracion>(x => x.TipoAdministracion).ThisKey("TipoAdministracionCodigo").OtherKey("Codigo").Storage("tipoAdministracion");
			}
		}

		public class EquivalenciaTransferenciaBCIConfiguration : Mapping<Castellano.EquivalenciaTransferenciaBCI>
		{
			public EquivalenciaTransferenciaBCIConfiguration()
			{
				this.Named("dbo.EquivalenciaTransferenciaBCI");

				this.Map<Int32>(x => x.TipoInstitucionValorSeguroCodigo).Named("TipoInstitucionValorSeguroCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.BancoCodigo).Named("BancoCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Equivalencia).Named("Equivalencia").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.InstitucionValorSeguro>(x => x.InstitucionValorSeguro).ThisKey("TipoInstitucionValorSeguroCodigo,BancoCodigo").OtherKey("TipoInstitucionValorSeguroCodigo,Codigo").Storage("institucionValorSeguro");
			}
		}

		public class EstadoCivilConfiguration : Mapping<Castellano.EstadoCivil>
		{
			public EstadoCivilConfiguration()
			{
				this.Named("dbo.EstadoCivil");

				this.Map<Int16>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class FeriadoConfiguration : Mapping<Castellano.Feriado>
		{
			public FeriadoConfiguration()
			{
				this.Named("dbo.Feriado");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Nullable<Guid>>(x => x.EmpresaId).Named("EmpresaId").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Guid>>(x => x.CentroCostoId).Named("CentroCostoId").UpdateCheck(UpdateCheck.Never);
				this.Map<DateTime>(x => x.Fecha).Named("Fecha").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Calendario>(x => x.Calendario).ThisKey("Fecha").OtherKey("Fecha").Storage("calendario");
				this.HasOne<Castellano.CentroCosto>(x => x.CentroCosto).ThisKey("EmpresaId,CentroCostoId").OtherKey("EmpresaId,Id").Storage("centroCosto");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
			}
		}

		public class FormaPagoConfiguration : Mapping<Castellano.FormaPago>
		{
			public FormaPagoConfiguration()
			{
				this.Named("dbo.FormaPago");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class ImpuestoUnicoConfiguration : Mapping<Castellano.ImpuestoUnico>
		{
			public ImpuestoUnicoConfiguration()
			{
				this.Named("dbo.ImpuestoUnico");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.Desde).Named("Desde").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<Decimal>>(x => x.Hasta).Named("Hasta").UpdateCheck(UpdateCheck.Never);
				this.Map<Decimal>(x => x.Rebaja).Named("Rebaja").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.Factor).Named("Factor").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
			}
		}

		public class InstitucionSaludConfiguration : Mapping<Castellano.InstitucionSalud>
		{
			public InstitucionSaludConfiguration()
			{
				this.Named("dbo.InstitucionSalud");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.RUT).Named("RUT").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Fonasa).Named("Fonasa").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class InstitucionSaludAnoMesConfiguration : Mapping<Castellano.InstitucionSaludAnoMes>
		{
			public InstitucionSaludAnoMesConfiguration()
			{
				this.Named("dbo.InstitucionSaludAnoMes");

				this.Map<Int32>(x => x.InstitucionSaludCodigo).Named("InstitucionSaludCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Nullable<Double>>(x => x.Cotizacion).Named("Cotizacion").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
				this.HasOne<Castellano.InstitucionSalud>(x => x.InstitucionSalud).ThisKey("InstitucionSaludCodigo").OtherKey("Codigo").Storage("institucionSalud");
			}
		}

		public class InstitucionValorSeguroConfiguration : Mapping<Castellano.InstitucionValorSeguro>
		{
			public InstitucionValorSeguroConfiguration()
			{
				this.Named("dbo.InstitucionValorSeguro");

				this.Map<Int32>(x => x.TipoInstitucionValorSeguroCodigo).Named("TipoInstitucionValorSeguroCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.TipoInstitucionValorSeguro>(x => x.TipoInstitucionValorSeguro).ThisKey("TipoInstitucionValorSeguroCodigo").OtherKey("Codigo").Storage("tipoInstitucionValorSeguro");
			}
		}

		public class InstitucionValorSeguroTipoAhorroConfiguration : Mapping<Castellano.InstitucionValorSeguroTipoAhorro>
		{
			public InstitucionValorSeguroTipoAhorroConfiguration()
			{
				this.Named("dbo.InstitucionValorSeguroTipoAhorro");

				this.Map<Int32>(x => x.TipoInstitucionValorSeguroCodigo).Named("TipoInstitucionValorSeguroCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.InstitucionValorSeguroCodigo).Named("InstitucionValorSeguroCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.TipoAhorroCodigo).Named("TipoAhorroCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.InstitucionValorSeguro>(x => x.InstitucionValorSeguro).ThisKey("TipoInstitucionValorSeguroCodigo,InstitucionValorSeguroCodigo").OtherKey("TipoInstitucionValorSeguroCodigo,Codigo").Storage("institucionValorSeguro");
				this.HasOne<Castellano.TipoAhorro>(x => x.TipoAhorro).ThisKey("TipoAhorroCodigo").OtherKey("Codigo").Storage("tipoAhorro");
			}
		}

		public class IPCConfiguration : Mapping<Castellano.IPC>
		{
			public IPCConfiguration()
			{
				this.Named("dbo.IPC");

				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.Variacion).Named("Variacion").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.Puntaje).Named("Puntaje").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
			}
		}

		public class MesConfiguration : Mapping<Castellano.Mes>
		{
			public MesConfiguration()
			{
				this.Named("dbo.Mes");

				this.Map<Int32>(x => x.Numero).Named("Numero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Inicial).Named("Inicial").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class MonedaConfiguration : Mapping<Castellano.Moneda>
		{
			public MonedaConfiguration()
			{
				this.Named("dbo.Moneda");

				this.Map<Int32>(x => x.TipoMonedaCodigo).Named("TipoMonedaCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.Valor).Named("Valor").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.TipoMoneda>(x => x.TipoMoneda).ThisKey("TipoMonedaCodigo").OtherKey("Codigo").Storage("tipoMoneda");
			}
		}

		public class MonedaDiariaConfiguration : Mapping<Castellano.MonedaDiaria>
		{
			public MonedaDiariaConfiguration()
			{
				this.Named("dbo.MonedaDiaria");

				this.Map<DateTime>(x => x.CalendarioFecha).Named("CalendarioFecha").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.TipoMonedaCodigo).Named("TipoMonedaCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.Valor).Named("Valor").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Calendario>(x => x.Calendario).ThisKey("CalendarioFecha").OtherKey("Fecha").Storage("calendario");
				this.HasOne<Castellano.TipoMoneda>(x => x.TipoMoneda).ThisKey("TipoMonedaCodigo").OtherKey("Codigo").Storage("tipoMoneda");
			}
		}

		public class MonedaMensualConfiguration : Mapping<Castellano.MonedaMensual>
		{
			public MonedaMensualConfiguration()
			{
				this.Named("dbo.MonedaMensual");

				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.TipoMonedaCodigo).Named("TipoMonedaCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.Valor).Named("Valor").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
				this.HasOne<Castellano.TipoMoneda>(x => x.TipoMoneda).ThisKey("TipoMonedaCodigo").OtherKey("Codigo").Storage("tipoMoneda");
			}
		}

		public class MutualConfiguration : Mapping<Castellano.Mutual>
		{
			public MutualConfiguration()
			{
				this.Named("dbo.Mutual");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.RUT).Named("RUT").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class NacionalidadConfiguration : Mapping<Castellano.Nacionalidad>
		{
			public NacionalidadConfiguration()
			{
				this.Named("dbo.Nacionalidad");

				this.Map<Int16>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Extranjero).Named("Extranjero").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class NivelEducacionalConfiguration : Mapping<Castellano.NivelEducacional>
		{
			public NivelEducacionalConfiguration()
			{
				this.Named("dbo.NivelEducacional");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class ParametroPrevisionalConfiguration : Mapping<Castellano.ParametroPrevisional>
		{
			public ParametroPrevisionalConfiguration()
			{
				this.Named("dbo.ParametroPrevisional");

				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Decimal>(x => x.MaximoImponibleAFP).Named("MaximoImponibleAFP").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.MaximoImponilbeRegimenAntiguo).Named("MaximoImponilbeRegimenAntiguo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.MaximoImponibleAFC).Named("MaximoImponibleAFC").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.TopeCotizacionSalud).Named("TopeCotizacionSalud").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.TopeCotizacionRegimenAntiguo).Named("TopeCotizacionRegimenAntiguo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Decimal>(x => x.SIS).Named("SIS").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
			}
		}

		public class ParentescoConfiguration : Mapping<Castellano.Parentesco>
		{
			public ParentescoConfiguration()
			{
				this.Named("dbo.Parentesco");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class PersonaConfiguration : Mapping<Castellano.Persona>
		{
			public PersonaConfiguration()
			{
				this.Named("dbo.Persona");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Run).Named("Run").UpdateCheck(UpdateCheck.Never).DbGenerated();
				this.Map<Int32>(x => x.RunCuerpo).Named("RunCuerpo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Char>(x => x.RunDigito).Named("RunDigito").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).DbGenerated();
				this.Map<String>(x => x.Nombres).Named("Nombres").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.ApellidoPaterno).Named("ApellidoPaterno").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.ApellidoMaterno).Named("ApellidoMaterno").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Email).Named("Email").UpdateCheck(UpdateCheck.Never);
				this.Map<Int16>(x => x.SexoCodigo).Named("SexoCodigo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<DateTime>>(x => x.FechaNacimiento).Named("FechaNacimiento").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.NacionalidadCodigo).Named("NacionalidadCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.EstadoCivilCodigo).Named("EstadoCivilCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.NivelEducacionalCodigo).Named("NivelEducacionalCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.RegionCodigo).Named("RegionCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.CiudadCodigo).Named("CiudadCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.ComunaCodigo).Named("ComunaCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.VillaPoblacion).Named("VillaPoblacion").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Direccion).Named("Direccion").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Telefono).Named("Telefono").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Celular).Named("Celular").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Observaciones).Named("Observaciones").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Ocupacion).Named("Ocupacion").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.TelefonoLaboral).Named("TelefonoLaboral").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.DireccionLaboral).Named("DireccionLaboral").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Comuna>(x => x.Comuna).ThisKey("RegionCodigo,CiudadCodigo,ComunaCodigo").OtherKey("RegionCodigo,CiudadCodigo,Codigo").Storage("comuna");
				this.HasOne<Castellano.EstadoCivil>(x => x.EstadoCivil).ThisKey("EstadoCivilCodigo").OtherKey("Codigo").Storage("estadoCivil");
				this.HasOne<Castellano.Nacionalidad>(x => x.Nacionalidad).ThisKey("NacionalidadCodigo").OtherKey("Codigo").Storage("nacionalidad");
				this.HasOne<Castellano.NivelEducacional>(x => x.NivelEducacional).ThisKey("NivelEducacionalCodigo").OtherKey("Codigo").Storage("nivelEducacional");
				this.HasOne<Castellano.Sexo>(x => x.Sexo).ThisKey("SexoCodigo").OtherKey("Codigo").Storage("sexo");
			}
		}

		public class ProveedorConfiguration : Mapping<Castellano.Proveedor>
		{
			public ProveedorConfiguration()
			{
				this.Named("dbo.Proveedor");

				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Rut).Named("Rut").UpdateCheck(UpdateCheck.Never).DbGenerated();
				this.Map<Int32>(x => x.RutCuerpo).Named("RutCuerpo").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Char>(x => x.RutDigito).Named("RutDigito").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.RazonSocial).Named("RazonSocial").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.NombreComercial).Named("NombreComercial").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.TipoCuentaCodigo).Named("TipoCuentaCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.NumeroCuenta).Named("NumeroCuenta").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.RegionCodigo).Named("RegionCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.CiudadCodigo).Named("CiudadCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int16>>(x => x.ComunaCodigo).Named("ComunaCodigo").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Direccion).Named("Direccion").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Email).Named("Email").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.PaginaWeb).Named("PaginaWeb").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int64>>(x => x.Telefono1).Named("Telefono1").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int64>>(x => x.Telefono2).Named("Telefono2").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Fax).Named("Fax").UpdateCheck(UpdateCheck.Never);
				this.Map<Nullable<Int32>>(x => x.Celular).Named("Celular").UpdateCheck(UpdateCheck.Never);
				this.Map<Boolean>(x => x.Eliminado).Named("Eliminado").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.TipoCuenta>(x => x.TipoCuenta).ThisKey("TipoCuentaCodigo").OtherKey("Codigo").Storage("tipoCuenta");
			}
		}

		public class PuebloIndigenaConfiguration : Mapping<Castellano.PuebloIndigena>
		{
			public PuebloIndigenaConfiguration()
			{
				this.Named("dbo.PuebloIndigena");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class RegimenPrevisionalConfiguration : Mapping<Castellano.RegimenPrevisional>
		{
			public RegimenPrevisionalConfiguration()
			{
				this.Named("dbo.RegimenPrevisional");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class RegionConfiguration : Mapping<Castellano.Region>
		{
			public RegionConfiguration()
			{
				this.Named("dbo.Region");

				this.Map<Int16>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class SectorActividadEconomicaConfiguration : Mapping<Castellano.SectorActividadEconomica>
		{
			public SectorActividadEconomicaConfiguration()
			{
				this.Named("dbo.SectorActividadEconomica");

				this.Map<Int32>(x => x.ActividadEconomicaPrincipalCodigo).Named("ActividadEconomicaPrincipalCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Descripcion).Named("Descripcion").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.ActividadEconomicaPrincipal>(x => x.ActividadEconomicaPrincipal).ThisKey("ActividadEconomicaPrincipalCodigo").OtherKey("Codigo").Storage("actividadEconomicaPrincipal");
			}
		}

		public class SecuenciaConfiguration : Mapping<Castellano.Secuencia>
		{
			public SecuenciaConfiguration()
			{
				this.Named("dbo.Secuencia");

				this.Map<String>(x => x.Clave).Named("Clave").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.Numero).Named("Numero").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class SecuenciaCentroCostoConfiguration : Mapping<Castellano.SecuenciaCentroCosto>
		{
			public SecuenciaCentroCostoConfiguration()
			{
				this.Named("dbo.SecuenciaCentroCosto");

				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.CentroCostoId).Named("CentroCostoId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Clave).Named("Clave").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.Numero).Named("Numero").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.CentroCosto>(x => x.CentroCosto).ThisKey("EmpresaId,CentroCostoId").OtherKey("EmpresaId,Id").Storage("centroCosto");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
			}
		}

		public class SecuenciaEmpresaConfiguration : Mapping<Castellano.SecuenciaEmpresa>
		{
			public SecuenciaEmpresaConfiguration()
			{
				this.Named("dbo.SecuenciaEmpresa");

				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Clave).Named("Clave").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.Numero).Named("Numero").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
			}
		}

		public class SemanaConfiguration : Mapping<Castellano.Semana>
		{
			public SemanaConfiguration()
			{
				this.Named("dbo.Semana");

				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumro).Named("MesNumro").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.Numero).Named("Numero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<DateTime>(x => x.Inicio).Named("Inicio").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<DateTime>(x => x.Termino).Named("Termino").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumro").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
			}
		}

		public class SexoConfiguration : Mapping<Castellano.Sexo>
		{
			public SexoConfiguration()
			{
				this.Named("dbo.Sexo");

				this.Map<Int16>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Char>(x => x.Letra).Named("Letra").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class SituacionLaboralConfiguration : Mapping<Castellano.SituacionLaboral>
		{
			public SituacionLaboralConfiguration()
			{
				this.Named("dbo.SituacionLaboral");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoAdministracionConfiguration : Mapping<Castellano.TipoAdministracion>
		{
			public TipoAdministracionConfiguration()
			{
				this.Named("dbo.TipoAdministracion");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoAFCConfiguration : Mapping<Castellano.TipoAFC>
		{
			public TipoAFCConfiguration()
			{
				this.Named("dbo.TipoAFC");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoAhorroConfiguration : Mapping<Castellano.TipoAhorro>
		{
			public TipoAhorroConfiguration()
			{
				this.Named("dbo.TipoAhorro");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoAtencionMedicaConfiguration : Mapping<Castellano.TipoAtencionMedica>
		{
			public TipoAtencionMedicaConfiguration()
			{
				this.Named("dbo.TipoAtencionMedica");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoCargaFamiliarConfiguration : Mapping<Castellano.TipoCargaFamiliar>
		{
			public TipoCargaFamiliarConfiguration()
			{
				this.Named("dbo.TipoCargaFamiliar");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoCuentaConfiguration : Mapping<Castellano.TipoCuenta>
		{
			public TipoCuentaConfiguration()
			{
				this.Named("dbo.TipoCuenta");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoEstablecimientoSaludConfiguration : Mapping<Castellano.TipoEstablecimientoSalud>
		{
			public TipoEstablecimientoSaludConfiguration()
			{
				this.Named("dbo.TipoEstablecimientoSalud");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoInstitucionValorSeguroConfiguration : Mapping<Castellano.TipoInstitucionValorSeguro>
		{
			public TipoInstitucionValorSeguroConfiguration()
			{
				this.Named("dbo.TipoInstitucionValorSeguro");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoMonedaConfiguration : Mapping<Castellano.TipoMoneda>
		{
			public TipoMonedaConfiguration()
			{
				this.Named("dbo.TipoMoneda");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Boolean>(x => x.Porcentual).Named("Porcentual").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoMonedaLegislacionLaboralConfiguration : Mapping<Castellano.TipoMonedaLegislacionLaboral>
		{
			public TipoMonedaLegislacionLaboralConfiguration()
			{
				this.Named("dbo.TipoMonedaLegislacionLaboral");

				this.Map<Int32>(x => x.TipoMonedaCodigo).Named("TipoMonedaCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.LegislacionLaboralCodigo).Named("LegislacionLaboralCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Boolean>(x => x.Haber).Named("Haber").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.TipoMoneda>(x => x.TipoMoneda).ThisKey("TipoMonedaCodigo").OtherKey("Codigo").Storage("tipoMoneda");
			}
		}

		public class TipoMonedaTipoPrevisionConfiguration : Mapping<Castellano.TipoMonedaTipoPrevision>
		{
			public TipoMonedaTipoPrevisionConfiguration()
			{
				this.Named("dbo.TipoMonedaTipoPrevision");

				this.Map<Int32>(x => x.TipoMonedaCodigo).Named("TipoMonedaCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.TipoPrevisionCodigo).Named("TipoPrevisionCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();

				this.HasOne<Castellano.TipoMoneda>(x => x.TipoMoneda).ThisKey("TipoMonedaCodigo").OtherKey("Codigo").Storage("tipoMoneda");
				this.HasOne<Castellano.TipoPrevision>(x => x.TipoPrevision).ThisKey("TipoPrevisionCodigo").OtherKey("Codigo").Storage("tipoPrevision");
			}
		}

		public class TipoPrevisionConfiguration : Mapping<Castellano.TipoPrevision>
		{
			public TipoPrevisionConfiguration()
			{
				this.Named("dbo.TipoPrevision");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoSubministroAguaConfiguration : Mapping<Castellano.TipoSubministroAgua>
		{
			public TipoSubministroAguaConfiguration()
			{
				this.Named("dbo.TipoSubministroAgua");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TipoViviendaConfiguration : Mapping<Castellano.TipoVivienda>
		{
			public TipoViviendaConfiguration()
			{
				this.Named("dbo.TipoVivienda");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TramoAsignacionFamiliarConfiguration : Mapping<Castellano.TramoAsignacionFamiliar>
		{
			public TramoAsignacionFamiliarConfiguration()
			{
				this.Named("dbo.TramoAsignacionFamiliar");

				this.Map<Int32>(x => x.Codigo).Named("Codigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();

			}
		}

		public class TramoCargaFamiliarConfiguration : Mapping<Castellano.TramoCargaFamiliar>
		{
			public TramoCargaFamiliarConfiguration()
			{
				this.Named("dbo.TramoCargaFamiliar");

				this.Map<Int32>(x => x.AnoNumero).Named("AnoNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.MesNumero).Named("MesNumero").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.TipoCargaFamiliarCodigo).Named("TipoCargaFamiliarCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.TramoAsignacionFamiliarCodigo).Named("TramoAsignacionFamiliarCodigo").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Int32>(x => x.Inicio).Named("Inicio").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<Nullable<Int32>>(x => x.Termino).Named("Termino").UpdateCheck(UpdateCheck.Never);
				this.Map<Int32>(x => x.Valor).Named("Valor").UpdateCheck(UpdateCheck.Never).NotNull();

				this.HasOne<Castellano.AnoMes>(x => x.AnoMes).ThisKey("AnoNumero,MesNumero").OtherKey("AnoNumero,MesNumero").Storage("anoMes");
				this.HasOne<Castellano.TipoCargaFamiliar>(x => x.TipoCargaFamiliar).ThisKey("TipoCargaFamiliarCodigo").OtherKey("Codigo").Storage("tipoCargaFamiliar");
				this.HasOne<Castellano.TramoAsignacionFamiliar>(x => x.TramoAsignacionFamiliar).ThisKey("TramoAsignacionFamiliarCodigo").OtherKey("Codigo").Storage("tramoAsignacionFamiliar");
			}
		}

		public class UnidadConfiguration : Mapping<Castellano.Unidad>
		{
			public UnidadConfiguration()
			{
				this.Named("dbo.Unidad");

				this.Map<Guid>(x => x.EmpresaId).Named("EmpresaId").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Guid>(x => x.Id).Named("Id").PrimaryKey().UpdateCheck(UpdateCheck.Always).NotNull();
				this.Map<Nullable<Guid>>(x => x.AdministradorId).Named("AdministradorId").UpdateCheck(UpdateCheck.Never);
				this.Map<String>(x => x.Nombre).Named("Nombre").UpdateCheck(UpdateCheck.Never).NotNull();
				this.Map<String>(x => x.Descripcion).Named("Descripcion").UpdateCheck(UpdateCheck.Never);

				this.HasOne<Castellano.Persona>(x => x.Administrador).ThisKey("AdministradorId").OtherKey("Id").Storage("administrador");
				this.HasOne<Castellano.Empresa>(x => x.Empresa).ThisKey("EmpresaId").OtherKey("Id").Storage("empresa");
			}
		}

		public class FunctionMapping : FunctionMapping<Context>
		{
			public FunctionMapping()
			{
				this.Map(x => x.FormatInt(
					Parameter<Int32>(param => param.Named("Number"))
					)).Named("dbo.FormatInt").Composable();

				this.Map(x => x.GetRunDigito(
					Parameter<Int32>(param => param.Named("RunCuerpo"))
					)).Named("dbo.GetRunDigito").Composable();
			}
		}
		#endregion
	}
}