using GSWA.Domain.Abstract;
using GSWA.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace GSWA.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ModelBinders.Binders.Add(typeof(ICart), new CartModelBinder());


            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
    }
}
