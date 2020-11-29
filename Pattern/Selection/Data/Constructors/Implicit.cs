using static Selection.SelectionBase;

namespace Selection.Implicit.Constructors
{
    public class BaselineTestType<TDependency, TDefault>
        : SelectionBaseType
    {
        public BaselineTestType()
            => Data[0] = new object[0];

        public BaselineTestType(TDependency value) 
            => Data[1] = new object[] { value };

        public BaselineTestType(TDefault import) 
            => Data[2] = new object[] { import };

        public BaselineTestType(TDependency value, TDefault import) 
            => Data[3] = new object[] { value, import };
    }

    public class NoPublicMember<TDependency>
    {
        private NoPublicMember(TDependency value) { }
    }

}

namespace Selection.Implicit.Constructors.Basics
{
    public class SuccessDummy : SelectionBaseType
    {
    }
}
