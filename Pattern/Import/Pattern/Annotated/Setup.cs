using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Regression.Annotated
{
    public abstract partial class Pattern : PatternBase
    {
        #region Fields

        private static Type _requiredNamed;
        private static Type _requiredInherited;
        private static Type _requiredTwice;
        
        private static Type _optionalNamed;
        private static Type _optionalInherited;
        private static Type _optionalTwice;


        #endregion


        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            PatternBase.ClassInitialize(context);

            _requiredInherited  = GetType("Required", "BaselineInheritedType`1");
            _optionalInherited  = GetType("Optional", "BaselineInheritedType`1");
            _requiredNamed      = GetType("Required", "BaselineTestTypeNamed`1");
            _optionalNamed      = GetType("Optional", "BaselineTestTypeNamed`1");
            _requiredTwice      = GetType("Required", "BaselineInheritedTwice`1");
            _optionalTwice      = GetType("Optional", "BaselineInheritedTwice`1"); 
        }

        #endregion


        #region Defaults

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
