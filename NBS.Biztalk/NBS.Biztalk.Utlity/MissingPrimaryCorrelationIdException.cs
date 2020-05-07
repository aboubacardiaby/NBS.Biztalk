using System;
using System.Runtime.Serialization;

namespace NBS.Biztalk.Utlity
{
    [Serializable]
    internal class MissingPrimaryCorrelationIdException : Exception
    {
        public MissingPrimaryCorrelationIdException()
        {
        }

        public MissingPrimaryCorrelationIdException(string message) : base(message)
        {
        }

        public MissingPrimaryCorrelationIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingPrimaryCorrelationIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}