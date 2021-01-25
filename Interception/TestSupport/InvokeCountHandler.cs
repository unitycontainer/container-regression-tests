#if UNITY_V4
using Microsoft.Practices.Unity.InterceptionExtension;
#elif UNITY_V5
using Unity.Interception.PolicyInjection.Pipeline;
#else
using Unity;
using Unity.Interception;
using Unity.Interception.PolicyInjection.Pipeline;
#endif


namespace Unity.Interception.Tests
{
    public class InvokeCountHandler : ICallHandler
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Clears the counter
        /// </summary>
        public void Reset() => Count = 0;


        #region ICallHandler

        /// <inheritdoc />
        public int Order { get;  set; }

        /// <inheritdoc />
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            ++Count;
            return getNext()(input, getNext);
        }

        #endregion
    }
}
