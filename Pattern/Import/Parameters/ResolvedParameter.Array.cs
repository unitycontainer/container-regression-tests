using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Import
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
        //[TestProperty(PARAMETER, nameof(ResolvedArrayParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedArray_ByValue(string test, Type type, object defaultValue, object defaultAttr,
                                                object registered, object named, object injected, object overridden, 
                                                object @default)
            => Assert_Array_Import(BaselineArrayType.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedArrayParameter(type, defaultValue, defaultAttr, registered, named, injected, overridden)),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });


#if !UNITY_V4
        //[TestProperty(PARAMETER, nameof(ResolvedArrayParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void ResolvedArray_Complex(string test, Type type, object defaultValue, object defaultAttr,
                                                 object registered, object named, object injected, object overridden, object @default)
            => Assert_Array_Import(BaselineArrayType.MakeGenericType(type), 
                InjectionMember_Value(new ResolvedArrayParameter(type, new InjectionParameter(type, defaultValue), 
                                                                       new InjectionParameter(defaultAttr), 
                                                                       new ResolvedParameter(type), new OptionalParameter(type, Name), 
                                                                       new ValidatingResolver(injected), new ValidatingResolverFactory(overridden))),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
#endif
    }
}
