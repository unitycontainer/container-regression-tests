using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class ImplicitPattern
    {
        [DynamicData(nameof(ParameterWithDefaults_Data))]
        [DataTestMethod]
        /// <summary>
        /// Tests providing default values
        /// </summary>
        public virtual void ParameterWithDefaults(string test, Type type, string name)
        {
            // Act
            var instance = Container.Resolve(type, name) as PatternBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.AreEqual(instance.Expected, instance.Value);
        }


        // Iterates through types with name starting with Implicit_WithDefault_*
        public static IEnumerable<object[]> ParameterWithDefaults_Data
        {
            get
            {
                foreach (var type in FromNamespace("ImplicitWithDefaults"))
                { 
                    yield return new object[] 
                    { 
                        type.Name, 
                        type, 
                        null
                    };
                }
            }
        }
    }
}
