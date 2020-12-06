using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Import
{
    public abstract partial class Pattern
    {
        #region Type

        [TestProperty(OVERRIDE, MEMBER_OVERRIDE)]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data))]
        public virtual void Parameter_Override_ByType(string test, Type type, object defaultValue,
                                                      object defaultAttr, object registered, object named,
                                                      object injected, object overridden, object @default) 
            => Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type),
                MemberOverride(overridden), overridden);

        #endregion
    }
}
