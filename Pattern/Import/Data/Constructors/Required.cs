using Regression;
using System;
using System.ComponentModel;
using static Import.Pattern;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Import.Required.Constructors
{
    #region Validation

    public class PrivateTestType<TDependency>
        : FixtureBaseType
    {
        private PrivateTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : FixtureBaseType
    {
        protected ProtectedTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : FixtureBaseType
    {
        internal InternalTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestType_Ref<TDependency>
        : FixtureBaseType where TDependency : class
    {
        public BaselineTestType_Ref([Dependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : FixtureBaseType where TDependency : class
    {
        public BaselineTestType_Out([Dependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion
}



namespace Import.Required.Constructors.WithDefault
{

    public class Required_Parameter_Int_WithDefault : ImportBaseType
    {
        public Required_Parameter_Int_WithDefault([Dependency] int value = Pattern.DefaultInt) => Value = value;
        public override object Default => Pattern.DefaultInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefault : ImportBaseType
    {
        public Required_Parameter_String_WithDefault([Dependency] string value = Pattern.DefaultString) => Value = value;
        public override object Default => Pattern.DefaultString;
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_DerivedFromInt_WithDefault : Required_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        public Required_Parameter_DerivedFromInt_WithDefault([Dependency] int value = _default) : base(value) { }
        public override object Default => _default;
        public override Type ImportType => typeof(int);
    }
}


namespace Import.Required.Constructors.WithDefaultAttribute
{
#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute

    public class Required_Parameter_Int_WithDefaultAttribute : ImportBaseType
    {
        public Required_Parameter_Int_WithDefaultAttribute([Dependency][DefaultValue(Pattern.DefaultValueInt)] int value) => Value = value;
        public override object Default => Pattern.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_WithDefaultAttribute_Int : ImportBaseType
    {
        public Required_Parameter_WithDefaultAttribute_Int([DefaultValue(Pattern.DefaultValueInt)][Dependency] int value) => Value = value;
        public override object Default => Pattern.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefaultAttribute : ImportBaseType
    {
        public Required_Parameter_String_WithDefaultAttribute([Dependency][DefaultValue(Pattern.DefaultValueString)] string value) => Value = value;
        public override object Default => Pattern.DefaultValueString;
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_WithDefaultAttribute_String : ImportBaseType
    {
        public Required_Parameter_WithDefaultAttribute_String([DefaultValue(Pattern.DefaultValueString)][Dependency] string value) => Value = value;
        public override object Default => Pattern.DefaultValueString;
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_Derived_WithDefaultAttribute : Required_Parameter_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Required_Parameter_Derived_WithDefaultAttribute([Dependency][DefaultValue(_default)] int value) : base(value) { }
        public override object Default => _default;
        public override Type ImportType => typeof(int);
    }

#endif
}


namespace Import.Required.Constructors.WithDefaultAndAttribute
{

    public class Required_Parameter_Int_WithDefaultAndAttribute : ImportBaseType
    {
        public Required_Parameter_Int_WithDefaultAndAttribute([Dependency][DefaultValue(Pattern.DefaultValueInt)] int value = Pattern.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => Pattern.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_WithDefaultAndAttribute_Int : ImportBaseType
    {
        public Required_Parameter_WithDefaultAndAttribute_Int([DefaultValue(Pattern.DefaultValueInt)][Dependency] int value = Pattern.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => Pattern.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefaultAndAttribute : ImportBaseType
    {
        public Required_Parameter_String_WithDefaultAndAttribute([Dependency][DefaultValue(Pattern.DefaultValueString)] string value = Pattern.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => Pattern.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_WithDefaultAndAttribute_String : ImportBaseType
    {
        public Required_Parameter_WithDefaultAndAttribute_String([DefaultValue(Pattern.DefaultValueString)][Dependency] string value = Pattern.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => Pattern.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_Derived_WithDefaultAndAttribute : Required_Parameter_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        public Required_Parameter_Derived_WithDefaultAndAttribute([Dependency][DefaultValue(_default)] int value = Pattern.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Default => ImportBase.DefaultValueInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }
}
