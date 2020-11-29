using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Methods.Required
{
    public class BaselineTestType<TDependency, TDefault>
        : MethodSelectionBase
    {
        public virtual void Method()
            => Data[0] = new object[0];

        [InjectionMethod]
        public virtual void Method([Dependency] TDependency value)
            => Data[1] = new object[] { value };

        public virtual void Method(TDefault import)
            => Data[2] = new object[] { import };

        public virtual void Method([Dependency] TDependency value, TDefault import)
            => Data[3] = new object[] { value, import };
    }

    public class NoPublicMember<TDependency>
    {
        [InjectionMethod]
        private void Method([Dependency] TDependency value) { }
    }
}



namespace Selection.Annotated.Methods.Required.EdgeCases
{
    public class DummySelection : SelectionBaseType { }
}
