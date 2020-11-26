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
    /// Container.RegisterType(target, new InjectionConstructor(new ResolvedArrayParameter(...)), 
    ///                                new InjectionMethod("Method", new ResolvedArrayParameter(...)) , 
    ///                                new InjectionField("Field", new ResolvedArrayParameter(...)), 
    ///                                new InjectionProperty("Property", new ResolvedArrayParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Implicit

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByResolvedArrayParameter_Implicit(string test, Type type, 
                                                              object @default, object defaultAttr, 
                                                              object registered, object named, 
                                                              object injected, object overridden, bool isResolveble)
            => TestArrayImport(ImplicitArrayType, type, 
                InjectionMember_Value(new ResolvedArrayParameter(type, @default, defaultAttr, registered, named, injected, overridden)));

        #endregion


        #region Required

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByResolvedArrayParameter_Required(string test, Type type,
                                                              object @default, object defaultAttr,
                                                              object registered, object named,
                                                              object injected, object overridden, bool isResolveble)
            => TestArrayImport(RequiredArrayType, type,
                InjectionMember_Value(new ResolvedArrayParameter(type, @default, defaultAttr, registered, named, injected, overridden)));

        #endregion


        #region Optional

        [DataTestMethod]
        [DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByResolvedArrayParameter_Optional(string test, Type type,
                                                              object @default, object defaultAttr,
                                                              object registered, object named,
                                                              object injected, object overridden, bool isResolveble)
            => TestArrayImport(OptionalArrayType, type,
                InjectionMember_Value(new ResolvedArrayParameter(type, @default, defaultAttr, registered, named, injected, overridden)));

        #endregion
    }
}
