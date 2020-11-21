using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Methods.Optional.WithDefaults
{
    #region WithDefault

#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Parameter_Int_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] int value = PatternBase.DefaultInt) => Value = value;
        public override object Expected => PatternBase.DefaultInt;
    }

    public class Optional_DerivedFromInt_WithDefault : Optional_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([OptionalDependency] int value = _default) => base.Method(value);

#if  !BEHAVIOR_V5 // Issue: https://github.com/unitycontainer/container/issues/291
        public override object Expected => _default;
#endif
    }
#endif

    public class Optional_Parameter_String_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] string value = PatternBase.DefaultString) => Value = value;

#if  BEHAVIOR_V4 // Unity v4 did not support default values
        public override object Expected => null;
#else
        public override object Expected => PatternBase.DefaultString;
#endif
    }

    #endregion


    #region WithDefaultAttribute

#if !BEHAVIOR_V4 // v4 did not support optional value types
    public class Optional_Int_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency][DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => 0;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
    }

    public class Optional_WithDefaultAttribute_Int : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueInt)][OptionalDependency] int value) => Value = value;
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => 0;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
    }

    public class Optional_Derived_WithDefaultAttribute : Optional_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public override void Method([DefaultValue(_default)][OptionalDependency] int value) => base.Method(value);

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => 0;
#else
        public override object Expected => _default;
#endif
    }

#endif

    public class Optional_String_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency][DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => null;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
    }

    public class Optional_WithDefaultAttribute_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueString)][OptionalDependency] string value) => Value = value;
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => null;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
    }

    #endregion


    #region WithDefaultAndAttribute

#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency][DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
    }

    public class Optional_WithDefaultAndAttribute_Int : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueInt)][OptionalDependency] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
    }

    public class Optional_Derived_WithDefaultAndAttribute : Optional_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([OptionalDependency][DefaultValue(_default)] int value = PatternBase.DefaultValueInt)
        { base.Method(value); }

#if BEHAVIOR_V5
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => _default;
#endif
    }

#endif

    public class Optional_String_WithDefaultAndAttribute : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency][DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V4     // Unity v4 did not support default values
        public override object Expected => null;
#elif BEHAVIOR_V5   // Unity v5 did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultString;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
    }

    public class Optional_WithDefaultAndAttribute_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueString)][OptionalDependency] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V4     // Unity v4 did not support default values
        public override object Expected => null;
#elif BEHAVIOR_V5   // Unity v5 did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultString;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
    }

    #endregion
}
