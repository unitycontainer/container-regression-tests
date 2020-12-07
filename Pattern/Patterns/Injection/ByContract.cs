using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Injection
{
    public abstract partial class Pattern
    {
        [TestCategory(CATEGORY_INJECT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Inject_Default(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestType.MakeGenericType(type),
                InjectionMember_Default(), registered);


        [TestCategory(CATEGORY_INJECT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Inject_Named_Default(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default)
            => Assert_UnregisteredThrows_RegisteredSuccess(
                BaselineTestNamed.MakeGenericType(type),
                InjectionMember_Default(), named);


        [TestCategory(CATEGORY_INJECT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Inject_ByTypeNull(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default) 
            => Assert_UnregisteredThrows_RegisteredSuccess(
                   BaselineTestType.MakeGenericType(type),
                   InjectionMember_Contract(type, null), registered);


        [TestCategory(CATEGORY_INJECT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Inject_Named_ByTypeNull(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default) 
            => Assert_UnregisteredThrows_RegisteredSuccess(
                   BaselineTestNamed.MakeGenericType(type),
                   InjectionMember_Contract(type, null), registered);


        [TestCategory(CATEGORY_INJECT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Inject_ByTypeName(string test, Type type, object defaultValue, object defaultAttr,
                                              object registered, object named, object injected, object overridden,
                                              object @default) 
            => Assert_UnregisteredThrows_RegisteredSuccess(
                   BaselineTestType.MakeGenericType(type),
                   InjectionMember_Contract(type, Name), named);


        [TestCategory(CATEGORY_INJECT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data))]
        public virtual void Inject_Named_ByTypeName(string test, Type type, object defaultValue, object defaultAttr,
                                              object registered, object named, object injected, object overridden,
                                              object @default) 
            => Assert_UnregisteredThrows_RegisteredSuccess(
                   BaselineTestNamed.MakeGenericType(type),
                   InjectionMember_Contract(type, Name), named);
    }
}
