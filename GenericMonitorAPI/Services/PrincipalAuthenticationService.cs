using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace GenericMonitorAPI.Services
{
    public class PrincipalAuthenticationService
    {
        internal IPrincipal ByToken(string token)
        {
            //TODO: Add validation logic

            IIdentity identity = new GenericIdentity("Full access");

            return new GenericPrincipal(identity, new[] { "Admin" });
        }
    }
}