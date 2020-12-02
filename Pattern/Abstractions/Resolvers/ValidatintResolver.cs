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

    public interface IResolve : IDependencyResolverPolicy
    { 
    }

    public interface IResolveContext : IBuilderContext
    { 
    }

#endif

    public class ValidatingResolver : IResolve
    {
        private object _value;

        public ValidatingResolver(object value)
        {
            _value = value;
        }

#if UNITY_V4
        public object Resolve(IBuilderContext context)
        {
            Type = context.OriginalBuildKey.Type;
            Name = context.OriginalBuildKey.Name;
            return _value;
        }
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


