using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Constructors.Optional
{
    public class BaselineTestType<TDependency, TDefault>
        : SelectionBaseType
    {
        public BaselineTestType()
            => Data[0] = new object[0];

        [InjectionConstructor]
        public BaselineTestType([OptionalDependency] TDependency value)
            => Data[1] = new object[] { value };

        public BaselineTestType(TDefault import)
            => Data[2] = new object[] { import };

        public BaselineTestType([OptionalDependency] TDependency value, TDefault import)
            => Data[3] = new object[] { value, import };
    }

    public class NoPublicMember<TDependency>
    {
        [InjectionConstructor]
        private NoPublicMember([OptionalDependency] TDependency value) { }
    }
}


namespace Selection.Annotated.Constructors.Basics
{
    public class SuccessDummyOptional : SelectionBaseType
    {
    }
}
