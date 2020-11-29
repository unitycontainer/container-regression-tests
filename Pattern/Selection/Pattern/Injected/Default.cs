using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
#endif

namespace Selection.Injected
{
    public abstract partial class Pattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(DefaultMemberTest_Data))]
        public virtual void DefaultMemberImplicit(Type dependency, Type @default)
        {
            // Setup
            var target = ImplicitType.MakeGenericType(new[] { dependency, @default });
            Container.RegisterType(null, target, null, null, InjectionMember_Default());

            // Act
            var instance = AssertResolutionPattern(target);

            Assert.IsNotNull(instance[0]);
        }

        [DataTestMethod]
        [DynamicData(nameof(DefaultMemberTest_Data))]
        public virtual void DefaultMemberImplicitGeneric(Type dependency, Type @default)
        {
            // Setup
            Container.RegisterType(null, ImplicitType, null, null, InjectionMember_Default());
            var target = ImplicitType.MakeGenericType(new[] { dependency, @default });

            // Act
            var instance = AssertResolutionPattern(target);
            Assert.IsNotNull(instance[0]);
        }

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(DefaultMemberTest_Data))]
        public virtual void DefaultMemberRequired(Type dependency, Type @default)
        {
            // Setup
            var target = RequiredType.MakeGenericType(new[] { dependency, @default });
            Container.RegisterType(null, target, null, null, InjectionMember_Default());
            RegisterTypes();

            // Act
            var instance = AssertResolutionPattern(target);
            Assert.IsNotNull(instance[0]);
        }

        [DataTestMethod]
        [DynamicData(nameof(DefaultMemberTest_Data))]
        public virtual void DefaultMemberRequiredGeneric(Type dependency, Type @default)
        {
            // Setup
            Container.RegisterType(null, RequiredType, null, null, InjectionMember_Default());
            var target = RequiredType.MakeGenericType(new[] { dependency, @default });
            RegisterTypes();

            // Act
            var instance = AssertResolutionPattern(target);
            Assert.IsNotNull(instance[0]);
        }

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(DefaultMemberTest_Data))]
        public virtual void DefaultMemberOptional(Type dependency, Type @default)
        {
            // Setup
            var target = OptionalType.MakeGenericType(new[] { dependency, @default });
            Container.RegisterType(null, target, null, null, InjectionMember_Default());
            RegisterTypes();

            // Act
            var instance = AssertResolutionPattern(target);
            Assert.IsNotNull(instance[0]);
        }

        [DataTestMethod]
        [DynamicData(nameof(DefaultMemberTest_Data))]
        public virtual void DefaultMemberOptionalGeneric(Type dependency, Type @default)
        {
            // Setup
            Container.RegisterType(null, OptionalType, null, null, InjectionMember_Default());
            var target = OptionalType.MakeGenericType(new[] { dependency, @default });
            RegisterTypes();

            // Act
            var instance = AssertResolutionPattern(target);
            Assert.IsNotNull(instance[0]);
        }

        #endregion
    }
}
