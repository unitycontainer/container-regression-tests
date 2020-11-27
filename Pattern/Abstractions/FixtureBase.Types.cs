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
    public abstract class PatternBaseType
    {
        public virtual object Value { get; protected set; }

        public virtual object Default { get; }
        public virtual object Injected { get; }
        public virtual object Registered { get; }
        public virtual object Override { get; }
        public virtual Type ImportType => typeof(object);
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

    public interface IUnresolvable { }

    public class Unresolvable : PatternBaseType, IUnresolvable
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

    #region ILogger

    public interface ILogger
    {
    }

    public class MockLogger : ILogger
    {
    }

    #endregion



    #region IFoo

    public interface IFoo<TEntity>
    {
        TEntity Value { get; }
    }
    public interface IFoo1<TEntity>
    {
        TEntity Value { get; }
    }
    public interface IFoo2<TEntity>
    {
        TEntity Value { get; }
    }
    public class Foo<TEntity> : IFoo<TEntity>, 
                                IFoo1<TEntity>, 
                                IFoo2<TEntity>
    {
        public Foo() { }

        [InjectionConstructor]
        public Foo(TEntity value)
        {
            Value = value;
        }

        public TEntity Value { get; }
    }

    #endregion


    #region IService

    public interface IService { }
    public interface IOtherService { }
    public interface IService1 { }
    public interface IService2 { }

    public class Service : IService, IService1, IService2, IDisposable
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public static int Instances;

        public Service()
        {
            Interlocked.Increment(ref Instances);
        }

        public bool Disposed;
        public void Dispose()
        {
            Disposed = true;
        }
    }

    public class OtherService : IService, IOtherService, IDisposable
    {
        [InjectionConstructor]
        public OtherService()
        {

        }

        public OtherService(IUnityContainer container)
        {

        }


        public bool Disposed;
        public void Dispose()
        {
            Disposed = true;
        }
    }

    #endregion


    #region Constrained Generic

    public interface IConstrained<TEntity>
        where TEntity : IService
    {
        TEntity Value { get; }
    }

    public class Constrained<TEntity> : IConstrained<TEntity>
        where TEntity : Service
    {
        public Constrained()
        {
        }

        public Constrained(TEntity value)
        {
            Value = value;
        }

        public TEntity Value { get; }
    }

    #endregion
}


