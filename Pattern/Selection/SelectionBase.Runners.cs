using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Selection
{
    public abstract partial class SelectionBase
    {
        public SelectionBaseType AssertResolutionPattern(Type type)
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
