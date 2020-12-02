using System;
using static Import.ImportBase;


namespace Import.Implicit.Properties
{

    public class DownTheLineType<TDependency>
        : ImportBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }

}
