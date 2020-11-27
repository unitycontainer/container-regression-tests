using Manager;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Implicit.Methods
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        [InjectionMethod]
        public virtual void Method(TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    #endregion
}
