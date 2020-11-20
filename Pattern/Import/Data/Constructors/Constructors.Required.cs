using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
#endif

namespace Regression.Annotated.Constructors
{
}


namespace Regression.Annotated.Constructors.Required
{
}

namespace Regression.Annotated.Constructors.Required.WithDefault
{

    public class Required_Int_WithDefault : PatternBaseType
    {
        public Required_Int_WithDefault(int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultInt;
    }

    public class Required_String_WithDefault : PatternBaseType
    {
        public Required_String_WithDefault(string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultString;
    }

    public class Required_Derived_WithDefault : Required_Int_WithDefault
    {
        private const int _default = 1111;

        public Required_Derived_WithDefault(int value = _default)
            : base(value) { }

        public override object Expected => _default;
    }
}

namespace Regression.Annotated.Constructors.Required.WithDefaultAttribute
{
    public class Required_Int_WithDefaultAttribute : PatternBaseType
    {
        public Required_Int_WithDefaultAttribute([DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Required_String_WithDefaultAttribute : PatternBaseType
    {
        public Required_String_WithDefaultAttribute([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Required_Derived_WithDefaultAttribute : Required_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Required_Derived_WithDefaultAttribute([DefaultValue(_default)] int value)
            : base(value) { }

        public override object Expected => _default;
    }
}

namespace Regression.Annotated.Constructors.Required.WithDefaultAndAttribute
{
    public class Required_Int_WithDefaultAndAttribute : PatternBaseType
    {
        public Required_Int_WithDefaultAndAttribute([DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => PatternBase.DefaultValueInt;
#endif
    }

    public class Required_String_WithDefaultAndAttribute : PatternBaseType
    {
        public Required_String_WithDefaultAndAttribute([DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

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

        public Required_Derived_WithDefaultAndAttribute([DefaultValue(_default)] int value = PatternBase.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Expected => PatternBase.DefaultValueInt;
#else
        public override object Expected => _default;
#endif
    }

}
