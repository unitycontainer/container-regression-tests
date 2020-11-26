using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Import.Injected
{
    /// <summary>
    /// Tests injecting dependencies with InjectionParameter
    /// </summary>
    /// <example>
    /// Container.RegisterType(target, new InjectionConstructor(new GenericResolvedArrayParameter(...)), 
    ///                                new InjectionMethod("Method", new GenericResolvedArrayParameter(...)) , 
    ///                                new InjectionField("Field", new GenericResolvedArrayParameter(...)), 
    ///                                new InjectionProperty("Property", new GenericResolvedArrayParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_Implicit(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
            => TestGenericArrayImport(ImplicitArrayType, type,
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, @default, defaultAttr, registered, named, injected, overridden)));

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_ArrayNotation(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
            => TestGenericArrayImport(ImplicitArrayType, type,
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency + "[]" , @default, defaultAttr, registered, named, injected, overridden)));

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_Required(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
            => TestGenericArrayImport(RequiredArrayType, type,
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, @default, defaultAttr, registered, named, injected, overridden)));

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_Optional(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
            => TestGenericArrayImport(OptionalArrayType, type,
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, @default, defaultAttr, registered, named, injected, overridden)));

        #endregion
    }
}
