using Regression;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression.Annotated.Methods.Required
{
}

namespace Regression.Annotated.Methods.Required.WithDefault
{
}

namespace Regression.Annotated.Methods.Required.WithDefaultAttribute
{
}

namespace Regression.Annotated.Methods.Required.WithDefaultAndAttribute
{
}


namespace Methods.Required
{
    public class Required_Dependency_Value : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] int value) => Value = value;
    }

    public class Required_Dependency_Class : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] Unresolvable value) => Value = value;
    }

    public class Required_Dependency_Dynamic : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] dynamic value) => Value = value;
    }

    public class Required_Dependency_Generic<T> : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] T value) => Value = value;
    }

    public class Required_Dependency_Named<T> : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency(PatternBase.Name)] T value) => Value = value;
    }

    public class Required_WithDefault_Value : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] int value = PatternBase.DefaultInt) => Value = value;
    }

    public class Required_WithDefault_Class : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] string value = PatternBase.DefaultString) => Value = value;
    }
}
