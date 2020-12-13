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
        #region Direct

        [TestMethod(DIRECTLY_IN_ROOT_XXX)]
        [DynamicData(nameof(Hierarchy_Direct_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InRootContainer_Directly_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(IUnityContainer), typeof(IUnityContainer));
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


        [TestMethod(DIRECTLY_IN_ROOT_XXX)]
        [DynamicData(nameof(Hierarchy_Direct_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InRootContainer_Directly_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(IUnityContainer), typeof(IUnityContainer));
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


        [TestMethod(DIRECTLY_IN_CHILD_XXX)]
        [DynamicData(nameof(Hierarchy_Direct_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InChildContainer_Directly_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(IUnityContainer), typeof(IUnityContainer));
            Container.RegisterType(target, (ITypeLifetimeManager)factory());

            var child1 = Container.CreateChildContainer();
            var child2 = Container.CreateChildContainer();

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


        [TestMethod(DIRECTLY_IN_CHILD_XXX)]
        [DynamicData(nameof(Hierarchy_Direct_Data)), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        public void Root_InChildContainer_Directly_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
        {
            var target = type.MakeGenericType(typeof(IUnityContainer), typeof(IUnityContainer));
            Container.RegisterType(target, (ITypeLifetimeManager)factory());

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


        #region Test Data

        public static IEnumerable<object[]> Hierarchy_Direct_Data
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
                        (AssertResolutionDelegate)Value_From_Resolved,
                        (AssertResolutionDelegate)Default_From_Resolved,
                        (AssertResolutionDelegate)Values_AreNotSame
                    };

                    #endregion

                    #region ContainerControlledLifetimeManager

                    yield return new object[]
                    {
                        typeof(ContainerControlledLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new ContainerControlledLifetimeManager()),
                        (AssertResolutionDelegate)Value_From_Root,
                        (AssertResolutionDelegate)Default_From_Root,
                        (AssertResolutionDelegate)Values_AreSame
                    };

                    #endregion
                }
            }
        }

        #endregion
    }
}
