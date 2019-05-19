using System;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using SiegeApi.Data;
using SiegeApi.Requests.ResponseModels;

namespace SiegeApi.Requests
{
    public static class StatsRequests
    {
        public static async Task<StatsResponse> GetStats(SiegeApiClient client, Platform platform, params Guid[] userIds)
        {
            var request = new RestRequest(UbiUrls.GetStatsUrl(platform, Stats.Data.Concat(Operators.Data.SelectMany(op => op.Gadgets)).ToArray(), userIds));
            request.AddHeader("Authorization", client.GetAuthorizationHeader());

            return await client.RestClient.GetAsync<StatsResponse>(request);
        }
    }
}