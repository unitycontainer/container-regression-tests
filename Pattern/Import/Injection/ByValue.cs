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
        [TestCategory(Category_Inject)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Inject_ByValue(string test, Type type,
                                           object defaultValue, object defaultAttr,
                                           object registered, object named,
                                           object injected, object overridden,
                                           object @default) 
            => Assert_Injected(BaselineTestType.MakeGenericType(type), 
                               InjectionMember_Value(injected), 
                               injected, injected);

#if !BEHAVIOR_V4 && !BEHAVIOR_V5
        [TestCategory(Category_Inject)]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Inject_ByValue_Array(string test, Type type, object defaultValue, object defaultAttr,
                                                                 object registered, object named,
                                                                 object injected, object overridden,
                                                                 object @default)
        {
            var instance = (object[])Array.CreateInstance(type, 1);
            var member = InjectionMember_Value(injected);
            instance[0] = @default;

            Assert_Array_Import(BaselineArrayType.MakeGenericType(type),
                                member, instance);

            Assert_Injected(BaselineArrayType.MakeGenericType(type),
                            member, instance, instance);

        }
#endif
    }
}
