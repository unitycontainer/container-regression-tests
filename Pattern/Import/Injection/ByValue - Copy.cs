using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif


namespace Import
{
    public abstract partial class Pattern
    {
        [TestCategory(Category_Inject)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Inject_ByType(string test, Type type,
                                          object defaultValue, object defaultAttr,
                                          object registered, object named,
                                          object injected, object overridden,
                                          object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type), 
                InjectionMember_Value(type), registered);

        /// <summary>
        /// Tests injecting dependencies by resolver 
        /// </summary>
        /// <remarks>
        /// A resolver is an object that implements <see cref="IResolve"/> interface
        /// </remarks>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(resolver), 
        ///                                new InjectionMethod("Method", resolver) , 
        ///                                new InjectionField("Field", resolver), 
        ///                                new InjectionProperty("Property", resolver));
        /// </example>
        [TestCategory(Category_Inject)]
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(Pattern))]
        public virtual void Inject_ByResolver(string test, Type type, object defaultValue, object defaultAttr,
                                              object registered, object named, object injected, object overridden,
                                              object @default)
            => Assert_Injected(BaselineTestType.MakeGenericType(type), 
                               InjectionMember_Value(new ValidatingResolver(injected)), 
                               injected, injected);

#if !UNITY_V4
        /// <summary>
        /// Tests injecting dependencies by resolver factory
        /// </summary>
        /// <remarks>
        /// A resolver is an object that implements <see cref="IResolverFactory{TMemberInfo}"/> interface
        /// </remarks>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(resolver), 
        ///                                new InjectionMethod("Method", resolver) , 
        ///                                new InjectionField("Field", resolver), 
        ///                                new InjectionProperty("Property", resolver));
        /// </example>
        [TestCategory(Category_Inject)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Inject_ByResolverFactory(string test, Type type, object defaultValue, object defaultAttr,
                                                     object registered, object named, object injected, object overridden,
                                                     object @default)
            => Assert_Injected(BaselineTestType.MakeGenericType(type), 
                               InjectionMember_Value(new ValidatingResolverFactory(injected)), 
                               injected, injected);
#endif
    }
}
