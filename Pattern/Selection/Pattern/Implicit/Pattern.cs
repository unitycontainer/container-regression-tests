using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Implicit
{
    public abstract partial class Pattern 
    {
        [DataTestMethod]
        [DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void NoPublicMebersToSelect(string test, Type type)
            => AssertResolution(NoPublicMemberImplicit.MakeGenericType(type));
    }
}
