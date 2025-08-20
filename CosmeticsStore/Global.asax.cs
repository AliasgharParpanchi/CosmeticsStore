using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DataLayer.Models;
using DataLayer.Context;
using CosmeticsStore.App_Start;
using DataLayer.Migrations;

namespace CosmeticsStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Initialize database
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<
                                                MyProjectContext,
                                                Configuration>());
            // Dependency Injection
            DependencyInjectionConfig.Register();
        }
    }
}
