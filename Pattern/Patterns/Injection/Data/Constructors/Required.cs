using Regression;
using Regression.Implicit.Constructors;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Injection.Required.Constructors
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency>
    {
        [InjectionConstructor] public Inherited_Import([Dependency] TDependency value) : base(value) { }
    }

    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency>
    {
        [InjectionConstructor] public Inherited_Twice([Dependency] TDependency value) : base(value) { }
    }


    #region Validation

    public class PrivateTestType<TDependency>
        : FixtureBaseType
    {
        private PrivateTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : FixtureBaseType
    {
        protected ProtectedTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : FixtureBaseType
    {
        internal InternalTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestType_Ref<TDependency>
        : FixtureBaseType where TDependency : class
    {
        public BaselineTestType_Ref([Dependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : FixtureBaseType where TDependency : class
    {
        public BaselineTestType_Out([Dependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion
}
