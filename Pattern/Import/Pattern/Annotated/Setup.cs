using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class AnnotatedPattern : PatternBase
    {
        [TestMethod]
        public void Baseline()
        {
        }
    }
}
