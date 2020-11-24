using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Fields.Optional
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [OptionalDependency] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        [OptionalDependency(PatternBase.Name)] public TDependency Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
        public override object Default => default(TDependency);
    }

    public class BaselineInheritedType<TDependency>
        : BaselineTestType<TDependency>
    {
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
    }

    #endregion


    #region Test Data


    public class Optional_Int : PatternBaseType
    {
        [OptionalDependency] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override Type ImportType => typeof(int);
    }

    public class Optional_String : PatternBaseType
    {
        [OptionalDependency] public string Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override Type ImportType => typeof(string);
    }

    public class Optional_Unresolvable : PatternBaseType
    {
        [OptionalDependency] public Unresolvable Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
