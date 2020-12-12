#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Optional.Fields
{
    #region Baseline

    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [OptionalDependency] public TDependency Field;
        public override object Value { get => Field; }
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : FixtureBaseType
    {
        [OptionalDependency(FixtureBase.Name)] public TDependency Field;

        public override object Value { get => Field; }
        public override object Default => default(TDependency);
    }

    public class BaselineTestType<TItem1, TItem2> : FixtureBaseType
    {
        [OptionalDependency] public TItem1 Item1;
        [OptionalDependency] public TItem2 Item2;

        public override object Value => Item1;
        public override object Default => Item2;
    }

    #endregion


    #region Object

    public class ObjectTestType : FixtureBaseType
    {
        [OptionalDependency] public object Field;
        public override object Value { get => Field; }
    }

    #endregion


    #region No Public Members

    public class NoPublicMember<TDependency>
    {
#pragma warning disable IDE0052 // Remove unread private members
        [OptionalDependency] private TDependency Field;
#pragma warning restore IDE0052 // Remove unread private members
        protected TDependency Dummy()
        {
            Field = default;
            return Field;
        }
    }

    #endregion


    #region Array

    public class BaselineArrayType<TDependency> : FixtureBaseType
    {
        [OptionalDependency] public TDependency[] Field;
        public override object Value { get => Field; }
        public override object Default => default(TDependency);
    }

    public class ObjectArrayType : FixtureBaseType
    {
        [OptionalDependency] public object[] Field;
        public override object Value { get => Field; }
    }

    #endregion


    #region Consumer

    public class BaselineConsumer<TDependency> : FixtureBaseType
    {
        public readonly BaselineTestType<TDependency> Item1;
        public readonly BaselineTestTypeNamed<TDependency> Item2;

        public BaselineConsumer(BaselineTestType<TDependency> item1, BaselineTestTypeNamed<TDependency> item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override object Value => Item1.Value;
        public override object Default => Item2.Value;
    }

    #endregion
}
