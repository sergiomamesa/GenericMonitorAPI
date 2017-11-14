using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using GenericMonitorAPI.Context;

namespace GenericMonitorAPI.Services
{
    public class PrincipalAuthenticationService
    {
        private readonly GenericMonitorAPIContext db = new GenericMonitorAPIContext();

        internal Task<IPrincipal> ByToken(string token)
        {
            var user = db.Users.FirstOrDefault(i => i.Token == token);
            if (user == null)
                return Task.FromResult<IPrincipal>(null);

            var identity = new GenericIdentity(user.Name);
            var principal = new GenericPrincipal(identity, user.Roles.Select(i => i.Name).ToArray());

            return Task.FromResult<IPrincipal>(principal);
        }
    }
}