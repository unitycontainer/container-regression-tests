﻿using System.Collections.Generic;
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


namespace Unity.Interception.Tests
{
    public class GlobalCountCallHandler : ICallHandler
    {
        public static Dictionary<string, int> Calls = new Dictionary<string, int>();
        private string callHandlerName;
        private int order = 0;

        [InjectionConstructor]
        public GlobalCountCallHandler()
            : this("default")
        {
        }

        public GlobalCountCallHandler(string callHandlerName)
        {
            this.callHandlerName = callHandlerName;
        }

        #region ICallHandler Members

        /// <summary>
        /// Gets or sets the order in which the handler will be executed
        /// </summary>
        public int Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            if (!Calls.ContainsKey(callHandlerName))
            {
                Calls.Add(callHandlerName, 0);
            }
            Calls[callHandlerName]++;

            return getNext().Invoke(input, getNext);
        }

        #endregion
    }

    public class GlobalCountCallHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer ignored)
        {
            return new GlobalCountCallHandler(this.handlerName);
        }

        private string handlerName;

        public string HandlerName
        {
            get { return this.handlerName; }
            set { this.handlerName = value; }
        }
    }
}
