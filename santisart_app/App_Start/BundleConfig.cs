using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace santisart_app
{ 
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new StyleBundle("~/Bundles/css")
            //   .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/bootstrap-select.css")
                //.Include("~/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/skins/skin-blue.css"));
            bundles.Add(new StyleBundle("~/Content/Core")
                 .Include("~/Content/vendors/bootstrap/dist/css/bootstrap.min.css")
               .Include("~/Content/vendors/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/vendors/nprogress/nprogress.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/vendors/google-code-prettify/dist/prettify.min.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/sweetAlert/sweetalert.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/vendors/bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/vendors/select2/css/select2.min.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/vendors/select2-bootstrap/select2-bootstrap.min.css", new CssRewriteUrlTransformAbsolute())

               .Include("~/Content/vendors/iCheck/skins/all.css", new CssRewriteUrlTransformAbsolute())

               .Include("~/Content/css/custom.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/GApp.WebApp/css/WebApp.Core.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/GApp.WebApp/css/WebApp.Components.css", new CssRewriteUrlTransformAbsolute())

               .Include("~/Content/site.css", new CssRewriteUrlTransformAbsolute()));

            bundles.Add(new ScriptBundle("~/bundles/Core").Include(
                "~/Content/vendors/jquery/dist/jquery.min.js",
                "~/Content/vendors/bootstrap/js/tooltip.js",
                "~/Content/vendors/bootstrap/dist/js/bootstrap.min.js",
                "~/Content/vendors/fastclick/lib/fastclick.js",
                "~/Content/vendors/nprogress/nprogress.js",
                "~/Content/vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js",
                "~/Content/vendors/jquery.hotkeys/jquery.hotkeys.js",
                "~/Content/vendors/google-code-prettify/dist/prettify.min.js",
                "~/Content/sweetAlert/sweetalert.min.js",
                "~/Content/vendors/datatables.net/js/jquery.dataTables.min.js",
                "~/Content/vendors/datatables.net-bs/js/dataTables.bootstrap.js",
                "~/Content/vendors/datatables.net-responsive/js/dataTables.responsive.js",
                "~/Content/vendors/moment/min/moment.min.js",
                  "~/Content/vendors/moment/locale/fr.js",
                "~/Content/vendors/bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                "~/Content/vendors/select2/js/select2.min.js",

                "~/Content/vendors/iCheck/icheck.min.js",

                "~/Content/js_trainingis.js",
                "~/Scripts/libs/js.cookie.js",
                 "~/Content/GApp.WebApp/js/WebApp.Core.js",
                 "~/Content/GApp.WebApp/js/WebApp.Components.js"
                 ));

            // Page - Index
            //
            bundles.Add(new StyleBundle("~/Content/Manager/Index")
                 .Include("~/Content/GApp.WebApp/css/WebApp.Index.css", new CssRewriteUrlTransformAbsolute())
                 .Include("~/Content/GApp.WebApp/css/components/GAppDataTable.WebApp.Component.css", new CssRewriteUrlTransformAbsolute())
                );
            bundles.Add(new ScriptBundle("~/bundles/Manager/Index").Include(
                 "~/Content/GApp.WebApp/js/WebApp.Index.js",
                 "~/Content/GApp.WebApp/js/components/GAppDataTable.WebApp.Component.js"
            ));

            // 
            // Page - Form ( Create, Edit)
            bundles.Add(new StyleBundle("~/Content/Form")
              .Include("~/Content/GApp.WebApp/css/WebApp.Form.css", new CssRewriteUrlTransformAbsolute())
              .Include("~/Content/GApp.WebApp/css/components/GPicture.WebApp.Component.css", new CssRewriteUrlTransformAbsolute())
                );
            bundles.Add(new ScriptBundle("~/bundles/Form").Include(
                "~/Content/GApp.WebApp/js/WebApp.Form.js",
                "~/Content/GApp.WebApp/js/components/GPicture.WebApp.Component.js"
                 ));

            // Page - Details
            //
            bundles.Add(new StyleBundle("~/Content/Manager/Details")
                .Include("~/Content/GApp.WebApp/css/WebApp.Details.css", new CssRewriteUrlTransformAbsolute())
                );


            //
            // Statistic
            //
            bundles.Add(new ScriptBundle("~/bundles/Statistic").Include(
               "~/Content/vendors/Chart.js/dist/Chart.min.js", new CssRewriteUrlTransformAbsolute()
           ));


            // Absences
            //
            bundles.Add(new ScriptBundle("~/bundles/Absences/Create_Absences").Include(
                "~/Content/views/absences/js/Create_Absences.js", new CssRewriteUrlTransformAbsolute()
            ));
            bundles.Add(new StyleBundle("~/Content/Absences/Create_Absences")
               .Include("~/Content/views/absences/css/Create_Absences.css", new CssRewriteUrlTransformAbsolute())
               );

            // Admin Panel : gentelella
            //
            bundles.Add(new StyleBundle("~/Content").Include(
                "~/Content/vendors/bootstrap/dist/css/bootstrap.min.css",
                "~/Content/vendors/font-awesome/css/font-awesome.min.css",
                "~/Content/vendors/nprogress/nprogress.css",
                "~/Content/vendors/iCheck/skins/flat/green.css",
                "~/Content/vendors/google-code-prettify/dist/prettify.min.css",
                "~/Content/vendors/select2/dist/css/select2.min.css",
                "~/Content/vendors/switchery/dist/switchery.min.css",
                "~/Content/vendors/starrr/dist/starrr.css",
                "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.css",
                "~/Content/css/custom.css",
                 "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles").Include(
                "~/Content/vendors/jquery/dist/jquery.min.js",
                "~/Content/vendors/bootstrap/dist/js/bootstrap.min.js",
                "~/Content/vendors/fastclick/lib/fastclick.js",
                "~/Content/vendors/nprogress/nprogress.js",
                "~/Content/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/Content/vendors/iCheck/icheck.min.js",
                "~/Content/vendors/moment/min/moment.min.js",
                "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/vendors/bootstrap-wysiwyg/js/bootstrap-wysiwyg.min.js",
                "~/Content/vendors/jquery.hotkeys/jquery.hotkeys.js",
                "~/Content/vendors/google-code-prettify/src/prettify.js",
                "~/Content/vendors/jquery.tagsinput/src/jquery.tagsinput.js",
                "~/Content/vendors/switchery/dist/switchery.min.js",
                "~/Content/vendors/select2/dist/js/select2.full.min.js",
                "~/Content/vendors/parsleyjs/dist/parsley.min.js",
                "~/Content/vendors/autosize/dist/autosize.min.js",
                "~/Content/vendors/devbridge-autocomplete/dist/jquery.autocomplete.min.js",
                "~/Content/vendors/starrr/dist/starrr.js",
                "~/Content/js/custom.js"
                 ));


            // Page - Login : Gentella
            bundles.Add(new StyleBundle("~/Content/Login")
                .Include("~/Content/vendors/bootstrap/dist/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/vendors/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/vendors/nprogress/nprogress.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/vendors/animate.css/animate.min.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/css/custom.min.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/sweetAlert/sweetalert.css", new CssRewriteUrlTransformAbsolute())
               .Include("~/Content/site.css", new CssRewriteUrlTransformAbsolute())
                );
            bundles.Add(new ScriptBundle("~/bundles/Login").Include(
                "~/Content/vendors/jquery/dist/jquery.min.js",
                 "~/Content/sweetAlert/sweetalert.min.js"
                 ));







            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include());
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendors2/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/all.css"));

        }
    }
}
