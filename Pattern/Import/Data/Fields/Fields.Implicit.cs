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


    #region Test Data

    public class Implicit_Int : PatternBaseType
    {
        public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String : PatternBaseType
    {
        public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Unresolvable : PatternBaseType
    {
        public Unresolvable Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
