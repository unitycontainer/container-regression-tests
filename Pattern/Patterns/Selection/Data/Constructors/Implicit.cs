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
