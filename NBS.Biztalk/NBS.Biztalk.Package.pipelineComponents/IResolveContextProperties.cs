using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBS.Biztalk.Package.pipelineComponents
{
   public interface IResolveContextProperties
    {
        string ResolvePropertyFromNameSemicolonNamespacePair(string propertyNameSemiColonNamespace, IBaseMessageContext context);
    }
}
