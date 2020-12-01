using Regression;
using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Import
{
    public abstract partial class ImportBase
    {
        #region Data Sets

        public static IEnumerable<object[]> Import_Test_Data
        {
            get
            {
                #region Integer
                yield return new object[]
                {
                    typeof(int).Name,        // Name
                    typeof(int),             // Type
                    DefaultInt,              // DefaultValue
                    DefaultValueInt,         // DefaultAttributeValue
                    RegisteredInt,           // Registered
                    NamedInt,                // Named
                    InjectedInt,             // Injected
                    OverriddenInt,           // Overridden
                    0                        // default
                };
                #endregion

                #region String
                yield return new object[]
                {
                    typeof(string).Name,     // Name
                    typeof(string),          // Type
                    DefaultString,           // DefaultValue
                    DefaultValueString,      // DefaultAttributeValue
                    RegisteredString,        // Registered
                    NamedString,             // Named
                    InjectedString,          // Injected
                    OverriddenString,        // Overridden
                    null                     // default
                };
                #endregion

                #region Unresolvable
                yield return new object[]
                {
                    typeof(Unresolvable).Name,// Name
                    typeof(Unresolvable),     // Type
                    DefaultUnresolvable,      // DefaultValue
                    DefaultValueUnresolvable, // DefaultAttributeValue
                    RegisteredUnresolvable,   // Registered
                    NamedUnresolvable,        // Named
                    InjectedUnresolvable,     // Injected
                    OverriddenUnresolvable,   // Overridden
                    null                      // default
                };
                #endregion
            }
        }

        public static IEnumerable<object[]> Import_Compatibility_Data
        {
            get
            {
                foreach (var set in Import_Test_Data)
                {
#if BEHAVIOR_V4
                    if (set[1] is Type type && type.IsValueType) continue;
#endif
                    yield return set;
                }
            }
        }

        #endregion
    }
}


