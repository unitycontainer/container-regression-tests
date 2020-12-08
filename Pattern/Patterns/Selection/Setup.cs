using Regression;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Resolution;
#endif

namespace Selection
{
    public abstract partial class Pattern : FixtureBase
    {
        #region Constants

        protected const string SELECTION_EDGE = "Edge Cases";

        #endregion
    }
}
