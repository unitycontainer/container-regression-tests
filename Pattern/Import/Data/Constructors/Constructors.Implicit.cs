using System;


namespace Regression.Implicit.Constructors
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public BaselineTestType(TDependency value) => Value = value;
        public override object Expected => default(TDependency);
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
}
