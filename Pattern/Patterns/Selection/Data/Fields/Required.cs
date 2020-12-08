using System;
using static Selection.Pattern;
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
}
