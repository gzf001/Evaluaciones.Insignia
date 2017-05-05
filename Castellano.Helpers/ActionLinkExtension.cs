using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Castellano.Helpers
{
    public static class ActionLinkExtension
    {
        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string text, string action, string controller, string area, Castellano.Helpers.TypeButton? typeButton, object dataValue, string css)
        {
            if (!typeButton.HasValue)
            {
                throw new Exception("El tipo de botón es obligatorio");
            }
            //< a class="btn btn-primary btn-xs btn-flat md-trigger" data-value="@aplicacion.Id" data-modal="form-primary" href="#" data-original-title="Editar" data-toggle="tooltip"><i class="fa fa-pencil"></i></a>
            TagBuilder t = new TagBuilder("a");

            if (!string.IsNullOrEmpty(css))
            {
                t.AddCssClass(css);
            }

            if (string.IsNullOrEmpty(action))
            {
                t.MergeAttribute("href", "#");
            }
            else
            {
                if (string.IsNullOrEmpty(area))
                {
                    t.MergeAttribute("href", string.Format("/{0}/{1}", controller, action));
                }
                else
                {
                    t.MergeAttribute("href", string.Format("/{0}/{1}/{2}", area, controller, action));
                }
            }

            if (!object.ReferenceEquals(dataValue, null))
            {
                t.MergeAttribute("data-value", dataValue.ToString());
            }

            switch (typeButton)
            {
                case Castellano.Helpers.TypeButton.Accept:
                    {
                        t.InnerHtml = string.Format("<i>{0}</i>", text);

                        break;
                    }
                case Castellano.Helpers.TypeButton.Edit:
                    {
                        t.MergeAttribute("title", "Editar");

                        t.InnerHtml = string.Format("<i class='fa fa-pencil'>{0}</i>", text);

                        break;
                    }
                case Castellano.Helpers.TypeButton.Delete:
                    {
                        t.MergeAttribute("title", "Eliminar");

                        t.InnerHtml = string.Format("<i class='fa fa-times'>{0}</i>", text);

                        break;
                    }
                case Castellano.Helpers.TypeButton.Back:
                    {
                        t.InnerHtml = string.Format("<i>{0}</i>", text);

                        break;
                    }
            }

            t.MergeAttribute("onclick", "clickEdicion(this)");

            t.MergeAttribute("typeButton", typeButton.Value.ToString());

            return new MvcHtmlString(t.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ActionLinkGridView(Guid id, Castellano.Helpers.TypeButton typeButton)
        {
            TagBuilder t = new TagBuilder("a");

            t.MergeAttribute("data-value", id.ToString());

            switch (typeButton)
            {
                case Castellano.Helpers.TypeButton.Edit:
                    {
                        t.AddCssClass("btn btn-primary btn-xs btn-flat md-trigger");

                        t.MergeAttribute("data-modal", "form-primary");

                        t.MergeAttribute("href", "#");

                        t.MergeAttribute("title", "Editar");

                        t.InnerHtml = "<i class='fa fa-pencil'></i>";

                        break;
                    }
                case Castellano.Helpers.TypeButton.Delete:
                    {
                        t.AddCssClass("btn btn-danger btn-xs");

                        t.MergeAttribute("title", "Eliminar");

                        t.InnerHtml = "<i class='fa fa-times'></i>";

                        break;
                    }
            }

            t.MergeAttribute("typeButton", typeButton.ToString());

            return new MvcHtmlString(t.ToString(TagRenderMode.Normal));
        }
    }
}
