using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace GenericMonitorAPI.API.Results
{
    public class AuthenticationErrorResult : IHttpActionResult
    {
        private readonly string error;
        private readonly HttpRequestMessage request;

        public AuthenticationErrorResult(string error, HttpRequestMessage request)
        {
            this.error = error;
            this.request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage
            {
                Content = new StringContent(error),
                RequestMessage = request,
                StatusCode = System.Net.HttpStatusCode.Unauthorized
            };

            return Task.FromResult(response);
        }
    }
}