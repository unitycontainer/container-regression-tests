using System;
using static Selection.Pattern;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Required.Fields
{
    public class BaselineTestType<TItem1, TItem2>
        : FieldSelectionBase
    {
#if !UNITY_V4
        [Dependency] 
#endif
        public TItem1 Field1;
#if !UNITY_V4
        [Dependency] 
#endif
        public TItem2 Field2;
    }
}
