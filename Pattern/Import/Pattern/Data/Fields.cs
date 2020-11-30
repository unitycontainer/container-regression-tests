using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Implicit.Fields
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        public TDependency Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }
}

namespace Import.Optional.Fields
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [OptionalDependency] public TDependency Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }
}

namespace Import.Required.Fields
{
    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [Dependency] public TDependency Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }
}
