using System.Net;
using System.Threading.Tasks;
using RestSharp;
using SiegeApi.Data;
using SiegeApi.Exceptions;
using SiegeApi.Requests.ResponseModels;

namespace SiegeApi.Requests
{
    internal static class AuthRequests
    {
        public static async Task<AuthResponse> SendAuthRequestAsync(RestClient client)
        {
            var request = new RestRequest(UbiUrls.LoginUrl);
            request.AddJsonBody(new {rememberMe = true});
            var response = await client.ExecutePostTaskAsync<AuthResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new LoginFailedException($"HttpStatusCode = {response.StatusCode}", null);

            return response.Data;
        }
    }
}