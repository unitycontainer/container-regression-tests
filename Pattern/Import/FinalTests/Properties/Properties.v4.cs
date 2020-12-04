using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Import.Properties
{
    public partial class Optional
    {
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Import.Pattern))]
        public override void ResolvedGeneric_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected,
                                           object overridden, object @default)
        {
            var target = _resolvedTestType ??= GetTestType("ObjectTestType");

            Assert.ThrowsException<ArgumentNullException>(()
                => Container.RegisterType(null, target, null, null, InjectionMember_Value(new GenericParameter(TDependency))));
        }

        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Import.Pattern))]
        public override void OptionalGeneric_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected,
                                           object overridden, object @default)
        {
            var target = _optionalTestType ??= GetTestType("ObjectTestType");

            Assert.ThrowsException<ArgumentNullException>(()
                => Container.RegisterType(null, target, null, null, InjectionMember_Value(new OptionalGenericParameter(TDependency))));
        }

    }

    public partial class Required
    {
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Import.Pattern))]
        public override void ResolvedGeneric_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected,
                                           object overridden, object @default)
        {
            var target = _resolvedTestType ??= GetTestType("ObjectTestType");

            Assert.ThrowsException<ArgumentNullException>(()
                => Container.RegisterType(null, target, null, null, InjectionMember_Value(new GenericParameter(TDependency))));
        }


        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Import.Pattern))]
        public override void OptionalGeneric_Incompatible(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected,
                                           object overridden, object @default)
        {
            var target = _optionalTestType ??= GetTestType("ObjectTestType");

            Assert.ThrowsException<ArgumentNullException>(()
                => Container.RegisterType(null, target, null, null, InjectionMember_Value(new OptionalGenericParameter(TDependency))));
        }
    }
}
