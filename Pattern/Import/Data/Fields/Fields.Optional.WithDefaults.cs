using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Annotated.Fields.Optional.WithDefaults
{
    #region WithDefault

#if !BEHAVIOR_V4 // v4 did not support optional value types
    public class Optional_Field_Int_WithDefault : PatternBaseType
    {
        [OptionalDependency] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

#if  BEHAVIOR_V5 // Unity v5 did not support default values for fields
        public override object Default => 0;
#else
        public override object Default => PatternBase.DefaultInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_DerivedFromInt_WithDefault : Optional_Field_Int_WithDefault
    {
    }

#endif


    public class Optional_Field_String_WithDefault : PatternBaseType
    {
        [OptionalDependency] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

#if  BEHAVIOR_V4 || BEHAVIOR_V5 // Unity v4 and v5 did not support default values for fields
        public override object Default => null;
#else
        public override object Default => PatternBase.DefaultString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Optional_DerivedFromString_WithDefault : Optional_Field_String_WithDefault
    {
    }

    #endregion


    #region WithDefaultAttribute

#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Int_WithDefaultAttribute : PatternBaseType
    {
        [OptionalDependency] [DefaultValue(PatternBase.DefaultValueInt)] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => 0;
#else
        public override object Default => PatternBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_WithDefaultAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] [OptionalDependency] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => 0;
#else
        public override object Default => PatternBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_Derived_WithDefaultAttribute : Optional_Int_WithDefaultAttribute
    {
    }

#endif

    public class Optional_String_WithDefaultAttribute : PatternBaseType
    {
        [OptionalDependency] [DefaultValue(PatternBase.DefaultValueString)] public string Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => null;
#else
        public override object Default => PatternBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Optional_WithDefaultAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] [OptionalDependency] public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => null;
#else
        public override object Default => PatternBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    #endregion


    #region 

#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [OptionalDependency] [DefaultValue(PatternBase.DefaultValueInt)] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V5   // Unity v5 did not support default value for fields
        public override object Default => 0;
#else
        public override object Default => PatternBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_WithDefaultAndAttribute_Int : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueInt)] [OptionalDependency] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V5   // Unity v5 did not support default value for fields
        public override object Default => 0;
#else
        public override object Default => PatternBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_Derived_WithDefaultAndAttribute : Optional_Int_WithDefaultAndAttribute
    {
    }

#endif

    public class Optional_String_WithDefaultAndAttribute : PatternBaseType
    {
        [OptionalDependency] [DefaultValue(PatternBase.DefaultValueString)] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V4 ||  BEHAVIOR_V5 // Unity v4 and v5 did not support default values for fields
        public override object Default => null;
#else
        public override object Default => PatternBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Optional_WithDefaultAndAttribute_String : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultValueString)] [OptionalDependency] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }


#if BEHAVIOR_V4 ||  BEHAVIOR_V5 // Unity v4 and v5 did not support default values for fields
        public override object Default => null;
#else
        public override object Default => PatternBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    #endregion
}
