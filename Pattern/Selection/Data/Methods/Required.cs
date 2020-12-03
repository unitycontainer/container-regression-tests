using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Methods.Required
{
    public class BaselineTestType<TItem1, TItem2>
        : MethodSelectionBase
    {
        public virtual void Method()
            => Data[0] = new object[0];

        [InjectionMethod]
        public virtual void Method([Dependency] TItem1 value)
            => Data[1] = new object[] { value };

        public virtual void Method(TItem2 value)
            => Data[2] = new object[] { value };

        public virtual void Method([Dependency] TItem1 item1, TItem2 item2)
            => Data[3] = new object[] { item1, item2 };
    }

    public class NoPublicMember<TDependency>
    {
        [InjectionMethod]
        private void Method([Dependency] TDependency value) { }
    }
}


namespace Selection.Annotated.Methods.Required.EdgeCases
{
    public class DynamicParameter : MethodSelectionBase
    {
        [InjectionMethod]
        public void Method([Dependency] dynamic value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }

}


namespace Selection.Annotated.Methods.Required.EdgeCasesThrowing
{
#if !BEHAVIOR_V4
    public class StructParameter : ConstructorSelectionBase
    {
        [InjectionMethod]
        public void Method([Dependency] TestStruct value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }
#endif

    public class OpenGenericType<T>
    {
        [InjectionMethod]
        public void Method([Dependency] T value) { }
    }
}