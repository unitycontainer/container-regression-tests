using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Methods.Optional
{
    public class BaselineTestType<TItem1, TItem2>
        : MethodSelectionBase
    {
        public virtual void Method()
            => Data[0] = new object[0];

        [InjectionMethod]
        public virtual void Method([OptionalDependency] TItem1 value)
            => Data[1] = new object[] { value };

        public virtual void Method(TItem2 value)
            => Data[2] = new object[] { value };

        public virtual void Method([OptionalDependency] TItem1 item1, TItem2 item2)
            => Data[3] = new object[] { item1, item2 };
    }

    public class NoPublicMember<TDependency>
    {
        [InjectionMethod]
        private void Method([OptionalDependency] TDependency value) { }
    }
}


namespace Selection.Annotated.Methods.Optional.EdgeCases
{
    public class DynamicParameter : MethodSelectionBase
    {
        [InjectionMethod]
        public void Method([OptionalDependency] dynamic value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }

#if !BEHAVIOR_V4
    public class StructParameter : ConstructorSelectionBase
    {
        [InjectionMethod]
        public void Method([OptionalDependency] TestStruct value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }
#endif
}


namespace Selection.Annotated.Methods.Optional.EdgeCasesThrowing
{
    public class OpenGenericType<T>
    {
        [InjectionMethod]
        public void Method([OptionalDependency] T value) { }
    }
}