using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBS.Biztalk.Utlity
{
    public static  class Utlities
    {
        public const string LoggingApplicationName = "OM.BizTalk.Common.Packages";
        public const string PrimaryCorrelationId_propertyNs = "https://OM.BizTalk.Common.Schemas.Log.LogPropertySchema";
        public const string PrimaryCorrelationId_propertyName = "PrimaryCorrelationId";

        public static Guid GetPrimaryCorrelationId(IBaseMessageContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "Unable to attempt to get the PrimaryCorrelationId from the message context becasue the context passed was null.");
            }

            var primaryCorrelationIdValue = context.Read(PrimaryCorrelationId_propertyName, PrimaryCorrelationId_propertyNs) as string;

            if (string.IsNullOrWhiteSpace(primaryCorrelationIdValue))
            {
                throw new MissingPrimaryCorrelationIdException(string.Concat("Unable to get the PrimaryCorrelationId from the message context. No value was found for context property \"", PrimaryCorrelationId_propertyName, "\" in namepsace \"", PrimaryCorrelationId_propertyNs, "\"."));
            }

            Guid primaryCorrelationId;

            if (!Guid.TryParse(primaryCorrelationIdValue ?? string.Empty, out primaryCorrelationId))
            {
                throw new InvalidPrimaryCorrelationIdException(string.Concat("Unable to get the PrimaryCorrelationId from the message context. The value for context property \"", PrimaryCorrelationId_propertyName, "\" in namepsace \"", PrimaryCorrelationId_propertyNs, "\" was not a valid System.Guid. Value was \"", primaryCorrelationIdValue, "\"."));
            }

            return primaryCorrelationId;
        }

        public static Guid ToPrimaryCorrelationId(this IBaseMessageContext source)
        {
            return GetPrimaryCorrelationId(source);
        }

        public static void SetPrimaryCorrelationId(this IBaseMessageContext source, Guid primaryCorrelationId)
        {
            source.Promote(PrimaryCorrelationId_propertyName, PrimaryCorrelationId_propertyNs, primaryCorrelationId.ToString());
        }

        /// <summary>
        /// Shortcut to check the values of a (string) pipeline configuration property and raise a unifoprm exception if need be.
        /// </summary>
        /// <param name="source">The pipeline configuration property value</param>
        /// <param name="propertyName">The name of the pipeline property which will appear in the exception.</param>
        public static void ValidateAsPipelineProperty(this string source, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                propertyName = "<propertyName is not specified>";
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new InvalidOperationException(string.Concat("The pipeline configuration property \"", propertyName, "\" is null, empty, or, whitespace. A value is required to be configured. Please check the pipeline configuration."));
            }
        }
    }
}

