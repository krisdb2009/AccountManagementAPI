using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.DirectoryServices.AccountManagement;
using System.Web.Routing;

namespace AccountManagementAPI.Handlers
{
    public class Get_User : IHttpHandler
    {
        public bool IsReusable => throw new NotImplementedException();
        public void ProcessRequest(HttpContext context)
        {
            RouteData rd = context.Request.RequestContext.RouteData;
            UserPrincipal up = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), (string)rd.Values["principal"]);
            context.Response.ContentType = "text/xml";
            XElement groups = new XElement("MemberOf");
            XDocument xml = new XDocument(
                new XElement("User",
                    new XElement("sAMAccountName", up.SamAccountName),
                    new XElement("UserPrincipalName", up.UserPrincipalName),
                    new XElement("SID", up.Sid),
                    new XElement("DisplayName", up.DisplayName),
                    new XElement("FirstName", up.GivenName),
                    new XElement("MiddleName", up.MiddleName),
                    new XElement("LastName", up.Surname),
                    new XElement("EmailAddress", up.EmailAddress),
                    new XElement("TelephoneNumber", up.VoiceTelephoneNumber),
                    new XElement("BadLogonCount", up.BadLogonCount),
                    new XElement("LastBadPasswordAttempt", up.LastBadPasswordAttempt),
                    new XElement("LastPasswordSet", up.LastPasswordSet),
                    new XElement("LastLogon", up.LastLogon),
                    new XElement("Description", up.Description),
                    groups
                )
            );
            foreach(Principal group in up.GetGroups())
            {
                groups.Add(new XElement("Group",
                    new XAttribute("sAMAccountName", group.SamAccountName),
                    new XAttribute("SID", group.Sid)
                ));
            }
            context.Response.Write(xml.ToString());
        }
    }
}