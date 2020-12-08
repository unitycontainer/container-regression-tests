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
