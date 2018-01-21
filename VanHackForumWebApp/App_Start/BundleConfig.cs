using System.Web;
using System.Web.Optimization;

namespace VanHackForumWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js",
                    "~/Scripts/datatables/jquery.dataTables.min.js",
                    "~/Scripts/datatables/datatables.bootstrap.js",
                    "~/Scripts/Typeahead.bundle.js",
                    "~/Scripts/toastr.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-cerulean.min.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/Typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));
        }
    }
}
