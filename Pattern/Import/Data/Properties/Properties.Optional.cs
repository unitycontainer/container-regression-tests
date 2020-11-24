using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Properties.Optional
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [OptionalDependency] public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [OptionalDependency(PatternBase.Name)] public TDependency Property { get; set; }

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

#if !BEHAVIOR_V4 // Unity v4 did not support value optionals
    public class Optional_Int : PatternBaseType
    {
        [OptionalDependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override object Override => PatternBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }
#endif

    public class Optional_String : PatternBaseType
    {
        [OptionalDependency] public string Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override object Override => PatternBase.OverriddenString;
        public override Type ImportType => typeof(string);
    }

    public class Optional_Unresolvable : PatternBaseType
    {
        [OptionalDependency] public Unresolvable Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override object Override => PatternBase.OverriddenUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
