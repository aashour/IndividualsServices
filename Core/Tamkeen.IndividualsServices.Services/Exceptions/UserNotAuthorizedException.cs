using System;
using System.Runtime.Serialization;

namespace Tamkeen.IndividualsServices.Services.Exceptions
{
    [Serializable]
    internal class UserNotAuthorizedException : Exception
    {
        public UserNotAuthorizedException()
        {
        }

        public UserNotAuthorizedException(string message) : base(message)
        {
        }

        public UserNotAuthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}