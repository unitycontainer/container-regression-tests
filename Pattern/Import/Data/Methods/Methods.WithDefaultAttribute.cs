using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Implicit.Methods.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Implicit_Derived_WithDefaultAttribute : Implicit_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([DefaultValue(_default)] int value = PatternBase.DefaultValueInt) => base.Method(value);

#if BEHAVIOR_V5
        // BUG: See https://github.com/unitycontainer/container/issues/291
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => _default;
#endif
    }
}


namespace Regression.Annotated.Methods.WithDefaultAttribute
{
    public class Required_Int_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency][DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Optional_Int_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency][DefaultValue(PatternBase.DefaultValueInt)] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }


    public class Required_WithDefaultAttribute_Int : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueInt)][Dependency] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Optional_WithDefaultAttribute_Int : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueInt)][OptionalDependency] int value) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }


    public class Required_String_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency][DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Optional_String_WithDefaultAttribute : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency][DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }


    public class Required_WithDefaultAttribute_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueString)][Dependency] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Optional_WithDefaultAttribute_String : PatternBaseType
    {
        [InjectionMethod]
        public void Method([DefaultValue(PatternBase.DefaultValueString)][OptionalDependency] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }


    public class Required_Derived_WithDefaultAttribute : Required_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public override void Method([DefaultValue(_default), Dependency] int value) => base.Method(value);

        public override object Expected => _default;
    }

    public class Optional_Derived_WithDefaultAttribute : Optional_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public override void Method([DefaultValue(_default), Dependency] int value) => base.Method(value);

        public override object Expected => _default;
    }
}
