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
        #region Fields
        
        Type _objectArrayType;

        #endregion


        [TestProperty(PARAMETER, nameof(GenericResolvedArrayParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void GenericResolvedArray_ByValues(string test, Type type, object defaultValue, object defaultAttr,
                                                                   object registered, object named, object injected, object overridden,
                                                                   object @default) 
            => Assert_Array_Import(BaselineArrayType, type,
                           InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, defaultValue, defaultAttr, registered, named, injected, overridden)),
                           new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });


        [TestProperty(PARAMETER, nameof(GenericResolvedArrayParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void GenericResolvedArray_Complex(string test, Type type,
                                                                  object defaultValue, object defaultAttr,
                                                                  object registered, object named,
                                                                  object injected, object overridden, 
                                                                  object @default)
        {
            Container.RegisterInstance(type, defaultAttr);
            Container.RegisterInstance(type, "named", named);
            Container.RegisterInstance(type, "overridden", overridden);

            var parameter = new GenericResolvedArrayParameter(TDependency,
                    defaultValue, new ResolvedParameter(type),
                    registered, new GenericParameter(TDependency, "named"),
                    injected, new GenericParameter(TDependency, "overridden"));

            Assert.AreEqual(TDependency + "[]", parameter.ParameterTypeName);
            Assert_Array_Import(BaselineArrayType, type, 
                InjectionMember_Value(parameter),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }


        [TestProperty(PARAMETER, nameof(GenericResolvedArrayParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
#if BEHAVIOR_V4
        [ExpectedException(typeof(InvalidOperationException))]
#else
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        public virtual void GenericResolvedArray_NoMatch(string test, Type type, object defaultValue, object defaultAttr,
                                                                   object registered, object named, object injected, object overridden,
                                                                   object @default)
            => Assert_Array_Import(BaselineArrayType, type,
                           InjectionMember_Value(new GenericResolvedArrayParameter("Dependency", defaultValue, defaultAttr, registered, named, injected, overridden)),
                           new object[0]);


        [TestProperty(PARAMETER, nameof(GenericResolvedArrayParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
#if BEHAVIOR_V4
        [ExpectedException(typeof(InvalidOperationException))]
#else
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        public virtual void GenericResolvedArray_NotArray(string test, Type type, object defaultValue, object defaultAttr,
                                                      object registered, object named, object injected, object overridden,
                                                      object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type),
                InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, defaultValue, defaultAttr, registered, named, injected, overridden)),
                named);


        [TestProperty(PARAMETER, nameof(GenericResolvedArrayParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
#if BEHAVIOR_V4
        [ExpectedException(typeof(InvalidOperationException))]
#else
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        public virtual void GenericResolvedArray_NotGeneric(string test, Type type, object defaultValue, object defaultAttr,
                                                            object registered, object named, object injected, object overridden,
                                                            object @default)
        {
            Assert_UnregisteredThrows_RegisteredSuccess(
                           _objectArrayType ??= GetTestType("ObjectArrayType"),
                           InjectionMember_Value(new GenericResolvedArrayParameter(TDependency, defaultValue, defaultAttr, registered, named, injected, overridden)),
                           named);
        }
    }
}
