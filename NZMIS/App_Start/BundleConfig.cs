using System.Web;
using System.Web.Optimization;

namespace NZMIS
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Content/plugins/datatables/jquery.dataTables.js",
                "~/Content/plugins/inputmask/jquery.inputmask.bundle.js",
                "~/Content/plugins/moment/moment.min.js",
                "~/Content/plugins/select2/js/select2.full.js",
                "~/Content/plugins/sweetalert2/sweetalert2.js",
                "~/Content/plugins/toastr/toastr.min.js",
                "~/Content/dist/js/adminlte.js",
                "~/Content/dist/js/demo.js",
                "~/Content/dist/js/pages/dashboard.js"

                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      // "~/Content/bootstrap.css",
                      "~/Content/plugins/toastr/toastr.css",
                      "~/Content/plugins/sweetalert2/sweetalert2.css",
                      "~/Content/plugins/select2/css/select2.css",
                      "~/Content/dist/css/adminlte.css",
                      "~/Content/plugins/fontawesome-free/css/all.min.css", 
                      "~/Content/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                      "~/Content/plugins/icheck-bootstrap/icheck-bootstrap.min.css", 
                      "~/Content/plugins/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"
                      // ,"~/Content/site.css"
                      ));
        }
    }
}
