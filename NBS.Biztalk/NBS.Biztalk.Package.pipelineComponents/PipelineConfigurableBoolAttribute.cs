using System;

namespace NBS.Biztalk.Package.pipelineComponents
{
    public class PipelineConfigurableBoolAttribute : Attribute
    {
        public Type Type { get; private set; }

        public PipelineConfigurableBoolAttribute()
        {
            this.Type = typeof(bool);
        }
    }
}