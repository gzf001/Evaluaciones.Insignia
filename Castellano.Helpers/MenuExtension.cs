﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Castellano.Helpers
{
    public static class MenuExtension
    {
        public static MvcHtmlString Menu(this HtmlHelper helper, Guid usuarioId)
        {
            Castellano.Membresia.Usuario usuario = Castellano.Membresia.Usuario.Get(usuarioId);

            Castellano.Persona persona = usuario.Persona;

            TagBuilder t = new TagBuilder("ul");

            t.Attributes.Add("id", "MenuPrincipal");

            t.AddCssClass("cl-vnavigation");

            bool primero = true;

            foreach (Castellano.Membresia.Aplicacion aplicacion in Castellano.Membresia.Aplicacion.GetAll(persona))
            {
                List<Castellano.Membresia.MenuItem> itemPadre = Castellano.Membresia.MenuItem.GetAll(Castellano.Membresia.Menu.MenuPrincipal, aplicacion, aplicacion.Inicio, false);

                t.InnerHtml += "<li><a href='#'><i class='fa fa-home'></i><span>" + aplicacion.Nombre + "</span></a>";
                t.InnerHtml += "<ul class='sub-menu'>";

                foreach (Castellano.Membresia.MenuItem menuItem in itemPadre)
                {
                    List<Castellano.Membresia.MenuItem> items = Castellano.Membresia.MenuItem.GetAll(menuItem);

                    if (items.Any())
                    {
                        if(primero)
                        {
                            t.InnerHtml += "<li class='active'><a href='#'><span>" + menuItem.Nombre + "</span><i class='fa fa-chevron-down'></i></a>";

                            primero = false;
                        }
                        else
                        {
                            t.InnerHtml += "<li><a href='#'>" + menuItem.Nombre + "<i class='fa fa-chevron-down'></i></a>";
                        }
                        
                        t.InnerHtml += "<ul class='sub-menu'>";
                        t.InnerHtml += MenuExtension.MenuString(menuItem, 10);
                        t.InnerHtml += "</ul></li>";
                    }
                    else
                    {
                        if (primero)
                        {
                            t.InnerHtml += "<li class='active'><a href='#'>" + menuItem.Nombre + "</a></li>";

                            primero = false;
                        }
                        else
                        {
                            t.InnerHtml += "<li><a href='#'>" + menuItem.Nombre + "</a></li>";
                        }
                    }
                }

                t.InnerHtml += "</ul></li>";
            }

            return new MvcHtmlString(t.ToString(TagRenderMode.Normal));
        }

        private static string MenuString(Castellano.Membresia.MenuItem menuItem, int padding)
        {
            string retorno = string.Empty;

            foreach (Castellano.Membresia.MenuItem m in Castellano.Membresia.MenuItem.GetAll(menuItem))
            {
                string style = string.Format("style='padding-left: {0}px;'", padding);

                List<Castellano.Membresia.MenuItem> items = Castellano.Membresia.MenuItem.GetAll(m);

                if (items.Any())
                {
                    retorno += string.Format("<li><a href='{0}'><span {1}>" + m.Nombre + "</span><i class='fa fa-chevron-down parent'></i></a>", m.Url, style);
                    retorno += "<ul class=\"sub-menu\">";
                    retorno += MenuExtension.MenuString(m, padding + 5);
                    retorno += "</ul></li>";
                }
                else
                {
                    retorno += string.Format("<li><a href='{0}'><span {1}>" + m.Nombre + "</span></a>", m.Url, style);
                    retorno += "</li>";
                }
            }

            return retorno;
        }
    }
}