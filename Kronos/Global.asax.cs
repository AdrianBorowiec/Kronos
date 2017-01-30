using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation;
using FluentValidation.Mvc;
using Kronos.Infrastructure;
using System.Globalization;
using System.Threading;

namespace Kronos
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pl-PL");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            FluentValidationModelValidatorProvider.Configure();            
            ValidatorOptions.ResourceProviderType = typeof(MyResourceProvider);
        }
    }
}
