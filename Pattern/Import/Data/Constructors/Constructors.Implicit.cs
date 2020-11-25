using System;


namespace Regression.Implicit.Constructors
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public BaselineTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency> 
        : BaselineTestType<TDependency>
    {
        public BaselineInheritedType(TDependency value) 
            : base(value)
        { }
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
        public BaselineInheritedTwice(TDependency value)
            : base(value)
        { }
    }

    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Ref(ref TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Out(out TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion
}
