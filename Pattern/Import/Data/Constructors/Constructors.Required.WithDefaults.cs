﻿using Regression;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif



namespace Import.Annotated.Constructors.Required.WithDefaults
{
    #region WithDefault

    public class Required_Parameter_Int_WithDefault : PatternBaseType
    {
        public Required_Parameter_Int_WithDefault([Dependency] int value = ImportBase.DefaultInt) => Value = value;
        public override object Default => ImportBase.DefaultInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefault : PatternBaseType
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

    #endregion


    #region WithDefaultAttribute

#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute

    public class Required_Parameter_Int_WithDefaultAttribute : PatternBaseType
    {
        public Required_Parameter_Int_WithDefaultAttribute([Dependency][DefaultValue(ImportBase.DefaultValueInt)] int value) => Value = value;
        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_WithDefaultAttribute_Int : PatternBaseType
    {
        public Required_Parameter_WithDefaultAttribute_Int([DefaultValue(ImportBase.DefaultValueInt)][Dependency] int value) => Value = value;
        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefaultAttribute : PatternBaseType
    {
        public Required_Parameter_String_WithDefaultAttribute([Dependency][DefaultValue(ImportBase.DefaultValueString)] string value) => Value = value;
        public override object Default => ImportBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_WithDefaultAttribute_String : PatternBaseType
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

    #endregion


    #region WithDefaultAndAttribute

    public class Required_Parameter_Int_WithDefaultAndAttribute : PatternBaseType
    {
        public Required_Parameter_Int_WithDefaultAndAttribute([Dependency][DefaultValue(ImportBase.DefaultValueInt)] int value = ImportBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultInt;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_WithDefaultAndAttribute_Int : PatternBaseType
    {
        public Required_Parameter_WithDefaultAndAttribute_Int([DefaultValue(ImportBase.DefaultValueInt)][Dependency] int value = ImportBase.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultInt;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }


    public class Required_Parameter_String_WithDefaultAndAttribute : PatternBaseType
    {
        public Required_Parameter_String_WithDefaultAndAttribute([Dependency][DefaultValue(ImportBase.DefaultValueString)] string value = ImportBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultString;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }


    public class Required_Parameter_WithDefaultAndAttribute_String : PatternBaseType
    {
        public Required_Parameter_WithDefaultAndAttribute_String([DefaultValue(ImportBase.DefaultValueString)][Dependency] string value = ImportBase.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => PatternBase.DefaultString;
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
        public override object Default => PatternBase.DefaultValueInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }

    #endregion
}
