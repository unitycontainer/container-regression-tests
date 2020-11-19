using Regression;
using System.ComponentModel;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Methods.ImplicitWithDefaults
{
    #region Integer

    public class Implicit_WithDefault_Int : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultInt;
    }

    public class Implicit_WithDefault_Attribute_Int : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Implicit_WithDefault_Attribute_Value_Int : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    #endregion


    #region String

    public class Implicit_WithDefault_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method(string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultString;
    }

    public class Implicit_WithDefault_Attribute_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Implicit_WithDefault_Attribute_Value_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    #endregion


    #region Derived

    public class Implicit_WithDefault_Derived : Implicit_WithDefault_Int
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method(int value = _default) => base.Method(value);
        public override object Expected => _default;
    }

    public class Implicit_WithDefault_Attribute_Derived : Implicit_WithDefault_Attribute_Int
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([DefaultValue(_default)] int value) => base.Method(value);
        public override object Expected => _default;
    }

    public class Implicit_WithDefault_Value_Overrides_Attribute : Implicit_WithDefault_Attribute_Value_Int
    {
        private const int _default = 1111;
        public override void Method(int value = _default) => base.Method(value);
        public override object Expected => _default;
    }

    public class Implicit_WithDefault_AttributeOverrides_Attribute_Value : Implicit_WithDefault_Attribute_Value_Int
    {
        private const int _default = 1111;
        public override void Method([DefaultValue(_default)]int value) => base.Method(value);
        public override object Expected => _default;
    }


    #endregion
}
