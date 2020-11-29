using System;
using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Annotated.Fields.Required
{
    public class BaselineTestType<TDependency>
        : FieldSelectionBase
    {
        [Dependency] public TDependency Field;

    }

    public class NoPublicMember<TDependency>
    {
        [Dependency]
        private TDependency Field;
    }
}


namespace Selection.Annotated.Fields.Required.EdgeCases
{
    public class DummySelection : SelectionBaseType { }
}
