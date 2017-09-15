using SampleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.Data.Entity;
using SampleWebApplication.Models.DB;

namespace SampleWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<ceit_gwa_databaseEntities1>(new CreateDatabaseIfNotExists<ceit_gwa_databaseEntities1>());
            Database.SetInitializer(new DatabaseInitializer());
            //Database.Initialize(true);
            using (var db = new ceit_gwa_databaseEntities1())
            {
                db.Database.Initialize(force: true);
            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
    }
}
