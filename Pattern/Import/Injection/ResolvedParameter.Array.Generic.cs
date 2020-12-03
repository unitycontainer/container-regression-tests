using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Import
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
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void GenericResolvedArrayParameter_ByValues(string test, Type type, object defaultValue, object defaultAttr,
                                                                   object registered, object named, object injected, object overridden, 
                                                                   object @default)
        {
            Assert_GenericArray(type,
                           InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, defaultValue, defaultAttr, registered, named, injected, overridden)),
                           new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void GenericResolvedArrayParameter_Complex(string test, Type type,
                                                                  object defaultValue, object defaultAttr,
                                                                  object registered, object named,
                                                                  object injected, object overridden, 
                                                                  object @default)
        {
            Container.RegisterInstance(type, defaultAttr);
            Container.RegisterInstance(type, "named", named);
            Container.RegisterInstance(type, "overridden", overridden);

            Assert_GenericArray(type, 
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, 
                    defaultValue,   new ResolvedParameter(type), 
                    registered, new GenericParameter(TDependency, "named"), 
                    injected,   new GenericParameter(TDependency, "overridden"))),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }
    }
}
