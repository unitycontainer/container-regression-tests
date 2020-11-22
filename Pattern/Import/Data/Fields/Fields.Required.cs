using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Fields.Required
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [Dependency] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [Dependency(PatternBase.Name)] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }
}
