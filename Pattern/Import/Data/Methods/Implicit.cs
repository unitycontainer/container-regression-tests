using System;
using System.ComponentModel;
using static Import.ImportBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Implicit.Methods
{
    public class DownTheLineType<TDependency>
        : ImportBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }

}
