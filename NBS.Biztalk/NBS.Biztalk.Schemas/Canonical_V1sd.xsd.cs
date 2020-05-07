namespace NBS.Biztalk.Schemas {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://NBS.Biztalk.Schemas.Canonical_V1sd",@"CanonicalResident")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"CanonicalResident"})]
    public sealed class Canonical_V1sd : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://NBS.Biztalk.Schemas.Canonical_V1sd"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://NBS.Biztalk.Schemas.Canonical_V1sd"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""CanonicalResident"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""ResidentId"" type=""xs:string"" />
        <xs:element name=""Nom"" type=""xs:string"" />
        <xs:element name=""DateNaissance"" type=""xs:string"" />
        <xs:element name=""LieuDeNaissance"" type=""xs:string"" />
        <xs:element name=""PaysOrigine"" type=""xs:string"" />
        <xs:element maxOccurs=""unbounded"" name=""Address"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Addresse"" type=""xs:string"" />
              <xs:element name=""Ville"" type=""xs:string"" />
              <xs:element name=""Ville"" type=""xs:string"" />
              <xs:element name=""Postal"" type=""xs:string"" />
              <xs:element name=""Pays"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Canonical_V1sd() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "CanonicalResident";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
