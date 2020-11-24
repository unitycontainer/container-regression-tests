using System;
using System.ComponentModel;



namespace Regression.Override.Properties.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] public int Property { get; set; }

        public override object Value { get => Property; }

        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] public string Property { get; set; }

        public override object Value { get => Property; }

        public override object Default => PatternBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }
}
