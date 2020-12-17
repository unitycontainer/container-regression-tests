using System;
using Unity.Builder;
using Unity.Extension;
using Unity.Strategies;

namespace Regression.Container
{
    /// <summary>
    /// A simple extension that puts the supplied strategy into the
    /// chain at the indicated stage.
    /// </summary>
    public class SpyExtension : UnityContainerExtension
    {
        private object _policy;
        private BuilderStrategy _strategy;
        private UnityBuildStage _stage;
        private Type _policyType;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="strategy"></param>
        /// <param name="stage"></param>
        public SpyExtension(BuilderStrategy strategy, UnityBuildStage stage)
        {
            _strategy = strategy;
            _stage = stage;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="strategy">The strategy to add</param>
        /// <param name="stage">Stage, or step to add it to</param>
        /// <param name="policy">
        /// The policy to add.
        /// <para>
        /// Unity v4 required a policy to be derived from <see cref="IBuilderPolicy"/>
        /// </para>
        /// <para>
        /// Unity v5 deprecated the interface and relaxed the requirement. Now any object
        /// implementing <paramref name="policyType"/> could be added as a policy.
        /// </para>
        /// </param>
        /// <param name="policyType"><see cref="Type"/> of the policy</param>
        public SpyExtension(BuilderStrategy strategy, UnityBuildStage stage, object policy, Type policyType)
        {
            _strategy = strategy;
            _stage = stage;
            _policy = policy;
            _policyType = policyType;
        }

        protected override void Initialize()
        {
            Context.Strategies.Add(this._strategy, this._stage);
            
            if (_policy != null)
                Context.Policies.Set(null, null, _policyType, _policy);
        }
    }
}
