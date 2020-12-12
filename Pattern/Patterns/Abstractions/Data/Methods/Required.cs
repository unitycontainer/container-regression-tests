#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Regression.Required.Methods
{
    #region Baseline

    public class BaselineTestType<TDependency> : FixtureBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : FixtureBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency(FixtureBase.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestType<TItem1, TItem2> : FixtureBaseType
    {
        [InjectionMethod]
        public virtual void Method([Dependency] TItem1 item1, [Dependency] TItem2 item2)
        {
            Value = item1;
            Default = item2;
        }
    }

    #endregion


    #region Object

    public class ObjectTestType : FixtureBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] object value) => Value = value;
    }

    #endregion


    #region No Public Members

    public class NoPublicMember<TDependency>
    {
        [InjectionMethod]
        private void Method([Dependency] TDependency value) { }
    }

    #endregion


    #region Array

    public class BaselineArrayType<TDependency> : FixtureBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] TDependency[] value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class ObjectArrayType : FixtureBaseType
    {
        [InjectionMethod]
        public void Method([Dependency] object[] value) => Value = value;
    }

    #endregion


    #region Consumer

    public class BaselineConsumer<TDependency> : FixtureBaseType
    {
        public BaselineTestType<TDependency> Item1 { get; private set; }
        public BaselineTestTypeNamed<TDependency> Item2 { get; private set; }

        [InjectionMethod]
        public void Method(BaselineTestType<TDependency> item1, BaselineTestTypeNamed<TDependency> item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override object Value => Item1.Value;
        public override object Default => Item2.Value;
    }

    #endregion
}
