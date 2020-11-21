using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif



namespace Regression.Annotated.Constructors.Required.WithDefaults
{
    #region WithDefault

    public class Required_Parameter_Int_WithDefault : PatternBaseType
    {
        public Required_Parameter_Int_WithDefault([Dependency] int value = PatternBase.DefaultInt) => Value = value;
        public override object Expected => PatternBase.DefaultInt;
    }

    public class Required_Parameter_String_WithDefault : PatternBaseType
    {
        public Required_Parameter_String_WithDefault([Dependency] string value = PatternBase.DefaultString) => Value = value;
        public override object Expected => PatternBase.DefaultString;
    }

    public class Required_DerivedFromInt_WithDefault : Required_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        public Required_DerivedFromInt_WithDefault([Dependency] int value = _default) : base(value) { }
        public override object Expected => _default;
    }

    #endregion


    #region WithDefaultAttribute

#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute

    public class Required_Int_WithDefaultAttribute : PatternBaseType
    {
        public Required_Int_WithDefaultAttribute([Dependency][DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Required_WithDefaultAttribute_Int : PatternBaseType
    {
        public Required_WithDefaultAttribute_Int([DefaultValue(PatternBase.DefaultValueInt)][Dependency] int value) => Value = value;
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Required_String_WithDefaultAttribute : PatternBaseType
    {
        public Required_String_WithDefaultAttribute([Dependency][DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Required_WithDefaultAttribute_String : PatternBaseType
    {
        public Required_WithDefaultAttribute_String([DefaultValue(PatternBase.DefaultValueString)][Dependency] string value) => Value = value;
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Required_Derived_WithDefaultAttribute : Required_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Required_Derived_WithDefaultAttribute([Dependency][DefaultValue(_default)] int value) : base(value) { }
        public override object Expected => _default;
    }

#endif

    #endregion


    #region WithDefaultAndAttribute

    public class Required_Int_WithDefaultAndAttribute : PatternBaseType
    {
        public Required_Int_WithDefaultAndAttribute([Dependency][DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
    }

    public class Required_WithDefaultAndAttribute_Int : PatternBaseType
    {
        public Required_WithDefaultAndAttribute_Int([DefaultValue(PatternBase.DefaultValueInt)][Dependency] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
    }

    public class Required_String_WithDefaultAndAttribute : PatternBaseType
    {
        public Required_String_WithDefaultAndAttribute([Dependency][DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultString;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
    }

    public class Required_WithDefaultAndAttribute_String : PatternBaseType
    {
        public Required_WithDefaultAndAttribute_String([DefaultValue(PatternBase.DefaultValueString)][Dependency] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultString;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
    }

    public class Required_Derived_WithDefaultAndAttribute : Required_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        public Required_Derived_WithDefaultAndAttribute([Dependency][DefaultValue(_default)] int value = PatternBase.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Expected => PatternBase.DefaultValueInt;
#else
        public override object Expected => _default;
#endif
    }

    #endregion
}
