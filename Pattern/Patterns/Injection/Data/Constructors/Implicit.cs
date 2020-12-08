using Regression;
using Regression.Implicit.Constructors;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Injection.Implicit.Constructors
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency>
    {
        public Inherited_Import(TDependency value) : base(value) { }
    }

    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency>
    {
        public Inherited_Twice(TDependency value) : base(value) { }
    }


    #region Validation

    public class BaselineTestType_Ref<TDependency>
        : FixtureBaseType where TDependency : class
    {
        public BaselineTestType_Ref(ref TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : FixtureBaseType where TDependency : class
    {
        public BaselineTestType_Out(out TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class PrivateTestType<TDependency>
        : FixtureBaseType
    {
        private PrivateTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : FixtureBaseType
    {
        protected ProtectedTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : FixtureBaseType
    {
        internal InternalTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    #endregion
}
