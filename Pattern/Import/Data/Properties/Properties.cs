using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Properties
{
    public class ImplicitTestType<TDependency>
        : PatternBaseType
    {
        public TDependency Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class RequiredTestType<TDependency>
        : PatternBaseType
    {
        [Dependency] public TDependency Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }

    }

    public class OptionalTestType<TDependency>
        : PatternBaseType
    {
        [OptionalDependency] public TDependency Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }


    #region Implicit

    public class Implicit<TDependency> : PatternBaseType
    {
        public TDependency Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_Dependency_Value : PatternBaseType
    {
        public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_Dependency_Class : PatternBaseType
    {
        public Unresolvable Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_Dependency_Dynamic : PatternBaseType
    {
        public dynamic Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_Dependency_Generic<T> : PatternBaseType
    {
        public T Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_WithDefault_Value : PatternBaseType
    {
        public int Property { get; set; } = PatternBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_WithDefault_Class : PatternBaseType
    {
        public string Property { get; set; } = PatternBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    #endregion


    #region Optional

    public class Optional_Dependency_Value : PatternBaseType
    {
        [OptionalDependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Optional_Dependency_Class : PatternBaseType
    {
        [OptionalDependency] public Unresolvable Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Optional_Dependency_Dynamic : PatternBaseType
    {
        [OptionalDependency] public dynamic Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Optional_Dependency_Generic<T> : PatternBaseType
    {
        [OptionalDependency] public T Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Optional_Dependency_Named<T> : PatternBaseType
    {
        [OptionalDependency(PatternBase.Name)] public T Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Optional_WithDefault_Value : PatternBaseType
    {
        [OptionalDependency] public int Property { get; set; } = PatternBase.DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Optional_WithDefault_Class : PatternBaseType
    {
        [OptionalDependency] public string Property { get; set; } = PatternBase.DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    #endregion
}
