using Unity.Extension;

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

        public override void PreBuildUp<TContext>(ref TContext context)
        {
            _called = true;
            _existing = context.Target;

#if BEHAVIOR_V5
            var policy = (SpyPolicy)context.Get(null, typeof(SpyPolicy));
#else
            var policy = context.Policies.GetDefault<SpyPolicy>();
#endif
            // Mark the policy
            if (policy != null) policy.WasSpiedOn = true;
        }

        public override void PostBuildUp<TContext>(ref TContext context)
        {
            // Spy on created object
            _existing = context.Target;
        }

        public object Existing => _existing;
        public bool BuildUpWasCalled => _called;
    }
}
