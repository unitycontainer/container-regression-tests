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
        /// <summary>
        /// Tests injecting dependencies by value
        /// </summary>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(15), 
        ///                                new InjectionMethod("Method", 15) , 
        ///                                new InjectionField("Field", 15), 
        ///                                new InjectionProperty("Property", 15));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Injection_ByValue(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default) 
            => Assert_Injected(type, InjectionMember_Value(injected), injected, injected);


        /// <summary>
        /// Tests injecting dependencies by type
        /// </summary>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(type), 
        ///                                new InjectionMethod("Method", type) , 
        ///                                new InjectionField("Field", type), 
        ///                                new InjectionProperty("Property", type));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Injection_ByType(string test, Type type,
                                                         object defaultValue, object defaultAttr,
                                                         object registered, object named,
                                                         object injected, object overridden,
                                                         object @default)
            => Assert_Injected(type, InjectionMember_Value(type), registered);


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
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void Injection_ByResolver(string test, Type type,
                                                          object defaultValue, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          object @default)
            => Assert_Injected(type, InjectionMember_Value(new ValidatingResolver(injected)), injected, injected);


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
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void Injection_ByResolverFactory(string test, Type type,
                                                          object defaultValue, object defaultAttr,
                                                          object registered, object named,
                                                          object injected, object overridden,
                                                          object @default)
            => Assert_Injected(type, InjectionMember_Value(new ValidatingResolverFactory(injected)), injected, injected);
    }
}
