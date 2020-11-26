using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections;
using System.Threading;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Resolution
{
    [TestClass]
    public partial class Generics : FixtureBase
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
        }

        public class Foo<TEntity> : IFoo<TEntity>
        {
        }
        public class ServiceFoo : IFoo<Service>
        { 
        
        }

        public class Refer<TEntity>
        {
            private string str;

            public string Str
            {
                get { return str; }
                set { str = value; }
            }

            public Refer()
            {
                str = "Hello";
            }
        }

        public interface IService
        {
        }

        public interface IOtherService
        {
        }

        public class Service : IService
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

        public class OtherService : IService, IOtherService, IDisposable
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


        public interface ICommand<T>
        {
            void Execute(T data);
            void ChainedExecute(ICommand<T> inner);
        }

        public class ConcreteCommand<T> : ICommand<T>
        {
            private object p = null;

            public void Execute(T data)
            {
            }

            public void ChainedExecute(ICommand<T> inner)
            {
            }

            public object NonGenericProperty
            {
                get { return p; }
                set { p = value; }
            }
        }

        public class LoggingCommand<T> : ICommand<T>
        {
            private ICommand<T> inner;

            public bool ChainedExecuteWasCalled = false;
            public bool WasInjected = false;

            public LoggingCommand(ICommand<T> inner)
            {
                this.inner = inner;
            }

            public LoggingCommand()
            {
            }

            public ICommand<T> Inner
            {
                get { return inner; }
                set { inner = value; }
            }

            public void Execute(T data)
            {
                // do logging here
                Inner.Execute(data);
            }

            public void ChainedExecute(ICommand<T> innerCommand)
            {
                ChainedExecuteWasCalled = true;
            }

            public void InjectMe()
            {
                WasInjected = true;
            }
        }

        public class DisposableCommand<T> : ICommand<T>, IDisposable
        {
            public bool Disposed { get; private set; }

            public void Execute(T data)
            {
            }

            public void ChainedExecute(ICommand<T> inner)
            {
            }

            public void Dispose()
            {
                Disposed = true;
            }
        }


        public interface IService<T> { }

        public class ServiceA<T> : IService<T> { }

        public class ServiceB<T> : IService<T> { }

        public class ServiceClass<T> : IService<T> where T : class { }

        public class ServiceStruct<T> : IService<T> where T : struct { }

        public class ServiceNewConstraint<T> : IService<T> where T : new() { }

        public class TypeWithNoPublicNoArgCtors
        {
            public TypeWithNoPublicNoArgCtors(int _) { }
            private TypeWithNoPublicNoArgCtors() { }
        }

        public class ServiceInterfaceConstraint<T> : IService<T> where T : IEnumerable { }

        #endregion
    }
}
