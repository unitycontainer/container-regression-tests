using Regression;
using System.ComponentModel;
#if V4
using Microsoft.Practices.Unity;
#else
#endif

namespace Constructors.ImplicitWithDefaults
{
    #region Integer

    public class Implicit_WithDefault_Int : PatternBaseType
    {
        public Implicit_WithDefault_Int(int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultInt;
    }

    public class Implicit_WithDefault_Attribute_Int : PatternBaseType
    {
        public Implicit_WithDefault_Attribute_Int([DefaultValue(PatternBase.DefaultValueInt)]int value) => Value = value;
        
        public override object Expected => PatternBase.DefaultValueInt;
    }

    public class Implicit_WithDefault_Attribute_Value_Int : PatternBaseType
    {
        public Implicit_WithDefault_Attribute_Value_Int([DefaultValue(PatternBase.DefaultValueInt)] int value = PatternBase.DefaultInt) => Value = value;

        public override object Expected => PatternBase.DefaultValueInt;
    }

    #endregion

    
    #region String

    public class Implicit_WithDefault_String : PatternBaseType
    {
        public Implicit_WithDefault_String(string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultString;
    }

    public class Implicit_WithDefault_Attribute_String : PatternBaseType
    {
        public Implicit_WithDefault_Attribute_String([DefaultValue(PatternBase.DefaultValueString)] string value) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    public class Implicit_WithDefault_Attribute_Value_String : PatternBaseType
    {
        public Implicit_WithDefault_Attribute_Value_String([DefaultValue(PatternBase.DefaultValueString)] string value = PatternBase.DefaultString) => Value = value;

        public override object Expected => PatternBase.DefaultValueString;
    }

    #endregion
}
