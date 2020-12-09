using Regression;
using System;
using System.Collections.Generic;
using System.Reflection;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity.Injection;
#endif

namespace Parameters
{
    public abstract partial class Pattern
    {
        #region Variants

        public static IEnumerable<string> MemberInfo_Types
        {
            get
            {
                yield return CONSTRUCTORS;
                yield return METHODS;
                yield return FIELDS;
                yield return PROPERTIES;
            }
        }

        public static IEnumerable<string> Annotation_Types
        {
            get
            {
                yield return IMPLICIT;
                yield return REQUIRED;
                yield return OPTIONAL;
            }
        }

        public static IEnumerable<(string, bool)> Test_Name_Types
        {
            get
            {
                yield return ("BaselineTestTypeNamed`1", true);
                yield return ("BaselineTestType`1",     false);
            }
        }

        public static IEnumerable<(string, bool)> Test_Array_Types
        {
            get
            {
                yield return ("BaselineArrayType`1", false);
            }
        }
        
        #endregion


        #region Baseline Test Type

        public static IEnumerable<object[]> Test_Variants_Data
        {
            get
            {
                var @namespace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                foreach (var member in MemberInfo_Types)
                {
                    var method = Type.GetType($"{typeof(Regression.FixtureBase).FullName}+{member}")
                                     .GetMethod("GetInjectionValue")
                                     .CreateDelegate(typeof(Func<object, InjectionMember>));

                    foreach (var annotation in Annotation_Types)
                    {
                        foreach (var nameInfo in Test_Name_Types)
                        {
                            var definition = GetTestType(nameInfo.Item1, annotation, member, @namespace);

                            if (definition is null) continue;

                            #region String
                            yield return new object[]
                            {
                                typeof(string),     // Type
                                definition,         // Test Type Definition
                                member,             // Constructors, Methods, etc.
                                annotation,         // Implicit, Optional, Required
                                method,             // Injection Method
                                RegisteredString,   // Registered
                                NamedString,        // Named
                                InjectedString,     // Injected
                                null,               // default
                                nameInfo.Item2      // Is Named
                            };
                            #endregion

                            #region Integer
                            yield return new object[]
                            {
                                typeof(int),        // Type
                                definition,         // Test Type Definition
                                member,             // Constructors, Methods, etc.
                                annotation,         // Implicit, Optional, Required
                                method,             // Injection Method
                                RegisteredInt,      // Registered
                                NamedInt,           // Named
                                InjectedInt,        // Injected
                                0,                  // default
                                nameInfo.Item2      // Is Named
                            };
                            #endregion

                            #region Unresolvable
                            yield return new object[]
                            {
                                typeof(Unresolvable),    // Type
                                definition,              // Test Type Definition
                                member,                  // Constructors, Methods, etc.
                                annotation,              // Implicit, Optional, Required
                                method,                  // Injection Method
                                RegisteredUnresolvable,  // Registered
                                NamedUnresolvable,       // Named
                                InjectedUnresolvable,    // Injected
                                null,                    // default
                                nameInfo.Item2           // Is Named
                            };
                            #endregion
                        }
                    }
                }
            }
        }

        #endregion


        #region Arrays

        public static IEnumerable<object[]> Test_Array_Data
        {
            get
            {
                var @namespace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                foreach (var member in MemberInfo_Types)
                {
                    var method = Type.GetType($"{typeof(Regression.FixtureBase).FullName}+{member}")
                                     .GetMethod("GetInjectionValue")
                                     .CreateDelegate(typeof(Func<object, InjectionMember>));

                    foreach (var annotation in Annotation_Types)
                    {
                        foreach (var nameInfo in Test_Array_Types)
                        {
                            var definition = GetTestType(nameInfo.Item1, annotation, member, @namespace);

                            if (definition is null) continue;

                            #region String
                            yield return new object[]
                            {
                                typeof(string),     // Type
                                definition,         // Test Type Definition
                                member,             // Constructors, Methods, etc.
                                annotation,         // Implicit, Optional, Required
                                method,             // Injection Method
                                RegisteredString,   // Registered
                                NamedString,        // Named
                                InjectedString,     // Injected
                                null,               // default
                                nameInfo.Item2      // Is Named
                            };
                            #endregion

                            #region Integer
                            yield return new object[]
                            {
                                typeof(int),        // Type
                                definition,         // Test Type Definition
                                member,             // Constructors, Methods, etc.
                                annotation,         // Implicit, Optional, Required
                                method,             // Injection Method
                                RegisteredInt,      // Registered
                                NamedInt,           // Named
                                InjectedInt,        // Injected
                                0,                  // default
                                nameInfo.Item2      // Is Named
                            };
                            #endregion

                            #region Unresolvable
                            yield return new object[]
                            {
                                typeof(Unresolvable),    // Type
                                definition,              // Test Type Definition
                                member,                  // Constructors, Methods, etc.
                                annotation,              // Implicit, Optional, Required
                                method,                  // Injection Method
                                RegisteredUnresolvable,  // Registered
                                NamedUnresolvable,       // Named
                                InjectedUnresolvable,    // Injected
                                null,                    // default
                                nameInfo.Item2           // Is Named
                            };
                            #endregion
                        }
                    }
                }
            }
        }

        #endregion
    }
}
