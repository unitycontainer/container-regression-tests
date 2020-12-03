using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Optional.Methods
{
    #region Baseline

    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionMethod] public void Method([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : FixtureBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency(Pattern.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    #endregion


    #region Array

    public class BaselineArrayType<TDependency> : FixtureBaseType
    {
        [InjectionMethod] public void Method([OptionalDependency] TDependency[] value) => Value = value;
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
