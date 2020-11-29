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
        : SelectionBaseType
    {
        [Dependency] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class NoPublicMember<TDependency>
    {
        [Dependency]
        private TDependency Field;
    }
}


namespace Selection.Annotated.Fields.Basics
{
    public class SuccessDummyRequired : SelectionBaseType
    {
    }
}
