using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var req = HttpContext.Current.Request;
            var resp = HttpContext.Current.Response;

            if (req.HttpMethod == "OPTIONS")
            {
                //These headers are handling the "pre-flight" OPTIONS call sent by the browser
                resp.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                resp.AddHeader("Access-Control-Allow-Headers", "Origin, Content-Type, Accept, SOAPAction");
                resp.AddHeader("Access-Control-Max-Age", "1728000");
                resp.End();
            }
        }
    }
}
