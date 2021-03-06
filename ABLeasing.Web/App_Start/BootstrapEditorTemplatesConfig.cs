using System;
using System.Web;
using System.Web.Optimization;
using System.Web.WebPages;

namespace ABLeasing.Web
{
    public class BootstrapEditorTemplatesConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles()
        {
            BundleCollection bundles = BundleTable.Bundles;

            bundles.Add(new ScriptBundle("~/Scripts/val").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/validation.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                        "~/Scripts/globalize/globalize.js",
                        "~/Scripts/globalize/cultures/globalize.culture." + System.Globalization.CultureInfo.CurrentCulture.ToString() + ".js",
                        "~/Scripts/lodash.js",
                        "~/Scripts/bootstrap*",
                        "~/Scripts/filebutton.js",
                        "~/Scripts/globalize-datepicker.js",
                        "~/Scripts/select2.js",
                        "~/Scripts/libs/TwitterBootstrapMvcJs-3.0.4.js"
                        ));

            bundles.Add(new ScriptBundle("~/Scripts/md").Include(
                "~/Scripts/MarkdownDeepLib.min.js",
                "~/Scripts/markdown.js"
                ));

            bundles.Add(new StyleBundle("~/Content/vendor").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/fontawesome/font-awesome.css",
                 "~/Content/css/select2.css"
                 ));

            // By default it will exclude the MarkdownDeepLib.min.js file because of its .min.js extension.
            bundles.IgnoreList.Clear();
            // BundleTable.EnableOptimizations = true;
        }
    }
}