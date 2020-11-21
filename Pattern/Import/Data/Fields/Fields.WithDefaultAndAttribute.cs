using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Fields.WithDefaultAndAttribute
{
    public class Required_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [Dependency][DefaultValue(PatternBase.DefaultValueInt)] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Optional_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [OptionalDependency][DefaultValue(PatternBase.DefaultValueInt)] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }


    public class Required_WithDefaultAndAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)][Dependency] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Optional_WithDefaultAndAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)][OptionalDependency] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }


    public class Required_String_WithDefaultAndAttribute : PatternBaseType
    {
        [Dependency][DefaultValue(PatternBase.DefaultValueString)] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Optional_String_WithDefaultAndAttribute : PatternBaseType
    {
        [OptionalDependency][DefaultValue(PatternBase.DefaultValueString)] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }


    public class Required_WithDefaultAndAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)][Dependency] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Optional_WithDefaultAndAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)][OptionalDependency] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }


    public class Required_Derived_WithDefaultAndAttribute : Required_Int_WithDefaultAndAttribute
    {
    }

    public class Optional_Derived_WithDefaultAndAttribute : Optional_Int_WithDefaultAndAttribute
    {
    }
}
