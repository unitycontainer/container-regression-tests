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
        : PropertySelectionBase
    {
        [OptionalDependency] public TDependency Property { get => (TDependency)Data[0]; set => Data[0] = value; }

    }

    public class NoPublicMember<TDependency>
    {
        [OptionalDependency] private TDependency Property { get; set; }
    }
}


namespace Selection.Annotated.Properties.Optional.EdgeCases
{
    public class DummySelection : SelectionBaseType { }
}
