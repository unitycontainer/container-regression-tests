using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Selection.Injected
{
    public abstract partial class Pattern 
    {
        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
#if BEHAVIOR_V4
        [ExpectedException(typeof(InvalidOperationException))]
#else
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        public void NoPublicMebersToSelect_Implicit(string test, Type type)
        {
            // Arrange
            var target = NoPublicMemberImplicit.MakeGenericType(type);

            Container.RegisterType(null, target, null, null, InjectionMember_Value(new ResolvedParameter(type)));

            Assert_ResolutionSuccess(target); 
        }

        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
#if BEHAVIOR_V4
        [ExpectedException(typeof(InvalidOperationException))]
#else
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        public void NoPublicMebersToSelect_Required(string test, Type type)
        {
            // Arrange
            var target = NoPublicMemberRequired.MakeGenericType(type);

            Container.RegisterType(null, target, null, null, InjectionMember_Value(new ResolvedParameter(type)));

            Assert_ResolutionSuccess(target);
        }


        [DataTestMethod, DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
#if BEHAVIOR_V4
        [ExpectedException(typeof(InvalidOperationException))]
#else
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        public void NoPublicMebersToSelect_Optional(string test, Type type)
        {
            // Arrange
            var target = NoPublicMemberOptional.MakeGenericType(type);

            Container.RegisterType(null, target, null, null, InjectionMember_Value(new ResolvedParameter(type)));

            Assert_ResolutionSuccess(target);
        }

    }
}
