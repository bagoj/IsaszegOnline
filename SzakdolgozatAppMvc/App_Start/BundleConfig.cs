using System.Web;
using System.Web.Optimization;

namespace SzakdolgozatAppMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
            "~/Scripts/menu.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/Views/login.js"));

            bundles.Add(new ScriptBundle("~/bundles/grid").Include(
                "~/Scripts/jqGrid/grid.locale-en.js",
                "~/Scripts/jqGrid/jquery.jqGrid.js"
                ));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Theme/base/core.css",
                "~/Content/Theme/base/resizable.css",
                "~/Content/Theme/base/selectable.css",
                "~/Content/Theme/base/accordion.css",
                "~/Content/Theme/base/autocomplete.css",
                "~/Content/Theme/base/button.css",
                "~/Content/Theme/base/dialog.css",
                "~/Content/Theme/base/slider.css",
                "~/Content/Theme/base/tabs.css",
                "~/Content/Theme/base/datepicker.css",
                "~/Content/Theme/base/progressbar.css",
                "~/Content/custom-bootstrap4/bootstrap.css",
                "~/Content/bootstrap-table.css",
                "~/Content/toastr.css"
                ));
        }
    }
}
