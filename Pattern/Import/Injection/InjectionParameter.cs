using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Regression;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
using Unity.Injection;
#endif


namespace Import
{
    // Tests injecting dependencies by value
    // 
    // Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(15)), 
    //                                new InjectionMethod("Method",     new InjectionParameter(15)) , 
    //                                new InjectionField("Field",       new InjectionParameter(15)), 
    //                                new InjectionProperty("Property", new InjectionParameter(15)));
    public abstract partial class Pattern
    {
        #region Value

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void InjectionParameter_ByValue(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden,
                                                       object @default)
            => Assert_Injected(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new InjectionParameter(injected)), injected, injected);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void InjectionParameter_ByValue_WithType(string test, Type type, object defaultValue, object defaultAttr,
                                                                  object registered, object named, object injected, object overridden,
                                                                  object @default)
            => Assert_Injected(BaselineTestType.MakeGenericType(type), InjectionMember_Value(new InjectionParameter(type, injected)), injected, injected);



        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void InjectionParameter_ByValue_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden,
                                                       object @default)
            => Assert_Injected(BaselineTestNamed.MakeGenericType(type), InjectionMember_Value(new InjectionParameter(type, injected)), injected, injected);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void InjectionParameter_ByValue_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                                                   object registered, object named, object injected, object overridden,
                                                                   object @default)
        {
            var target = BaselineTestType.MakeGenericType(type);

            Container.RegisterType(null, target, null, null, InjectionMember_Value(new InjectionParameter(type, type)));

            // Validate
#if BEHAVIOR_V5
            Assert.ThrowsException<ArgumentException>(() => Container.Resolve(target, null));
#else
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));
#endif

            // Register missing types
            RegisterTypes();

            // Act
#if BEHAVIOR_V5
            Assert.ThrowsException<ArgumentException>(() => Container.Resolve(target, null));
#else
            Assert.ThrowsException<ResolutionFailedException>(() => Container.Resolve(target, null));
#endif
        }

        #endregion


        #region Type 

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [ExpectedException(typeof(InvalidOperationException))]
#else
        // Starting with v6 no validation during registration
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void InjectionParameter_ByType(string test, Type type, object defaultValue, object defaultAttr,
                                                      object registered, object named, object injected, object overridden,
                                                      object @default)
            => Assert_Fail(BaselineTestType.MakeGenericType(type), 
                           InjectionMember_Value(new InjectionParameter(type)));


        #endregion


        #region Target

        // TODO: Add OnType

        #endregion
    }
}
