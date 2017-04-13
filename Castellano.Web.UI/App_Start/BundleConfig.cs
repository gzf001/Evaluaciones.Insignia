﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Castellano.Web.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JS
            bundles.Add(new ScriptBundle("~/Content/js/jquery").Include("~/Content/js/jquery-3.1.1.js"));
            bundles.Add(new ScriptBundle("~/Content/js/bootstrap").Include("~/Content/assets/bootstrap/js/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/Content/js/rut").Include("~/Content/js/jquery.Rut.js"));

            bundles.Add(new ScriptBundle("~/Content/js/jquery.nanoscroller").Include("~/Content/assets/jquery.nanoscroller/javascripts/jquery.nanoscroller.js"));
            bundles.Add(new ScriptBundle("~/Content/js/cleanzone").Include("~/Content/js/cleanzone.js"));
            bundles.Add(new ScriptBundle("~/Content/js/voice-recognition").Include("~/Content/js/voice-recognition.js"));
            bundles.Add(new ScriptBundle("~/Content/js/jquery.gritter").Include("~/Content/assets/jquery.gritter/js/jquery.gritter.js"));
            bundles.Add(new ScriptBundle("~/Content/js/skycons").Include("~/Content/assets/skycons/skycons.js"));
            bundles.Add(new ScriptBundle("~/Content/js/jquery.sparkline").Include("~/Content/assets/jquery.sparkline/jquery.sparkline.min.js"));
            bundles.Add(new ScriptBundle("~/Content/js/jquery.easypiechart").Include("~/Content/assets/jquery.easypiechart/jquery.easypiechart.js"));
            bundles.Add(new ScriptBundle("~/Content/js/intro.js").Include("~/Content/assets/intro.js/intro.js"));
            bundles.Add(new ScriptBundle("~/Content/js/jquery.flot").Include("~/Content/assets/jquery.flot/jquery.flot.js"));
            bundles.Add(new ScriptBundle("~/Content/js/jquery.flot.pie").Include("~/Content/assets/jquery.flot/jquery.flot.pie.js"));
            bundles.Add(new ScriptBundle("~/Content/js/jquery.flot.resize").Include("~/Content/assets/jquery.flot/jquery.flot.resize.js"));
            bundles.Add(new ScriptBundle("~/Content/js/jquery-ui").Include("~/Content/js/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/Content/js/page-dashboard").Include("~/Content/js/page-dashboard.js"));

            //script-js
            bundles.Add(new ScriptBundle("~/js/Layout/layout").Include("~/js/Layout/layOut.js"));

            //CSS
            bundles.Add(new StyleBundle("~/Content/layout").Include("~/Content/assets/css/layout.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/assets/bootstrap/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/style-jquery-ui").Include("~/Content/assets/jquery-ui/jquery-ui.min.css"));
            bundles.Add(new StyleBundle("~/Content/font-awesome").Include("~/Content/assets/font-awesome/css/font-awesome.min.css"));
            bundles.Add(new StyleBundle("~/Content/jquery.nanoscroller").Include("~/Content/assets/jquery.nanoscroller/css/nanoscroller.css"));
            bundles.Add(new StyleBundle("~/Content/jquery.gritter").Include("~/Content/assets/jquery.gritter/css/jquery.gritter.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap.switch").Include("~/Content/assets/bootstrap.switch/css/bootstrap3/bootstrap-switch.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap.datetimepicker").Include("~/Content/assets/bootstrap.datetimepicker/css/bootstrap-datetimepicker.min.css"));
            bundles.Add(new StyleBundle("~/Content/select2").Include("~/Content/assets/jquery.select2/select2.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap.slider").Include("~/Content/assets/bootstrap.slider/css/bootstrap-slider.css"));
            bundles.Add(new StyleBundle("~/Content/intro").Include("~/Content/assets/intro.js/introjs.css"));
            bundles.Add(new StyleBundle("~/Content/style").Include("~/Content/assets/css/style.css"));
        }
    }
}