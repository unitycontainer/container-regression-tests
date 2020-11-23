using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Resolution;
#endif

namespace Regression
{
    public abstract class PatternBaseType
    {
        public virtual object Value { get; protected set; }

        public virtual object Expected { get; }

        public virtual Type Dependency => typeof(object);
    }

    public struct TestStruct
    {
        public int Integer;
        public object Instance;

        public TestStruct(int value, object instance)
        {
            Integer = value;
            Instance = instance;
        }
    }

    public class Unresolvable : PatternBaseType
    {
        protected Unresolvable(string id) { Value = id; }

        public static Unresolvable Create(string name) => new Unresolvable(name);

        public override string ToString() => $"Unresolvable.{Value}";
    }

    public class SubUnresolvable : Unresolvable
    {
        private SubUnresolvable(string id)
            : base(id) { }

        public override string ToString() => $"SubUnresolvable.{Value}";

        public new static SubUnresolvable Create(string name) => new SubUnresolvable(name);
    }

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


