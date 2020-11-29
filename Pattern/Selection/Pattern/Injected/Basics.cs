using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Injected
{
    public abstract partial class Pattern 
    {
        [DataTestMethod]
        [DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void NoPublicMebersToSelect_Implicit(string test, Type type)
        {
            // Arrange
            var target = NoPublicMemberImplicit.MakeGenericType(type);

            Container.RegisterType(null, target, null, null, InjectionMember_Required_ByType(type));

            AssertResolutionSuccessfull(target); 
        }

        [DataTestMethod]
        [DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void NoPublicMebersToSelect_Required(string test, Type type)
        {
            // Arrange
            var target = NoPublicMemberRequired.MakeGenericType(type);

            Container.RegisterType(null, target, null, null, InjectionMember_Required_ByType(type));

            AssertResolutionSuccessfull(target);
        }


        [DataTestMethod]
        [DynamicData(nameof(Unsupported_Data), typeof(FixtureBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void NoPublicMebersToSelect_Optional(string test, Type type)
        {
            // Arrange
            var target = NoPublicMemberOptional.MakeGenericType(type);

            Container.RegisterType(null, target, null, null, InjectionMember_Required_ByType(type));

            AssertResolutionSuccessfull(target);
        }


        #region Not Supported

        public override void BasicOperationTest(string test, Type type) { }

        #endregion
    }
}
