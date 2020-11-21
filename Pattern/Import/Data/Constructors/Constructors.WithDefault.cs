using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Implicit.Constructors.WithDefault
{
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

    public class Implicit_Derived_WithDefault : Implicit_Int_WithDefault
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefault(int value = _default)
            : base(value) { }

        public override object Expected => _default;
    }
}


namespace Regression.Annotated.Constructors.WithDefault
{
    public class Required_Int_WithDefault : PatternBaseType
    {
        public Required_Int_WithDefault([Dependency] int value = PatternBase.DefaultInt) => Value = value;
        public override object Expected => PatternBase.DefaultInt;
    }

    public class Required_String_WithDefault : PatternBaseType
    {
        public Required_String_WithDefault([Dependency] string value = PatternBase.DefaultString) => Value = value;
        public override object Expected => PatternBase.DefaultString;
    }

    public class Required_DerivedFromInt_WithDefault : Required_Int_WithDefault
    {
        private const int _default = 1111;

        public Required_DerivedFromInt_WithDefault([Dependency] int value = _default) : base(value) { }
        public override object Expected => _default;
    }

    public class Optional_Int_WithDefault : PatternBaseType
    {
        public Optional_Int_WithDefault([OptionalDependency] int value = PatternBase.DefaultInt) => Value = value;
        public override object Expected => PatternBase.DefaultInt;
    }

    public class Optional_String_WithDefault : PatternBaseType
    {
        public Optional_String_WithDefault([OptionalDependency] string value = PatternBase.DefaultString) => Value = value;
        public override object Expected => PatternBase.DefaultString;
    }

    public class Optional_DerivedFromInt_WithDefault : Optional_Int_WithDefault
    {
        private const int _default = 1111;

        public Optional_DerivedFromInt_WithDefault([OptionalDependency] int value = _default) : base(value) { }
        public override object Expected => _default;
    }
}
