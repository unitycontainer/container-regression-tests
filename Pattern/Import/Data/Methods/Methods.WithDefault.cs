#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Implicit.Methods.WithDefault
{
    public class Implicit_Int_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultInt;
    }

    public class Implicit_String_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultString;
    }

    public class Implicit_Derived_WithDefault : Implicit_Int_WithDefault
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method(int value = _default) => base.Method(value);

#if BEHAVIOR_V5
        // BUG: See https://github.com/unitycontainer/container/issues/291
        public override object Expected => PatternBase.DefaultInt;
#else
        public override object Expected => _default;
#endif
    }
}


namespace Regression.Annotated.Methods.WithDefault
{
    public class Required_Int_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] int value = PatternBase.DefaultInt) => Value = value;
        public override object Expected => PatternBase.DefaultInt;
    }

    public class Optional_Int_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] int value = PatternBase.DefaultInt) => Value = value;
        public override object Expected => PatternBase.DefaultInt;
    }


    public class Required_String_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] string value = PatternBase.DefaultString) => Value = value;
        public override object Expected => PatternBase.DefaultString;
    }

    public class Optional_String_WithDefault : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method([OptionalDependency] string value = PatternBase.DefaultString) => Value = value;
        public override object Expected => PatternBase.DefaultString;
    }


    public class Required_DerivedFromInt_WithDefault : Required_Int_WithDefault
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([Dependency] int value = _default) => base.Method(value);
        public override object Expected => _default;
    }

    public class Optional_DerivedFromInt_WithDefault : Optional_Int_WithDefault
    {
        private const int _default = 1111;

        [InjectionMethod]
        public override void Method([OptionalDependency] int value = _default) => base.Method(value);
        public override object Expected => _default;
    }
}
