using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Methods.Optional
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] TDependency value) => Value = value;
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency(PatternBase.Name)] TDependency value) => Value = value;
    }



    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }
}

