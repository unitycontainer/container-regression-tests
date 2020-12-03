using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Optional.Fields
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
        [OptionalDependency(Pattern.Name)] public TDependency Field;

        public override object Value { get => Field; }
        public override object Default => default(TDependency);
    }

    #endregion


    #region Array

    public class BaselineArrayType<TDependency> : FixtureBaseType
    {
        [OptionalDependency] public TDependency[] Field;
        public override object Value { get => Field; }
        public override object Default => default(TDependency);
    }

    #endregion


    #region Consumer

    public class BaselineConsumer<TDependency> : FixtureBaseType
    {
        public BaselineConsumer(BaselineTestType<TDependency> dependency, BaselineTestTypeNamed<TDependency> dummy)
        {
            Value = dependency.Value;
            Default = dummy.Value;
        }
    }

    #endregion
}
