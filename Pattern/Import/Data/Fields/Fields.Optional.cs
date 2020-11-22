using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Fields.Optional
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [OptionalDependency] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [OptionalDependency(PatternBase.Name)] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => default(TDependency);
    }
}

