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
    public partial class Mapping : FixtureBase
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) => ClassInitialize(context);

        #endregion


        #region Test Data

        public interface IFoo<TEntity>
        {
            TEntity Value { get; }
        }

        public interface IFoo1<TEntity>
        {
            TEntity Value { get; }
        }

        public interface IFoo2<TEntity>
        {
            TEntity Value { get; }
        }

        public class Foo<TEntity> : IFoo<TEntity>, IFoo1<TEntity>, IFoo2<TEntity>
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

        public interface IService { }

        public interface IService1 { }
        
        public interface IService2 { }

        public class Service : IService, IService1, IService2, IDisposable
        {
            public string Id { get; } = Guid.NewGuid().ToString();

            public static int Instances;

            public Service()
            {
                Interlocked.Increment(ref Instances);
            }

            public bool Disposed;
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


            public bool Disposed;
            public void Dispose()
            {
                Disposed = true;
            }
        }

        #endregion
    }
}
