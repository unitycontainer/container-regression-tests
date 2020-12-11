using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Lifetime;
#endif

namespace Lifetime.Synchronization
{
    public abstract partial class Pattern : Lifetime.Pattern
    {
        #region Test Data

        public static IEnumerable<object[]> Synchronized_Managers_Extended_Data
        {
            get
            {
                yield return new object[] 
                { 
                    typeof(ContainerControlledLifetimeManager).Name,    // Name
                    
                    (Func<SynchronizedLifetimeManager>)(() =>           // Manager factory
                    new ContainerControlledLifetimeManager()),
                };

                yield return new object[]
                {
                    typeof(ExternallyControlledLifetimeManager).Name,    // Name
                    
                    (Func<SynchronizedLifetimeManager>)(() =>           // Manager factory
                    new ExternallyControlledLifetimeManager()),
                };

                yield return new object[]
                {
                    typeof(HierarchicalLifetimeManager).Name,    // Name
                    
                    (Func<SynchronizedLifetimeManager>)(() =>           // Manager factory
                    new HierarchicalLifetimeManager()),
                };
            }
        }

        #endregion
    }
}
