using GenericMonitorAPI.API.Results;
using GenericMonitorAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace GenericMonitorAPI.API.Filters
{
    public class SimpleAuthenticationFilter : IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (authorization == null)
                return Task.CompletedTask;

            if (authorization.Scheme != "Token")
                return Task.CompletedTask;

            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationErrorResult("Missing credentials", request);
                return Task.CompletedTask;
            }

            String token = authorization.Parameter;
            IPrincipal principal = new PrincipalAuthenticationService().ByToken(token);
            if (principal == null)
            {
                context.ErrorResult = new AuthenticationErrorResult("Invalid token", request);
                return Task.CompletedTask;
            }

            context.Principal = principal;
            return Task.CompletedTask;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}