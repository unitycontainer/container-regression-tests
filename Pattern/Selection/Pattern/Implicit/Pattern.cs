using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Implicit
{
    public abstract partial class OldPattern 
    {
        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void Selection_NoPublicMebers(string test, Type type)
            => Assert_ResolutionSuccess(NoPublicMemberImplicit.MakeGenericType(type));
    }
}
