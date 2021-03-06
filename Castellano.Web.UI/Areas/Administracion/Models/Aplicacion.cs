﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Castellano.Web.UI.Areas.Administracion.Models
{
    public class Aplicacion : Castellano.Membresia.Aplicacion
    {
        public Aplicacion() : base()
        {
            this.SelectedPerfil = new List<Guid>();

            this.Perfiles = new List<SelectListItem>();
        }

        public string Accion
        {
            get;
            set;
        }

        public List<Guid> SelectedPerfil
        {
            get;
            set;
        }

        public List<SelectListItem> Perfiles
        {
            get;
            set;
        }

        public new class Aplicaciones
        {
            public List<Aplicacion> data
            {
                get;
                set;
            }
        }
    }
}