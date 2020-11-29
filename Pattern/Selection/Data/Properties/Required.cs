using System;
using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Properties.Required
{
    public class BaselineTestType<TDependency>
        : PropertySelectionBase
    {
        [Dependency] public TDependency Property { get => (TDependency)Data[0]; set => Data[0] = value; }

    }

    public class NoPublicMember<TDependency>
    {
        [Dependency]
        private TDependency Property { get; set; }
    }
}


namespace Selection.Annotated.Properties.Required.EdgeCases
{
    public class DummySelection : SelectionBaseType { }
}
