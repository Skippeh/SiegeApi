using System;
using System.Net;
using System.Threading.Tasks;
 using RestSharp;
 using SiegeApi.Data;
using SiegeApi.Exceptions;
using SiegeApi.Requests.ResponseModels;

namespace SiegeApi.Requests
 {
     public static class ProgressionRequests
     {
         public static async Task<ProgressionResponse> GetProgression(SiegeApiClient apiClient, Platform platform, params Guid[] profileIds)
         {
             var request = new RestRequest(UbiUrls.GetLevelUrl(platform, profileIds));
             request.AddHeader("Authorization", apiClient.GetAuthorizationHeader());
             
             var response = await apiClient.RestClient.ExecuteGetTaskAsync<ProgressionResponse>(request);

             if (response.StatusCode != HttpStatusCode.OK)
                 throw new UnexpectedHttpStatusCodeException(response.StatusCode);
             
             if (response.ErrorException != null)
                 throw response.ErrorException;

             return response.Data;
         }
     }
 }