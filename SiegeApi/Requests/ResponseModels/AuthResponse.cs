using System;

namespace SiegeApi.Requests.ResponseModels
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string Ticket { get; set; }
        public object TwoFactorAuthenticationTicket { get; set; }
        public DateTime Expiration { get; set; }
        public string PlatformType { get; set; }
        public Guid ProfileId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string NameOnPlatform { get; set; }
        public bool InitializeUser { get; set; }
        public Guid SpaceId { get; set; }
        public string Environment { get; set; }
        public bool HasAcceptedLegalOptins { get; set; }
        public object AccountIssues { get; set; }
        public Guid SessionId { get; set; }
        public string ClientIp { get; set; }
        public string ClientIpCountry { get; set; }
        public DateTime ServerTime { get; set; }
        public string RememberMeTicket { get; set; }
    }
}