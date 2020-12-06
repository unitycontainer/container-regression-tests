using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Properties
{
    public partial class Optional
    {
        [TestProperty(OVERRIDE, MEMBER_OVERRIDE)]
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Member_null()
        {
            Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(typeof(object)),
                MemberOverride_ByName(null, this), this);
        }
    }

    public partial class Required
    {
        [TestProperty(OVERRIDE, MEMBER_OVERRIDE)]
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Member_null()
        {
            Assert_AlwaysSuccessful(BaselineTestType.MakeGenericType(typeof(object)),
                MemberOverride_ByName(null, this), this);
        }
    }
}
