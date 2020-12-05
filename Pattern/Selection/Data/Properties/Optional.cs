using System;
using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Properties.Optional
{
    public class BaselineTestType<TItem1, TItem2>
        : PropertySelectionBase
    {
        [OptionalDependency] public TItem1 Property1 { get => (TItem1)Data[0]; set => Data[0] = value; }
        [OptionalDependency] public TItem2 Property2 { get => (TItem2)Data[1]; set => Data[1] = value; }
    }
}


namespace Selection.Annotated.Properties.Optional.EdgeCases
{
#if !BEHAVIOR_V4
    public class StructProperty : PropertySelectionBase
    {
        [OptionalDependency] public TestStruct  Property { get; set; }
    }
#endif
}

namespace Selection.Annotated.Properties.Optional.EdgeCasesThrowing
{

    public class OpenGenericType<T>
    {
        [OptionalDependency] public T Property { get; set; }
    }
}
