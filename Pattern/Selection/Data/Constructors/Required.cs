using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Annotated.Constructors.Required
{
    public class BaselineTestType<TItem1, TItem2>
        : ConstructorSelectionBase
    {
        public BaselineTestType()
            => Data[0] = new object[0];

        [InjectionConstructor]
        public BaselineTestType([Dependency] TItem1 value)
            => Data[1] = new object[] { value };

        public BaselineTestType(TItem2 value)
            => Data[2] = new object[] { value };

        public BaselineTestType([Dependency] TItem1 item1, TItem2 item2)
            => Data[3] = new object[] { item1, item2 };
    }

    public class NoPublicMember<TDependency>
    {
        [InjectionConstructor]
        private NoPublicMember([Dependency] TDependency value) { }
    }
}


namespace Selection.Annotated.Constructors.Required.EdgeCases
{
    public class DynamicParameter : ConstructorSelectionBase
    {
        public DynamicParameter([Dependency] dynamic value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }
}

namespace Selection.Annotated.Constructors.Required.EdgeCasesThrowing
{ 
    public class StructParameter : ConstructorSelectionBase
    {
        public StructParameter([Dependency] TestStruct value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }
    public class OpenGenericType<T>
    {
        public OpenGenericType([Dependency] T value) { }
    }

}
