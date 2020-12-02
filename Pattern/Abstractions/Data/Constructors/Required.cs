using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Import.Required.Constructors
{
    #region Baseline

    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionConstructor]public BaselineTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
    
    public class BaselineTestTypeNamed<TDependency>
        : FixtureBaseType
    {
        public BaselineTestTypeNamed([Dependency(ImportBase.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    #endregion


    #region Array

    public class BaselineArrayType<TDependency> : FixtureBaseType
    {
        [InjectionConstructor] public BaselineArrayType([Dependency] TDependency[] value) => Value = value;
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
