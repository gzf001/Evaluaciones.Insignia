using System;
using System.Linq;
namespace Castellano
{
    internal static class Query
    {
        #region ActividadEconomica
        internal static IQueryable<ActividadEconomica> GetActividadEconomicas()
        {
            return
                from actividadEconomica in Context.Instancia.ActividadEconomicas
                select actividadEconomica;
        }

        internal static IQueryable<ActividadEconomica> GetActividadEconomicas(Castellano.SectorActividadEconomica sectorActividadEconomica)
        {
            return
                from actividadEconomica in GetActividadEconomicas()
                where actividadEconomica.SectorActividadEconomica == sectorActividadEconomica
                select actividadEconomica;
        }
        #endregion

        #region ActividadEconomicaPrincipal
        internal static IQueryable<ActividadEconomicaPrincipal> GetActividadEconomicaPrincipales()
        {
            return
                 from actividadEconomicaPrincipal in Context.Instancia.ActividadEconomicaPrincipales
                 select actividadEconomicaPrincipal;
        }
        #endregion

        #region AFCAnoMes
        internal static IQueryable<AFCAnoMes> GetAFCAnoMeses()
        {
            return
                from afcAnoMes in Context.Instancia.AFCAnoMeses
                select afcAnoMes;
        }

        internal static IQueryable<AFCAnoMes> GetAFCAnoMeses(Ano ano, Mes mes)
        {
            return
                from afcAnoMes in Context.Instancia.AFCAnoMeses
                where afcAnoMes.AnoMes.Ano == ano &&
                      afcAnoMes.AnoMes.Mes == mes
                select afcAnoMes;
        }

        internal static IQueryable<AFCAnoMes> GetAFCAnoMeses(AnoMes anoMes)
        {
            return
                from afcAnoMes in Context.Instancia.AFCAnoMeses
                where afcAnoMes.AnoMes == anoMes
                select afcAnoMes;
        }
        #endregion

        #region AFPAnoMes
        internal static IQueryable<AFPAnoMes> GetAFPAnoMeses()
        {
            return
                from AFPAnoMes in Context.Instancia.AFPAnoMeses
                select AFPAnoMes;
        }

        internal static IQueryable<AFPAnoMes> GetAFPAnoMeses(Ano ano, Mes mes)
        {
            return
                from AFPAnoMes in GetAFPAnoMeses()
                where AFPAnoMes.AnoMes.Ano == ano &&
                      AFPAnoMes.AnoMes.Mes == mes
                select AFPAnoMes;
        }

        internal static IQueryable<AFPAnoMes> GetAFPAnoMeses(AnoMes anoMes)
        {
            return
                from AFPAnoMes in GetAFPAnoMeses()
                where AFPAnoMes.AnoMes == anoMes
                select AFPAnoMes;
        }
        #endregion

        #region Ambito
        internal static IQueryable<Ambito> GetAmbitos()
        {
            return
                from ambito in Context.Instancia.Ambitos
                select ambito;
        }
        #endregion

        #region Ano
        internal static IQueryable<Ano> GetAnos()
        {
            return
                from ano in Context.Instancia.Anos
                select ano;
        }

        internal static IQueryable<Ano> GetAnos(bool activo)
        {
            return
                from ano in Context.Instancia.Anos
                where ano.Activo == activo
                select ano;
        }
        #endregion

        #region AnoMes
        internal static IQueryable<AnoMes> GetAnoMeses()
        {
            return
                from anoMes in Context.Instancia.AnoMeses
                select anoMes;
        }

        internal static IQueryable<AnoMes> GetAnoMeses(Ano ano)
        {
            return
                from anoMes in GetAnoMeses()
                where anoMes.Ano == ano
                select anoMes;
        }

        internal static IQueryable<AnoMes> GetAnoMeses(DateTime desde, DateTime hasta)
        {
            return
                from anoMes in Context.Instancia.AnoMeses
                where (anoMes.Termino >= desde)
                && (anoMes.Inicio <= hasta)
                select anoMes;
        }
        #endregion

        #region AreaGeografica
        internal static IQueryable<AreaGeografica> GetAreaGeograficas()
        {
            return
                from areaGeografica in Context.Instancia.AreaGeograficas
                select areaGeografica;
        }
        #endregion

        #region CajaCompensacion
        internal static IQueryable<CajaCompensacion> GetCajaCompensaciones()
        {
            return
                from cajaCompensacion in Context.Instancia.CajaCompensaciones
                select cajaCompensacion;
        }
        #endregion

        #region CajaPrevisionalExRegimen
        internal static IQueryable<CajaPrevisionalExRegimen> GetCajaPrevisionalExRegimenes()
        {
            return
                from cajaPrevisionalExRegimen in Context.Instancia.CajaPrevisionalExRegimenes
                select cajaPrevisionalExRegimen;
        }
        #endregion

        #region Calendario
        internal static IQueryable<Calendario> GetCalendarios()
        {
            return
                from calendario in Context.Instancia.Calendarios
                select calendario;
        }

        internal static IQueryable<Calendario> GetCalendarios(Ano ano)
        {
            return
                from calendario in GetCalendarios()
                where calendario.AnoMes.Ano == ano
                select calendario;
        }

        internal static IQueryable<Calendario> GetCalendarios(AnoMes anoMes)
        {
            return
                from calendario in GetCalendarios()
                where calendario.AnoMes == anoMes
                select calendario;
        }

        internal static IQueryable<Calendario> GetCalendarios(AnoMes anoMes, bool laboral)
        {
            return
                from calendario in GetCalendarios(anoMes)
                where calendario.Dia.Laboral == laboral
                select calendario;
        }

        internal static IQueryable<Calendario> GetCalendarios(DateTime inicio, DateTime termino)
        {
            return
                from calendario in GetCalendarios()
                where calendario.Fecha >= inicio
                && calendario.Fecha <= termino
                select calendario;
        }

        internal static IQueryable<Calendario> GetCalendarios(Semana semana)
        {
            return
                from calendario in GetCalendarios()
                where calendario.Semana == semana
                select calendario;
        }
        #endregion

        #region CentroCosto
        internal static IQueryable<CentroCosto> GetCentroCostos()
        {
            return
                from centroCosto in Context.Instancia.CentroCostos
                select centroCosto;
        }

        internal static IQueryable<CentroCosto> GetCentroCostos(Empresa empresa)
        {
            return
                from centroCosto in GetCentroCostos()
                where centroCosto.Empresa == empresa
                select centroCosto;
        }
        #endregion

        #region Ciudad
        internal static IQueryable<Ciudad> GetCiudades()
        {
            return
                from ciudad in Context.Instancia.Ciudades
                select ciudad;
        }

        internal static IQueryable<Ciudad> GetCiudades(Region region)
        {
            return
                from ciudad in GetCiudades()
                where ciudad.Region == region
                select ciudad;
        }
        #endregion

        #region Comuna
        internal static IQueryable<Comuna> GetComunas()
        {
            return
                from comuna in Context.Instancia.Comunas
                select comuna;
        }

        internal static IQueryable<Comuna> GetComunas(Ciudad ciudad)
        {
            return
                from comuna in GetComunas()
                where comuna.Ciudad == ciudad
                select comuna;
        }
        #endregion

        #region ConfiguracionContable
        internal static IQueryable<ConfiguracionContable> GetConfiguracionContables()
        {
            return
               from configuracionContable in Context.Instancia.ConfiguracionContables
               select configuracionContable;
        }

        internal static IQueryable<ConfiguracionContable> GetConfiguracionContables(Castellano.Empresa empresa)
        {
            return
               from configuracionContable in GetConfiguracionContables()
               where configuracionContable.Empresa == empresa
               select configuracionContable;
        }
        #endregion

        #region Contacto
        internal static IQueryable<Contacto> GetContactos()
        {
            return
                from contacto in Context.Instancia.Contactos
                select contacto;
        }

        internal static IQueryable<Contacto> GetContactos(Proveedor proveedor)
        {
            return
                from contacto in GetContactos()
                where contacto.Proveedor == proveedor
                select contacto;
        }
        #endregion

        #region CorreccionMonetaria
        internal static IQueryable<CorreccionMonetaria> GetCorreccionMonetarias()
        {
            return
                from correccionMonetaria in Castellano.Context.Instancia.CorreccionMonetarias
                select correccionMonetaria;
        }

        internal static IQueryable<CorreccionMonetaria> GetCorreccionMonetarias(Ano anio)
        {
            return
                from correccionMonetaria in GetCorreccionMonetarias()
                where correccionMonetaria.AnoMes.Ano == anio
                select correccionMonetaria;
        }
        #endregion

        #region Cliente
        internal static IQueryable<Cliente> GetClientes()
        {
            return
                from cliente in Castellano.Context.Instancia.Clientes
                select cliente;
        }

        internal static IQueryable<Cliente> GetClientes(Empresa empresa)
        {
            return
                from cliente in GetClientes()
                where cliente.Empresa == empresa
                select cliente;
        }

        internal static IQueryable<Cliente> GetClientes(Empresa empresa, int cuerpo, char digito)
        {
            return
                from cliente in GetClientes(empresa)
                where cliente.RutCuerpo == cuerpo && cliente.RutDigito == digito
                select cliente;
        }

        internal static IQueryable<Cliente> GetClientes(FindType findType, Empresa empresa, string nombre)
        {
            switch (findType)
            {
                case FindType.StartsWith: return from cliente in GetClientes(empresa) where cliente.Nombre.StartsWith(nombre) select cliente;
                case FindType.Contains: return from cliente in GetClientes(empresa) where cliente.Nombre.Contains(nombre) select cliente;
                case FindType.EndsWith: return from cliente in GetClientes(empresa) where cliente.Nombre.EndsWith(nombre) select cliente;
                default: return from cliente in GetClientes(empresa) where cliente.Nombre == nombre select cliente;
            }
        }
        #endregion

        #region CuentaIFRS
        internal static IQueryable<CuentaIFRS> GetCuentaIFRSes()
        {
            return
                from cuentaIFRS in Context.Instancia.CuentaIFRSes
                select cuentaIFRS;
        }

        internal static IQueryable<CuentaIFRS> GetCuentaIFRSes(int ano)
        {
            return
                from cuentaIFRS in GetCuentaIFRSes()
                where cuentaIFRS.AnoNumero == ano
                select cuentaIFRS;
        }

        private static IQueryable<CuentaIFRS> GetCuentaIFRSes(Ano anio)
        {
            return
                from cuentaIFRS in GetCuentaIFRSes()
                where cuentaIFRS.Ano == anio
                select cuentaIFRS;

        }

        internal static IQueryable<CuentaIFRS> GetCuentaIFRSes(Empresa empresa, Ano anio)
        {
            return
                from cuenta in GetCuentaIFRSes(anio)
                where cuenta.Empresa == empresa
                select cuenta;
        }

        internal static IQueryable<CuentaIFRS> GetCuentaIFRSes(Empresa empresa, Ano anio, CuentaIFRSTipoInforme tipoInforme)
        {
            return
                from cuenta in GetCuentaIFRSes(empresa, anio)
                where cuenta.CuentaIFRSTipoInforme == tipoInforme
                select cuenta;
        }

        internal static IQueryable<CuentaIFRS> GetCuentaIFRSes(CuentaIFRSTipoInforme tipoInforme)
        {
            return
                from cuentaIFRS in GetCuentaIFRSes()
                where cuentaIFRS.CuentaIFRSTipoInforme == tipoInforme
                select cuentaIFRS;
        }

        internal static IQueryable<CuentaIFRS> GetCuentaIFRSes(CuentaIFRSClasificacion clasificacion)
        {
            return
                from cuentaIFRS in GetCuentaIFRSes()
                where cuentaIFRS.CuentaIFRSClasificacion == clasificacion
                select cuentaIFRS;
        }

        internal static IQueryable<CuentaIFRS> GetCuentaIFRSes(CuentaIFRSClasificacion clasificacion, CuentaIFRSTipoInforme tipoInforme)
        {
            return
                from cuentaIFRS in GetCuentaIFRSes()
                where cuentaIFRS.CuentaIFRSClasificacion == clasificacion && cuentaIFRS.CuentaIFRSTipoInforme == tipoInforme
                select cuentaIFRS;
        }
        #endregion

        #region CuentaIFRSClasificacion
        internal static IQueryable<CuentaIFRSClasificacion> GetCuentaIFRSClasificaciones()
        {
            return
                from cuentaIFRSClasificacion in Context.Instancia.CuentaIFRSClasificaciones
                select cuentaIFRSClasificacion;
        }

        internal static IQueryable<CuentaIFRSClasificacion> GetCuentaIFRSClasificaciones(CuentaIFRSSubTipo subTipo)
        {
            return
                 from cuentaIFRSClasificacion in GetCuentaIFRSClasificaciones()
                 where cuentaIFRSClasificacion.CuentaIFRSSubTipo == subTipo
                 select cuentaIFRSClasificacion;
        }
        #endregion

        #region CuentaIFRSSubTipo
        internal static IQueryable<CuentaIFRSSubTipo> GetCuentaIFRSSubTipos()
        {
            return
                from cuentaIFRSSubTipo in Context.Instancia.CuentaIFRSSubTipos
                select cuentaIFRSSubTipo;
        }

        internal static IQueryable<CuentaIFRSSubTipo> GetCuentaIFRSSubTipos(CuentaIFRSTipo tipoCuenta)
        {
            return
                from cuentaIFRSSubTipo in GetCuentaIFRSSubTipos()
                where cuentaIFRSSubTipo.CuentaIFRSTipo == tipoCuenta
                select cuentaIFRSSubTipo;
        }
        #endregion

        #region CuentaIFRSTipo
        internal static IQueryable<CuentaIFRSTipo> GetCuentaIFRSTipos()
        {
            return
                from cuentaIFRSTipo in Context.Instancia.CuentaIFRSTipos
                select cuentaIFRSTipo;
        }

        internal static IQueryable<CuentaIFRSTipo> GetCuentaIFRSTipos(CuentaIFRSTipoInforme tipoInforme)
        {
            return
                from cuentaIFRSTipo in GetCuentaIFRSTipos()
                where cuentaIFRSTipo.CuentaIFRSTipoInforme == tipoInforme
                select cuentaIFRSTipo;
        }
        #endregion

        #region CuentaIFRSTipoInforme
        internal static IQueryable<CuentaIFRSTipoInforme> GetCuentaIFRSTipoInformes()
        {
            return
                from cuentaIFRSTipoInforme in Context.Instancia.CuentaIFRSTipoInformes
                select cuentaIFRSTipoInforme;
        }
        #endregion

        #region Departamento
        internal static IQueryable<Departamento> GetDepartamentos()
        {
            return
                from departamento in Context.Instancia.Departamentos
                select departamento;
        }

        internal static IQueryable<Departamento> GetDepartamentos(Empresa empresa)
        {
            return
               from departamento in GetDepartamentos()
               where departamento.Unidad.Empresa == empresa
               select departamento;
        }

        internal static IQueryable<Departamento> GetDepartamentos(Unidad unidad)
        {
            return
                from departamento in GetDepartamentos()
                where departamento.Unidad == unidad
                select departamento;
        }
        #endregion

        #region Dia
        internal static IQueryable<Dia> GetDias()
        {
            return
                from dia in Context.Instancia.Dias
                select dia;
        }

        internal static IQueryable<Dia> GetDias(bool laboral)
        {
            return
                from dia in GetDias()
                where dia.Laboral == laboral
                select dia;
        }
        #endregion

        #region Empresa
        internal static IQueryable<Empresa> GetEmpresas()
        {
            return
                from empresa in Context.Instancia.Empresas
                select empresa;
        }
        #endregion

        #region EstadoCivil
        internal static IQueryable<EstadoCivil> GetEstadoCiviles()
        {
            return
                from estadoCivil in Context.Instancia.EstadoCiviles
                select estadoCivil;
        }
        #endregion

        #region EquivalenciaTransferBCI
        internal static IQueryable<EquivalenciaTransferenciaBCI> GetEquivalenciaTransferenciaBCIs()
        {
            return
                from equivalenciaTransferenciaBCI in Context.Instancia.EquivalenciaTransferenciaBCIs
                select equivalenciaTransferenciaBCI;
        }

        internal static IQueryable<EquivalenciaTransferenciaBCI> GetEquivalenciaTransferenciaBCIs(Castellano.InstitucionValorSeguro banco)
        {
            return
                from equivalenciaTransferenciaBCI in GetEquivalenciaTransferenciaBCIs()
                where equivalenciaTransferenciaBCI.InstitucionValorSeguro == banco
                select equivalenciaTransferenciaBCI;
        }
        #endregion

        #region Feriado
        internal static IQueryable<Feriado> GetFeriados()
        {
            return
                from feriado in Context.Instancia.Feriados
                select feriado;
        }

        internal static IQueryable<Feriado> GetFeriados(Ano ano)
        {
            return
                from feriado in GetFeriados()
                where feriado.Calendario.AnoMes.Ano == ano
                && (feriado.EmpresaId == null)
                && (feriado.CentroCostoId == null)
                select feriado;
        }

        internal static IQueryable<Feriado> GetFeriados(CentroCosto centroCosto, Ano ano)
        {
            return
                from feriado in GetFeriados()
                where feriado.Calendario.AnoMes.Ano == ano
                && (feriado.Empresa == null || feriado.Empresa == centroCosto.Empresa)
                && (feriado.CentroCosto == null || feriado.CentroCosto == centroCosto)
                select feriado;
        }
        #endregion

        #region FormaPago
        internal static IQueryable<FormaPago> GetFormaPagos()
        {
            return
                from formaPago in Context.Instancia.FormaPagos
                select formaPago;
        }
        #endregion

        #region InstitucionSalud
        internal static IQueryable<InstitucionSalud> GetInstitucionSaludes()
        {
            return
                from institucionSalud in Context.Instancia.InstitucionSaludes
                select institucionSalud;
        }

        internal static IQueryable<InstitucionSalud> GetInstitucionSaludes(bool isapre)
        {
            return
                from institucionSalud in GetInstitucionSaludes()
                where institucionSalud.Fonasa != isapre
                select institucionSalud;
        }
        #endregion

        #region InsitucionSaludAnoMes
        internal static IQueryable<InstitucionSaludAnoMes> GetInstitucionSaludAnoMeses()
        {
            return
                from insitucionSaludAnoMes in Context.Instancia.InstitucionSaludAnoMeses
                select insitucionSaludAnoMes;
        }

        internal static IQueryable<InstitucionSaludAnoMes> GetInstitucionSaludAnoMeses(AnoMes anoMes)
        {
            return
                from insitucionSaludAnoMes in GetInstitucionSaludAnoMeses()
                where insitucionSaludAnoMes.AnoMes == anoMes
                select insitucionSaludAnoMes;
        }
        #endregion

        #region InstitucionValorSeguro
        internal static IQueryable<InstitucionValorSeguro> GetInstitucionValorSeguros()
        {
            return
                from institucionValorSeguro in Context.Instancia.InstitucionValorSeguros
                select institucionValorSeguro;
        }

        internal static IQueryable<InstitucionValorSeguro> GetInstitucionValorSeguros(TipoInstitucionValorSeguro tipoInstitucionValorSeguro)
        {
            return
                from institucionValorSeguro in GetInstitucionValorSeguros()
                where institucionValorSeguro.TipoInstitucionValorSeguro == tipoInstitucionValorSeguro
                select institucionValorSeguro;
        }
        #endregion

        #region InstitucionValorSeguroTipoAhorro
        internal static IQueryable<InstitucionValorSeguroTipoAhorro> GetInstitucionValorSeguroTipoAhorros()
        {
            return
                from institucionValorSeguroTipoAhorro in Context.Instancia.InstitucionValorSeguroTipoAhorros
                select institucionValorSeguroTipoAhorro;
        }

        internal static IQueryable<InstitucionValorSeguroTipoAhorro> GetInstitucionValorSeguroTipoAhorros(TipoAhorro tipoAhorro)
        {
            return
                from institucionValorSeguroTipoAhorro in GetInstitucionValorSeguroTipoAhorros()
                where institucionValorSeguroTipoAhorro.TipoAhorro == tipoAhorro
                select institucionValorSeguroTipoAhorro;
        }

        internal static IQueryable<InstitucionValorSeguroTipoAhorro> GetInstitucionValorSeguroTipoAhorros(TipoInstitucionValorSeguro tipoInstitucionValorSeguro)
        {
            return
                from institucionValorSeguroTipoAhorro in GetInstitucionValorSeguroTipoAhorros()
                where GetInstitucionValorSeguros(tipoInstitucionValorSeguro).Contains<InstitucionValorSeguro>(institucionValorSeguroTipoAhorro.InstitucionValorSeguro)
                select institucionValorSeguroTipoAhorro;
        }

        internal static IQueryable<InstitucionValorSeguroTipoAhorro> GetInstitucionValorSeguroTipoAhorros(TipoInstitucionValorSeguro tipoInstitucionValorSeguro, TipoAhorro tipoAhorro)
        {
            return
                from institucionValorSeguroTipoAhorro in GetInstitucionValorSeguroTipoAhorros(tipoInstitucionValorSeguro)
                where institucionValorSeguroTipoAhorro.TipoAhorro == tipoAhorro
                select institucionValorSeguroTipoAhorro;
        }
        #endregion

        #region ImpuestoUnico
        internal static IQueryable<ImpuestoUnico> GetImpuestoUnicos()
        {
            return
                from impuestoUnico in Context.Instancia.ImpuestoUnicos
                select impuestoUnico;
        }

        internal static IQueryable<ImpuestoUnico> GetImpuestoUnicos(AnoMes anoMes)
        {
            return
                from impuestoUnico in GetImpuestoUnicos()
                where impuestoUnico.AnoMes == anoMes
                select impuestoUnico;
        }
        #endregion

        #region IPC
        internal static IQueryable<IPC> GetIPCes()
        {
            return
                from IPC in Context.Instancia.IPCes
                select IPC;
        }
        #endregion

        #region Mes
        internal static IQueryable<Mes> GetMeses()
        {
            return
                from mes in Context.Instancia.Meses
                select mes;
        }

        internal static IQueryable<Mes> GetMeses(DateTime desde, DateTime hasta)
        {
            return
                from anoMes in GetAnoMeses(desde, hasta)
                orderby anoMes.Inicio
                select anoMes.Mes;
        }
        #endregion

        #region Moneda
        internal static IQueryable<Moneda> GetMonedas()
        {
            return
                from moneda in Context.Instancia.Monedas
                select moneda;
        }
        #endregion

        #region MonedaDiaria
        internal static IQueryable<MonedaDiaria> GetMonedaDiarias()
        {
            return
                from monedaDiaria in Context.Instancia.MonedaDiarias
                select monedaDiaria;
        }

        internal static IQueryable<MonedaDiaria> GetMonedaDiarias(TipoMoneda tipoMoneda)
        {
            return
                from monedaDiaria in GetMonedaDiarias()
                where monedaDiaria.TipoMoneda == tipoMoneda
                select monedaDiaria;
        }

        internal static IQueryable<MonedaDiaria> GetMonedaDiarias(TipoMoneda tipoMoneda, AnoMes anoMes)
        {
            return
                from monedaDiaria in GetMonedaDiarias(tipoMoneda)
                where monedaDiaria.Calendario.AnoMes == anoMes
                select monedaDiaria;
        }
        #endregion

        #region MonedaMensual
        internal static IQueryable<MonedaMensual> GetMonedaMensuales()
        {
            return
                from monedaMensual in Context.Instancia.MonedaMensuales
                select monedaMensual;
        }

        internal static IQueryable<MonedaMensual> GetMonedaMensuales(TipoMoneda tipoMoneda)
        {
            return
                from monedaMensual in GetMonedaMensuales()
                where monedaMensual.TipoMoneda == tipoMoneda
                select monedaMensual;
        }

        internal static IQueryable<MonedaMensual> GetMonedaMensuales(TipoMoneda tipoMoneda, Ano ano)
        {
            return
                from monedaMensual in GetMonedaMensuales(tipoMoneda)
                where monedaMensual.AnoMes.Ano == ano
                select monedaMensual;
        }

        internal static IQueryable<MonedaMensual> GetMonedaMensuales(TipoMoneda tipoMoneda, AnoMes anoMes)
        {
            return
                from monedaMensual in GetMonedaMensuales(tipoMoneda, anoMes)
                where monedaMensual.TipoMoneda == tipoMoneda &&
                      monedaMensual.AnoMes == anoMes
                select monedaMensual;
        }
        #endregion

        #region Mutual
        internal static IQueryable<Mutual> GetMutuales()
        {
            return
                from mutual in Context.Instancia.Mutuales
                select mutual;
        }
        #endregion

        #region Nacionalidad
        internal static IQueryable<Nacionalidad> GetNacionalidades()
        {
            return
                from nacionalidad in Context.Instancia.Nacionalidades
                select nacionalidad;
        }
        #endregion

        #region NivelEducacional
        internal static IQueryable<NivelEducacional> GetNivelEducacionales()
        {
            return
                from nivelEducacional in Context.Instancia.NivelEducacionales
                select nivelEducacional;
        }
        #endregion

        #region ParametroPrevisional
        internal static IQueryable<ParametroPrevisional> GetParametroPrevisionales()
        {
            return
                from parametroPrevisional in Context.Instancia.ParametroPrevisionales
                select parametroPrevisional;
        }
        #endregion

        #region Parentesco
        internal static IQueryable<Parentesco> GetParentescos()
        {
            return
                from parentesco in Context.Instancia.Parentescos
                select parentesco;
        }
        #endregion

        #region Persona
        internal static IQueryable<Persona> GetPersonas()
        {
            return
                from persona in Context.Instancia.Personas
                select persona;
        }

        internal static IQueryable<Persona> GetPersonas(FindType findType, string filter)
        {
            switch (findType)
            {
                case FindType.StartsWith: return from usuario in GetPersonas() where (usuario.Nombre.StartsWith(filter)) select usuario;
                case FindType.Contains: return from usuario in GetPersonas() where (usuario.Nombre.Contains(filter)) select usuario;
                case FindType.EndsWith: return from usuario in GetPersonas() where (usuario.Nombre.EndsWith(filter)) select usuario;
                default: return from usuario in GetPersonas() where (usuario.Nombre == filter) select usuario;
            }
        }

        internal static IQueryable<Persona> GetPersonas(int cuerpo, char digito)
        {
            return
                from persona in GetPersonas()
                where persona.RunCuerpo == cuerpo
                && persona.RunDigito == digito
                select persona;
        }
        #endregion

        #region Proveedor
        internal static IQueryable<Proveedor> GetProveedores()
        {
            return
                from proveedor in Context.Instancia.Proveedores
                select proveedor;
        }
        #endregion

        #region PuebloIndigena
        internal static IQueryable<PuebloIndigena> GetPuebloIndigenas()
        {
            return
                from puebloIndigena in Context.Instancia.PuebloIndigenas
                select puebloIndigena;
        }
        #endregion

        #region RegimenPrevisional
        internal static IQueryable<RegimenPrevisional> GetRegimenPrevisionales()
        {
            return
                from regimenPrevisional in Context.Instancia.RegimenPrevisionales
                select regimenPrevisional;
        }
        #endregion

        #region Region
        internal static IQueryable<Region> GetRegiones()
        {
            return
                from region in Context.Instancia.Regiones
                select region;
        }
        #endregion

        #region Secuencia
        internal static IQueryable<Secuencia> GetSecuencias()
        {
            return
                from secuencia in Context.Instancia.Secuencias
                select secuencia;
        }
        #endregion

        #region SecuenciaCentroCosto
        internal static IQueryable<SecuenciaCentroCosto> GetSecuenciaCentroCostos()
        {
            return
                from secuenciaCentroCosto in Context.Instancia.SecuenciaCentroCostos
                select secuenciaCentroCosto;
        }

        internal static IQueryable<SecuenciaCentroCosto> GetSecuenciaCentroCostos(Empresa empresa)
        {
            return
                from secuenciaCentroCostos in GetSecuenciaCentroCostos()
                where secuenciaCentroCostos.Empresa == empresa
                select secuenciaCentroCostos;
        }
        #endregion

        #region SecuenciaEmpresa
        internal static IQueryable<SecuenciaEmpresa> GetSecuenciaEmpresas()
        {
            return
                from secuenciaEmpresa in Context.Instancia.SecuenciaEmpresas
                select secuenciaEmpresa;
        }

        internal static IQueryable<SecuenciaEmpresa> GetSecuenciaEmpresas(Empresa empresa)
        {
            return
                from secuenciaEmpresa in GetSecuenciaEmpresas()
                where secuenciaEmpresa.Empresa == empresa
                select secuenciaEmpresa;
        }
        #endregion

        #region Semana
        internal static IQueryable<Semana> GetSemanas()
        {
            return
                from semana in Context.Instancia.Semanas
                select semana;
        }

        internal static IQueryable<Semana> GetSemanas(AnoMes anoMes)
        {
            return
                from semana in GetSemanas()
                where semana.AnoMes == anoMes
                select semana;
        }

        internal static IQueryable<Semana> GetSemanas(DateTime desde, DateTime hasta)
        {
            return
                from semana in GetSemanas()
                where semana.Termino >= desde && semana.Inicio <= hasta
                select semana;
        }
        #endregion

        #region SectorActividadEconomica
        internal static IQueryable<SectorActividadEconomica> GetSectorActividadEconomicas()
        {
            return
                from sectorActividadEconomica in Context.Instancia.SectorActividadEconomicas
                select sectorActividadEconomica;
        }

        internal static IQueryable<SectorActividadEconomica> GetSectorActividadEconomicas(Castellano.ActividadEconomicaPrincipal actividadEconomicaPrincipal)
        {
            return
                from sectorActividadEconomica in Context.Instancia.SectorActividadEconomicas
                where sectorActividadEconomica.ActividadEconomicaPrincipal == actividadEconomicaPrincipal
                select sectorActividadEconomica;
        }
        #endregion

        #region Sexo
        internal static IQueryable<Sexo> GetSexos()
        {
            return
                from sexo in Context.Instancia.Sexos
                select sexo;
        }
        #endregion

        #region SituacionLaboral
        internal static IQueryable<SituacionLaboral> GetSituacionLaborales()
        {
            return
                from situacionLaboral in Context.Instancia.SituacionLaborales
                select situacionLaboral;
        }
        #endregion

        #region TramoCargaFamiliar
        internal static IQueryable<TramoCargaFamiliar> GetTramoCargaFamiliares()
        {
            return
                from tramoCargaFamiliar in Context.Instancia.TramoCargaFamiliares
                select tramoCargaFamiliar;
        }

        internal static IQueryable<TramoCargaFamiliar> GetTramoCargaFamiliares(Ano ano, Mes mes)
        {
            return
                from tramoCargaFamiliar in GetTramoCargaFamiliares()
                where tramoCargaFamiliar.AnoMes.Ano == ano &&
                      tramoCargaFamiliar.AnoMes.Mes == mes
                select tramoCargaFamiliar;
        }

        internal static IQueryable<TramoCargaFamiliar> GetTramoCargaFamiliares(Ano ano, Mes mes, TipoCargaFamiliar tipoCargaFamiliar)
        {
            return
                from tramoCargaFamiliar in GetTramoCargaFamiliares(ano, mes)
                where tramoCargaFamiliar.TipoCargaFamiliar == tipoCargaFamiliar
                select tramoCargaFamiliar;
        }

        internal static IQueryable<TramoCargaFamiliar> GetTramoCargaFamiliares(AnoMes anoMes)
        {
            return
                from tramoCargaFamiliar in GetTramoCargaFamiliares()
                where tramoCargaFamiliar.AnoMes == anoMes
                select tramoCargaFamiliar;
        }
        #endregion

        #region TipoAdministracion
        internal static IQueryable<TipoAdministracion> GetTipoAdministraciones()
        {
            return
                from tipoAdministracion in Context.Instancia.TipoAdministraciones
                select tipoAdministracion;
        }
        #endregion

        #region TipoAFC
        internal static IQueryable<TipoAFC> GetTipoAFCes()
        {
            return
                from tipoAFC in Context.Instancia.TipoAFCes
                select tipoAFC;
        }
        #endregion

        #region TipoAhorro
        internal static IQueryable<TipoAhorro> GetTipoAhorros()
        {
            return
                from tipoAhorro in Context.Instancia.TipoAhorros
                select tipoAhorro;
        }
        #endregion

        #region TipoAtencionMedica
        internal static IQueryable<TipoAtencionMedica> GetTipoAtencionMedicas()
        {
            return
                from tipoAtencionMedica in Context.Instancia.TipoAtencionMedicas
                select tipoAtencionMedica;
        }
        #endregion

        #region TipoCargaFamiliar
        internal static IQueryable<TipoCargaFamiliar> GetTipoCargaFamiliares()
        {
            return
                from tipoCargaFamiliar in Context.Instancia.TipoCargaFamiliares
                select tipoCargaFamiliar;
        }
        #endregion

        #region TipoCuenta
        internal static IQueryable<TipoCuenta> GetTipoCuentas()
        {
            return
                from tipoCuenta in Context.Instancia.TipoCuentas
                select tipoCuenta;
        }
        #endregion

        #region TipoEstablecimientoSalud
        internal static IQueryable<TipoEstablecimientoSalud> GetTipoEstablecimientoSaludes()
        {
            return
               from tipoEstablecimientoSalud in Context.Instancia.TipoEstablecimientoSaludes
               select tipoEstablecimientoSalud;
        }
        #endregion

        #region TipoInstitucionValorSeguro
        internal static IQueryable<TipoInstitucionValorSeguro> GetTipoInstitucionValorSeguros()
        {
            return
                from tipoInstitucionValorSeguro in Context.Instancia.TipoInstitucionValorSeguros
                select tipoInstitucionValorSeguro;
        }

        internal static IQueryable<TipoInstitucionValorSeguro> GetTipoInstitucionValorSeguros(TipoAhorro tipoAhorro)
        {
            return
                from tipoInstitucionValorSeguro in GetTipoInstitucionValorSeguros()
                where GetInstitucionValorSeguroTipoAhorros(tipoAhorro).Select<InstitucionValorSeguroTipoAhorro, TipoInstitucionValorSeguro>(x => x.InstitucionValorSeguro.TipoInstitucionValorSeguro).Contains<TipoInstitucionValorSeguro>(tipoInstitucionValorSeguro)
                select tipoInstitucionValorSeguro;
        }
        #endregion

        #region TipoMoneda
        internal static IQueryable<TipoMoneda> GetTipoMonedas()
        {
            return
                from tipoMoneda in Context.Instancia.TipoMonedas
                select tipoMoneda;
        }

        internal static IQueryable<TipoMoneda> GetTipoMonedas(TipoPrevision tipoPrevision)
        {
            return
                from tipoMoneda in GetTipoMonedas()
                where GetTipoMonedaTipoPrevisiones(tipoPrevision).Select<TipoMonedaTipoPrevision, TipoMoneda>(x => x.TipoMoneda).Contains<TipoMoneda>(tipoMoneda)
                select tipoMoneda;
        }
        #endregion

        #region TipoMonedaTipoPrevision
        internal static IQueryable<TipoMonedaTipoPrevision> GetTipoMonedaTipoPrevisiones()
        {
            return
                from tipoMonedaTipoPrevision in Context.Instancia.TipoMonedaTipoPrevisiones
                select tipoMonedaTipoPrevision;
        }

        internal static IQueryable<TipoMonedaTipoPrevision> GetTipoMonedaTipoPrevisiones(TipoPrevision tipoPrevision)
        {
            return
                from tipoMonedaTipoPrevision in GetTipoMonedaTipoPrevisiones()
                where tipoMonedaTipoPrevision.TipoPrevision == tipoPrevision
                select tipoMonedaTipoPrevision;
        }
        #endregion

        #region TipoMonedaLegislacionLaboral
        internal static IQueryable<TipoMonedaLegislacionLaboral> GetTipoMonedaLegislacionLaborales()
        {
            return
                from tipoMonedaLegislacionLaborales in Context.Instancia.TipoMonedaLegislacionLaborales
                select tipoMonedaLegislacionLaborales;
        }
        #endregion

        #region TipoPrevision
        internal static IQueryable<TipoPrevision> GetTipoPrevisiones()
        {
            return
                from tipoPrevision in Context.Instancia.TipoPrevisiones
                select tipoPrevision;
        }
        #endregion

        #region TipoSubministroAgua
        internal static IQueryable<TipoSubministroAgua> GetTipoSubministroAguas()
        {
            return
                from tipoSubministroAgua in Context.Instancia.TipoSubministroAguas
                select tipoSubministroAgua;
        }
        #endregion

        #region TipoVivienda
        internal static IQueryable<TipoVivienda> GetTipoViviendas()
        {
            return
                from tipoVivienda in Context.Instancia.TipoViviendas
                select tipoVivienda;
        }
        #endregion

        #region TramoAsignacionFamiliar
        internal static IQueryable<TramoAsignacionFamiliar> GetTramoAsignacionFamiliares()
        {
            return
                from tramoAsignacionFamiliar in Context.Instancia.TramoAsignacionFamiliares
                select tramoAsignacionFamiliar;
        }
        #endregion

        #region Unidad
        internal static IQueryable<Unidad> GetUnidades()
        {
            return
                from unidad in Context.Instancia.Unidades
                select unidad;
        }

        internal static IQueryable<Unidad> GetUnidades(Empresa empresa)
        {
            return
            from unidad in GetUnidades()
            where unidad.Empresa == empresa
            select unidad;
        }
        #endregion

    }
}