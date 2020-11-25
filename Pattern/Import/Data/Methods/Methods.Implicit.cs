using Regression;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Implicit.Methods
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency>
        : BaselineTestType<TDependency>
    {
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
    }

    public class DownTheLineType<TDependency>
        : PatternBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }

    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method(ref TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method(out TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion
}
