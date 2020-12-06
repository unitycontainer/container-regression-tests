using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Import.Properties
{
    public partial class Optional
    {
#if !BEHAVIOR_V4
        [TestProperty(OVERRIDE, MEMBER_OVERRIDE)]
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
#endif
        public void Member_null()
        {
            _ = MemberOverride_ByName(null, this);
        }
    }

    public partial class Required
    {
#if !BEHAVIOR_V4
        [TestProperty(OVERRIDE, MEMBER_OVERRIDE)]
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
#endif
        public void Member_null()
        {
            _ = MemberOverride_ByName(null, this);
        }
    }
}
