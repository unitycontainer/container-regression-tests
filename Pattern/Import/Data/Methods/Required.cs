using System;
using System.ComponentModel;
using static Import.Pattern;
using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Import.Required.Methods
{
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


namespace Import.Required.Methods.WithDefault
{
    public class Required_Parameter_Int_WithDefault : ImportBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] int value = Pattern.DefaultInt) => Value = value;
        public override object Default => Pattern.DefaultInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_Parameter_String_WithDefault : ImportBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] string value = Pattern.DefaultString) => Value = value;
        public override object Default => Pattern.DefaultString;
        public override Type ImportType => typeof(string);
    }

    public class Required_DerivedFromInt_WithDefault : Required_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([Dependency] int value = _default) => base.Method(value);

#if  !BEHAVIOR_V5 // Issue: https://github.com/unitycontainer/container/issues/291
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }
}


namespace Import.Required.Methods.WithDefaultAttribute
{
#if !BEHAVIOR_V5 // Unity v5 did not support DefaultValueAttribute
    public class Required_Int_WithDefaultAttribute : ImportBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency][DefaultValue(Pattern.DefaultValueInt)] int value) => Value = value;

        public override object Default => Pattern.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_WithDefaultAttribute_Int : ImportBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(Pattern.DefaultValueInt)][Dependency] int value) => Value = value;

        public override object Default => Pattern.DefaultValueInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_String_WithDefaultAttribute : ImportBaseType
    {
        [InjectionMethod]
        public void Method([Dependency][DefaultValue(Pattern.DefaultValueString)] string value) => Value = value;

        public override object Default => Pattern.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_WithDefaultAttribute_String : ImportBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(Pattern.DefaultValueString)][Dependency] string value) => Value = value;

        public override object Default => Pattern.DefaultValueString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Derived_WithDefaultAttribute : Required_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public override void Method([DefaultValue(_default), Dependency] int value) => base.Method(value);

        public override object Default => _default;
        public override Type ImportType => typeof(int);
    }

#endif
}


namespace Import.Required.Methods.WithDefaultAndAttribute
{
    public class Required_Int_WithDefaultAndAttribute : ImportBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency][DefaultValue(Pattern.DefaultValueInt)] int value = Pattern.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => Pattern.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Required_WithDefaultAndAttribute_Int : ImportBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(Pattern.DefaultValueInt)][Dependency] int value = Pattern.DefaultInt) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => Pattern.DefaultValueInt;
#endif
        public override Type ImportType => typeof(int);
    }

    public class Required_String_WithDefaultAndAttribute : ImportBaseType
    {
        [InjectionMethod]
        public void Method([Dependency][DefaultValue(Pattern.DefaultValueString)] string value = Pattern.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => Pattern.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Required_WithDefaultAndAttribute_String : ImportBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(Pattern.DefaultValueString)][Dependency] string value = Pattern.DefaultString) => Value = value;

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultString;
#else
        public override object Default => Pattern.DefaultValueString;
#endif
        public override Type ImportType => typeof(string);
    }

    public class Required_Derived_WithDefaultAndAttribute : Required_Int_WithDefaultAndAttribute
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([Dependency][DefaultValue(_default)] int value = Pattern.DefaultValueInt)
        { base.Method(value); }

#if BEHAVIOR_V5
        // Prior to v6 Unity did not support DefaultValueAttribute
        public override object Default => ImportBase.DefaultInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }
}
