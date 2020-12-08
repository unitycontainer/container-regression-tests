using static Selection.Pattern;

namespace Selection.Implicit.Constructors
{
    public class BaselineTestType<TItem1, TItem2>
        : ConstructorSelectionBase
    {
        public BaselineTestType()
            => Data[0] = new object[0];

        public BaselineTestType(TItem1 value) 
            => Data[1] = new object[] { value };

        public BaselineTestType(TItem2 value) 
            => Data[2] = new object[] { value };

        public BaselineTestType(TItem1 item1, TItem2 item2) 
            => Data[3] = new object[] { item1, item2 };
    }
}


namespace Selection.Implicit.Constructors.EdgeCases
{
    public class DynamicParameter : ConstructorSelectionBase
    {
        public DynamicParameter(dynamic value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }
}


namespace Selection.Implicit.Constructors.EdgeCasesThrowing
{
    public class NoPublicCtor : SelectionBaseType 
    {
        private NoPublicCtor() { }
    }

    public class RefParameter : SelectionBaseType
    {
        public RefParameter(ref int value) { }
    }

    public class OutParameter : SelectionBaseType
    {
        public OutParameter(out int value) { value = 0; }
    }

#if !BEHAVIOR_V4
    public class StructParameter : ConstructorSelectionBase
    {
        public StructParameter(TestStruct value) => Data[0] = value;
        public override bool IsSuccessfull => this[0] is not null;
    }
#endif
    
    public class OpenGenericType<T>
    {
        public OpenGenericType(T value) { }
    }
}
