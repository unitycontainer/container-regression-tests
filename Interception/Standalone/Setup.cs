using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity.InterceptionExtension;
#elif UNITY_V5
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors;
using Unity.Interception.Interceptors.InstanceInterceptors;
using Unity.Interception.Interceptors.TypeInterceptors;
using Unity.Interception.PolicyInjection.Pipeline;
#else
using Unity;
using Unity.Interception;
using Unity.Interception.PolicyInjection.Pipeline;
#endif

namespace Standalone
{
    [TestClass]
    public partial class StaticInterception
    {
        #region Constants

        const string PROPERTY = "Test";
        const string INSTANCE = "Instance";
        const string TYPE = "Type";

        #endregion
    }

    #region Test Data

    public class BaseClass : IInterface
    {
        private readonly int value;

        public BaseClass()
            : this(0)
        { }

        public BaseClass(int value)
        {
            this.value = value;
        }

        public virtual int DoSomething()
        {
            return value;
        }
    }

    public interface IInterface
    {
        int DoSomething();
    }

    public interface ISomeInterface
    {
        int DoSomethingElse();
    }

    public class RejectingInterceptor : IInstanceInterceptor, ITypeInterceptor
    {
#if UNITY_V6
        public ISequenceSegment Next { get; set; }
#endif
        public bool CanIntercept(Type t)
        {
            return false;
        }

        public IEnumerable<MethodImplementationInfo> GetInterceptableMethods(Type interceptedType, Type implementationType)
        {
            throw new NotImplementedException();
        }

        public IInterceptingProxy CreateProxy(Type t, object target, params Type[] additionalInterfaces)
        {
            throw new NotImplementedException();
        }

        public Type CreateProxyType(Type t, params Type[] additionalInterfaces)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class AbstractClass
    {
        public abstract int DoSomething();
    }

    public class TestDelegateBehavior : IInterceptionBehavior
    {
        public static readonly Func<IEnumerable<Type>> NoRequiredInterfaces = () => Type.EmptyTypes;

        private readonly Func<IMethodInvocation, GetNextInterceptionBehaviorDelegate, IMethodReturn> invoke;
        private readonly Func<IEnumerable<Type>> requiredInterfaces;

        public TestDelegateBehavior(Func<IMethodInvocation, GetNextInterceptionBehaviorDelegate, IMethodReturn> invoke)
            : this(invoke, NoRequiredInterfaces)
        { }

        public TestDelegateBehavior(
            Func<IMethodInvocation, GetNextInterceptionBehaviorDelegate, IMethodReturn> invoke,
            Func<IEnumerable<Type>> requiredInterfaces)
        {
            this.invoke = invoke;
            this.requiredInterfaces = requiredInterfaces;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            return invoke(input, getNext);
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return requiredInterfaces();
        }

        /// <summary>
        /// Returns a flag indicating if this behavior will actually do anything when invoked.
        /// </summary>
        /// <remarks>This is used to optimize interception. If the behaviors won't actually
        /// do anything (for example, PIAB where no policies match) then the interception
        /// mechanism can be skipped completely.</remarks>
        public bool WillExecute
        {
            get { return true; }
        }
    }


    #endregion
}
