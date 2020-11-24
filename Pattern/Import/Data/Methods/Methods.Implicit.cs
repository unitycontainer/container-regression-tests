using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Implicit.Methods
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(TDependency value) => Value = value;
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
        public virtual void Method(ref TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method(out TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion


    #region Test Data

    public class Implicit_Int : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(int value) => Value = value;

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override object Override => PatternBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(string value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override object Override => PatternBase.OverriddenString;
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Unresolvable : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(Unresolvable value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override object Override => PatternBase.OverriddenUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
