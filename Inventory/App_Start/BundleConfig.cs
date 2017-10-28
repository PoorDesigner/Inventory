using System.Web.Optimization;

namespace Inventory.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/roots").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-{version}.intellisense.js",
                "~/Scripts/jquery.*",
                "~/Scripts/underscore.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/toastr.js"
                )
            );

            bundles.Add(new ScriptBundle("~/scripts/bootstrapdatatables").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                "~/Scripts/DataTables/dataTables.fixedHeader.min.js",
                "~/Scripts/DataTables/dataTables.responsive.min.js",
                "~/Scripts/DataTables/responsive.bootstrap.min.js"
                ));

            bundles.Add(new StyleBundle("~/styles/bootstrapdatatables").Include(
                "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                "~/Content/DataTables/css/fixedHeader.bootstrap.min.css",
                "~/Content/DataTables/css/responsive.bootstrap.min.css"
                ));

            bundles.Add(new StyleBundle("~/styles/roots").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css",
                 "~/Content/toastr.css",
                 "~/Content/bootstrap-theme.css"));
        }
    }
}