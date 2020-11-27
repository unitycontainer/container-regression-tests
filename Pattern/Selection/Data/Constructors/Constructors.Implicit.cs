using Manager;
using System;


namespace Selection.Implicit.Constructors
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public BaselineTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    #endregion
}
