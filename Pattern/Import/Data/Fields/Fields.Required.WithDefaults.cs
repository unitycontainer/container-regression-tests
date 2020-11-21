using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Fields.Required.WithDefaults
{
    #region WithDefault

    // Unity does not support implicit default values on fields
    // When resolved it will throw if not registered
    //
    //public class Required_WithDefault : PatternBaseType
    //{
    //    [Dependency] public int Field = PatternBase.DefaultInt;
    //}

    #endregion

#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute on fields

    #region WithDefaultAttribute

    public class Required_Field_Int_WithDefaultAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueInt)] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Required_Field_WithDefaultAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] [Dependency] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Required_Field_String_WithDefaultAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueString)] public string Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Required_Field_WithDefaultAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] [Dependency] public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Required_Derived_WithDefaultAttribute : Required_Field_Int_WithDefaultAttribute
    {
    }

    #endregion


    #region WithDefaultAndAttribute

    public class Required_Field_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueInt)] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Required_Field_WithDefaultAndAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] [Dependency] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Required_Field_String_WithDefaultAndAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueString)] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Required_Field_WithDefaultAndAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] [Dependency] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Required_Derived_WithDefaultAndAttribute : Required_Field_Int_WithDefaultAndAttribute
    {
    }

    #endregion

#else

    public class Dummy_Success_Type : PatternBaseType
    {
        public override object Value { get => null; }
        public override object Expected => null;
    }

#endif

}
