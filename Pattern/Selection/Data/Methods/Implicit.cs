using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Implicit.Methods
{
    public class BaselineTestType<TDependency, TDefault>
        : MethodSelectionBase
    {
        public virtual void Method()
            => Data[0] = new object[0];

        public virtual void Method(TDependency value)
            => Data[1] = new object[] { value };

        public virtual void Method(TDefault import)
            => Data[2] = new object[] { import };

        public virtual void Method(TDependency value, TDefault import)
            => Data[3] = new object[] { value, import };
    }

    public class NoPublicMember<TDependency>
    {
        private void Method(TDependency value) { }
    }
}


namespace Selection.Implicit.Methods.EdgeCases
{
    public class DummySelectionImplicit : SelectionBaseType { }
}
