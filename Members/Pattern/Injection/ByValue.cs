﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Injection
{
    public abstract partial class Pattern
    {
        [TestCategory(CATEGORY_INJECT)]
        [PatternTestMethod("Inject dependency with {1}"), DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Value(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default) 
            => Assert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(injected), 
                injected, injected);

        [TestCategory(CATEGORY_INJECT)]
        [PatternTestMethod("Inject with {1} dependency"), DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Named(string test, Type type, object defaultValue, object defaultAttr,
                                         object registered, object named, object injected, object overridden,
                                         object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestNamed.MakeGenericType(type),
                InjectionMember_Value(injected),
                injected, injected);

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("https://github.com/unitycontainer/container/issues/235")]
#endif
        [TestCategory(CATEGORY_INJECT)]
        [PatternTestMethod("Inject with Type"), DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_With_Type(string test, Type type, object defaultValue, object defaultAttr,
                                            object registered, object named, object injected, object overridden,
                                            object @default)
            => Assert_Injection(BaselineTestType.MakeGenericType(type),
                                InjectionMember_Value(type), @default, registered);

        [TestCategory(CATEGORY_INJECT)]
        [PatternTestMethod("Inject with unresolvable dependency"), DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
#if UNITY_V4 || UNITY_V5
        [ExpectedException(typeof(InvalidOperationException))]
#else
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        public virtual void Inject_NoMatch(string test, Type type, object defaultValue, object defaultAttr,
                                            object registered, object named, object injected, object overridden,
                                            object @default)
        {
            var target = BaselineConsumer.MakeGenericType(type);
            var inject = InjectionMember_Value(injected);
            Container.RegisterType(null, target, null, null, inject);

            // Register missing types
            RegisterTypes();

            // Act
            _ = Container.Resolve(target, null);
        }

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore()]
#endif
        [TestCategory(CATEGORY_INJECT)]
        [PatternTestMethod("Inject with array"), DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Array(string test, Type type, object defaultValue, object defaultAttr,
                                         object registered, object named, object injected, object overridden,
                                         object @default)
        {
            var instance = Array.CreateInstance(type, 1);
            ((IList)instance)[0] = @default;

            Assert_Array_Import(BaselineArrayType.MakeGenericType(type), InjectionMember_Value(instance), instance);
        }

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore()]
#endif
        [TestCategory(CATEGORY_INJECT)]
        [PatternTestMethod("Inject with Enumerable"), DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Enumerable(string test, Type type, object defaultValue, object defaultAttr, 
                                              object registered, object named, object injected, object overridden, 
                                              object @default)
        {
            var instance = Array.CreateInstance(type, 1);
            ((IList)instance)[0] = @default;

            var target = BaselineTestType.MakeGenericType(typeof(IEnumerable<>).MakeGenericType(type));

            Assert_AlwaysSuccessful(target, InjectionMember_Value(instance), instance, instance);
        }

        [TestCategory(CATEGORY_INJECT)]
        [PatternTestMethod("Inject with Resolver"), DynamicData(nameof(Type_Compatibility_Data), typeof(PatternBase))]
        public virtual void Inject_Resolver(string test, Type type, object defaultValue, object defaultAttr,
                                            object registered, object named, object injected, object overridden,
                                            object @default)
            => Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type),
                               InjectionMember_Value(new ValidatingResolver(injected)),
                               injected, injected);
#if !UNITY_V4
        [TestCategory(CATEGORY_INJECT)]
        [PatternTestMethod("Inject with Type Factory"), DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_TypeFactory(string test, Type type, object defaultValue, object defaultAttr,
                                               object registered, object named, object injected, object overridden,
                                               object @default)
            => Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type),
                               InjectionMember_Value(new ValidatingResolverFactory(injected)),
                               injected, injected);
        // TODO: Implement in Diagnostic mode
        [TestCategory(CATEGORY_INJECT)]
#if BEHAVIOR_V5
        [ExpectedException(typeof(InvalidOperationException))]
#endif
        [PatternTestMethod("Inject with invalid Type"), DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_NoPublicMember(string test, Type type, object defaultValue, object defaultAttr,
                                                   object registered, object named, object injected, object overridden,
                                                   object @default)
#if BEHAVIOR_V5
            => Assert_Fail(NoPublicMember.MakeGenericType(type), InjectionMember_Value(injected));
#else
            => Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(type),
                               InjectionMember_Value(new ValidatingResolverFactory(injected)),
                               injected, injected);
#endif
#endif
    }
}
