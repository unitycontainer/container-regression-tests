using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
#elif UNITY_V5
using Unity.Builder;
using Unity.Strategies;
#else
using Unity;
using Unity.Extension;
#endif

namespace Regression.Container
{
    /// <summary>
    /// A small snoop strategy that lets us check afterwards to
    /// see if it ran in the strategy chain.
    /// </summary>
    public class SpyStrategy : BuilderStrategy
    {
        #region Fields

        private bool _called = false;
        private object _existing = null;
        
        #endregion

#if UNITY_V4
        public override void PreBuildUp(IBuilderContext context)
#else
        public override void PreBuildUp(ref BuilderContext context)
#endif
        {
            _called = true;
            _existing = context.Existing;

#if UNITY_V4
            SpyPolicy policy = context.Policies.Get<SpyPolicy>(context.BuildKey);
#else
            // 'null' type and name indicate that default should be used
            SpyPolicy policy = (SpyPolicy)context.Get(null, null, typeof(SpyPolicy));
#endif
            // Mark the policy
            if (policy != null) policy.WasSpiedOn = true;
        }

#if UNITY_V4
        public override void PostBuildUp(IBuilderContext context)
#else
        public override void PostBuildUp(ref BuilderContext context)
#endif
        {
            // Spy on created object
            _existing = context.Existing;
        }

        public object Existing => _existing;
        public bool BuildUpWasCalled => _called;
    }
}
