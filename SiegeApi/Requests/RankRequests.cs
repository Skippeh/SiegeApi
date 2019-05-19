using System;
using System.Threading.Tasks;
using RestSharp;
using SiegeApi.Data;
using SiegeApi.Models;
using SiegeApi.Requests.ResponseModels;

namespace SiegeApi.Requests
{
    public static class RankRequests
    {
        public static async Task<RankResponse> GetRank(SiegeApiClient client, Platform platform, Region region, Season season, params Guid[] userIds)
        {
            var request = new RestRequest(UbiUrls.GetRankUrl(platform, region, season.Id, userIds));
            request.AddHeader("Authorization", client.GetAuthorizationHeader());

            var response = await client.RestClient.GetAsync<RankResponse>(request);
            return response;
        }
    }
}