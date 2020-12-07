using Regression;
using System;


namespace Injection.Implicit.Fields
{
    #region Validation

    public class PrivateTestType<TDependency>
        : FixtureBaseType
    {
        private TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
        protected TDependency Dummy()
        {
            Field = default;
            return Field;
        }
    }

    public class ProtectedTestType<TDependency>
        : FixtureBaseType
    {
        protected TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : FixtureBaseType
    {
        internal TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
        protected TDependency Dummy()
        {
            Field = default;
            return Field;
        }
    }

    #endregion
}

