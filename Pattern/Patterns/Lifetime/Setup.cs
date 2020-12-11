using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;

namespace Lifetime
{
    public abstract partial class Pattern : FixtureBase
    {
        protected const string SAME_SCOPE  = "Same Scope";
        protected const string CHILD_SCOPE = "Child Scope";
        protected const string TWO_SCOPES  = "Two Child Scopes";
        protected const string LIFETIME_MANAGER = "Manager";
    }
}
