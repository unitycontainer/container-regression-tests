using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Methods.Optional
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency(PatternBase.Name)] TDependency value) => Value = value;
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


    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion


    #region Test Data

#if !BEHAVIOR_V4 // Unity v4 did not support value optionals

    public class Optional_Int : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] int value) => Value = value;

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override object Override => PatternBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

#endif

    public class Optional_String : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] string value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override object Override => PatternBase.OverriddenString;
        public override Type ImportType => typeof(string);
    }

    public class Optional_Unresolvable : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] Unresolvable value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override object Override => PatternBase.OverriddenUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
