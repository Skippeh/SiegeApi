using System;
using System.Net;

namespace SiegeApi.Exceptions
{
    public class UnexpectedHttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        
        public UnexpectedHttpStatusCodeException(HttpStatusCode statusCode) : base($"An unexpected http status code was received: {statusCode}")
        {
            StatusCode = statusCode;
        }
    }
}