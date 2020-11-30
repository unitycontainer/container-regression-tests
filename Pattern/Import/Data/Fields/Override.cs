using System;
using System.ComponentModel;
using static Import.ImportBase;


namespace Import.Override.Fields.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueInt)] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueString)] public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => ImportBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }
}
