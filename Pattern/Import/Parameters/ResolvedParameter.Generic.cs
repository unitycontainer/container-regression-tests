﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    /// Container.RegisterType(target, new InjectionConstructor(new GenericParameter(...)), 
    ///                                new InjectionMethod("Method", new GenericParameter(...)) , 
    ///                                new InjectionField("Field", new GenericParameter(...)), 
    ///                                new InjectionProperty("Property", new GenericParameter(...)));
    /// </example>
    public abstract partial class Pattern
    {
        #region Default
#if !UNITY_V4
        //[TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Generic_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                     object registered, object named, object injected, object overridden, 
                                                     object @default)
            => Assert_InjectedGeneric(type, InjectionMember_Value(new GenericParameter(TDependency)), registered);


        //[TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Generic_Default_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                             object registered, object named, object injected, object overridden, 
                                                             object @default)
            => Assert_InjectNamedGeneric(type, InjectionMember_Value(new GenericParameter(TDependency)), registered);
#endif
        #endregion


        #region Name

        //[TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Generic_WithName(string test, Type type, object defaultValue, object defaultAttr,
                                                      object registered, object named, object injected, object overridden, 
                                                      object @default)
            => Assert_InjectedGeneric(type, InjectionMember_Value(new GenericParameter(TDependency, Name)), named);


        //[TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Generic_WithName_OnNamed(string test, Type type, object defaultValue, object defaultAttr,
                                                              object registered, object named, object injected, object overridden, 
                                                              object @default)
            => Assert_InjectNamedGeneric(type, InjectionMember_Value(new GenericParameter(TDependency, (string)null)), registered);

        #endregion


        #region Array

        //[TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Generic_ArrayNotation(string test, Type type, object defaultValue, object defaultAttr,
                                                           object registered, object named, object injected, object overridden,
                                                           object @default)
        {
            Container.RegisterInstance(type, "default",     defaultValue);
            Container.RegisterInstance(type, "defaultAttr", defaultAttr);
            Container.RegisterInstance(type, "registered ", registered);
            Container.RegisterInstance(type, "named",       named);
            Container.RegisterInstance(type, "injected ",   injected);
            Container.RegisterInstance(type, "overridden",  overridden);

            Assert_Array_Import(BaselineArrayType, type, 
                InjectionMember_Value(new GenericParameter(TDependency + "[]")),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }

        //[TestProperty(PARAMETER, nameof(GenericParameter))]
        [DataTestMethod, DynamicData(nameof(Import_Test_Data), typeof(Pattern))]
        public virtual void Generic_ParentnessNotation(string test, Type type, object defaultValue, object defaultAttr,
                                                                object registered, object named, object injected, object overridden, 
                                                                object @default)
        {
            Container.RegisterInstance(type, "default",     defaultValue);
            Container.RegisterInstance(type, "defaultAttr", defaultAttr);
            Container.RegisterInstance(type, "registered ", registered);
            Container.RegisterInstance(type, "named",       named);
            Container.RegisterInstance(type, "injected",    injected);
            Container.RegisterInstance(type, "overridden",  overridden);

            Assert_Array_Import(BaselineArrayType, type, 
                InjectionMember_Value(new GenericParameter(TDependency + "()")),
                new object[] { defaultValue, defaultAttr, registered, named, injected, overridden });
        }

        #endregion
    }
}
