using System;
using System.Reflection;
using Unity.Injection;
using Unity.Resolution;

namespace Regression
{
    public class ValidatingResolver : IResolve, IMatchTo<ParameterInfo> 
    {
        private object _value;

        public ValidatingResolver(object value) 
            => _value = value;

        public object Resolve<TContext>(ref TContext context) where TContext : IResolveContext
        {
            Type = context.Type;
            Name = context.Name;

            return _value;
        }

        public Type Type { get; private set; }

        public string Name { get; private set; }

        public MatchRank MatchTo(ParameterInfo other) 
            => _value.MatchTo(other);
    }
}


