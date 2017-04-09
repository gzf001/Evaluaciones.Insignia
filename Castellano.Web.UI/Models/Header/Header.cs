using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Castellano.Web.UI.Models.Header
{
    public class Header
    {
        private string run;
        private string userName;

        public string UserName
        {
            get
            {
                return "Guillermo Zuleta Flores";
            }
            set
            {
                userName = value;
            }
        }

        public string Run
        {
            get
            {
                return run;
            }
            set
            {
                run = value;
            }
        }

        //public string UserName
        //{
        //    get
        //    {
        //        string run = HttpContext.Current.Items[this.Run] == null ? string.Empty : HttpContext.Current.Items[this.Run] as string;

        //        if (string.IsNullOrEmpty(run))
        //        {
        //            int runCuerpo = int.Parse(run.Substring(0, run.Length - 1));

        //            char runDigito = char.Parse(run.Substring(run.Length - 1, 1));

        //            Castellano.Persona persona = Castellano.Persona.Get(runCuerpo, runDigito);

        //            return string.Format("{0} {1} {2}", persona.Nombres, persona.ApellidoPaterno, string.IsNullOrEmpty(persona.ApellidoMaterno) ? persona.ApellidoMaterno : string.Empty);
        //        }
        //        else
        //        {
        //            return string.Empty;
        //        }
        //    }
        //    set
        //    {
        //        HttpContext.Current.Items[this.Run] = this.Run;
        //    }
        //}
    }
}