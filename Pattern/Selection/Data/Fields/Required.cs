using System;
using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Annotated.Fields.Required
{
    public class BaselineTestType<TItem1, TItem2>
        : FieldSelectionBase
    {
        [Dependency] public TItem1 Field1;
        [Dependency] public TItem2 Field2;
    }

    public class NoPublicMember<TDependency>
    {
        [Dependency]
        private TDependency Field;
        protected TDependency Dummy()
        {
            Field = default;
            return Field;
        }
    }
}


namespace Selection.Annotated.Fields.Required.EdgeCasesThrowing
{
#if !BEHAVIOR_V4
    public class StructField : FieldSelectionBase
    {
        [Dependency] public TestStruct Field;
        public override bool IsSuccessfull => this[0] is not null;
    }
#endif

    public class OpenGenericType<T>
    {
        [Dependency] public T Field;
    }
}
