using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Properties.WithDefault
{
    public class Optional_Int_WithDefault : PatternBaseType
    {
        [OptionalDependency] public int Property { get; set; } = PatternBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultInt;
    }

    public class Optional_String_WithDefault : PatternBaseType
    {
        [OptionalDependency] public string Property { get; set; } = PatternBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultString;
    }

    public class Optional_DerivedFromInt_WithDefault : Optional_Int_WithDefault
    {
    }
}
