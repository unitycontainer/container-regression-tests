using static Selection.Pattern;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Annotated.Fields.Optional
{
    public class BaselineTestType<TItem1, TItem2>
        : FieldSelectionBase
    {
        [OptionalDependency] public TItem1 Field1;
        [OptionalDependency] public TItem2 Field2;
    }
}

namespace Selection.Annotated.Fields.Optional.EdgeCases
{
#if !BEHAVIOR_V4
    public class StructField : FieldSelectionBase
    {
        [OptionalDependency] public TestStruct Field;
        public override bool IsSuccessfull => this[0] is not null;
    }
#endif
}

namespace Selection.Annotated.Fields.Optional.EdgeCasesThrowing
{

    public class OpenGenericType<T>
    {
        [OptionalDependency] public T Field;
    }
}
