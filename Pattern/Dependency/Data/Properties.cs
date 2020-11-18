﻿using Regression;
using System;
using System.ComponentModel;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Properties
{
    #region No Default

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
        public int Property { get; set; } = DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_WithDefault_Class : PatternBaseType
    {
        public string Property { get; set; } = DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    #endregion


    #region Required

    public class Required_Dependency_Value : PatternBaseType
    {
        [Dependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Class : PatternBaseType
    {
        [Dependency] public Unresolvable Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Dynamic : PatternBaseType
    {
        [Dependency] public dynamic Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Generic<T> : PatternBaseType
    {
        [Dependency] public T Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Named<T> : PatternBaseType
    {
        [Dependency(Name)] public T Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_WithDefault_Value : PatternBaseType
    {
        [Dependency]
        [DefaultValue(DefaultInt)]
        public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_WithDefault_Class : PatternBaseType
    {
        [Dependency]
        [DefaultValue(DefaultString)]
        public string Property { get; set; }

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
        [OptionalDependency(Name)] public T Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Optional_WithDefault_Value : PatternBaseType
    {
        [OptionalDependency] public int Property { get; set; } = DefaultInt;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Optional_WithDefault_Class : PatternBaseType
    {
        [OptionalDependency] public string Property { get; set; } = DefaultString;

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    #endregion
}
