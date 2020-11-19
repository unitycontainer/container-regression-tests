using Regression;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Methods
{
    #region Baseline

    public class BaselineTestType : PatternBaseType
    {
        [InjectionMethod]
        public void Method() { }
    }

    public class Implicit<TDependency> : PatternBaseType
    {
        [InjectionMethod]
        public void Method(TDependency value) => Value = value;
    }

    #endregion


    #region Required

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

    #endregion


    #region Optional

    public class Optional_Dependency_Value : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency] int value) => Value = value;
    }

    public class Optional_Dependency_Class : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency] Unresolvable value) => Value = value;
    }

    public class Optional_Dependency_Dynamic : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency] dynamic value) => Value = value;
    }

    public class Optional_Dependency_Generic<T> : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency] T value) => Value = value;
    }

    public class Optional_Dependency_Named<T> : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency(PatternBase.Name)] T value) => Value = value;
    }

    public class Optional_WithDefault_Value : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency] int value = PatternBase.DefaultInt) => Value = value;
    }

    public class Optional_WithDefault_Class : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency] string value = PatternBase.DefaultString) => Value = value;
    }

    public class Optional_Dependency_Value_Named : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency(PatternBase.Name)] int value) => Value = value;
    }

    public class Optional_Dependency_Class_Named : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency(PatternBase.Name)] Unresolvable value) => Value = value;
    }

    #endregion


    #region Unsupported


    public class Implicit_Dependency_Ref : PatternBaseType
    {
        [InjectionMethod]
        public void Method(ref Unresolvable value) => Value = value;
    }

    public class Implicit_Dependency_Out : PatternBaseType
    {
        [InjectionMethod]
        public void Method(out Unresolvable value) => value = null;
    }

    public class Implicit_Generic_Ref<T> : PatternBaseType where T : class
    {
        [InjectionMethod]
        public void Method(ref T value) => Value = value;
    }

    public class Implicit_Generic_Out<T> : PatternBaseType where T : class
    {
        [InjectionMethod]
        public void Method(out T value) => value = null;
    }



    public class Required_Dependency_Ref : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] ref Unresolvable value) => Value = value;
    }

    public class Required_Dependency_Out : PatternBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] out Unresolvable value) => value = null;
    }

    public class Required_Generic_Ref<T> : PatternBaseType where T : class
    {
        [InjectionMethod]
        public void Method([Dependency] ref T value) => Value = value;
    }

    public class Required_Generic_Out<T> : PatternBaseType where T : class
    {
        [InjectionMethod]
        public void Method([Dependency] out T value) => value = null;
    }



    public class Optional_Dependency_Ref : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency] ref Unresolvable value) => Value = value;
    }

    public class Optional_Dependency_Out : PatternBaseType
    {
        [InjectionMethod]
        public void Method([OptionalDependency] out Unresolvable value) => value = null;
    }

    public class Optional_Generic_Ref<T> : PatternBaseType where T : class
    {
        [InjectionMethod]
        public void Method([OptionalDependency] ref T value) => Value = value;
    }

    public class Optional_Generic_Out<T> : PatternBaseType where T : class
    {
        [InjectionMethod]
        public void Method([OptionalDependency] out T value) => value = null;
    }

    #endregion
}
