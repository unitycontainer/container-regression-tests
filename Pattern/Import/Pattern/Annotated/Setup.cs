using System;
using System.Collections.Generic;

namespace Regression.Annotated
{
    public abstract partial class Pattern : PatternBase
    {
        #region Fields

        private Type _typeDefinition;

        #endregion


        #region Test Data

        public static IEnumerable<object[]> Required_WithDefaults_Data
        {
            get
            {
                foreach (var type in FromNamespace("Required.WithDefaults"))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        public static IEnumerable<object[]> Optional_WithDefaults_Data
        {
            get
            {
                foreach (var type in FromNamespace("Optional.WithDefaults"))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }
        
        #endregion
    }
}
