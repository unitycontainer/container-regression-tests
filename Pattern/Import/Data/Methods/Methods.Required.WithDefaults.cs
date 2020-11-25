using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif



namespace Import.Annotated.Methods.Required.WithDefaults
{
    #region WithDefault

    public class Required_Parameter_Int_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] int value = PatternBase.DefaultInt) => Value = value;
        public override object Default => PatternBase.DefaultInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Parameter_String_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] string value = PatternBase.DefaultString) => Value = value;
        public override object Default => PatternBase.DefaultString;
        public override Type ImportType => typeof(string);
    }

    public class Required_DerivedFromInt_WithDefault : Required_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([Dependency] int value = _default) => base.Method(value);

#if  !BEHAVIOR_V5 // Issue: https://github.com/unitycontainer/container/issues/291
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }

    #endregion


    #region WithDefaultAttribute

#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute

    public class Required_Int_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency][DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_WithDefaultAttribute_Int : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueInt)][Dependency] int value) => Value = value;

        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_String_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency][DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Default => PatternBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_WithDefaultAttribute_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueString)][Dependency] string value) => Value = value;

        public override object Default => PatternBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Derived_WithDefaultAttribute : Required_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public override void Method([DefaultValue(_default), Dependency] int value) => base.Method(value);

        public override object Default => _default;
        public override Type ImportType => typeof(int);
    }

#endif

    #endregion


    #region WithDefaultAndAttribute

    public class Required_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency][DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultInt;
#else
        public override object Default => PatternBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Required_WithDefaultAndAttribute_Int : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueInt)][Dependency] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultInt;
#else
        public override object Default => PatternBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Required_String_WithDefaultAndAttribute : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency][DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultString;
#else
        public override object Default => PatternBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Required_WithDefaultAndAttribute_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueString)][Dependency] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultString;
#else
        public override object Default => PatternBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Required_Derived_WithDefaultAndAttribute : Required_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([Dependency][DefaultValue(_default)] int value = PatternBase.DefaultValueInt)
        { base.Method(value); }

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }

    #endregion
}
