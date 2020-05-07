namespace NBS.Biztalk.Pipelines
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class Incoming_Resident_ReceivePipeline : Microsoft.BizTalk.PipelineOM.ReceivePipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>f66b9f5e-43ff-4f5f-ba46-885348ae1b4e</CategoryId>  <FriendlyName>Receive</FriendlyName>"+
"  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Decode\" minOccurs=\""+
"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4103-4cce-4536-83fa-4a5040674ad6\" />      <Component"+
"s>        <Component>          <Name>NBS.Biztalk.PipelineComponents.Archiver,NBS.Biztalk.PipelineCom"+
"ponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4998120d0cabe6c4</Name>          <Componen"+
"tName>NBSArchiveComponent</ComponentName>          <Description>Biztalk file Archive Components</Des"+
"cription>          <Version>1.0.0.0</Version>          <Properties>            <Property Name=\"IsDbA"+
"rchive\">              <Value xsi:type=\"xsd:boolean\">false</Value>            </Property>            "+
"<Property Name=\"FileLocation\" />            <Property Name=\"ArchiveFileNameProp\" />          </Prope"+
"rties>          <CachedDisplayName>NBSArchiveComponent</CachedDisplayName>          <CachedIsManaged"+
">true</CachedIsManaged>        </Component>      </Components>    </Stage>    <Stage>      <PolicyFi"+
"leStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Disassemble\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"F"+
"irstMatch\" stageId=\"9d0e4105-4cce-4536-83fa-4a5040674ad6\" />      <Components>        <Component>   "+
"       <Name>Microsoft.BizTalk.Component.FFDasmComp,Microsoft.BizTalk.Pipeline.Components, Version=3"+
".0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</Name>          <ComponentName>Flat file di"+
"sassembler</ComponentName>          <Description>Streaming flat file disassembler component</Descrip"+
"tion>          <Version>1.0</Version>          <Properties>            <Property Name=\"HeaderSpecNam"+
"e\" />            <Property Name=\"DocumentSpecName\">              <Value xsi:type=\"xsd:string\">BTS.so"+
"ap_encoding_1__1+anyType, Microsoft.BizTalk.GlobalPropertySchemas, Version=3.0.1.0, Culture=neutral,"+
" PublicKeyToken=31bf3856ad364e35</Value>            </Property>            <Property Name=\"TrailerSp"+
"ecName\" />            <Property Name=\"PreserveHeader\">              <Value xsi:type=\"xsd:boolean\">fa"+
"lse</Value>            </Property>            <Property Name=\"ValidateDocumentStructure\">           "+
"   <Value xsi:type=\"xsd:boolean\">false</Value>            </Property>            <Property Name=\"Rec"+
"overableInterchangeProcessing\">              <Value xsi:type=\"xsd:boolean\">true</Value>            <"+
"/Property>          </Properties>          <CachedDisplayName>Flat file disassembler</CachedDisplayN"+
"ame>          <CachedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </St"+
"age>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" Name=\"Validate\" minOccurs=\"0\" m"+
"axOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e410d-4cce-4536-83fa-4a5040674ad6\" />      <Components />"+
"    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"4\" Name=\"ResolveParty\" min"+
"Occurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e410e-4cce-4536-83fa-4a5040674ad6\" />      <C"+
"omponents />    </Stage>  </Stages></Document>";
        
        private const string _versionDependentGuid = "a3a74821-95b4-467c-bc71-8aa0fa09ed09";
        
        public Incoming_Resident_ReceivePipeline()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4103-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("NBS.Biztalk.PipelineComponents.Archiver,NBS.Biztalk.PipelineComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4998120d0cabe6c4");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"IsDbArchive\">  "+
"    <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>    <Property Name=\"FileLocation\" />  "+
"  <Property Name=\"ArchiveFileNameProp\" />  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
            stage = this.AddStage(new System.Guid("9d0e4105-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.firstRecognized);
            IBaseComponent comp1 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.FFDasmComp,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp1 is IPersistPropertyBag)
            {
                string comp1XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"HeaderSpecName\""+
" />    <Property Name=\"DocumentSpecName\">      <Value xsi:type=\"xsd:string\">BTS.soap_encoding_1__1+a"+
"nyType, Microsoft.BizTalk.GlobalPropertySchemas, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31"+
"bf3856ad364e35</Value>    </Property>    <Property Name=\"TrailerSpecName\" />    <Property Name=\"Pres"+
"erveHeader\">      <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>    <Property Name=\"Vali"+
"dateDocumentStructure\">      <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>    <Property"+
" Name=\"RecoverableInterchangeProcessing\">      <Value xsi:type=\"xsd:boolean\">true</Value>    </Prope"+
"rty>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp1XmlProperties);;
                ((IPersistPropertyBag)(comp1)).Load(pb, 0);
            }
            this.AddComponent(stage, comp1);
        }
        
        public override string XmlContent
        {
            get
            {
                return _strPipeline;
            }
        }
        
        public override System.Guid VersionDependentGuid
        {
            get
            {
                return new System.Guid(_versionDependentGuid);
            }
        }
    }
}
