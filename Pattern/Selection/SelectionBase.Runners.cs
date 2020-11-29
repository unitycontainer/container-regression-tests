using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Selection
{
    public abstract partial class SelectionBase
    {
        public object AssertResolutionSuccessfull(Type type)
        {
            // Act
            var instance = Container.Resolve(type, null);

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);

            return instance;
        }

        public SelectionBaseType AssertBasicPatternSuccessfull(Type type)
        {
            // Act
            var instance = Container.Resolve(type, null) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, type);

            return instance;
        }
    }
}
