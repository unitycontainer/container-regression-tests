using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Unity.Storage
{
    public class LifetimeContainer : List<IDisposable>
#if UNITY_V5 || UNITY_V6
        , ILifetimeContainer
#endif
    {
        public IUnityContainer Container => throw new NotImplementedException();

        public void Add(object item)
        {
            if (item is IDisposable disposable)
                base.Add(disposable);
        }

        public bool Contains(object item)
        {
            return item is IDisposable disposable
                ? base.Remove(disposable)
                : false;
        }

        public void Dispose() => Clear();

        public new IEnumerator<object> GetEnumerator()
            => base.GetEnumerator();

        public void Remove(object item)
        {
            if (item is IDisposable disposable)
                base.Remove(disposable);
        }
    }
}
