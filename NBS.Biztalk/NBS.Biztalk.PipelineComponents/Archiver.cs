using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Component.Interop;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.BizTalk.Streaming;
using System.Collections;
using NBS.Biztalk.Package.pipelineComponents;
using System.Threading;
using NBS.Biztalk.Logging;

namespace NBS.Biztalk.PipelineComponents
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [Guid("3A5913DB-293E-48BA-9F2D-93AAC6C99A8D")]
    public class Archiver : PipelineComponentWithConfigurablePropertiesBase, IBaseComponent, IComponent, IComponentUI
    {
        private const string ClassId = "a9d497c1-dff6-4d79-afe3-80f9a2eba64e";
        private const string PcidXmlns = "https://NBS.Biztalk.Schemas.Logs.LogspropertySchema";
        private const string PcidProperty = "primaryCorrelationId";
        [PipelineConfigurable]
        public string ArchiveFileNameProp { get; set; }
        [PipelineConfigurable]
        public string FileLocation { get; set; }
        [PipelineConfigurable]
        public bool IsDbArchive  { get; set; }
        public string Description
        {
            get
            {
                return "Biztalk file Archive Components";
            }
        }

        public string Name
        {
            get
            {
                return "NBSArchiveComponent";
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0.0";
            }
        }

        public IntPtr Icon
        {
            get
            {
                return new System.IntPtr();
            }
        }

       

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            var booleanValueFromPropertyBag = this.ReadPropertyBag(propertyBag, "IsDbArchive");
            if ((booleanValueFromPropertyBag != null))
            {
                this.IsDbArchive = ((bool)(booleanValueFromPropertyBag));
            }
           var  stringValueFromPropertyBag = this.ReadPropertyBag(propertyBag, "FileLocation");
            if ((stringValueFromPropertyBag != null))
            {
                this.FileLocation = ((string)(stringValueFromPropertyBag));
            }
             stringValueFromPropertyBag = this.ReadPropertyBag(propertyBag, "ArchiveFileNameProp");
            if ((stringValueFromPropertyBag != null))
            {
                this.ArchiveFileNameProp = ((string)(stringValueFromPropertyBag));
            }

        }

        private object ReadPropertyBag(IPropertyBag propertyBag, string propName)
        {
            object val = null;
            try
            {
                propertyBag.Read(propName, out val, 0);
            }
            catch (ArgumentException)
            {
                return val;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }
            return val;
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            WritePropertyBag(propertyBag, "IsDbArchive", this.IsDbArchive);
            WritePropertyBag(propertyBag, "FileLocation", this.FileLocation);
            WritePropertyBag(propertyBag, "ArchiveFileNameProp", this.ArchiveFileNameProp);
        }

        private void WritePropertyBag(IPropertyBag propertyBag, string propName, object val   )
        {
            try
            {
                propertyBag.Write(propName,
                ref val);
            }
            catch (System.Exception e)
            {
                throw new System.ApplicationException(e.Message);
            }
        }

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            string pcidContext = string.Empty;
            Guid pcid = Guid.Empty;
            pcidContext = pInMsg.Context.Read(PcidProperty, PcidXmlns) as string;
            if (pInMsg == null || pInMsg.BodyPart == null || pInMsg.Context == null)
            {
                return pInMsg;

            }
            using (StreamReader streamReader = new StreamReader(pInMsg.BodyPart.Data))
            {
                string msg = streamReader.ReadToEnd();
                SaveFile(msg, FileLocation);
                string callingDomainName = Thread.GetDomain().FriendlyName;
                Log.LogInSql("1", "high", Environment.MachineName, callingDomainName, "", "", "", msg);
            }
            return pInMsg;
        }
        private void SaveFile(string file, string dir)
        {
          

            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);
            
            // use Path.Combine to combine 2 strings to a path
            string savefile = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
            File.WriteAllText(Path.Combine(dir, savefile), file);
        }

        public IEnumerator Validate(object projectSystem)
        {
            ArrayList list = new ArrayList();
            return list.GetEnumerator();
        }

        public override void GetClassID(out Guid classID)
        {
            classID = new Guid(ClassId);
        }

        public override void InitNew()
        {
            
        }
    }
}
