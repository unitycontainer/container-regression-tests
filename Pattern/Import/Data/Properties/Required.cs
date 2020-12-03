using System;
using System.ComponentModel;
using static Import.Pattern;
using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Required.Properties
{
    #region Validation

    public class PrivateTestType<TDependency>
        : FixtureBaseType
    {
        [Dependency] private TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : FixtureBaseType
    {
        [Dependency] protected TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : FixtureBaseType
    {
        [Dependency] internal TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    #endregion
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
        [Dependency] [DefaultValue(Pattern.DefaultValueInt)] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => Pattern.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_WithDefaultAttribute_Int : ImportBaseType
    {
        [DefaultValue(Pattern.DefaultValueInt)] [Dependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => Pattern.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_String_WithDefaultAttribute : ImportBaseType
    {
        [Dependency] [DefaultValue(Pattern.DefaultValueString)] public string Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => Pattern.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_WithDefaultAttribute_String : ImportBaseType
    {
        [DefaultValue(Pattern.DefaultValueString)] [Dependency] public string Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => Pattern.DefaultValueString;
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
        [Dependency] [DefaultValue(Pattern.DefaultValueInt)] public int Property { get; set; } = Pattern.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => Pattern.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_WithDefaultAndAttribute_Int : ImportBaseType
    {
        [DefaultValue(Pattern.DefaultValueInt)] [Dependency] public int Property { get; set; } = Pattern.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => Pattern.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Property_String_WithDefaultAndAttribute : ImportBaseType
    {
        [Dependency] [DefaultValue(Pattern.DefaultValueString)] public string Property { get; set; } = Pattern.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => Pattern.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_WithDefaultAndAttribute_String : ImportBaseType
    {
        [DefaultValue(Pattern.DefaultValueString)] [Dependency] public string Property { get; set; } = Pattern.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => Pattern.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Property_Derived_WithDefaultAndAttribute : Required_Property_Int_WithDefaultAndAttribute
    {
    }
#endif
}

