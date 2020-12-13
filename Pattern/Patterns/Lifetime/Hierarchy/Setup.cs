using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Lifetime.Hierarchies
{
    public abstract partial class Pattern : Lifetime.Pattern
    {
        #region Constants

        protected const string REGISTERED_IN_ROOT  = "Registered In Root";
        protected const string REGISTERED_IN_CHILD = "Registered In Child";

        protected const string DIRECTLY_IN_ROOT_XXX = "Resolve in root than in child containers";
        protected const string DIRECTLY_IN_CHILD_XXX = "Resolve in child than in root & child containers";

        protected const string SINGLETON_IN_ROOT_XXX = "Registered singleton in root then in child containers";
        protected const string SINGLETON_IN_CHILD_XXX = "Registered singleton in child then in root containers";
        protected const string SINGLETON_IN_SAME_XXX = "Registered singleton in child then in child container";

        #endregion


        #region Delegates

        public delegate void AssertResolutionDelegate(IUnityContainer root, FixtureBaseType fromRoot,
                                                      IUnityContainer child1, FixtureBaseType fromChild1,
                                                      IUnityContainer child2, FixtureBaseType fromChild2);
        #endregion


        #region Default

        public static void Default_From_Root(IUnityContainer root,   FixtureBaseType instance,
                                             IUnityContainer child1, FixtureBaseType instance1,
                                             IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreSame(root, instance.Default,  $"{nameof(instance)} should be created in root container");
            Assert.AreSame(root, instance1.Default, $"{nameof(instance1)} should be created in root container");
            Assert.AreSame(root, instance2.Default, $"{nameof(instance2)} should be created in root container");
        }

        public static void Default_From_Resolved(IUnityContainer root, FixtureBaseType instance,
                                                 IUnityContainer child1, FixtureBaseType instance1,
                                                 IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreSame(root,   instance.Default,  $"{nameof(instance)} should be created in root container");
            Assert.AreSame(child1, instance1.Default, $"{nameof(instance1)} should be created in child1 container");
            Assert.AreSame(child2, instance2.Default, $"{nameof(instance2)} should be created in child2 container");
        }

        public static void Defaults_AreSame(IUnityContainer root, FixtureBaseType instance,
                                            IUnityContainer child1, FixtureBaseType instance1,
                                            IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreSame(instance.Default, instance1.Default, $"{nameof(instance1)}.Default should be same as {nameof(instance)}.Default");
            Assert.AreSame(instance.Default, instance2.Default, $"{nameof(instance2)}.Default should be same as {nameof(instance)}.Default");
        }

        public static void Defaults_AreNotSame(IUnityContainer root, FixtureBaseType instance,
                                               IUnityContainer child1, FixtureBaseType instance1,
                                               IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreNotSame(instance.Default, instance1.Default, $"{nameof(instance1)}.Default should not be the same as {nameof(instance)}.Default");
            Assert.AreNotSame(instance.Default, instance2.Default, $"{nameof(instance2)}.Default should not be the same as {nameof(instance)}.Default");
            Assert.AreNotSame(instance1.Default, instance2.Default, $"{nameof(instance2)}.Default should not be the same as {nameof(instance1)}.Default");
        }

        #endregion

        
        #region Value

        public static void Value_From_Root(IUnityContainer root, FixtureBaseType instance,
                                           IUnityContainer child1, FixtureBaseType instance1,
                                           IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreSame(root, instance.Value,  $"{nameof(instance)} should be created in root container");
            Assert.AreSame(root, instance1.Value, $"{nameof(instance1)} should be created in root container");
            Assert.AreSame(root, instance2.Value, $"{nameof(instance2)} should be created in root container");
        }

        public static void Value_From_Resolved(IUnityContainer root, FixtureBaseType instance,
                                               IUnityContainer child1, FixtureBaseType instance1,
                                               IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreSame(root, instance.Value, $"{nameof(instance)} should be created in root container");
            Assert.AreSame(child1, instance1.Value, $"{nameof(instance1)} should be created in child1 container");
            Assert.AreSame(child2, instance2.Value, $"{nameof(instance2)} should be created in child2 container");
        }

        public static void Values_AreSame(IUnityContainer root, FixtureBaseType instance,
                                          IUnityContainer child1, FixtureBaseType instance1,
                                          IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreSame(instance.Value, instance1.Value, $"{nameof(instance1)}.Value should be same as {nameof(instance)}.Value");
            Assert.AreSame(instance.Value, instance2.Value, $"{nameof(instance2)}.Value should be same as {nameof(instance)}.Value");
        }

        public static void Values_AreNotSame(IUnityContainer root, FixtureBaseType instance,
                                             IUnityContainer child1, FixtureBaseType instance1,
                                             IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreNotSame(instance.Value, instance1.Value, $"{nameof(instance1)}.Value should not be the same as {nameof(instance)}.Value");
            Assert.AreNotSame(instance.Value, instance2.Value, $"{nameof(instance2)}.Value should not be the same as {nameof(instance)}.Value");
            Assert.AreNotSame(instance1.Value, instance2.Value, $"{nameof(instance2)}.Value should not be the same as {nameof(instance1)}.Value");
        }

        #endregion


        #region Import

        public static void Import_From_Root(IUnityContainer root, FixtureBaseType instance,
                                             IUnityContainer child1, FixtureBaseType instance1,
                                             IUnityContainer child2, FixtureBaseType instance2)
        {
            var host  = (instance.Value  as FixtureBaseType).Default;
            var host1 = (instance1.Value as FixtureBaseType).Default;
            var host2 = (instance2.Value as FixtureBaseType).Default;

            Assert.AreSame(root, host,  $"{nameof(instance)} should be created in root container");
            Assert.AreSame(root, host1, $"{nameof(instance1)} should be created in root container");
            Assert.AreSame(root, host2, $"{nameof(instance2)} should be created in root container");
        }
         
        public static void Import_From_Resolved(IUnityContainer root, FixtureBaseType instance,
                                                   IUnityContainer child1, FixtureBaseType instance1,
                                                   IUnityContainer child2, FixtureBaseType instance2)
        {
            var host = (instance.Value as FixtureBaseType).Default;
            var host1 = (instance1.Value as FixtureBaseType).Default;
            var host2 = (instance2.Value as FixtureBaseType).Default;

            Assert.AreSame(root,   host,  $"{nameof(instance)} should be created in root container");
            Assert.AreSame(child1, host1, $"{nameof(instance1)} should be created in child1 container");
            Assert.AreSame(child2, host2, $"{nameof(instance2)} should be created in child2 container");
        }

        public static void Imports_AreSame(IUnityContainer root, FixtureBaseType instance,
                                             IUnityContainer child1, FixtureBaseType instance1,
                                             IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreSame(instance.Value, instance1.Value, $"{nameof(instance1)}.Value should be same as {nameof(instance)}.Value");
            Assert.AreSame(instance.Value, instance2.Value, $"{nameof(instance2)}.Value should be same as {nameof(instance)}.Value");
        }

        public static void Imports_AreNotSame(IUnityContainer root, FixtureBaseType instance,
                                                IUnityContainer child1, FixtureBaseType instance1,
                                                IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreNotSame(instance.Value, instance1.Value, $"{nameof(instance1)}.Value should not be the same as {nameof(instance)}.Value");
            Assert.AreNotSame(instance.Value, instance2.Value, $"{nameof(instance2)}.Value should not be the same as {nameof(instance)}.Value");
            Assert.AreNotSame(instance1.Value, instance2.Value, $"{nameof(instance2)}.Value should not be the same as {nameof(instance1)}.Value");
        }

        #endregion


        #region Middle

        public static void Import_From_Middle(IUnityContainer root, FixtureBaseType instance,
                                              IUnityContainer child1, FixtureBaseType instance1,
                                              IUnityContainer child2, FixtureBaseType instance2)
        {
            var host = (instance.Value as FixtureBaseType).Default;
            var host1 = (instance1.Value as FixtureBaseType).Default;
            var host2 = (instance2.Value as FixtureBaseType).Default;

            Assert.AreSame(root, host, $"{nameof(instance)} should be created in root container");
            Assert.AreSame(host1, host2, $"{nameof(instance2)} should not be created in child1 container");

            Assert.AreNotSame(root, host1, $"{nameof(instance1)} should not be created in root container");
            Assert.AreNotSame(root, host2, $"{nameof(instance2)} should not be created in root container");
        }

        public static void Singleton_From_Middle(IUnityContainer root, FixtureBaseType instance,
                                                 IUnityContainer child1, FixtureBaseType instance1,
                                                 IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreNotSame(instance.Value, instance1.Value, $"{nameof(instance1)}.Value should not be the same as {nameof(instance)}.Value");
            Assert.AreNotSame(instance.Value, instance2.Value, $"{nameof(instance2)}.Value should not be the same as {nameof(instance)}.Value");
            Assert.AreSame(instance1.Value, instance2.Value, $"{nameof(instance2)}.Value should be same as {nameof(instance1)}.Value");
        }

        public static void Middle_AreNotSame(IUnityContainer root, FixtureBaseType instance,
                                                IUnityContainer child1, FixtureBaseType instance1,
                                                IUnityContainer child2, FixtureBaseType instance2)
        {
            Assert.AreNotSame(instance1.Value, instance2.Value, $"{nameof(instance2)}.Value should not be the same as {nameof(instance1)}.Value");
        }

        #endregion


        #region Test Data

        class SingletonService : FixtureBaseType, IDisposable
        {
            public SingletonService(IUnityContainer container)
            {
                Default = container;
                Value = container.GetHashCode();
            }

            public bool IsDisposed { get; private set; }
            public void Dispose() => IsDisposed = true;
        }

        #endregion

    }
}
