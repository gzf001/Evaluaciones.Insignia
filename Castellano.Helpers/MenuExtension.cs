using System;
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
                List<Castellano.Membresia.MenuItem> itemPadre = Castellano.Membresia.MenuItem.GetAll(Castellano.Membresia.Menu.MenuPrincipal, aplicacion, aplicacion.Inicio);

                t.InnerHtml += "<li><a href='#'><i class='fa fa-home'></i><span>" + aplicacion.Nombre + "</span></a>";
                t.InnerHtml += "<ul class='sub-menu'>";

                foreach (Castellano.Membresia.MenuItem menuItem in itemPadre)
                {
                    List<Castellano.Membresia.MenuItem> items = Castellano.Membresia.MenuItem.GetAll(menuItem);

                    if (items.Any())
                    {
                        if (primero)
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
                            t.InnerHtml += string.Format("<li class='active'><a href='{0}'>{1}</a></li>", menuItem.Url, menuItem.Nombre);

                            primero = false;
                        }
                        else
                        {
                            t.InnerHtml += string.Format("<li><a href='{0}'>{1}</a></li>", menuItem.Url, menuItem.Nombre);
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

        public static MvcHtmlString MenuOrderable(this HtmlHelper helper, Castellano.Membresia.Aplicacion aplicacion)
        {
            if (!aplicacion.MenuItemId.HasValue)
            {
                throw new Exception("La aplicación no tiene la relación con el ítem de menú root");
            }

            TagBuilder t = new TagBuilder("div");

            t.Attributes.Add("id", "menu");

            t.AddCssClass("dd");

            t.InnerHtml += "<ol class='dd-list'>";

            foreach (Castellano.Membresia.MenuItem menuItem in Castellano.Membresia.MenuItem.GetAll(Castellano.Membresia.Menu.MenuPrincipal, aplicacion, aplicacion.Inicio))
            {
                t.InnerHtml += "<li class='dd-item' data-id='" + menuItem.Id.ToString() + "'>";

                t.InnerHtml += string.Format("<div class='dd-handle'>{0}</div>", menuItem.Nombre);

                t.InnerHtml += string.Format("<div>{0}{1}{2}</div>", Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(menuItem.Id, menuItem.MenuItemId, TypeButton.Add), Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(menuItem.Id, menuItem.MenuItemId, TypeButton.Edit), Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(menuItem.Id, menuItem.MenuItemId, TypeButton.Delete));

                string html = MenuExtension.MenuOrderable(menuItem);

                if (string.IsNullOrEmpty(html))
                {
                    t.InnerHtml += "</li>";
                }
                else
                {
                    t.InnerHtml += "<ol class='dd-list'>";

                    t.InnerHtml += html;

                    t.InnerHtml += "</ol></li>";
                }
            }

            t.InnerHtml += "</ol>";

            return new MvcHtmlString(t.ToString(TagRenderMode.Normal));
        }

        private static string MenuOrderable(Castellano.Membresia.MenuItem menuItem)
        {
            string retorno = string.Empty;

            foreach (Castellano.Membresia.MenuItem m in Castellano.Membresia.MenuItem.GetAll(menuItem))
            {
                List<Castellano.Membresia.MenuItem> items = Castellano.Membresia.MenuItem.GetAll(m);

                if (items.Any())
                {
                    retorno += string.Format("<li class='dd-item' data-id='{0}'>", m.Id);
                    retorno += string.Format("<div class='dd-handle'>{0}</div>", m.Nombre);
                    retorno += string.Format("<div>{0}{1}{2}</div>", Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(m.Id, m.MenuItemId, TypeButton.Add), Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(m.Id, m.MenuItemId, TypeButton.Edit), Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(m.Id, m.MenuItemId, TypeButton.Delete));
                    retorno += "<ol class='dd-list'>";
                    retorno += MenuExtension.MenuOrderable(m);
                    retorno += "</ol></li>";
                }
                else
                {
                    retorno += string.Format("<li class='dd-item' data-id='{0}'>", m.Id);
                    retorno += string.Format("<div class='dd-handle'>{0}</div>", m.Nombre);
                    retorno += string.Format("<div>{0}{1}</div>", Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(m.Id, m.MenuItemId, TypeButton.Edit), Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(m.Id, m.MenuItemId, TypeButton.Delete));
                    retorno += "</li>";
                }
            }

            return retorno;
        }
    }
}