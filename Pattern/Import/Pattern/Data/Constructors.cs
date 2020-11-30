using Regression;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Import.Implicit.Constructors
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionConstructor] public BaselineTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
}

namespace Import.Optional.Constructors
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionConstructor] public BaselineTestType([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
}

namespace Import.Required.Constructors
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionConstructor]public BaselineTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
}