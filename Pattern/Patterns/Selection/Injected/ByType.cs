﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Selection.Injected
{
    public abstract partial class Pattern
    {
        [TestMethod("Select by Type (First)"), TestProperty(SELECTION, BY_TYPE)]
        public virtual void Select_ByType_First()
        {
            var target = BaselineTestType.MakeGenericType(TypesForward);

            // Arrange
            Container.RegisterType(target, InjectionMember_Value(TypesForward[0]));

            // Act
            var instance = Container.Resolve(target) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[1] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[0]);
        }

        [TestMethod("Select by Type (Second)"), TestProperty(SELECTION, BY_TYPE)]
        public virtual void Select_ByType_Second()
        {
            var target = BaselineTestType.MakeGenericType(TypesForward);

            // Arrange
            Container.RegisterInstance(Name)
                     .RegisterType(target, InjectionMember_Value(TypesForward[1]));

            // Act
            var instance = Container.Resolve(target) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[2] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[1]);
        }

        [TestMethod("Select by Type (Reversed)"), TestProperty(SELECTION, BY_TYPE)]
        public virtual void Select_ByType_Reversed()
        {
            var target = BaselineTestType.MakeGenericType(TypesReverse);

            // Arrange
            Container.RegisterInstance(Name)
                     .RegisterType(target, InjectionMember_Value(TypesForward[1]));

            // Act
            var instance = Container.Resolve(target) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[2] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[1]);
        }

        [TestMethod("Select by Type (First Two)"), TestProperty(SELECTION, BY_TYPE)]
        public virtual void Select_ByType_FirstTwo()
        {
            var target = BaselineTestType.MakeGenericType(TypesForward);

            // Arrange
            Container.RegisterInstance(Name)
                     .RegisterType(target, InjectionMember_Args(new[] { TypesForward[0], TypesForward[1] }));

            // Act
            var instance = Container.Resolve(target) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[4] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(2, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[0]);
            Assert.IsInstanceOfType(parameters[1], TypesForward[1]);
        }

    }
}
