using System;
using System.Threading;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
#endif

namespace Regression
{
#if UNITY_V4
    public class ValidatingResolver : InjectionParameterValue, IDependencyResolverPolicy
#else
    public class ValidatingResolver : IResolve
#endif
    {
        private object _value;

        public ValidatingResolver(object value) 
            => _value = value;

#if UNITY_V4
        public object Resolve(IBuilderContext context)
        {
            Type = context.OriginalBuildKey.Type;
            Name = context.OriginalBuildKey.Name;
            return _value;
        }

        public override bool MatchesType(Type t)
        {
            if (_value is null) return false;

            return t.IsAssignableFrom(_value.GetType());
        }

        public override IDependencyResolverPolicy GetResolverPolicy(Type typeToBuild) 
            => this;

        public override string ParameterTypeName => _value?.GetType().Name;
#else
        public object Resolve<TContext>(ref TContext context) where TContext : IResolveContext
        {
            Type = context.Type;
            Name = context.Name;

            return _value;
        }
#endif

        public Type Type { get; private set; }

        public string Name { get; private set; }

    }

#if !UNITY_V4
    public class ValidatingResolverFactory : IResolverFactory<Type>
    {
        private object _value;

        public ValidatingResolverFactory(object value)
        {
            _value = value;
        }

        public Type Type { get; private set; }
        public string Name { get; private set; }

        public ResolveDelegate<TContext> GetResolver<TContext>(Type info)
            where TContext : IResolveContext
        {
            return (ref TContext context) =>
            {
                Type = context.Type;
                Name = context.Name;

                return _value;
            };
        }
    }
#endif
}


