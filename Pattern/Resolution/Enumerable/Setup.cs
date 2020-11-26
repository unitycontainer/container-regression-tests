using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Threading;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Resolution
{
    [TestClass]
    public partial class Enumerables : FixtureBase
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion


        #region Test Data

        public interface IService
        {
        }

        public class Service : IService, IDisposable
        {
            public string ID { get; } = Guid.NewGuid().ToString();

            public static int Instances = 0;

            public Service()
            {
                Interlocked.Increment(ref Instances);
            }

            public bool Disposed = false;
            public void Dispose()
            {
                Disposed = true;
            }
        }

        public class OtherService : IService, IDisposable
        {
            [InjectionConstructor]
            public OtherService()
            {

            }

            public OtherService(IUnityContainer container)
            {

            }


            public bool Disposed = false;
            public void Dispose()
            {
                Disposed = true;
            }
        }

        public interface IFoo<TEntity>
        {
            TEntity Value { get; }
        }

        public class Foo<TEntity> : IFoo<TEntity>
        {
            public Foo()
            {
            }

            public Foo(TEntity value)
            {
                Value = value;
            }

            public TEntity Value { get; }
        }

        public interface IConstrained<TEntity>
            where TEntity : IService
        {
            TEntity Value { get; }
        }

        public class Constrained<TEntity> : IConstrained<TEntity>
            where TEntity : Service
        {
            public Constrained()
            {
            }

            public Constrained(TEntity value)
            {
                Value = value;
            }

            public TEntity Value { get; }
        }


        #endregion
    }
}
