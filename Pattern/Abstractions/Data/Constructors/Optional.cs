using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Import.Optional.Constructors
{
    #region Baseline

    public class ObjectTestType : FixtureBaseType
    {
        [InjectionConstructor] public ObjectTestType([OptionalDependency] object value) => Value = value;
        public override object Default => default(object);
    }

    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionConstructor] public BaselineTestType([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : FixtureBaseType
    {
        public BaselineTestTypeNamed([OptionalDependency(Pattern.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    #endregion


    #region Array

    public class BaselineArrayType<TDependency> : FixtureBaseType
    {
        [InjectionConstructor] public BaselineArrayType([OptionalDependency] TDependency[] value) => Value = value;
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
