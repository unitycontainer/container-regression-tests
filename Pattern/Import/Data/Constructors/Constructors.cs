using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Constructors
{
    public class ImplicitTestType<TDependency>
        : PatternBaseType
    {
        public ImplicitTestType(TDependency value) => Value = value;
    }

    public class RequiredTestType<TDependency>
        : PatternBaseType
    {
        public RequiredTestType([Dependency] TDependency value) => Value = value;
    }

    public class OptionalTestType<TDependency>
        : PatternBaseType
    {
        public OptionalTestType([OptionalDependency] TDependency value) => Value = value;
    }


    #region Invalid

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

    #endregion



    #region Optional

    public class Optional_Dependency_Value : PatternBaseType
    {
        public Optional_Dependency_Value([OptionalDependency] int value) => Value = value;
    }

    public class Optional_Dependency_Class : PatternBaseType
    {
        public Optional_Dependency_Class([OptionalDependency] Unresolvable value) => Value = value;
    }

    public class Optional_Dependency_Dynamic : PatternBaseType
    {
        public Optional_Dependency_Dynamic([OptionalDependency] dynamic value) => Value = value;
    }

    public class Optional_Dependency_Generic<T> : PatternBaseType
    {
        public Optional_Dependency_Generic([OptionalDependency] T value) => Value = value;
    }

    public class Optional_Dependency_Named<T> : PatternBaseType
    {
        public Optional_Dependency_Named([OptionalDependency(PatternBase.Name)] T value) => Value = value;
    }

    public class Optional_WithDefault_Value : PatternBaseType
    {
        public Optional_WithDefault_Value([OptionalDependency] int value = PatternBase.DefaultInt) => Value = value;
    }

    public class Optional_WithDefault_Class : PatternBaseType
    {
        public Optional_WithDefault_Class([OptionalDependency] string value = PatternBase.DefaultString) => Value = value;
    }

    #endregion


    #region Unsupported

    public class Implicit_Dependency_Ref : PatternBaseType
    {
        public Implicit_Dependency_Ref(ref Unresolvable value) => Value = value;
    }

    public class Implicit_Dependency_Out : PatternBaseType
    {
        public Implicit_Dependency_Out(out Unresolvable value) => value = null;
    }

    public class Implicit_Generic_Ref<T> : PatternBaseType where T : class
    {
        public Implicit_Generic_Ref(ref T value) => Value = value;
    }

    public class Implicit_Generic_Out<T> : PatternBaseType where T : class
    {
        public Implicit_Generic_Out(out T value) => value = null;
    }


    public class Required_Dependency_Ref : PatternBaseType
    {
        public Required_Dependency_Ref([Dependency] ref Unresolvable value) => Value = value;
    }

    public class Required_Dependency_Out : PatternBaseType
    {
        public Required_Dependency_Out([Dependency] out Unresolvable value) => value = null;
    }

    public class Required_Generic_Ref<T> : PatternBaseType where T : class
    {
        public Required_Generic_Ref([Dependency] ref T value) => Value = value;
    }

    public class Required_Generic_Out<T> : PatternBaseType where T : class
    {
        public Required_Generic_Out([Dependency] out T value) => value = null;
    }


    public class Optional_Dependency_Ref : PatternBaseType
    {
        public Optional_Dependency_Ref([OptionalDependency] ref Unresolvable value) => Value = value;
    }

    public class Optional_Dependency_Out : PatternBaseType
    {
        public Optional_Dependency_Out([OptionalDependency] out Unresolvable value) => value = null;
    }

    public class Optional_Generic_Ref<T> : PatternBaseType where T : class
    {
        public Optional_Generic_Ref([OptionalDependency] ref T value) => Value = value;
    }

    public class Optional_Generic_Out<T> : PatternBaseType where T : class
    {
        public Optional_Generic_Out([OptionalDependency] out T value) => value = null;
    }

    #endregion
}
