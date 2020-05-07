using System;
using System.Runtime.Serialization;

namespace NBS.Biztalk.Utlity
{
    [Serializable]
    internal class InvalidPrimaryCorrelationIdException : Exception
    {
        public InvalidPrimaryCorrelationIdException()
        {
        }

        public InvalidPrimaryCorrelationIdException(string message) : base(message)
        {
        }

        public InvalidPrimaryCorrelationIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPrimaryCorrelationIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}