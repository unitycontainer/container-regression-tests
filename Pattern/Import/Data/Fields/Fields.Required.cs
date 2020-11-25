using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Annotated.Fields.Required
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [Dependency] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [Dependency(ImportBase.Name)] public TDependency Field;

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
