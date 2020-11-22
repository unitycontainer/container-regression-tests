using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Implicit.Methods.WithDefault
{
    public class Implicit_Parameter_Int_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultInt;
        public override Type Dependency => typeof(int);
    }

    public class Implicit_Parameter_String_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultString;
        public override Type Dependency => typeof(string);
    }

    public class Implicit_Derived_WithDefault : Implicit_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method(int value = _default) => base.Method(value);

#if BEHAVIOR_V5
        // BUG: See https://github.com/unitycontainer/container/issues/291
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => _default;
#endif
    }
}


namespace Regression.Implicit.Methods.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
        public override Type Dependency => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
        public override Type Dependency => typeof(string);
    }

    public class Implicit_Derived_WithDefaultAttribute : Implicit_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([DefaultValue(_default)] int value = PatternBase.DefaultValueInt) => base.Method(value);

#if BEHAVIOR_V5
        // BUG: See https://github.com/unitycontainer/container/issues/291
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => _default;
#endif
        public override Type Dependency => typeof(int);
    }
}


namespace Regression.Implicit.Methods.WithDefaultAndAttribute
{
    public class Implicit_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
        public override Type Dependency => typeof(int);
    }

    public class Implicit_String_WithDefaultAndAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultString;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
        public override Type Dependency => typeof(string);
    }

    public class Implicit_Derived_WithDefaultAndAttribute : Implicit_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([DefaultValue(_default)] int value = PatternBase.DefaultValueInt) => base.Method(value);
#if BEHAVIOR_V5
        // BUG: See https://github.com/unitycontainer/container/issues/291
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => _default;
#endif
    }
}
