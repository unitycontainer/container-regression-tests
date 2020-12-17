using System;
using Unity.Extension;

namespace Regression.Container
{
//    /// <summary>
//    /// A small snoop strategy that lets us check afterwards to
//    /// see if it ran in the strategy chain.
//    /// </summary>
//    public class SpyStrategy : BuilderStrategy
//    {
//        #region Fields

//        private bool _called = false;
//        private object _existing = null;

//        #endregion

//        public override void PreBuildUp<TContext>(ref TContext context)
//        {
//            _called = true;
//            _existing = context.Existing;

////#if BEHAVIOR_V4
////            SpyPolicy policy = context.Policies.Get<SpyPolicy>(context.BuildKey);
////#else
////            SpyPolicy policy = (SpyPolicy)context.Get(null, null, typeof(SpyPolicy));
////#endif
////            // Mark the policy
////            if (policy != null) policy.WasSpiedOn = true;
//        }

//        public override void PostBuildUp<TContext>(ref TContext context)
//        {
//            // Spy on created object
//            _existing = context.Existing;
//        }

//        public object Existing => _existing;
//        public bool BuildUpWasCalled => _called;
//    }
}
