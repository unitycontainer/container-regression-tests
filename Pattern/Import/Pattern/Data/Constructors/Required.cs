using Regression;
using System;
using System.ComponentModel;
using static Import.ImportBase;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Import.Required.Constructors
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionConstructor]public BaselineTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
    public class BaselineTestTypeNamed<TDependency>
        : ImportBaseType
    {
        public BaselineTestTypeNamed([Dependency(ImportBase.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
}



namespace Import.Required.Constructors.WithDefault
{

    public class Required_Parameter_Int_WithDefault : ImportBaseType
    {
        public Required_Parameter_Int_WithDefault([Dependency] int value = ImportBase.DefaultInt) => Value = value;
        public override object Default => ImportBase.DefaultInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefault : ImportBaseType
    {
        public Required_Parameter_String_WithDefault([Dependency] string value = ImportBase.DefaultString) => Value = value;
        public override object Default => ImportBase.DefaultString;
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
        public Required_Parameter_Int_WithDefaultAttribute([Dependency][DefaultValue(ImportBase.DefaultValueInt)] int value) => Value = value;
        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_WithDefaultAttribute_Int : ImportBaseType
    {
        public Required_Parameter_WithDefaultAttribute_Int([DefaultValue(ImportBase.DefaultValueInt)][Dependency] int value) => Value = value;
        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefaultAttribute : ImportBaseType
    {
        public Required_Parameter_String_WithDefaultAttribute([Dependency][DefaultValue(ImportBase.DefaultValueString)] string value) => Value = value;
        public override object Default => ImportBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_WithDefaultAttribute_String : ImportBaseType
    {
        public Required_Parameter_WithDefaultAttribute_String([DefaultValue(ImportBase.DefaultValueString)][Dependency] string value) => Value = value;
        public override object Default => ImportBase.DefaultValueString;
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
        public Required_Parameter_Int_WithDefaultAndAttribute([Dependency][DefaultValue(ImportBase.DefaultValueInt)] int value = ImportBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_WithDefaultAndAttribute_Int : ImportBaseType
    {
        public Required_Parameter_WithDefaultAndAttribute_Int([DefaultValue(ImportBase.DefaultValueInt)][Dependency] int value = ImportBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefaultAndAttribute : ImportBaseType
    {
        public Required_Parameter_String_WithDefaultAndAttribute([Dependency][DefaultValue(ImportBase.DefaultValueString)] string value = ImportBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_WithDefaultAndAttribute_String : ImportBaseType
    {
        public Required_Parameter_WithDefaultAndAttribute_String([DefaultValue(ImportBase.DefaultValueString)][Dependency] string value = ImportBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_Derived_WithDefaultAndAttribute : Required_Parameter_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        public Required_Parameter_Derived_WithDefaultAndAttribute([Dependency][DefaultValue(_default)] int value = ImportBase.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Default => ImportBase.DefaultValueInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }
}
