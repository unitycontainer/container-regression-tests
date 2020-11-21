using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Implicit.Constructors.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        public Implicit_Int_WithDefaultAttribute([DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        public Implicit_String_WithDefaultAttribute([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Implicit_Derived_WithDefaultAttribute : Implicit_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefaultAttribute([DefaultValue(_default)] int value)
            : base(value) { }

        public override object Expected => _default;
    }
}


namespace Regression.Annotated.Constructors.WithDefaultAttribute
{
    public class Required_Int_WithDefaultAttribute : PatternBaseType
    {
        public Required_Int_WithDefaultAttribute([Dependency][DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Optional_Int_WithDefaultAttribute : PatternBaseType
    {
        public Optional_Int_WithDefaultAttribute([OptionalDependency][DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;
        public override object Expected => PatternBase.DefaultValueInt;
    }


    public class Required_WithDefaultAttribute_Int : PatternBaseType
    {
        public Required_WithDefaultAttribute_Int([DefaultValue(PatternBase.DefaultValueInt)][Dependency] int value) => Value = value;
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Optional_WithDefaultAttribute_Int : PatternBaseType
    {
        public Optional_WithDefaultAttribute_Int([DefaultValue(PatternBase.DefaultValueInt)][OptionalDependency] int value) => Value = value;
        public override object Expected => PatternBase.DefaultValueInt;
    }


    public class Required_String_WithDefaultAttribute : PatternBaseType
    {
        public Required_String_WithDefaultAttribute([Dependency][DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Optional_String_WithDefaultAttribute : PatternBaseType
    {
        public Optional_String_WithDefaultAttribute([OptionalDependency][DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;
        public override object Expected => PatternBase.DefaultValueString;
    }


    public class Required_WithDefaultAttribute_String : PatternBaseType
    {
        public Required_WithDefaultAttribute_String([DefaultValue(PatternBase.DefaultValueString)][Dependency] string value) => Value = value;
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Optional_WithDefaultAttribute_String : PatternBaseType
    {
        public Optional_WithDefaultAttribute_String([DefaultValue(PatternBase.DefaultValueString)][OptionalDependency] string value) => Value = value;
        public override object Expected => PatternBase.DefaultValueString;
    }


    public class Required_Derived_WithDefaultAttribute : Required_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Required_Derived_WithDefaultAttribute([Dependency][DefaultValue(_default)] int value) : base(value) { }
        public override object Expected => _default;
    }

    public class Optional_Derived_WithDefaultAttribute : Optional_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Optional_Derived_WithDefaultAttribute([OptionalDependency][DefaultValue(_default)] int value) : base(value) { }
        public override object Expected => _default;
    }
}
