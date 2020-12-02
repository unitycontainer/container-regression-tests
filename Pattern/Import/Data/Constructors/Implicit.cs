using Regression;
using System;
using System.ComponentModel;
using static Import.ImportBase;


namespace Import.Implicit.Constructors
{

    public class DownTheLineType<TDependency>
        : ImportBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }
}
