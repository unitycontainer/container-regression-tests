using System;
using System.ComponentModel;


namespace Regression.Implicit.Constructors.WithDefault
{
    public class Implicit_Parameter_Int_WithDefault : PatternBaseType
    {
        public Implicit_Parameter_Int_WithDefault(int value = PatternBase.DefaultInt) => Value = value;

        public override object Default => PatternBase.DefaultInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_Parameter_String_WithDefault : PatternBaseType
    {
        public Implicit_Parameter_String_WithDefault(string value = PatternBase.DefaultString) => Value = value;

        public override object Default => PatternBase.DefaultString;
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


namespace Regression.Implicit.Constructors.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        public Implicit_Int_WithDefaultAttribute([DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        public Implicit_String_WithDefaultAttribute([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Default => PatternBase.DefaultValueString;
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


namespace Regression.Implicit.Constructors.WithDefaultAndAttribute
{
    public class Implicit_Int_WithDefaultAndAttribute : PatternBaseType
    {
        public Implicit_Int_WithDefaultAndAttribute([DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Default => PatternBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAndAttribute : PatternBaseType
    {
        public Implicit_String_WithDefaultAndAttribute([DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultString;
#else
        public override object Default => PatternBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Derived_WithDefaultAndAttribute : Implicit_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefaultAndAttribute([DefaultValue(_default)] int value = PatternBase.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Expected => PatternBase.DefaultValueInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }
}
