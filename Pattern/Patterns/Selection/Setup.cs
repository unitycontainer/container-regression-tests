using System.Reflection;

namespace Selection
{
    public abstract partial class Pattern : Regression.PatternBase
    {
        #region Scaffolding

        public static void Pattern_Initialize(string name, Assembly assembly = null)
        {
            PatternBaseInitialize(name, assembly);
        }

        #endregion
    }
}
