using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBS.Biztalk.Package.pipelineComponents
{
   public class ContextPropertyResolver: IResolveContextProperties
    {
        public string ResolvePropertyFromNameSemicolonNamespacePair(string propertyNameSemiColonNamespace, IBaseMessageContext context)
        {
            var propertyNamesAndNamespaceValues = propertyNameSemiColonNamespace.Split(';');

            if (propertyNamesAndNamespaceValues.Length != 2)
            {
                var errorMessage = "must be in the format name;namesapce representing value in the context";
               // Logging.LoggingClient.WriteLog(this.GetType().Namespace, Guid.Empty, this.GetType().FullName, LoggingEventTypes.Exception, errorMessage);
                return null;
            }

            var name = propertyNamesAndNamespaceValues[0];
            var @namespace = propertyNamesAndNamespaceValues[1];
            //var propertyValue = context.ReadProperty(name, @namespace);

            //if (string.IsNullOrEmpty(propertyValue))
            //{
            //    var errorMessage = propertyNameSemiColonNamespace + " is used in an archiving pipeline property and therefore must have a value in message context.";
            //    //Logging.LoggingClient.WriteLog(this.GetType().Namespace, Guid.Empty, this.GetType().FullName, LoggingEventTypes.Exception, errorMessage);
            //    return null;
            //}

            return null;
        }
    }
}
