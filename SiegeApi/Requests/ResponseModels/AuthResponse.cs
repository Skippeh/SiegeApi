using System;

namespace SiegeApi.Requests.ResponseModels
{
    public class AuthResponse
    {
        public string Token { get; set; } = null!;
        public string Ticket { get; set; } = null!;
        public object TwoFactorAuthenticationTicket { get; set; } = null!;
        public DateTime Expiration { get; set; }
        public string PlatformType { get; set; } = null!;
        public Guid ProfileId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string NameOnPlatform { get; set; } = null!;
        public bool InitializeUser { get; set; }
        public Guid SpaceId { get; set; }
        public string Environment { get; set; } = null!;
        public bool HasAcceptedLegalOptins { get; set; }
        public object AccountIssues { get; set; } = null!;
        public Guid SessionId { get; set; }
        public string ClientIp { get; set; } = null!;
        public string ClientIpCountry { get; set; } = null!;
        public DateTime ServerTime { get; set; }
        public string RememberMeTicket { get; set; } = null!;
    }
}