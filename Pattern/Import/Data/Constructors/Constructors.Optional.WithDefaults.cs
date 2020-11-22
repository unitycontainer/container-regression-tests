using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Constructors.Optional.WithDefaults
{
    #region WithDefault

#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Parameter_Int_WithDefault : PatternBaseType
    {
        public Optional_Parameter_Int_WithDefault([OptionalDependency] int value = PatternBase.DefaultInt) => Value = value;
        public override object Expected => PatternBase.DefaultInt;
        public override Type Dependency => typeof(int);
    }


    public class Optional_DerivedFromInt_WithDefault : Optional_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        public Optional_DerivedFromInt_WithDefault([OptionalDependency] int value = _default) : base(value) { }
        public override object Expected => _default;
        public override Type Dependency => typeof(int);
    }

#endif


    public class Optional_Parameter_String_WithDefault : PatternBaseType
    {
        public Optional_Parameter_String_WithDefault([OptionalDependency] string value = PatternBase.DefaultString) => Value = value;

#if  BEHAVIOR_V4 // Unity v4 did not support default values
        public override object Expected => null;
#else
        public override object Expected => PatternBase.DefaultString;
#endif
        public override Type Dependency => typeof(string);
    }

    #endregion


    #region WithDefaultAttribute


#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Int_WithDefaultAttribute : PatternBaseType
    {
        public Optional_Int_WithDefaultAttribute([OptionalDependency][DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => 0;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
        public override Type Dependency => typeof(int);
    }


    public class Optional_WithDefaultAttribute_Int : PatternBaseType
    {
        public Optional_WithDefaultAttribute_Int([DefaultValue(PatternBase.DefaultValueInt)][OptionalDependency] int value) => Value = value;
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => 0;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
        public override Type Dependency => typeof(int);
    }


    public class Optional_Derived_WithDefaultAttribute : Optional_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Optional_Derived_WithDefaultAttribute([OptionalDependency][DefaultValue(_default)] int value) : base(value) { }
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => 0;
#else
        public override object Expected => _default;
#endif
        public override Type Dependency => typeof(int);
    }


#endif


    public class Optional_String_WithDefaultAttribute : PatternBaseType
    {
        public Optional_String_WithDefaultAttribute([OptionalDependency][DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => null;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
        public override Type Dependency => typeof(string);
    }


    public class Optional_WithDefaultAttribute_String : PatternBaseType
    {
        public Optional_WithDefaultAttribute_String([DefaultValue(PatternBase.DefaultValueString)][OptionalDependency] string value) => Value = value;
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => null;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
        public override Type Dependency => typeof(string);
    }

    #endregion


    #region WithDefaultAndAttribute


#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Int_WithDefaultAndAttribute : PatternBaseType
    {
        public Optional_Int_WithDefaultAndAttribute([OptionalDependency][DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
        public override Type Dependency => typeof(int);
    }


    public class Optional_WithDefaultAndAttribute_Int : PatternBaseType
    {
        public Optional_WithDefaultAndAttribute_Int([DefaultValue(PatternBase.DefaultValueInt)][OptionalDependency] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
        public override Type Dependency => typeof(int);
    }


    public class Optional_Derived_WithDefaultAndAttribute : Optional_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        public Optional_Derived_WithDefaultAndAttribute([OptionalDependency][DefaultValue(_default)] int value = PatternBase.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Expected => PatternBase.DefaultValueInt;
#else
        public override object Expected => _default;
#endif
        public override Type Dependency => typeof(int);
    }


#endif


    public class Optional_String_WithDefaultAndAttribute : PatternBaseType
    {
        public Optional_String_WithDefaultAndAttribute([OptionalDependency][DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V4     // Unity v4 did not support default values
        public override object Expected => null;
#elif BEHAVIOR_V5   // Unity v5 did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultString;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
        public override Type Dependency => typeof(string);
    }


    public class Optional_WithDefaultAndAttribute_String : PatternBaseType
    {
        public Optional_WithDefaultAndAttribute_String([DefaultValue(PatternBase.DefaultValueString)][OptionalDependency] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V4     // Unity v4 did not support default values
        public override object Expected => null;
#elif BEHAVIOR_V5   // Unity v5 did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultString;
#else
        public override object Expected => PatternBase.DefaultValueString;
#endif
        public override Type Dependency => typeof(string);
    }

    #endregion
}
