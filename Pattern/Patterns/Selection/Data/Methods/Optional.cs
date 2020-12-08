using static Selection.Pattern;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Methods.Optional
{
    public class BaselineTestType<TItem1, TItem2>
        : MethodSelectionBase
    {
        public virtual void Method()
            => Data[0] = new object[0];

        [InjectionMethod]
        public virtual void Method([OptionalDependency] TItem1 value)
            => Data[1] = new object[] { value };

        public virtual void Method(TItem2 value)
            => Data[2] = new object[] { value };

        public virtual void Method([OptionalDependency] TItem1 item1, TItem2 item2)
            => Data[3] = new object[] { item1, item2 };
    }
}
