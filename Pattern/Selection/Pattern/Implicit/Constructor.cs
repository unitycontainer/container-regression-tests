using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Selection.Implicit
{
    public abstract partial class Pattern 
    {
        [DataTestMethod, DynamicData(nameof(Selection_Data))]
        public virtual void Selection_Constructor_Implicit(string test, Type contract, object registered, 
                                           Type dependency, Type import, int selection, string example)
        {
            // Arrange
            Container.RegisterInstance(contract, registered);
            Type type = ImplicitType.MakeGenericType(new[] { dependency, import });

            // Act 
            var instance = AssertResolutionPattern(type);

            Assert.IsNotNull(instance[selection]);
        }



        public static IEnumerable<object[]> Selection_Data
        {
            get
            {
                // Test cases
                yield return TestRecord
                (
                    "Longest if matches all",
                    typeof(int),                // Registered instance ContractType
                    22,                         // Registered instance
                    typeof(object),             // Type of TDependency
                    typeof(IUnityContainer),    // Type of TImport
                    3                           // Index of selected member
                );

                //yield return TestRecord
                //(
                //    "Default If nothing matches",
                //    typeof(object),                 // Registered instance ContractType
                //    new object(),                   // Registered instance
                //    typeof(string),                    // Type of TDependency
                //    typeof(string),                 // Type of TImport
                //    0                               // Index of selected member
                //);

                // Test cases
                /*
                yield return TestRecord
                (
                    "",          //  Test Name
                    typeof(),    // Registered instance ContractType
                    xx,          // Registered instance
                    typeof(),    // Type of TDependency
                    typeof(),    // Type of TImport
                    0            // Index of selected member
                );
                 */
            }
        }
    }
}
