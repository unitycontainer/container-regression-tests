using Regression;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Resolution;
#endif


namespace Import.Implicit.Methods
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionMethod] public void Method(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
}

namespace Import.Optional.Methods
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionMethod] public void Method([OptionalDependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
}

namespace Import.Required.Methods
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }
}
