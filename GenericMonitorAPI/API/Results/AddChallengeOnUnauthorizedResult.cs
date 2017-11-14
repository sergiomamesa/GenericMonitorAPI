using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace GenericMonitorAPI.API.Results
{
    public class AddChallengeOnUnauthorizedResult : IHttpActionResult
    {
        public AuthenticationHeaderValue Challenge { get; }

        public IHttpActionResult InnerResult { get; }

        public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
        {
            Challenge = challenge;
            InnerResult = innerResult;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await InnerResult.ExecuteAsync(cancellationToken);
            if (response.StatusCode != HttpStatusCode.Unauthorized)
                return response;

            if (response.Headers.WwwAuthenticate.All(h => h.Scheme != Challenge.Scheme)) 
                response.Headers.WwwAuthenticate.Add(Challenge);

            return response;
        }
    }
}