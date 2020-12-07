﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Properties
{
    [TestClass]
    public partial class Injecting_Required_With_Optional : Injection.Required.Pattern
    {
        #region Properties

        protected override string DependencyName => "Property";

        #endregion


        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            ClassInitialize(context);

            Type support = Type.GetType($"{typeof(FixtureBase).FullName}+{Member}");

            if (support is null) return;

            // Override injectors with optional
            InjectionMember_Value = (Func<object, InjectionMember>)support
                .GetMethod("GetInjectionValueOptional").CreateDelegate(typeof(Func<object, InjectionMember>));

            InjectionMember_Default = (Func<InjectionMember>)support
                .GetMethod("GetInjectionDefaultOptional").CreateDelegate(typeof(Func<InjectionMember>));

            InjectionMember_Contract = (Func<Type, string, InjectionMember>)support
                .GetMethod("GetInjectionContractOptional").CreateDelegate(typeof(Func<Type, string, InjectionMember>));
        }

        #endregion
    }
}