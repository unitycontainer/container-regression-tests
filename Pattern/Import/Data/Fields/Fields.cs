using Regression;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Fields
{
    public class ImplicitTestType<TDependency>
        : PatternBaseType
    {
        public TDependency Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class RequiredTestType<TDependency>
        : PatternBaseType
    {
        [Dependency] public TDependency Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

    }

    public class OptionalTestType<TDependency>
        : PatternBaseType
    {
        [OptionalDependency] public TDependency Field;
        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }




    #region Implicit

    public class Implicit<TDependency> : PatternBaseType
    {
        public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_Dependency_Value : PatternBaseType
    {
        public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_Dependency_Class : PatternBaseType
    {
        public Unresolvable Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_Dependency_Dynamic : PatternBaseType
    {
        public dynamic Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_Dependency_Generic<T> : PatternBaseType
    {
        public T Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_WithDefault_Value : PatternBaseType
    {
        public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_WithDefault_Class : PatternBaseType
    {
        public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    #endregion


    #region Optional

    public class Optional_Dependency_Value : PatternBaseType
    {
        [OptionalDependency] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Optional_Dependency_Class : PatternBaseType
    {
        [OptionalDependency] public Unresolvable Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Optional_Dependency_Dynamic : PatternBaseType
    {
        [OptionalDependency] public dynamic Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Optional_Dependency_Generic<T> : PatternBaseType
    {
        [OptionalDependency] public T Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Optional_Dependency_Named<T> : PatternBaseType
    {
        [OptionalDependency(PatternBase.Name)] public T Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Optional_WithDefault_Value : PatternBaseType
    {
        [OptionalDependency] public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Optional_WithDefault_Class : PatternBaseType
    {
        [OptionalDependency] public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    #endregion
}
