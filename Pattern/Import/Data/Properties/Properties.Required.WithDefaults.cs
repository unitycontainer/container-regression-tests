using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Annotated.Properties.Required.WithDefaults
{

    #region WithDefault

    // Unity does not support implicit default values on properties
    // When resolved it will throw if not registered
    //
    //public class Required_WithDefault : PatternBaseType
    //{
    //    [Dependency] public int Property { get; set; } = PatternBase.DefaultInt;
    //}

    #endregion


#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute on properties


    #region WithDefaultAttribute

    public class Required_Property_Int_WithDefaultAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueInt)] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_WithDefaultAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] [Dependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_String_WithDefaultAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueString)] public string Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => PatternBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_WithDefaultAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] [Dependency] public string Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => PatternBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_Derived_WithDefaultAttribute
        : Required_Property_Int_WithDefaultAttribute
    {
    }

    #endregion


    #region WithDefaultAndAttribute

    public class Required_Property_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueInt)] public int Property { get; set; } = PatternBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_WithDefaultAndAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] [Dependency] public int Property { get; set; } = PatternBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => PatternBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_String_WithDefaultAndAttribute : PatternBaseType
    {
        [Dependency] [DefaultValue(PatternBase.DefaultValueString)] public string Property { get; set; } = PatternBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => PatternBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_WithDefaultAndAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] [Dependency] public string Property { get; set; } = PatternBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => PatternBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_Derived_WithDefaultAndAttribute : Required_Property_Int_WithDefaultAndAttribute
    {
    }

    #endregion


#else

    public class Dummy_Success_Type : PatternBaseType
    {
        public override object Value { get => null; }
        public override object Default => null;
    }

#endif
}
