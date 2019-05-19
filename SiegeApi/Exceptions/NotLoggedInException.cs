using System;

namespace SiegeApi.Exceptions
{
    public class NotLoggedInException : Exception
    {
        public NotLoggedInException(string message) : base(message)
        {
        }

        public NotLoggedInException()
        {
        }
    }
}