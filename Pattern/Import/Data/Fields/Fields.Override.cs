using System;
using System.ComponentModel;


namespace Import.Override.Fields.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => PatternBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }
}
