using System;
using System.Threading;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public interface IService { }

    public interface IService1 { }
    
    public interface IService2 { }

    public class Service : IService, IService1, IService2, IDisposable
    {
        public readonly string Id = Guid.NewGuid().ToString();

        public static int Instances;

        public Service() => Interlocked.Increment(ref Instances);

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }


    public interface IOtherService { }

    public class OtherService : IService, IOtherService, IDisposable
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
}


