using Regression;
using System;
using System.ComponentModel;

namespace Import.Implicit.Constructors
{
    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public BaselineTestType(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency> 
        : BaselineTestType<TDependency>
    {
        public BaselineInheritedType(TDependency value) 
            : base(value)
        { }
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
        public BaselineInheritedTwice(TDependency value)
            : base(value)
        { }
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
        public ArrayTestType(TDependency[] value) => Value = value;
        public override object Default => default(TDependency);
    }


    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Ref(ref TDependency value)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Out(out TDependency value)
            => throw new InvalidOperationException("should never execute");
    }
}


namespace Import.Implicit.Constructors.WithDefault
{
    public class Implicit_Parameter_Int_WithDefault : PatternBaseType
    {
        public Implicit_Parameter_Int_WithDefault(int value = ImportBase.DefaultInt) => Value = value;

        public override object Default => ImportBase.DefaultInt;
        public override object Injected => ImportBase.InjectedInt;
        public override object Registered => ImportBase.RegisteredInt;
        public override object Override => ImportBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_Parameter_String_WithDefault : PatternBaseType
    {
        public Implicit_Parameter_String_WithDefault(string value = ImportBase.DefaultString) => Value = value;

        public override object Default => ImportBase.DefaultString;
        public override object Injected => ImportBase.InjectedString;
        public override object Registered => ImportBase.RegisteredString;
        public override object Override => ImportBase.OverriddenString;
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Derived_WithDefault : Implicit_Parameter_Int_WithDefault
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefault(int value = _default)
            : base(value) { }

        public override object Default => _default;
    }
}


namespace Import.Implicit.Constructors.WithDefaultAttribute
{
    public class Implicit_Int_WithDefaultAttribute : PatternBaseType
    {
        public Implicit_Int_WithDefaultAttribute([DefaultValue(ImportBase.DefaultValueInt)] int value) => Value = value;

        public override object Default => ImportBase.DefaultValueInt;
        public override object Injected => ImportBase.InjectedInt;
        public override object Registered => ImportBase.RegisteredInt;
        public override object Override => ImportBase.OverriddenInt;
        public override Type ImportType => typeof(int);
    }

    public class Implicit_String_WithDefaultAttribute : PatternBaseType
    {
        public Implicit_String_WithDefaultAttribute([DefaultValue(ImportBase.DefaultValueString)] string value) => Value = value;

        public override object Default => ImportBase.DefaultValueString;
        public override object Injected => ImportBase.InjectedString;
        public override object Registered => ImportBase.RegisteredString;
        public override object Override => ImportBase.OverriddenString;
        public override Type ImportType => typeof(string);
    }

    public class Implicit_Derived_WithDefaultAttribute : Implicit_Int_WithDefaultAttribute
    {
        private const int _default = 1111;

        public Implicit_Derived_WithDefaultAttribute([DefaultValue(_default)] int value)
            : base(value) { }

        public override object Default => _default;
    }
}


namespace Import.Implicit.Constructors.WithDefaultAndAttribute
{
    public class Implicit_Int_WithDefaultAndAttribute : PatternBaseType
    {
        public Implicit_Int_WithDefaultAndAttribute([DefaultValue(ImportBase.DefaultValueInt)] int value = ImportBase.DefaultInt) => Value = value;

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
        public Implicit_String_WithDefaultAndAttribute([DefaultValue(ImportBase.DefaultValueString)] string value = ImportBase.DefaultString) => Value = value;

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

        public Implicit_Derived_WithDefaultAndAttribute([DefaultValue(_default)] int value = ImportBase.DefaultValueInt)
            : base(value) { }

#if BEHAVIOR_V5
        public override object Default => ImportBase.DefaultValueInt;
#else
        public override object Default => _default;
#endif
        public override Type ImportType => typeof(int);
    }
}
