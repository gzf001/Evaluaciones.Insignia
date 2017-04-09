using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castellano
{
    [Serializable]
    public class ProveedorPersona
    {
        public enum Tipo
        {
            Persona,
            Proveedor
        }

        public Guid Id
        {
            get;
            set;
        }

        public int RutCuerpo
        {
            get;
            set;
        }

        public char RutDigito
        {
            get;
            set;
        }

        public string RUT
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public Tipo TipoProveedorPersona
        {
            get;
            set;
        }

        public static List<ProveedorPersona> GetAll(FindType findType, string nombre)
        {
            List<Castellano.Persona> personas = new List<Persona>();

            List<Castellano.Proveedor> proveedores = new List<Proveedor>();

            //Busqueda de personas

            switch (findType)
            {
                case FindType.StartsWith:
                    {
                        personas = (from persona in Castellano.Context.Instancia.Personas where persona.Nombre.StartsWith(nombre) select persona).ToList<Castellano.Persona>();

                        break;
                    }
                case FindType.Contains:
                    {
                        personas = (from persona in Castellano.Context.Instancia.Personas where persona.Nombre.Contains(nombre) select persona).ToList<Castellano.Persona>();

                        break;
                    }
                case FindType.EndsWith:
                    {
                        personas = (from persona in Castellano.Context.Instancia.Personas where persona.Nombre.EndsWith(nombre) select persona).ToList<Castellano.Persona>();

                        break;
                    }
                default:
                    {
                        personas = (from persona in Castellano.Context.Instancia.Personas where persona.Nombre == nombre select persona).ToList<Castellano.Persona>();

                        break;
                    }
            }

            //Busqueda de proveedores

            switch (findType)
            {
                case FindType.StartsWith:
                    {
                        proveedores = (from proveedor in Castellano.Context.Instancia.Proveedores where proveedor.RazonSocial.StartsWith(nombre) select proveedor).ToList<Castellano.Proveedor>();

                        break;
                    }
                case FindType.Contains:
                    {
                        proveedores = (from proveedor in Castellano.Context.Instancia.Proveedores where proveedor.RazonSocial.Contains(nombre) select proveedor).ToList<Castellano.Proveedor>();

                        break;
                    }
                case FindType.EndsWith:
                    {
                        proveedores = (from proveedor in Castellano.Context.Instancia.Proveedores where proveedor.RazonSocial.EndsWith(nombre) select proveedor).ToList<Castellano.Proveedor>();

                        break;
                    }
                default:
                    {
                        proveedores = (from proveedor in Castellano.Context.Instancia.Proveedores where proveedor.RazonSocial == nombre select proveedor).ToList<Castellano.Proveedor>();

                        break;
                    }
            }

            List<ProveedorPersona> listaPersona = (from persona in personas
                                                   select new ProveedorPersona
                                                   {
                                                       Id = persona.Id,
                                                       RutCuerpo = persona.RunCuerpo,
                                                       RutDigito = persona.RunDigito,
                                                       RUT = persona.Run,
                                                       Nombre = persona.Nombre,
                                                       TipoProveedorPersona = Tipo.Persona
                                                   }).Distinct().ToList<ProveedorPersona>();

            List<ProveedorPersona> listaProveedor = (from proveedor in proveedores
                                                     select new ProveedorPersona
                                                     {
                                                         Id = proveedor.Id,
                                                         RutCuerpo = proveedor.RutCuerpo,
                                                         RutDigito = proveedor.RutDigito,
                                                         RUT = proveedor.Rut,
                                                         Nombre = proveedor.RazonSocial,
                                                         TipoProveedorPersona = Tipo.Proveedor
                                                     }).Distinct().ToList<ProveedorPersona>();

            List<ProveedorPersona> proveedoresPersonas = new List<ProveedorPersona>();

            if (listaPersona.Any())
            {
                if (listaProveedor.Any())
                {
                    listaPersona.AddRange(listaProveedor);
                }

                proveedoresPersonas = listaPersona;
            }
            else
            {
                proveedoresPersonas = listaProveedor;
            }

            return proveedoresPersonas.Distinct().OrderBy(x => x.Nombre).ToList<ProveedorPersona>();
        }
    }
}
