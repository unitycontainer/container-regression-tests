using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Injection
{
    // Tests injecting dependencies by value
    // 
    // Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(15)), 
    //                                new InjectionMethod("Method",     new InjectionParameter(15)) , 
    //                                new InjectionField("Field",       new InjectionParameter(15)), 
    //                                new InjectionProperty("Property", new InjectionParameter(type, 15)));
    public abstract partial class Pattern
    {
        #region default
        
#if !BEHAVIOR_V4 // Unity v4 did not support null as valid value
        [TestProperty(PARAMETER, nameof(InjectionParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Parameter_default(string test, Type type, object defaultValue, object defaultAttr,
                                      object registered, object named, object injected,
                                      object overridden, object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type),
                InjectionMember_Value(new InjectionParameter(@default)),
                @default, @default);
#endif

        [TestProperty(PARAMETER, nameof(InjectionParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Parameter_Type_default(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, 
                                           object overridden, object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new InjectionParameter(type, @default)), 
                @default, @default);


        [TestProperty(PARAMETER, nameof(InjectionParameter))]
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Parameter_null_Value(string test, Type type, object defaultValue, object defaultAttr,
                                         object registered, object named, object injected,
                                         object overridden, object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type),
                InjectionMember_Value(new InjectionParameter(null, injected)),
                injected, injected);
        
        #endregion


        #region Value

        [TestProperty(PARAMETER, nameof(InjectionParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Parameter_Value(string test, Type type, object defaultValue, object defaultAttr,
                                    object registered, object named, object injected, 
                                    object overridden, object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new InjectionParameter(injected)), 
                injected, injected);


        [TestProperty(PARAMETER, nameof(InjectionParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Parameter_Type_Value(string test, Type type, object defaultValue, object defaultAttr,
                                         object registered, object named, object injected, 
                                         object overridden, object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(new InjectionParameter(type, injected)), 
                injected, injected);


        [TestProperty(PARAMETER, nameof(InjectionParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Parameter_Named(string test, Type type, object defaultValue, object defaultAttr,
                                    object registered, object named, object injected, 
                                    object overridden, object @default)
            => Assert_AlwaysSuccessful(
                BaselineTestNamed.MakeGenericType(type), 
                InjectionMember_Value(new InjectionParameter(type, injected)), 
                injected, injected);
        
        #endregion


        #region Type 

        [TestProperty(PARAMETER, nameof(InjectionParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Parameter_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, 
                                           object overridden, object @default)
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


#if BEHAVIOR_V4 || BEHAVIOR_V5
        [ExpectedException(typeof(InvalidOperationException))]
#else
        // Starting with v6 no validation during registration
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [TestProperty(PARAMETER, nameof(InjectionParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public void Parameter_ByType(string test, Type type, object defaultValue, object defaultAttr,
                                     object registered, object named, object injected, 
                                     object overridden, object @default)
            => Assert_Fail(BaselineTestType.MakeGenericType(type), 
                           InjectionMember_Value(new InjectionParameter(type)));

        #endregion
    }
}
