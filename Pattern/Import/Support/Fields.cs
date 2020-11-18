﻿using Regression;
using System;
using System.ComponentModel;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Fields
{
    #region Support

    public static class Support
    {
        private const string FieldName = "Field";

        public static InjectionMember GetByNameMember(Type type, string name)
            => new InjectionField(FieldName);

        public static InjectionMember GetByNameOptional(Type type, string name)
#if V5
            => new InjectionField(FieldName, true);
#else
            => new OptionalField(FieldName);
#endif

        public static InjectionMember GetResolvedMember(Type type, string name)
            => new InjectionField(FieldName, new ResolvedParameter(type, name));

        public static InjectionMember GetOptionalMember(Type type, string name)
            => new InjectionField(FieldName, new OptionalParameter(type, name));

        public static InjectionMember GetOptionalOptional(Type type, string name)
#if V5
            => new InjectionField(FieldName, new OptionalParameter(type, name));
#else
            => new OptionalField(FieldName, new OptionalParameter(type, name));
#endif

        public static InjectionMember GetGenericMember(Type _, string name)
            => new InjectionField(FieldName, new GenericParameter("T", name));

        public static InjectionMember GetGenericOptional(Type type, string name)
            => new InjectionField(FieldName, new OptionalGenericParameter("T", name));

        public static InjectionMember GetInjectionValue(object argument)
            => new InjectionField(FieldName, argument);

        public static InjectionMember GetInjectionOptional(object argument)
#if V5
            => new InjectionField(FieldName, argument);
#else
            => new OptionalField(FieldName, argument);
#endif
    }

    #endregion


    #region Baseline

    public class BaselineTestType : PatternBaseType
    {
        public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    #endregion


    #region Implicit

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
        [DefaultValue(PatternBase.DefaultInt)]
        public int Field = PatternBase.DefaultInt;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Implicit_WithDefault_Class : PatternBaseType
    {
        [DefaultValue(PatternBase.DefaultString)]
        public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    #endregion


    #region Required

    public class Required_Dependency_Value : PatternBaseType
    {
        [Dependency] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Class : PatternBaseType
    {
        [Dependency] public Unresolvable Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Dynamic : PatternBaseType
    {
        [Dependency] public dynamic Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Generic<T> : PatternBaseType
    {
        [Dependency] public T Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Named<T> : PatternBaseType
    {
        [Dependency(PatternBase.Name)] public T Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_WithDefault_Value : PatternBaseType
    {
        [Dependency]
        [DefaultValue(PatternBase.DefaultInt)]
        public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_WithDefault_Class : PatternBaseType
    {
        [Dependency]
        [DefaultValue(PatternBase.DefaultString)]
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
