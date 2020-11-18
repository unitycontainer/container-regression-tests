using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression
{
    public abstract partial class BaselinePattern : PatternBase
    {
        [TestMethod]
        public void Baseline()
        { 
        }
    }
}
