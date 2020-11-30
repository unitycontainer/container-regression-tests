using static Selection.SelectionBase;
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

    public class NoPublicMember<TDependency>
    {
        [OptionalDependency] private TDependency Field;
    }
}

namespace Selection.Annotated.Fields.Optional.EdgeCases
{
    public class StructField : FieldSelectionBase
    {
        [OptionalDependency] public TestStruct Field;
        public override bool IsSuccessfull => this[0] is not null;
    }
}

namespace Selection.Annotated.Fields.Optional.EdgeCasesThrowing
{

    public class OpenGenericType<T>
    {
        [OptionalDependency] public T Field;
    }
}
