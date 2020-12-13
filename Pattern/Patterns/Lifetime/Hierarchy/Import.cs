﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Lifetime.Hierarchies
{
    public abstract partial class Pattern
    {
        #region Registered Singleton

        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Root_Children_Singleton_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            Container.RegisterType(typeof(SingletonService), (ITypeLifetimeManager)factory());

            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));
            var child1 = Container.CreateChildContainer();
            var child2 = Container.CreateChildContainer();

            var instance_from_root = Container.Resolve(target) as FixtureBaseType;
            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;

            foreach (var assert in methods)
            {
                assert(Container, instance_from_root,
                          child1, instanceFromChild1,
                          child2, instanceFromChild2);
            }
        }


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Root_Children_Singleton_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            Container.RegisterType(typeof(SingletonService), (ITypeLifetimeManager)factory());

            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));
            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            var instance_from_root = Container.Resolve(target) as FixtureBaseType;
            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;

            foreach (var assert in methods)
            {
                assert(Container, instance_from_root,
                          child1, instanceFromChild1,
                          child2, instanceFromChild2);
            }
        }


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Children_Root_Singleton_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            Container.RegisterType(typeof(SingletonService), (ITypeLifetimeManager)factory());

            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));
            var child1 = Container.CreateChildContainer();
            var child2 = Container.CreateChildContainer();

            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;
            var instance_from_root = Container.Resolve(target) as FixtureBaseType;

            foreach (var assert in methods)
            {
                assert(Container, instance_from_root,
                          child1, instanceFromChild1,
                          child2, instanceFromChild2);
            }
        }


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Children_Root_Singleton_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            Container.RegisterType(typeof(SingletonService), (ITypeLifetimeManager)factory());

            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));
            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instance_from_root = Container.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;

            foreach (var assert in methods)
            {
                assert(Container, instance_from_root,
                          child1, instanceFromChild1,
                          child2, instanceFromChild2);
            }
        }

        #endregion


        #region Unregistered Import

        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Root_Children_Import_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));
            Container.RegisterType(target, (ITypeLifetimeManager)factory());

            var child1 = Container.CreateChildContainer();
            var child2 = Container.CreateChildContainer();

            var instance_from_root = Container.Resolve(target) as FixtureBaseType;
            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;

            foreach (var assert in methods)
            {
                assert(Container, instance_from_root,
                          child1, instanceFromChild1,
                          child2, instanceFromChild2);
            }
        }


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Root_Children_Import_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));
            Container.RegisterType(target, (ITypeLifetimeManager)factory());

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            var instance_from_root = Container.Resolve(target) as FixtureBaseType;
            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;

            foreach (var assert in methods)
            {
                assert(Container, instance_from_root,
                          child1, instanceFromChild1,
                          child2, instanceFromChild2);
            }
        }


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, "Unregistered")]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Root_Children_Service_Resolvable(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            var instance_from_root = Container.Resolve(target) as FixtureBaseType;
            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;

            var service  = instance_from_root.Value as SingletonService;
            var service1 = instanceFromChild1.Value as SingletonService;
            var service2 = instanceFromChild2.Value as SingletonService;

            TType2_From_Resolved(Container, instance_from_root,
                                    child1, instanceFromChild1,
                                    child2, instanceFromChild2);

            Assert.AreSame(Container, service.Default);
            Assert.AreSame(child1,   service1.Default);
            Assert.AreSame(child2,   service2.Default);

            Assert.AreNotSame(service, service1);
            Assert.AreNotSame(service, service2);
            Assert.AreNotSame(service1, service2);
            
            Assert.AreNotSame(instance_from_root, instanceFromChild1);
            Assert.AreNotSame(instance_from_root, instanceFromChild2);
            Assert.AreNotSame(instanceFromChild1, instanceFromChild2);
        }


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Children_Root_Import_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));
            Container.RegisterType(target, (ITypeLifetimeManager)factory());

            var child1 = Container.CreateChildContainer();
            var child2 = Container.CreateChildContainer();

            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;
            var instance_from_root = Container.Resolve(target) as FixtureBaseType;

            foreach (var assert in methods)
            {
                assert(Container, instance_from_root,
                          child1, instanceFromChild1,
                          child2, instanceFromChild2);
            }
        }


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Import_Data))]
        public void Resolve_Children_Root_Import_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));
            Container.RegisterType(target, (ITypeLifetimeManager)factory());

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;
            var instance_from_root = Container.Resolve(target) as FixtureBaseType;

            foreach (var assert in methods)
            {
                assert(Container, instance_from_root,
                          child1, instanceFromChild1,
                          child2, instanceFromChild2);
            }
        }

        #endregion


        #region Test Data

        public static IEnumerable<object[]> Hierarchy_Import_Data
        {
            get
            {
                foreach (var member in MemberInfo_Namespace_Names)
                {
                    var definition = GetTestType("BaselineTestType`2", IMPORT_REQUIRED, member);

                    #region ContainerControlledLifetimeManager

                    yield return new object[]
                    {
                        typeof(ContainerControlledLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new ContainerControlledLifetimeManager()),
                        (AssertResolutionDelegate)Import_From_Root,
                        (AssertResolutionDelegate)Imports_AreSame
                    };

                    #endregion

                    #region ContainerControlledTransientManager

                    yield return new object[]
                    {
                        typeof(ContainerControlledTransientManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new ContainerControlledTransientManager()),
                        (AssertResolutionDelegate)Import_From_Resolved,
                        (AssertResolutionDelegate)Imports_AreNotSame
                    };

                    #endregion

                    #region ExternallyControlledLifetimeManager

                    yield return new object[]
                    {
                        typeof(ExternallyControlledLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new ExternallyControlledLifetimeManager()),
                        (AssertResolutionDelegate)Import_From_Root,
                        (AssertResolutionDelegate)Imports_AreSame
                    };

                    #endregion

                    #region HierarchicalLifetimeManager

                    yield return new object[]
                    {
                        typeof(HierarchicalLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new HierarchicalLifetimeManager()),
                        (AssertResolutionDelegate)Import_From_Resolved,
                        (AssertResolutionDelegate)Imports_AreNotSame
                    };

                    #endregion

                    #region PerThreadLifetimeManager

                    yield return new object[]
                    {
                        typeof(PerThreadLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new PerThreadLifetimeManager()),
                        (AssertResolutionDelegate)Import_From_Root,
                        (AssertResolutionDelegate)Imports_AreSame
                    };

                    #endregion

                    #region TransientLifetimeManager

                    yield return new object[]
                    {
                        typeof(TransientLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new TransientLifetimeManager()),
                        (AssertResolutionDelegate)Import_From_Root,
                        (AssertResolutionDelegate)Imports_AreNotSame
                    };

                    #endregion
                }
            }
        }

        #endregion
    }
}
