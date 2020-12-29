using static Selection.Pattern;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Optional.Fields
{
    public class BaselineTestType<TItem1, TItem2>
        : FieldSelectionBase
    {
#if !UNITY_V4
        [OptionalDependency] 
#endif
        public TItem1 Field1;

#if !UNITY_V4
        [OptionalDependency] 
#endif
        public TItem2 Field2;
    }
}
