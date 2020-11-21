using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Fields.WithDefaultAttribute
{
    public class Required_Int_WithDefaultAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueInt)] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Optional_Int_WithDefaultAttribute : PatternBaseType
    {
        [OptionalDependency] [DefaultValue(PatternBase.DefaultValueInt)] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Required_WithDefaultAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] [Dependency] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Optional_WithDefaultAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] [OptionalDependency] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }


    public class Required_String_WithDefaultAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueString)] public string Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Optional_String_WithDefaultAttribute : PatternBaseType
    {
        [OptionalDependency] [DefaultValue(PatternBase.DefaultValueString)] public string Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }


    public class Required_WithDefaultAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] [Dependency] public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Optional_WithDefaultAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] [OptionalDependency] public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }


    public class Required_Derived_WithDefaultAttribute : Required_Int_WithDefaultAttribute
    {
    }

    public class Optional_Derived_WithDefaultAttribute : Optional_Int_WithDefaultAttribute
    {
    }
}
