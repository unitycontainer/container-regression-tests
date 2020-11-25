using System;


namespace Regression.Implicit.Fields
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public TDependency Field;

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

    #endregion
}
