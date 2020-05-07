namespace NBS.Biztalk.Transformations {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"NBS.Biztalk.Schemas.Resident", typeof(global::NBS.Biztalk.Schemas.Resident))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"NBS.Biztalk.Schemas.Canonical_V1sd", typeof(global::NBS.Biztalk.Schemas.Canonical_V1sd))]
    public sealed class MapResidentToCanonical_V1 : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0"" version=""1.0"" xmlns:ns0=""http://NBS.Biztalk.Schemas.Canonical_V1sd"" xmlns:s0=""http://NBS.Biztalk.Schemas.Resident"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:Resident"" />
  </xsl:template>
  <xsl:template match=""/s0:Resident"">
    <ns0:CanonicalResident>
      <ResidentId>
        <xsl:value-of select=""Info/ResidentId/text()"" />
      </ResidentId>
      <Nom>
        <xsl:value-of select=""Info/Nom/text()"" />
      </Nom>
      <DateNaissance>
        <xsl:value-of select=""Info/DateNaissance/text()"" />
      </DateNaissance>
      <LieuDeNaissance>
        <xsl:value-of select=""Info/LieuNaissance/text()"" />
      </LieuDeNaissance>
      <PaysOrigine>
        <xsl:value-of select=""Info/PaysOrigine/text()"" />
      </PaysOrigine>
      <xsl:for-each select=""Address"">
        <Address>
          <Addresse>
            <xsl:value-of select=""Addresse/text()"" />
          </Addresse>
          <Ville>
            <xsl:value-of select=""Ville/text()"" />
          </Ville>
          <Ville>
            <xsl:value-of select=""Ville/text()"" />
          </Ville>
          <Postal>
            <xsl:value-of select=""PostalCode/text()"" />
          </Postal>
          <Pays>
            <xsl:value-of select=""Pays/text()"" />
          </Pays>
        </Address>
      </xsl:for-each>
    </ns0:CanonicalResident>
  </xsl:template>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"NBS.Biztalk.Schemas.Resident";
        
        private const global::NBS.Biztalk.Schemas.Resident _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"NBS.Biztalk.Schemas.Canonical_V1sd";
        
        private const global::NBS.Biztalk.Schemas.Canonical_V1sd _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"NBS.Biztalk.Schemas.Resident";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"NBS.Biztalk.Schemas.Canonical_V1sd";
                return _TrgSchemas;
            }
        }
    }
}
