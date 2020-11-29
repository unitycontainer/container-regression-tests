using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Annotated.Constructors.Required
{
    public class BaselineTestType<TDependency, TDefault>
        : ConstructorSelectionBase
    {
        public BaselineTestType()
            => Data[0] = new object[0];

        [InjectionConstructor]
        public BaselineTestType([Dependency] TDependency value)
            => Data[1] = new object[] { value };

        public BaselineTestType(TDefault import)
            => Data[2] = new object[] { import };

        public BaselineTestType([Dependency] TDependency value, TDefault import)
            => Data[3] = new object[] { value, import };
    }

    public class NoPublicMember<TDependency>
    {
        [InjectionConstructor]
        private NoPublicMember([Dependency] TDependency value) { }
    }
}


namespace Selection.Annotated.Constructors.Required.EdgeCases
{
    public class DummySelection : SelectionBaseType { }
}
