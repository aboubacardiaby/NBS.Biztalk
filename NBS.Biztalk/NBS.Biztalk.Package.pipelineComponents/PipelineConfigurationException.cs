using System;
using System.Runtime.Serialization;

namespace NBS.Biztalk.Package.pipelineComponents
{
    [Serializable]
    internal class PipelineConfigurationException : Exception
    {
        public PipelineConfigurationException()
        {
        }

        public PipelineConfigurationException(string message) : base(message)
        {
        }

        public PipelineConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PipelineConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}