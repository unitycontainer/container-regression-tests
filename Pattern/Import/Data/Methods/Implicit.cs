using Regression;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import.Implicit.Methods
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency>
        : BaselineTestType<TDependency>
    {
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
    }

    public class DownTheLineType<TDependency>
        : PatternBaseType
    {
        public DownTheLineType(BaselineTestType<TDependency> import)
            => Value = import;
    }

    public class ArrayTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(TDependency[] value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method(ref TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        [InjectionMethod]
        public virtual void Method(out TDependency value)
            => throw new InvalidOperationException("should never execute");
    }
}



namespace Import.Implicit.Methods.WithDefault
{
    public class Implicit_Parameter_Int_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(int value = ImportBase.DefaultInt) => Value = value;

        public override object Default => ImportBase.DefaultInt;
        public override object Injected => ImportBase.InjectedInt;
        public override object Registered => ImportBase.RegisteredInt;
        public override object Override => ImportBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_Parameter_String_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(string value = ImportBase.DefaultString) => Value = value;

        public override object Default => ImportBase.DefaultString;
        public override object Injected => ImportBase.InjectedString;
        public override object Registered => ImportBase.RegisteredString;
        public override object Override => ImportBase.OverriddenString;

        public override Type ImportType => typeof(string);
    }

    public class Implicit_Derived_WithDefault : Implicit_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method(int value = _default) => base.Method(value);
#if BEHAVIOR_V5
        // BUG: See https://github.com/unitycontainer/container/issues/291
        public override object Default => ImportBase.DefaultInt;
        public override object Injected => ImportBase.DefaultInt;
#else
        public override object Default => _default;
#endif
    }
}


namespace Import.Implicit.Methods.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(ImportBase.DefaultValueInt)] int value) => Value = value;

        public override object Default => ImportBase.DefaultValueInt;
        public override object Injected => ImportBase.InjectedInt;
        public override object Registered => ImportBase.RegisteredInt;
        public override object Override => ImportBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(ImportBase.DefaultValueString)] string value) => Value = value;

        public override object Default => ImportBase.DefaultValueString;
        public override object Injected => ImportBase.InjectedString;
        public override object Registered => ImportBase.RegisteredString;
        public override object Override => ImportBase.OverriddenString;
        public override Type ImportType => typeof(string);
    }

#if !BEHAVIOR_V5 // BUG: See https://github.com/unitycontainer/container/issues/291
    public class Implicit_Derived_WithDefaultAttribute : Implicit_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([DefaultValue(_default)] int value = ImportBase.DefaultValueInt) => base.Method(value);

        public override object Default => _default;
        public override Type ImportType => typeof(int);
    }
#endif
}


namespace Import.Implicit.Methods.WithDefaultAndAttribute
{
    public class Implicit_Int_WithDefaultAndAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(ImportBase.DefaultValueInt)] int value = ImportBase.DefaultInt) => Value = value;

        public override object Injected => ImportBase.InjectedInt;
        public override object Registered => ImportBase.RegisteredInt;
        public override object Override => ImportBase.OverriddenInt;
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => ImportBase.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAndAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(ImportBase.DefaultValueString)] string value = ImportBase.DefaultString) => Value = value;

        public override object Injected => ImportBase.InjectedString;
        public override object Registered => ImportBase.RegisteredString;
        public override object Override => ImportBase.OverriddenString;
#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => ImportBase.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Derived_WithDefaultAndAttribute : Implicit_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([DefaultValue(_default)] int value = ImportBase.DefaultValueInt) => base.Method(value);
#if BEHAVIOR_V5
        // BUG: See https://github.com/unitycontainer/container/issues/291
        public override object Default => ImportBase.DefaultInt;
        public override object Injected => ImportBase.DefaultInt;
#else
        public override object Default => _default;
#endif
    }
}
