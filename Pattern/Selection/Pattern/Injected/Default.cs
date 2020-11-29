using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
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
            var instance = AssertBasicPatternSuccessfull(target);

            Assert.IsNotNull(instance.Data[0]);
        }

        [DataTestMethod]
        [DynamicData(nameof(DefaultMemberTest_Data))]
        public virtual void DefaultMemberImplicitGeneric(Type dependency, Type @default)
        {
            // Setup
            Container.RegisterType(null, ImplicitType, null, null, InjectionMember_Default());
            var target = ImplicitType.MakeGenericType(new[] { dependency, @default });

            // Act
            var instance = AssertBasicPatternSuccessfull(target);
            Assert.IsNotNull(instance.Data[0]);
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
            var instance = AssertBasicPatternSuccessfull(target);
            Assert.IsNotNull(instance.Data[0]);
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
            var instance = AssertBasicPatternSuccessfull(target);
            Assert.IsNotNull(instance.Data[0]);
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
            var instance = AssertBasicPatternSuccessfull(target);
            Assert.IsNotNull(instance.Data[0]);
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
            var instance = AssertBasicPatternSuccessfull(target);
            Assert.IsNotNull(instance.Data[0]);
        }

        #endregion


        public static IEnumerable<object[]> DefaultMemberTest_Data
        {
            get
            {
                yield return new object[] { typeof(IUnityContainer), typeof(object) };
                yield return new object[] { typeof(int),             typeof(string) };
                yield return new object[] { typeof(string),          typeof(int) };
                yield return new object[] { typeof(Unresolvable),    typeof(IUnityContainer) };
            }
        }
    }
}
