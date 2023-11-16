using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using WebApi.Models;
using Microsoft.Owin.Security;
using System.Web.Http.Cors;

namespace WebApi
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var db = new EmployeeDBEntities1())
            {
                if (db != null)
                {
                    var user = db.Users.ToList();
                    if (user != null)
                    {
                        if (!string.IsNullOrEmpty(user.Where(u => u.UserName == context.UserName && u.Password == context.Password).FirstOrDefault().Name))
                        {
                            identity.AddClaim(new Claim("Age", "16"));
                            var props = new AuthenticationProperties(new Dictionary<string, string> {
                                {
                                    "userdisplayname", context.UserName
                                },
                                {
                                    "role","admin"
                                }
                            });

                            var ticket = new AuthenticationTicket(identity, props);
                            context.Validated(ticket);
                        }
                        else
                        {
                            context.SetError("invalid_grant", "Provided username and password is incorrect");
                            context.Rejected();
                        }
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    context.Rejected();
                }
                return;
            }
        }
    }
}