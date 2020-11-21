using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Annotated.Fields.WithDefault
{
    public class Optional_Int_WithDefault : PatternBaseType
    {
        [OptionalDependency] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultInt;
    }

    public class Optional_String_WithDefault : PatternBaseType
    {
        [OptionalDependency] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Expected => PatternBase.DefaultString;
    }

    public class Optional_DerivedFromInt_WithDefault : Optional_Int_WithDefault
    {
    }
}
