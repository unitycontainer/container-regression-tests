using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        #region Constants

        const string IMPORT_IN_ROOT_XXX = "Import in root then in child ({3})";
        const string IMPORT_IN_CHILD_XXX = "Import in child then in root ({3})";

        #endregion


        #region Registered Singleton

        [TestMethod(SINGLETON_IN_ROOT_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InRootContainer_Singleton_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [TestMethod(SINGLETON_IN_ROOT_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InRootContainer_Singleton_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [TestMethod(SINGLETON_IN_CHILD_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InChildContainer_Singleton_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [TestMethod(SINGLETON_IN_CHILD_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InChildContainer_Singleton_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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

        [PatternTestMethod(IMPORT_IN_ROOT_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InRootContainer_Import_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [PatternTestMethod(IMPORT_IN_ROOT_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InRootContainer_Import_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [PatternTestMethod(IMPORT_IN_ROOT_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, "Unregistered")]
        public void Singleton_Service_Unregistered_Resolvable(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(SingletonService), typeof(IUnityContainer));

            var child1 = Container.CreateChildContainer();
            var child2 = child1.CreateChildContainer();

            var instance_from_root = Container.Resolve(target) as FixtureBaseType;
            var instanceFromChild1 = child1.Resolve(target) as FixtureBaseType;
            var instanceFromChild2 = child2.Resolve(target) as FixtureBaseType;

            Default_From_Resolved(Container, instance_from_root,
                                     child1, instanceFromChild1,
                                     child2, instanceFromChild2);

            Values_AreNotSame(Container, instance_from_root,
                                 child1, instanceFromChild1,
                                 child2, instanceFromChild2);
        }


        [PatternTestMethod(IMPORT_IN_CHILD_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InChildContainer_Import_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [PatternTestMethod(IMPORT_IN_CHILD_XXX)]
        [DynamicData(nameof(Hierarchy_Import_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InChildContainer_Import_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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
                }
            }
        }

        #endregion
    }
}
