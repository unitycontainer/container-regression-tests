﻿using System;
using System.ComponentModel;
using static Import.ImportBase;
using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Optional.Properties
{
    #region Validation

    public class PrivateTestType<TDependency>
        : FixtureBaseType
    {
        [OptionalDependency] private TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : FixtureBaseType
    {
        [OptionalDependency] protected TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : FixtureBaseType
    {
        [OptionalDependency] internal TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    #endregion
}


namespace Import.Optional.Properties.WithDefault
{
#if !BEHAVIOR_V4 // v4 did not support optional value types
    public class Optional_Property_Int_WithDefault : ImportBaseType
    {
        [OptionalDependency] public int Property { get; set; } = ImportBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V5 // Unity v5 did not support default values for Properties
        public override object Default => 0;
#else
        public override object Default => ImportBase.DefaultInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_DerivedFromInt_WithDefault : Optional_Property_Int_WithDefault
    {
    }
#endif

    public class Optional_Property_String_WithDefault : ImportBaseType
    {
        [OptionalDependency] public string Property { get; set; } = ImportBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V4 || BEHAVIOR_V5  // Unity v4 and v5 did not support default values for properties
        public override object Default => null;
#else
        public override object Default => ImportBase.DefaultString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Optional_DerivedFromString_WithDefault : Optional_Property_String_WithDefault
    {
    }
}


namespace Import.Optional.Properties.WithDefaultAttribute
{

#if !BEHAVIOR_V4 // v4 did not support optional value types
    public class Optional_Int_WithDefaultAttribute : ImportBaseType
    {
        [OptionalDependency] [DefaultValue(ImportBase.DefaultValueInt)] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => 0;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_WithDefaultAttribute_Int : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueInt)] [OptionalDependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => 0;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_Derived_WithDefaultAttribute
        : Optional_Int_WithDefaultAttribute
    {
    }

#endif

    public class Optional_String_WithDefaultAttribute : ImportBaseType
    {
        [OptionalDependency] [DefaultValue(ImportBase.DefaultValueString)] public string Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => null;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Optional_WithDefaultAttribute_String : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueString)] [OptionalDependency] public string Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
#if BEHAVIOR_V4 || BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => null;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

}


namespace Import.Optional.Properties.WithDefaultAndAttribute
{

#if !BEHAVIOR_V4 // v4 did not support optional value types

    public class Optional_Int_WithDefaultAndAttribute : ImportBaseType
    {
        [OptionalDependency] [DefaultValue(ImportBase.DefaultValueInt)] public int Property { get; set; } = ImportBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V5 // Unity v5 did not support default values for properties
        public override object Default => 0;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_WithDefaultAndAttribute_Int : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueInt)] [OptionalDependency] public int Property { get; set; } = ImportBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V5 // Unity v5 did not support default values for properties
        public override object Default => 0;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Optional_Derived_WithDefaultAndAttribute : Optional_Int_WithDefaultAndAttribute
    {
    }

#endif

    public class Optional_String_WithDefaultAndAttribute : ImportBaseType
    {
        [OptionalDependency] [DefaultValue(ImportBase.DefaultValueString)] public string Property { get; set; } = ImportBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V4 ||  BEHAVIOR_V5 // Unity v4 and v5 did not support default values for properties
        public override object Default => null;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Optional_WithDefaultAndAttribute_String : ImportBaseType
    {
        [DefaultValue(ImportBase.DefaultValueString)] [OptionalDependency] public string Property { get; set; } = ImportBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

#if BEHAVIOR_V4 ||  BEHAVIOR_V5 // Unity v4 and v5 did not support default values for properties
        public override object Default => null;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

}