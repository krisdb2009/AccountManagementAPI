using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountManagementAPI.Handlers
{
    public class Default : IHttpHandler
    {
        public bool IsReusable => throw new NotImplementedException();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.StatusCode = 404;
            context.Response.Write("Account Management API: Route not found!");
        }
    }
}