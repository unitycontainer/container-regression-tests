using System;
using System.Reflection;

namespace Selection
{
    public abstract partial class Pattern : Regression.PatternBase
    {
        #region Fields

        protected static Type BaselineTestType;

        #endregion


        #region Scaffolding

        public static void Pattern_Initialize(string name, Assembly assembly = null)
        {
            PatternBaseInitialize(name, assembly);
            
            BaselineTestType = GetTestType("BaselineTestType`3");
        }

        #endregion
    }
}
