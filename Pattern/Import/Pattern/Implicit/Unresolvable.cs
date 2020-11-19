using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class ImplicitPattern
    {
        /// <summary>
        /// Tests invalid parameter types
        /// </summary>
        [DataTestMethod]
        [DataRow("Implicit_Dependency_Ref")]
        [DataRow("Implicit_Dependency_Out")]
        [ExpectedException(typeof(ResolutionFailedException))]
        public virtual void ThrowsOnInvalidParameter(string name)
        {
            var type = GetType(name);

            // Make dependencies available
            RegisterTypes();

            // Act
            _ = Container.Resolve(type);
        }

    }
}
