using System.Web;
using System.Web.Optimization;

namespace TableReservation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery/jquery-2.2.4.min.js",
                        "~/Scripts/jquery-ui-1.12.1.js",
                        //"~/Scripts/jquery.datatables.min.js",
                        "~/Scripts/jquery.datetimepicker.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      //"~/Content/site.css",
                      //"~/Content/jquery.datatables.css",
                      "~/Content/jquery.datetimepicker.css"));
        }
    }
}
