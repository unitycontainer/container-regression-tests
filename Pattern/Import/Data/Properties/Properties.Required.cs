using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Properties.Required
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [Dependency] public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [Dependency(PatternBase.Name)] public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }
}
