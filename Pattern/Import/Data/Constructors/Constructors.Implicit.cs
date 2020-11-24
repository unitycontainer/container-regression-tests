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


    #region Test Data

    public class Implicit_Int : PatternBaseType
    {
        public Implicit_Int(int value) => Value = value;

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override object Override => PatternBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }


    public class Implicit_String : PatternBaseType
    {
        public Implicit_String(string value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override object Override => PatternBase.OverriddenString;
        public override Type ImportType => typeof(string);
    }


    public class Implicit_Unresolvable : PatternBaseType
    {
        public Implicit_Unresolvable(Unresolvable value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override object Override => PatternBase.OverriddenUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
