using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Fields.Optional
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [OptionalDependency] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [OptionalDependency(PatternBase.Name)] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
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


    #endregion
}
