using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Properties.Required
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [Dependency] public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [Dependency(PatternBase.Name)] public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
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

    public class Required_Int : PatternBaseType
    {
        [Dependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override object Override => PatternBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_String : PatternBaseType
    {
        [Dependency] public string Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override object Override => PatternBase.OverriddenString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Unresolvable : PatternBaseType
    {
        [Dependency] public Unresolvable Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override object Override => PatternBase.OverriddenUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
