using System;
using System.ComponentModel;
using static Import.ImportBase;

namespace Import.Override.Properties.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueInt)] public int Property { get; set; }

        public override object Value { get => Property; }

        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueString)] public string Property { get; set; }

        public override object Value { get => Property; }

        public override object Default => ImportBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }
}
