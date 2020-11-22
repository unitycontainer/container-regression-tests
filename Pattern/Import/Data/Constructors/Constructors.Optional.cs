using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Constructors.Optional
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public BaselineTestType([OptionalDependency] TDependency value) => Value = value;
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        public BaselineTestTypeNamed([OptionalDependency(PatternBase.Name)] TDependency value) => Value = value;
    }


    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Ref([OptionalDependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Out([OptionalDependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }
}
