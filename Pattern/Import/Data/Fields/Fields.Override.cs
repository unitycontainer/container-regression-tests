using System;
using System.ComponentModel;


namespace Regression.Override.Fields.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Expected => PatternBase.DefaultValueInt;
        public override Type Dependency => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Expected => PatternBase.DefaultValueString;
        public override Type Dependency => typeof(string);
    }
}
