using System;

namespace NBS.Biztalk.Package.pipelineComponents
{
    public class PipelineConfigurableStringAttribute : Attribute
    {
        public Type Type { get; private set; }

        public PipelineConfigurableStringAttribute()
        {
            this.Type = typeof(string);
        }
    }

}