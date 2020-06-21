using System;
using System.Web;
using System.Web.Routing;

namespace AccountManagementAPI
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new Route("{action}/{type}/{principal}", new Routers.Action_Type_Principal()));
            RouteTable.Routes.Add(new Route("{*.*}", new Routers.Default()));
        }
    }
}