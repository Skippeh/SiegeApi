using System;

namespace SiegeApi.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException(string message, Exception innerException) : base(message ?? "Failed to log in to uplay services.", innerException)
        {
            
        }
    }
}