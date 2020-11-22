﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated
{

    public abstract partial class Pattern
    {
#if BEHAVIOR_V4
        [ExpectedException(typeof(ResolutionFailedException))]
#endif
        [DataTestMethod]
        [DynamicData(nameof(Required_WithDefaults_Data))]
        public virtual void Required_FromEmpty_WithDefaults(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Expected, instance.Value);
        }


        [DataTestMethod]
        [DynamicData(nameof(Optional_WithDefaults_Data))]
        public virtual void Optional_FromEmpty_WithDefaults(string test, Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(instance.Expected, instance.Value);
        }



        [DataTestMethod]
        [DynamicData(nameof(Required_WithDefaults_Data))]
        public virtual void Required_Registered_WithDefaults(string test, Type type)
        {
            // Arrange
            RegisterTypes();

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(Container.Resolve(instance.Dependency, null), instance.Value);
        }


        [DataTestMethod]
        [DynamicData(nameof(Optional_WithDefaults_Data))]
        public virtual void Optional_Registered_WithDefaults(string test, Type type)
        {
            // Arrange
            RegisterTypes();

            // Act
            var instance = Container.Resolve(type, null) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);
            Assert.AreEqual(Container.Resolve(instance.Dependency, null), instance.Value);
        }
    }
}
