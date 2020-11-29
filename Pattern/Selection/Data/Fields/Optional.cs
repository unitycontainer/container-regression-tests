using static Selection.SelectionBase;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Annotated.Fields.Optional
{
    public class BaselineTestType<TDependency>
        : SelectionBaseType
    {
        [OptionalDependency] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class NoPublicMember<TDependency>
    {
        [OptionalDependency] private TDependency Field;
    }
}

namespace Selection.Annotated.Fields.Basics
{
    public class SuccessDummyOptional : SelectionBaseType
    {
    }
}
