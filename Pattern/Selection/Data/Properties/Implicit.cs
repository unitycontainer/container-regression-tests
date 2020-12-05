using static Selection.SelectionBase;

namespace Selection.Implicit.Properties
{
    public class BaselineTestType<TItem1, TItem2>
        : PropertySelectionBase
    {
        public TItem1 Property1 { get => (TItem1)Data[0]; set => Data[0] = value; }
        public TItem2 Property2 { get => (TItem2)Data[1]; set => Data[1] = value; }
    }
}

