using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
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
#if BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [TestCategory(INJECT_SUBCLASS)]
        [DataTestMethod, DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Inherited(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default)
        {
            // Setup
            var subclass = BaselineTestType.MakeGenericType(type);
            var target = GetTestType("BaselineTestInherited`1").MakeGenericType(type);

            RegisterTypes();

            Container.RegisterType(subclass, InjectionMember_Value(injected));
            Container.RegisterType(target, InjectionMember_Value(injected));

            // Subclass
            var instance = Container.Resolve(subclass, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(injected, instance.Value);

            // Superclass
            instance = Container.Resolve(target, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(injected, instance.Value);
        }
    }
}
