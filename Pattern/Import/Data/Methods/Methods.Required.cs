using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Methods.Required
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
    : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency(PatternBase.Name)] TDependency value) => Value = value;
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
        public virtual void Method([Dependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method([Dependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion


    #region Test Data

    public class Required_Int : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] int value) => Value = value;

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_String : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] string value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Unresolvable : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] Unresolvable value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
