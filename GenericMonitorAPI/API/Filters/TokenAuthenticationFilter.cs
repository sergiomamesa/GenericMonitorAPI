using GenericMonitorAPI.API.Results;
using GenericMonitorAPI.Services;
using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace GenericMonitorAPI.API.Filters
{

    public class TokenAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        private const string SCHEME = "Basic";

        public bool AllowMultiple => false;
        
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authenticationHeader = request.Headers.Authorization;

            if (authenticationHeader == null)
            {
                context.ErrorResult = new AuthenticationErrorResult("Missing credentials", request);
                return;
            }

            if (authenticationHeader.Scheme != SCHEME)
            {
                context.ErrorResult = new AuthenticationErrorResult("Missing credentials", request);
                return;
            }

            if (string.IsNullOrEmpty(authenticationHeader.Parameter))
            {
                context.ErrorResult = new AuthenticationErrorResult("Missing credentials", request);
                return;
            }

            var principal = await new PrincipalAuthenticationService().ByToken(authenticationHeader.Parameter);
            if (principal == null)
            {
                context.ErrorResult = new AuthenticationErrorResult("Invalid token", request);
            }

            context.Principal = principal;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var challenge = new AuthenticationHeaderValue(SCHEME, "Realm here");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            return Task.FromResult(0);
        }
    }
}