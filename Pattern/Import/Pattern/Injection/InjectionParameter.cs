using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Regression;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
using Unity.Injection;
#endif


namespace Import
{
    public abstract partial class Pattern
    {
        #region Value

        /// <summary>
        /// Tests injecting dependencies by value
        /// </summary>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(15)), 
        ///                                new InjectionMethod("Method",     new InjectionParameter(15)) , 
        ///                                new InjectionField("Field",       new InjectionParameter(15)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(15)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByValue(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden, 
                                                       object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(injected)), injected, injected);
        

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByValue_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                       object registered, object named, object injected, object overridden,
                                                       object @default)
            => Assert_InjectNamed(type, InjectionMember_Value(new InjectionParameter(type, injected)), injected, injected);

        /// <summary>
        /// Tests injecting dependencies by value
        /// </summary>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(type, 15)), 
        ///                                new InjectionMethod("Method",     new InjectionParameter(type, 15)) , 
        ///                                new InjectionField("Field",       new InjectionParameter(type, 15)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(type, 15)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByValue_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                                  object registered, object named, object injected, object overridden,
                                                                  object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(type, injected)), injected, injected);

        #endregion


        #region Type 

        /// <summary>
        /// Tests injecting dependencies by type
        /// </summary>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(type)), 
        ///                                new InjectionMethod("Method",     new InjectionParameter(type)) , 
        ///                                new InjectionField("Field",       new InjectionParameter(type)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(type)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByType(string test, Type type, object defaultValue, object defaultAttr,
                                                      object registered, object named, object injected, object overridden,
                                                      object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(type)), registered);

        /// <summary>
        /// Must override named
        /// </summary>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByType_OverridesName(string test, Type type, object defaultValue, object defaultAttr,
                                                              object registered, object named, object injected, object overridden,
                                                              object @default)
            => Assert_InjectNamed(type, InjectionMember_Value(new InjectionParameter(type)), registered);


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByType_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                                              object registered, object named, object injected, object overridden,
                                                              object @default)
            => Assert_InjectNamed(type, InjectionMember_Value(new InjectionParameter(type, type)), registered);


        /// <summary>
        /// Tests injecting dependencies by type
        /// </summary>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(contractType, type)), 
        ///                                new InjectionMethod("Method",     new InjectionParameter(contractType, type)) , 
        ///                                new InjectionField("Field",       new InjectionParameter(contractType, type)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(contractType, type)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByType_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                                 object registered, object named, object injected, object overridden, 
                                                                 object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(type, type)), registered);

        #endregion


        #region Parameter

#if !UNITY_V4
        /// <summary>
        /// Tests injecting dependencies by resolver 
        /// </summary>
        /// <remarks>
        /// A resolver is an object that implements <see cref="IResolve"/> interface
        /// </remarks>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(resolver)), 
        ///                                new InjectionMethod("Method",    new InjectionParameter(resolver)) , 
        ///                                new InjectionField("Field",      new InjectionParameter(resolver)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(resolver)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByParameter(string test, Type type, object defaultValue, object defaultAttr,
                                                           object registered, object named, object injected, object overridden,
                                                           object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(new ResolvedParameter())), registered);


        /// <summary>
        /// Tests injecting dependencies by resolver 
        /// </summary>
        /// <remarks>
        /// A resolver is an object that implements <see cref="IResolve"/> interface
        /// </remarks>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(type, resolver)), 
        ///                                new InjectionMethod("Method",    new InjectionParameter(type, resolver)) , 
        ///                                new InjectionField("Field",      new InjectionParameter(type, resolver)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(type, resolver)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByParameter_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                                      object registered, object named, object injected, object overridden,
                                                                      object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(type, new ResolvedParameter())), registered);
#endif

        #endregion


        #region Resolver

#if !BEHAVIOR_V4
        /// <summary>
        /// Tests injecting dependencies by resolver 
        /// </summary>
        /// <remarks>
        /// A resolver is an object that implements <see cref="IResolve"/> interface
        /// </remarks>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(resolver)), 
        ///                                new InjectionMethod("Method",    new InjectionParameter(resolver)) , 
        ///                                new InjectionField("Field",      new InjectionParameter(resolver)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(resolver)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByResolver(string test, Type type, object defaultValue, object defaultAttr,
                                                          object registered, object named, object injected, object overridden,
                                                          object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(new ValidatingResolver(injected))), injected, injected);


        /// <summary>
        /// Tests injecting dependencies by resolver 
        /// </summary>
        /// <remarks>
        /// A resolver is an object that implements <see cref="IResolve"/> interface
        /// </remarks>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(type, resolver)), 
        ///                                new InjectionMethod("Method",    new InjectionParameter(type, resolver)) , 
        ///                                new InjectionField("Field",      new InjectionParameter(type, resolver)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(type, resolver)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Compatibility_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByResolver_WithContract(string test, Type type,
                                                                       object defaultValue, object defaultAttr,
                                                                       object registered, object named,
                                                                       object injected, object overridden,
                                                                       object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(type, new ValidatingResolver(injected))), injected, injected);
#endif
        #endregion


        #region Factory

#if !UNITY_V4
        /// <summary>
        /// Tests injecting dependencies by resolver factory
        /// </summary>
        /// <remarks>
        /// A resolver is an object that implements <see cref="IResolverFactory{TMemberInfo}"/> interface
        /// </remarks>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(resolver)), 
        ///                                new InjectionMethod("Method",    new InjectionParameter(resolver)) , 
        ///                                new InjectionField("Field",      new InjectionParameter(resolver)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(resolver)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByFactory(string test, Type type, object defaultValue, object defaultAttr,
                                                         object registered, object named, object injected, object overridden,
                                                         object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(new ValidatingResolverFactory(injected))), injected, injected);


        /// <summary>
        /// Tests injecting dependencies by resolver factory
        /// </summary>
        /// <remarks>
        /// A resolver is an object that implements <see cref="IResolverFactory{TMemberInfo}"/> interface
        /// </remarks>
        /// <example>
        /// Container.RegisterType(target, new InjectionConstructor(new InjectionParameter(type, resolver)), 
        ///                                new InjectionMethod("Method",    new InjectionParameter(type, resolver)) , 
        ///                                new InjectionField("Field",      new InjectionParameter(type, resolver)), 
        ///                                new InjectionProperty("Property", new InjectionParameter(type, resolver)));
        /// </example>
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void InjectionParameter_ByFactory_WithContract(string test, Type type, object defaultValue, object defaultAttr,
                                                                    object registered, object named, object injected, object overridden,
                                                                    object @default)
            => Assert_Injected(type, InjectionMember_Value(new InjectionParameter(type, new ValidatingResolverFactory(injected))), injected, injected);
#endif

        #endregion


        #region Target
        
        // TODO: Add OnType
        
        #endregion
    }
}
