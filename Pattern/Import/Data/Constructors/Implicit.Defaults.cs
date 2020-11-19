using Regression;
using System.ComponentModel;

namespace Constructors.ImplicitWithDefaults
{
    #region Default Only

    public class Implicit_Int_WithDefault : PatternBaseType
    {
        public Implicit_Int_WithDefault(int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultInt;
    }

    public class Implicit_String_WithDefault : PatternBaseType
    {
        public Implicit_String_WithDefault(string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultString;
    }

    #endregion


    #region Attribute Only

    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        public Implicit_Int_WithDefaultAttribute([DefaultValue(PatternBase.DefaultValueInt)]int value) => Value = value;
        
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        public Implicit_String_WithDefaultAttribute([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    #endregion


    #region Attribute And Default

    public class Implicit_Int_WithDefaultAndAttribute : PatternBaseType
    {
        public Implicit_Int_WithDefaultAndAttribute([DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
    }

    public class Implicit_String_WithDefaultAndAttribute : PatternBaseType
    {
        public Implicit_String_WithDefaultAndAttribute([DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

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

        public Implicit_Derived_WithDefault(int value = _default)
            : base(value) { }

        public override object Expected => _default;
    }

    public class Implicit_Derived_WithDefaultAttribute : Implicit_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefaultAttribute([DefaultValue(_default)] int value)
            : base(value) { }

        public override object Expected => _default;
    }

    public class Implicit_Derived_WithDefaultAndAttribute : Implicit_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;
        
        public Implicit_Derived_WithDefaultAndAttribute([DefaultValue(_default)] int value = PatternBase.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Expected => PatternBase.DefaultValueInt;
#else
        public override object Expected => _default;
#endif
    }

    #endregion
}


