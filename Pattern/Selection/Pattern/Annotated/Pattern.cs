using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Annotated
{
    public abstract partial class Pattern 
    {
        [DataTestMethod]
        [DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void Selection_NoPublicMebers_Required(string test, Type type)
            => AssertResolution(NoPublicMemberRequired.MakeGenericType(type));
        
        [DataTestMethod]
        [DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        public virtual void Selection_NoPublicMebers_Optional(string test, Type type)
            => AssertResolution(NoPublicMemberOptional.MakeGenericType(type));
    }
}
