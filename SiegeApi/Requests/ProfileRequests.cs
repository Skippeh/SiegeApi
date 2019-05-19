using System;
using System.Threading.Tasks;
using RestSharp;
using SiegeApi.Data;
using SiegeApi.Requests.ResponseModels;

namespace SiegeApi.Requests
{
    internal static class ProfileRequests
    {
        public static async Task<ProfileResponse> FindProfileAsync(SiegeApiClient client, string username, Platform platform)
        {
            var request = new RestRequest(UbiUrls.GetProfileUrl(platform, username));
            request.AddHeader("Authorization", client.GetAuthorizationHeader());

            var response = await client.RestClient.ExecuteGetTaskAsync<ProfileResponse>(request);

            return response.Data;
        }

        public static async Task<ProfileResponse> FindProfilesAsync(SiegeApiClient client, Guid userId)
        {
            var request = new RestRequest(UbiUrls.GetReverseUrl(userId));
            request.AddHeader("Authorization", client.GetAuthorizationHeader());

            var response = await client.RestClient.ExecuteGetTaskAsync<ProfileResponse>(request);

            return response.Data;
        }
    }
}