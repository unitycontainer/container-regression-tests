using System;
using Regression;
using Regression.Implicit.Methods;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Injection.Required.Methods
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }


    #region Validation

    public class PrivateTestType<TDependency>
        : FixtureBaseType
    {
        [InjectionMethod]
        private void Method([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : FixtureBaseType
    {
        [InjectionMethod]
        protected void Method([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : FixtureBaseType
    {
        [InjectionMethod]
        internal void Method([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestType_Ref<TDependency>
        : FixtureBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method([Dependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : FixtureBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method([Dependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion
}
