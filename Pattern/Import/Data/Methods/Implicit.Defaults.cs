using Regression;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Methods.ImplicitWithDefaults
{
    #region Default Only

    public class Implicit_Int_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultInt;
    }

    public class Implicit_String_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultString;
    }

    #endregion


    #region Attribute Only

    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    #endregion


    #region Attribute And Default

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
    }

    #endregion


    #region Derived

    public class Implicit_Derived_WithDefault : Implicit_Int_WithDefault
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
    }

    public class Implicit_Derived_WithDefaultAndAttribute : Implicit_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;
        
        [InjectionMethod]
        public override void Method([DefaultValue(_default)]int value = PatternBase.DefaultValueInt) => base.Method(value);
#if BEHAVIOR_V5
        // BUG: See https://github.com/unitycontainer/container/issues/291
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => _default;
#endif
    }

    #endregion
}
