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
        
        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Dependency_Data))]
        public void Resolve_Root_Children_Type_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Dependency_Data))]
        public void Resolve_Root_Children_Type_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Dependency_Data))]
        public void Resolve_Children_Root_Type_Siblings(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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


        [PatternTestMethod(PATTERN_NAME_FORMAT), TestProperty(RESOLVING, REGISTERED_IN_ROOT)]
        [DynamicData(nameof(Hierarchy_Dependency_Data))]
        public void Resolve_Children_Root_Type_Hierarchical(string name, Type type, Func<LifetimeManager> factory, params AssertResolutionDelegate[] methods)
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

        public static IEnumerable<object[]> Hierarchy_Dependency_Data
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
                        (AssertResolutionDelegate)TTypes1_From_Root,
                        (AssertResolutionDelegate)TType2_From_Root,
                        (AssertResolutionDelegate)TTypes1_AreSame
                    };

                    #endregion

                    #region ContainerControlledTransientManager

                    yield return new object[]
                    {
                        typeof(ContainerControlledTransientManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new ContainerControlledTransientManager()),
                        (AssertResolutionDelegate)TType1_From_Resolved,
                        (AssertResolutionDelegate)TType2_From_Resolved,
                        (AssertResolutionDelegate)TTypes1_AreNotSame
                    };

                    #endregion

                    #region ExternallyControlledLifetimeManager

                    yield return new object[]
                    {
                        typeof(ExternallyControlledLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new ExternallyControlledLifetimeManager()),
                        (AssertResolutionDelegate)TTypes1_From_Root,
                        (AssertResolutionDelegate)TType2_From_Root,
                        (AssertResolutionDelegate)TTypes1_AreSame
                    };

                    #endregion

                    #region HierarchicalLifetimeManager

                    yield return new object[]
                    {
                        typeof(HierarchicalLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new HierarchicalLifetimeManager()),
                        (AssertResolutionDelegate)TType1_From_Resolved,
                        (AssertResolutionDelegate)TType2_From_Resolved,
                        (AssertResolutionDelegate)TTypes1_AreNotSame
                    };

                    #endregion

                    #region PerThreadLifetimeManager

                    yield return new object[]
                    {
                        typeof(PerThreadLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new PerThreadLifetimeManager()),
                        (AssertResolutionDelegate)TTypes1_From_Root,
                        (AssertResolutionDelegate)TType2_From_Root,
                        (AssertResolutionDelegate)TTypes1_AreSame
                    };

                    #endregion

                    #region TransientLifetimeManager

                    yield return new object[]
                    {
                        typeof(TransientLifetimeManager).Name,
                        definition,                 // Test type
                        (Func<LifetimeManager>)(() => new TransientLifetimeManager()),
                        (AssertResolutionDelegate)TTypes1_From_Root,
                        (AssertResolutionDelegate)TType2_From_Root,
                        (AssertResolutionDelegate)Items_AreNotSame
                    };

                    #endregion
                }
            }
        }

        #endregion
    }
}
