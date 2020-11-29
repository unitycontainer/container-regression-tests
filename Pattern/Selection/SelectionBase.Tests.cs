using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Selection
{
    public abstract partial class SelectionBase
    {
        [TestMethod]
        public void NoMebersToSelect() 
            => AssertResolutionSuccessfull(typeof(NoMembersType));

        [DataTestMethod]
        [DynamicData(nameof(BasicOperationTests_Data))]
        public virtual void BasicOperationTest(string test, Type type)
            => AssertBasicPatternSuccessfull(type);
    }
}
