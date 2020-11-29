using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
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

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_Implicit_Values(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
        {
            TestGenericArrayImport(ImplicitArrayType, type,
                           InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, @default, defaultAttr, registered, named, injected, overridden)));
        }

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_Implicit_Complex(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
        {
            Container.RegisterInstance(type, defaultAttr);
            Container.RegisterInstance(type, "named", named);
            Container.RegisterInstance(type, "overridden", overridden);

            var instance = TestGenericArrayImport(ImplicitArrayType, type, 
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, 
                    @default,   new ResolvedParameter(type), 
                    registered, new GenericParameter(TDependency, "named"), 
                    injected,   new GenericParameter(TDependency, "overridden"))));

            Assert.IsTrue(instance.Contains(defaultAttr));
            Assert.IsTrue(instance.Contains(named));
            Assert.IsTrue(instance.Contains(overridden));
            Assert.IsTrue(instance.Contains(@default));
            Assert.IsTrue(instance.Contains(registered));
            Assert.IsTrue(instance.Contains(injected));
        }

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_ArrayNotation(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
        {
            Container.RegisterInstance(type, "@default",    @default);
            Container.RegisterInstance(type, "defaultAttr", defaultAttr);
            Container.RegisterInstance(type, "registered ", registered);
            Container.RegisterInstance(type, "named",       named);
            Container.RegisterInstance(type, "injected ",   injected);
            Container.RegisterInstance(type, "overridden",  overridden);

            var instance = TestGenericArrayImport(ImplicitArrayType, type, InjectionMember_Value(new GenericParameter(TDependency + "[]")));

            Assert.IsTrue(instance.Contains(defaultAttr));
            Assert.IsTrue(instance.Contains(named));
            Assert.IsTrue(instance.Contains(overridden));
            Assert.IsTrue(instance.Contains(@default));
            Assert.IsTrue(instance.Contains(registered));
            Assert.IsTrue(instance.Contains(injected));
        }

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_ParentnessNotation(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
        {
            Container.RegisterInstance(type, "default",     @default);
            Container.RegisterInstance(type, "defaultAttr", defaultAttr);
            Container.RegisterInstance(type, "registered ", registered );
            Container.RegisterInstance(type, "named",       named );
            Container.RegisterInstance(type, "injected",    injected );
            Container.RegisterInstance(type, "overridden",  overridden);

            var instance = TestGenericArrayImport(ImplicitArrayType, type, InjectionMember_Value(new GenericParameter(TDependency + "()")));

            Assert.IsTrue(instance.Contains(defaultAttr));
            Assert.IsTrue(instance.Contains(named));
            Assert.IsTrue(instance.Contains(overridden));
            Assert.IsTrue(instance.Contains(@default));
            Assert.IsTrue(instance.Contains(registered));
            Assert.IsTrue(instance.Contains(injected));
        }

        #endregion


        #region Required

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_Required(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
            => TestGenericArrayImport(RequiredArrayType, type,
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, @default, defaultAttr, registered, named, injected, overridden)));

        #endregion


        #region Optional

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(ImportBase))]
        public virtual void ByGenericResolvedArrayParameter_Optional(string test, Type type,
                                                                     object @default, object defaultAttr,
                                                                     object registered, object named,
                                                                     object injected, object overridden, bool isResolveble)
            => TestGenericArrayImport(OptionalArrayType, type,
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, @default, defaultAttr, registered, named, injected, overridden)));

        #endregion
    }
}
