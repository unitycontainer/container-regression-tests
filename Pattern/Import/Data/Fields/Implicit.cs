using System;
using static Import.ImportBase;


namespace Import.Implicit.Fields
{
    public class DownTheLineType<TDependency>
        : ImportBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }

}
