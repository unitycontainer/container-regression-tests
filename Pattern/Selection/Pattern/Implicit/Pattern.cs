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
    public abstract partial class Pattern 
    {
        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void Selection_NoPublicMebers(string test, Type type)
            => AssertResolution(NoPublicMemberImplicit.MakeGenericType(type));
    }
}
