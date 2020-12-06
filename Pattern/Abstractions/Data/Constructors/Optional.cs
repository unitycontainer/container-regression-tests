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


    #region No Public Members

    public class NoPublicMember<TDependency>
    {
        [InjectionConstructor]
        private NoPublicMember([OptionalDependency] TDependency value) { }
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
