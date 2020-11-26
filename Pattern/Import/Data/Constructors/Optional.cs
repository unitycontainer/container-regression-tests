using Regression;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Annotated.Constructors.Optional
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public BaselineTestType([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        public BaselineTestTypeNamed([OptionalDependency(ImportBase.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency>
        : BaselineTestType<TDependency>
    {
        public BaselineInheritedType([OptionalDependency] TDependency value)
            : base(value)
        { }
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
        public BaselineInheritedTwice([OptionalDependency] TDependency value)
            : base(value)
        { }
    }

    public class DownTheLineType<TDependency>
        : PatternBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }

    public class ArrayTestType<TDependency>
        : PatternBaseType
    {
        public ArrayTestType([OptionalDependency] TDependency[] value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class PrivateTestType<TDependency>
        : PatternBaseType
    {
        private PrivateTestType([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : PatternBaseType
    {
        protected ProtectedTestType([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : PatternBaseType
    {
        internal InternalTestType([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Ref([OptionalDependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Out([OptionalDependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }
}



namespace Import.Annotated.Constructors.Optional.WithDefaults
{
    #region WithDefault

#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Parameter_Int_WithDefault : PatternBaseType
    {
        public Optional_Parameter_Int_WithDefault([OptionalDependency] int value = ImportBase.DefaultInt) => Value = value;
        public override object Default => ImportBase.DefaultInt;
        public override Type ImportType => typeof(int);
    }


    public class Optional_DerivedFromInt_WithDefault : Optional_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        public Optional_DerivedFromInt_WithDefault([OptionalDependency] int value = _default) : base(value) { }
        public override object Default => _default;
        public override Type ImportType => typeof(int);
    }

#endif


    public class Optional_Parameter_String_WithDefault : PatternBaseType
    {
        public Optional_Parameter_String_WithDefault([OptionalDependency] string value = ImportBase.DefaultString) => Value = value;

#if  BEHAVIOR_V4 // Unity v4 did not support default values
        public override object Default => null;
#else
        public override object Default => ImportBase.DefaultString;
#endif
        public override Type ImportType => typeof(string);
    }

    #endregion


    #region WithDefaultAttribute


#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Int_WithDefaultAttribute : PatternBaseType
    {
        public Optional_Int_WithDefaultAttribute([OptionalDependency][DefaultValue(ImportBase.DefaultValueInt)] int value) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => 0;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Optional_WithDefaultAttribute_Int : PatternBaseType
    {
        public Optional_WithDefaultAttribute_Int([DefaultValue(ImportBase.DefaultValueInt)][OptionalDependency] int value) => Value = value;
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => 0;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Optional_Derived_WithDefaultAttribute : Optional_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Optional_Derived_WithDefaultAttribute([OptionalDependency][DefaultValue(_default)] int value) : base(value) { }
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => 0;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }


#endif


    public class Optional_String_WithDefaultAttribute : PatternBaseType
    {
        public Optional_String_WithDefaultAttribute([OptionalDependency][DefaultValue(ImportBase.DefaultValueString)] string value) => Value = value;
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => null;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }


    public class Optional_WithDefaultAttribute_String : PatternBaseType
    {
        public Optional_WithDefaultAttribute_String([DefaultValue(ImportBase.DefaultValueString)][OptionalDependency] string value) => Value = value;
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => null;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    #endregion


    #region WithDefaultAndAttribute


#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Int_WithDefaultAndAttribute : PatternBaseType
    {
        public Optional_Int_WithDefaultAndAttribute([OptionalDependency][DefaultValue(ImportBase.DefaultValueInt)] int value = ImportBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Optional_WithDefaultAndAttribute_Int : PatternBaseType
    {
        public Optional_WithDefaultAndAttribute_Int([DefaultValue(ImportBase.DefaultValueInt)][OptionalDependency] int value = ImportBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Optional_Derived_WithDefaultAndAttribute : Optional_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        public Optional_Derived_WithDefaultAndAttribute([OptionalDependency][DefaultValue(_default)] int value = ImportBase.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Default => ImportBase.DefaultValueInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }


#endif


    public class Optional_String_WithDefaultAndAttribute : PatternBaseType
    {
        public Optional_String_WithDefaultAndAttribute([OptionalDependency][DefaultValue(ImportBase.DefaultValueString)] string value = ImportBase.DefaultString) => Value = value;

#if BEHAVIOR_V4     // Unity v4 did not support default values
        public override object Default => null;
#elif BEHAVIOR_V5   // Unity v5 did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }


    public class Optional_WithDefaultAndAttribute_String : PatternBaseType
    {
        public Optional_WithDefaultAndAttribute_String([DefaultValue(ImportBase.DefaultValueString)][OptionalDependency] string value = ImportBase.DefaultString) => Value = value;

#if BEHAVIOR_V4     // Unity v4 did not support default values
        public override object Default => null;
#elif BEHAVIOR_V5   // Unity v5 did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    #endregion
}
