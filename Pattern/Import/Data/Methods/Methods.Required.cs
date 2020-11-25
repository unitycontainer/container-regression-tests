using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Methods.Required
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
    : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency(PatternBase.Name)] TDependency value) => Value = value;
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
        public virtual void Method([Dependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method([Dependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion
}
