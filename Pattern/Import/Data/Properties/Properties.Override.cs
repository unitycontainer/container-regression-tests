using System;
using System.ComponentModel;



namespace Regression.Override.Properties.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] public int Property { get; set; }

        public override object Value { get => Property; }

        public override object Expected => PatternBase.DefaultValueInt;
        public override Type Dependency => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] public string Property { get; set; }

        public override object Value { get => Property; }

        public override object Expected => PatternBase.DefaultValueString;
        public override Type Dependency => typeof(string);
    }
}
