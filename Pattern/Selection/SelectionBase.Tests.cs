using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Selection
{
    public abstract partial class SelectionBase
    {

        [DataTestMethod, DynamicData(nameof(EdgeCases_Data))]
        public virtual void EdgeCases(string test, Type type)
        {
            // Arrange
            RegisterTypes();

            // Act
            var instance = AssertResolutionPattern(type);

            // Validate
            Assert.IsTrue(instance.IsSuccessfull);
        }
    }
}
