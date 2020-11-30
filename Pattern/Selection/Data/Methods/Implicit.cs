using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Implicit.Methods
{
    public class BaselineTestType<TItem1, TItem2>
        : MethodSelectionBase
    {
        public virtual void Method()
            => Data[0] = new object[0];

        public virtual void Method(TItem1 value)
            => Data[1] = new object[] { value };

        public virtual void Method(TItem2 value)
            => Data[2] = new object[] { value };

        public virtual void Method(TItem1 item1, TItem2 item2)
            => Data[3] = new object[] { item1, item2 };
    }

    public class NoPublicMember<TDependency>
    {
        private void Method(TDependency value) { }
    }
}


namespace Selection.Implicit.Methods.EdgeCases
{
    public class DynamicParameter : MethodSelectionBase
    {
        [InjectionMethod]
        public void Method(dynamic value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }
}


namespace Selection.Implicit.Methods.EdgeCasesThrowing
{
    public class RefParameter : SelectionBaseType
    {
        [InjectionMethod]
        public void Method(ref int value) { }
    }

    public class OutParameter : SelectionBaseType
    {
        [InjectionMethod]
        public void Method(out int value) { value = 0; }
    }

    public class StructParameter : ConstructorSelectionBase
    {
        [InjectionMethod]
        public void Method(TestStruct value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }
    
    public class OpenGenericType<T>
    {
        [InjectionMethod]
        public void Method(T value) { }
    }
}
