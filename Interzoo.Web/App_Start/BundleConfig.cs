using System.Web;
using System.Web.Optimization;

namespace Interzoo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/loadEvent").Include(
                "~/js/loadEvent.js"));
            // --------------------------------------------------------------
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/css/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/blast.min").Include(
                 "~/css/blast.min.css"));

            bundles.Add(new StyleBundle("~/Content/portfolio").Include(
               "~/css/portfolio.css"));

            bundles.Add(new StyleBundle("~/Content/style").Include(
               "~/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesome.min").Include(
                "~/css/font-awesome.min.css"));

            // ----------------------------------------------------------------
            bundles.Add(new ScriptBundle("~/Scripts/jquery-2.2.3").Include(
                "~/js/jquery-2.2.3.min.js"));
                
            bundles.Add(new ScriptBundle("~/Scripts/password").Include(
                "~/js/password.js"));
            bundles.Add(new ScriptBundle("~/Scripts/responsiveslides").Include(
                "~/js/responsiveslides.min.js",
                "~/js/responsiveslides.js"));
            bundles.Add(new ScriptBundle("~/Scripts/scrolling").Include(
                "~/js/scrolling-nav.js",
                "~/js/counter.js"));

            bundles.Add(new ScriptBundle("~/Scripts/portfolio").Include(
               "~/js/jquery.picEyes.js", 
               "~/js/demo-li.js"));
            bundles.Add(new ScriptBundle("~/Scripts/smooth-scrolling").Include(
               "~/js/move-top.js",
               "~/js/easing.js",
               "~/js/scrolling-html-body.js"));

            bundles.Add(new ScriptBundle("~/Scripts/smooth-scrolling-of-move-up").Include(
               "~/js/smooth-scrolling-of-move-up.js",
               "~/js/SmoothScroll.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/color-switch").Include("~/js/blast.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/js/js/bootstrap.js"));




            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));


        }
    }
}
