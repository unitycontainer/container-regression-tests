using System;
using Unity.Builder;
using Unity.Strategies;

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

        public override void PreBuildUp(ref BuilderContext context)
        {
            _called = true;
            _existing = context.Existing;

            // 'null' type and name indicate that policy applies to current registration
            SpyPolicy policy = (SpyPolicy)context.Get(null, null, typeof(SpyPolicy));

            // Mark the policy
            if (policy != null) policy.WasSpiedOn = true;
        }

        public override void PostBuildUp(ref BuilderContext context)
        {
            // Spy on created object
            _existing = context.Existing;
        }

        public object Existing => _existing;
        public bool BuildUpWasCalled => _called;
    }
}
