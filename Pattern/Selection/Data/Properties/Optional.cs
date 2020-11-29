using System;
using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Properties.Optional
{
    public class BaselineTestType<TDependency>
        : SelectionBaseType
    {
        [OptionalDependency] public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class NoPublicMember<TDependency>
    {
        [OptionalDependency] private TDependency Property { get; set; }
    }
}


namespace Selection.Annotated.Properties.Basics
{
    public class SuccessDummyOptional : SelectionBaseType
    {
    }
}
