using System;
using System.ComponentModel;
using static Import.ImportBase;
using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Required.Constructors
{
    public class BaselineTestTypeNamed<TDependency>
        : ImportBaseType
    {
        public BaselineTestTypeNamed([Dependency(ImportBase.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency>
        : BaselineTestType<TDependency>
    {
        public BaselineInheritedType([Dependency] TDependency value)
            : base(value)
        { }
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
        public BaselineInheritedTwice([Dependency] TDependency value)
            : base(value)
        { }
    }

    public class DownTheLineType<TDependency>
        : ImportBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }

    public class ArrayTestType<TDependency>
        : ImportBaseType
    {
        public ArrayTestType([Dependency] TDependency[] value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class PrivateTestType<TDependency>
        : ImportBaseType
    {
        private PrivateTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : ImportBaseType
    {
        protected ProtectedTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : ImportBaseType
    {
        internal InternalTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestType_Ref<TDependency>
        : ImportBaseType where TDependency : class
    {
        public BaselineTestType_Ref([Dependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : ImportBaseType where TDependency : class
    {
        public BaselineTestType_Out([Dependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }
}

namespace Import.Annotated.Constructors.Required
{
    public class BaselineTestType<TDependency>
        : ImportBaseType
    {
        public BaselineTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : ImportBaseType
    {
        public BaselineTestTypeNamed([Dependency(ImportBase.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency>
        : BaselineTestType<TDependency>
    {
        public BaselineInheritedType([Dependency] TDependency value)
            : base(value)
        { }
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
        public BaselineInheritedTwice([Dependency] TDependency value)
            : base(value)
        { }
    }

    public class DownTheLineType<TDependency>
        : ImportBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }

    public class ArrayTestType<TDependency>
        : ImportBaseType
    {
        public ArrayTestType([Dependency] TDependency[] value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class PrivateTestType<TDependency>
        : ImportBaseType
    {
        private PrivateTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ProtectedTestType<TDependency>
        : ImportBaseType
    {
        protected ProtectedTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class InternalTestType<TDependency>
        : ImportBaseType
    {
        internal InternalTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestType_Ref<TDependency>
        : ImportBaseType where TDependency : class
    {
        public BaselineTestType_Ref([Dependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : ImportBaseType where TDependency : class
    {
        public BaselineTestType_Out([Dependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }
}



namespace Import.Annotated.Constructors.Required.WithDefaults
{
    #region WithDefault

    #endregion


    #region WithDefaultAttribute


    #endregion


    #region WithDefaultAndAttribute

    #endregion
}
