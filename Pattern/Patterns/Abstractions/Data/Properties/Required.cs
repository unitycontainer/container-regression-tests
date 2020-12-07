﻿using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Required.Properties
{
    #region Baseline

    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [Dependency] public TDependency Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency> : FixtureBaseType
    {
        [Dependency(FixtureBase.Name)] public TDependency Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    #endregion


    #region No Public Members

    public class NoPublicMember<TDependency>
    {
        [Dependency]
        private TDependency Property { get; set; }
    }

    #endregion


    #region Object

    public class ObjectTestType : FixtureBaseType
    {
        [Dependency] public object Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    #endregion


    #region Array

    public class BaselineArrayType<TDependency> : FixtureBaseType
    {
        [Dependency] public TDependency[] Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class ObjectArrayType : FixtureBaseType
    {
        [Dependency] public object[] Property { get; set; }
        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    #endregion


    #region Consumer

    public class BaselineConsumer<TDependency> : FixtureBaseType
    {
        public readonly BaselineTestType<TDependency> Item1;
        public readonly BaselineTestTypeNamed<TDependency> Item2;

        public BaselineConsumer(BaselineTestType<TDependency> item1, BaselineTestTypeNamed<TDependency> item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override object Value => Item1.Value;
        public override object Default => Item2.Value;
    }

    #endregion
}