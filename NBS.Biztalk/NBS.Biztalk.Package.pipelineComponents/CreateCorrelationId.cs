using Microsoft.BizTalk.Component.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.BizTalk.Message.Interop;
using System.Collections;

namespace NBS.Biztalk.Package.pipelineComponents
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [System.Runtime.InteropServices.Guid(ClassId)]
    public  class CreateCorrelationId: PipelineComponentWithConfigurablePropertiesBase, IBaseComponent, Microsoft.BizTalk.Component.Interop.IComponent, IComponentUI
    {
        private const string ClassId = "f4b5caf1-efeb-458c-8ca3-3da185ef1398";
        public  string Description
        {
            get
            {
                return "Assignthe Primary Correaltion Id";
            }
        }

        public IntPtr Icon
        {
            get
            {
                return new IntPtr();
            }
        }

        [Browsable(false)]
        public string Name
        {
            get
            {
                return "CreatePrimaryCorrelation";
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0.0";
            }
        }

        public override void GetClassID(out Guid classID)
        {
            classID = new Guid(ClassId);
        }



     
       

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            pInMsg.Context.Promote(Utlity.Utlities.PrimaryCorrelationId_propertyName, Utlity.Utlities.PrimaryCorrelationId_propertyNs, Guid.NewGuid());
            pInMsg.BodyPart.Data.Position = 0;

            return pInMsg;
        }
        public override void InitNew()
        {
        }


        IEnumerator IComponentUI.Validate(object projectSystem)
        {
            return null;
        }
    }
}
