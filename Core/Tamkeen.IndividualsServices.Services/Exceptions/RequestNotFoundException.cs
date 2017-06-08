using System;
using System.Runtime.Serialization;

namespace Tamkeen.IndividualsServices.Services.Exceptions
{
    [Serializable]
    internal class RequestNotFoundException : Exception
    {
        public RequestNotFoundException()
        {
        }

        public RequestNotFoundException(string message) : base(message)
        {
        }

        public RequestNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RequestNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}