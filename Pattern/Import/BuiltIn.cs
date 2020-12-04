using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import
{
    public abstract partial class Pattern
    {
        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Import_Array(string test, Type type, object defaultValue, object defaultAttr,
                                                                 object registered, object named,
                                                                 object injected, object overridden,
                                                                 object @default)
            => Assert_Array_Import(BaselineTestType.MakeGenericType(type.MakeArrayType()));


#if !BEHAVIOR_V4
        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Import_Enumerable(string test, Type type, object defaultValue, object defaultAttr, object registered,
                                       object named, object injected, object overridden, object @default)
            => Assert_Enumerable_Import(BaselineTestType.MakeGenericType(typeof(IEnumerable<>).MakeGenericType(type)));
#endif


        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Import_Lazy(string test, Type type, object defaultValue, object defaultAttr, object registered,
                                 object named, object injected, object overridden, object @default)
            => Assert_Lazy_Import(
                BaselineTestType.MakeGenericType(typeof(Lazy<>).MakeGenericType(type)), registered);


        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Import_Func(string test, Type type, object defaultValue, object defaultAttr, object registered,
                                 object named, object injected, object overridden, object @default)
            => Assert_Func_Import(
                BaselineTestType.MakeGenericType(typeof(Func<>).MakeGenericType(type)), registered);


        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(BuiltInTypes_Data), typeof(FixtureBase))]
        public virtual void Import_BuiltIn_Interface(string test, Type type)
            => Assert_ResolutionSuccess(BaselineTestType.MakeGenericType(type));


        [TestCategory(CATEGORY_IMPORT)]
        [DataTestMethod, DynamicData(nameof(BuiltInTypes_Data), typeof(FixtureBase))]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void Import_BuiltIn_Interface_Named(string test, Type type) 
            => _ = Container.Resolve(type, Name) as FixtureBaseType;
    }
}
