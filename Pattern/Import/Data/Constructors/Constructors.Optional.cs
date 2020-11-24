using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Constructors.Optional
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public BaselineTestType([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        public BaselineTestTypeNamed([OptionalDependency(PatternBase.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency>
        : BaselineTestType<TDependency>
    {
        public BaselineInheritedType([OptionalDependency] TDependency value)
            : base(value)
        { }
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
        public BaselineInheritedTwice([OptionalDependency] TDependency value)
            : base(value)
        { }
    }


    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Ref([OptionalDependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Out([OptionalDependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion


    #region Test Data

#if !BEHAVIOR_V4 // Unity v4 did not support value optionals

    public class Optional_Int : PatternBaseType
    {
        public Optional_Int([OptionalDependency] int value) => Value = value;

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override Type ImportType => typeof(int);
    }
#endif

    public class Optional_String : PatternBaseType
    {
        public Optional_String([OptionalDependency] string value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override Type ImportType => typeof(string);
    }

    public class Optional_Unresolvable : PatternBaseType
    {
        public Optional_Unresolvable([OptionalDependency] Unresolvable value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
