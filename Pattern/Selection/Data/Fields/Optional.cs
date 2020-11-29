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
        : FieldSelectionBase
    {
        [OptionalDependency] public TDependency Field;

    }

    public class NoPublicMember<TDependency>
    {
        [OptionalDependency] private TDependency Field;
    }
}

namespace Selection.Annotated.Fields.Optional.EdgeCases
{
    public class DummySelection : SelectionBaseType { }
}
