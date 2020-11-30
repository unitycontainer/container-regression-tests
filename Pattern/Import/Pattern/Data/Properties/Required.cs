using System;
using System.ComponentModel;
using static Import.ImportBase;
using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Required.Properties
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [Dependency] public TDependency Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }
}


namespace Import.Optional.Properties.WithDefault
{
    // Unity does not support implicit default values on properties
    // When resolved it will throw if not registered
    //
    //public class Required_WithDefault : PatternBaseType
    //{
    //    [Dependency] public int Property { get; set; } = PatternBase.DefaultInt;
    //}
}


namespace Import.Optional.Properties.WithDefaultAttribute
{

#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute on properties
    public class Required_Property_Int_WithDefaultAttribute : ImportBaseType
    {
        [Dependency] [DefaultValue(ImportBase.DefaultValueInt)] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_WithDefaultAttribute_Int : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueInt)] [Dependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_String_WithDefaultAttribute : ImportBaseType
    {
        [Dependency] [DefaultValue(ImportBase.DefaultValueString)] public string Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => ImportBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_WithDefaultAttribute_String : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueString)] [Dependency] public string Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => ImportBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_Derived_WithDefaultAttribute
        : Required_Property_Int_WithDefaultAttribute
    {
    }
#endif
}


namespace Import.Optional.Properties.WithDefaultAndAttribute
{
#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute on properties

    public class Required_Property_Int_WithDefaultAndAttribute : ImportBaseType
    {
        [Dependency] [DefaultValue(ImportBase.DefaultValueInt)] public int Property { get; set; } = ImportBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_WithDefaultAndAttribute_Int : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueInt)] [Dependency] public int Property { get; set; } = ImportBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => ImportBase.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_String_WithDefaultAndAttribute : ImportBaseType
    {
        [Dependency] [DefaultValue(ImportBase.DefaultValueString)] public string Property { get; set; } = ImportBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => ImportBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_WithDefaultAndAttribute_String : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueString)] [Dependency] public string Property { get; set; } = ImportBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => ImportBase.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_Derived_WithDefaultAndAttribute : Required_Property_Int_WithDefaultAndAttribute
    {
    }
#endif
}

