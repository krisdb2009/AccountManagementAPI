using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace AccountManagementAPI.Routers
{
    public class Action_Type_Principal : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            RouteData rd = requestContext.RouteData;
            if (rd.Compare("action", "get"))
            {
                if (rd.Compare("type", "user"))
                {
                    return new Handlers.Get_User();
                }
            }
            return new Handlers.Default();
        }
    }
    public static class RouteExtensions
    {
        public static bool Compare(this RouteData rd, string routeKey, string equals)
        {
            object routeOut;
            return (
                rd.Values.TryGetValue(routeKey, out routeOut) &&
                ((string)routeOut).Equals(equals, StringComparison.OrdinalIgnoreCase)
            );
        }
    }
}