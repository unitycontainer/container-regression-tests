using Regression;
using System;
using System.ComponentModel;
using static Import.Pattern;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Import.Implicit.Constructors
{
    #region Validation

    public class BaselineTestType_Ref<TDependency>
        : FixtureBaseType where TDependency : class
    {
        public BaselineTestType_Ref(ref TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : FixtureBaseType where TDependency : class
    {
        public BaselineTestType_Out(out TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class PrivateTestType<TDependency>
        : FixtureBaseType
    {
        private PrivateTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : FixtureBaseType
    {
        protected ProtectedTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : FixtureBaseType
    {
        internal InternalTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    #endregion
}

namespace Import.Implicit.Constructors.WithDefault
{
    public class Implicit_Parameter_Int_WithDefault : ImportBaseType
    {
        public Implicit_Parameter_Int_WithDefault(int value = Pattern.DefaultInt) => Value = value;

        public override object Default => Pattern.DefaultInt;
        public override object Injected => Pattern.InjectedInt;
        public override object Registered => Pattern.RegisteredInt;
        public override object Override => Pattern.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_Parameter_String_WithDefault : ImportBaseType
    {
        public Implicit_Parameter_String_WithDefault(string value = Pattern.DefaultString) => Value = value;

        public override object Default => Pattern.DefaultString;
        public override object Injected => Pattern.InjectedString;
        public override object Registered => Pattern.RegisteredString;
        public override object Override => Pattern.OverriddenString;
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Derived_WithDefault : Implicit_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefault(int value = _default)
            : base(value) { }

        public override object Default => _default;
    }
}


namespace Import.Implicit.Constructors.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : ImportBaseType
    {
        public Implicit_Int_WithDefaultAttribute([DefaultValue(Pattern.DefaultValueInt)] int value) => Value = value;

        public override object Default => Pattern.DefaultValueInt;
        public override object Injected => Pattern.InjectedInt;
        public override object Registered => Pattern.RegisteredInt;
        public override object Override => Pattern.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : ImportBaseType
    {
        public Implicit_String_WithDefaultAttribute([DefaultValue(Pattern.DefaultValueString)] string value) => Value = value;

        public override object Default => Pattern.DefaultValueString;
        public override object Injected => Pattern.InjectedString;
        public override object Registered => Pattern.RegisteredString;
        public override object Override => Pattern.OverriddenString;
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Derived_WithDefaultAttribute : Implicit_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefaultAttribute([DefaultValue(_default)] int value)
            : base(value) { }

        public override object Default => _default;
    }
}


namespace Import.Implicit.Constructors.WithDefaultAndAttribute
{
    public class Implicit_Int_WithDefaultAndAttribute : ImportBaseType
    {
        public Implicit_Int_WithDefaultAndAttribute([DefaultValue(Pattern.DefaultValueInt)] int value = Pattern.DefaultInt) => Value = value;

        public override object Injected => Pattern.InjectedInt;
        public override object Registered => Pattern.RegisteredInt;
        public override object Override => Pattern.OverriddenInt;
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => Pattern.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAndAttribute : ImportBaseType
    {
        public Implicit_String_WithDefaultAndAttribute([DefaultValue(Pattern.DefaultValueString)] string value = Pattern.DefaultString) => Value = value;

        public override object Injected => Pattern.InjectedString;
        public override object Registered => Pattern.RegisteredString;
        public override object Override => Pattern.OverriddenString;
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => Pattern.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Derived_WithDefaultAndAttribute : Implicit_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefaultAndAttribute([DefaultValue(_default)] int value = Pattern.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Default => ImportBase.DefaultValueInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }
}
