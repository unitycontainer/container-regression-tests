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
        #region Type Based Data

        public static IEnumerable<Type> UnResolvableTypes
        {
            get
            {
                yield return typeof(Unresolvable);
                yield return typeof(string);

#if !BEHAVIOR_V4 // Unity v4 did not support optional value types
                yield return typeof(int);
                yield return typeof(bool);
                yield return typeof(long);
                yield return typeof(short);
                yield return typeof(float);
                yield return typeof(double);
                // TODO: typeof(TestStruct)
#endif                                            
                yield return typeof(Type);
                yield return typeof(ICloneable);
                yield return typeof(Delegate);
            }
        }

        public static IEnumerable<Type> ResolvableTypes
        {
            get
            {
                yield return typeof(object);
                yield return typeof(Lazy<IUnityContainer>);
                yield return typeof(Func<IUnityContainer>);
                yield return typeof(object[]);
#if !BEHAVIOR_V4
                yield return typeof(List<int>);
                yield return typeof(List<string>);
                yield return typeof(IEnumerable<IUnityContainer>);
#endif
            }
        }

        public static IEnumerable<object[]> BuiltInTypes_Data
        {
            get
            {
                yield return new object[] { typeof(IUnityContainer).Name, typeof(IUnityContainer) };
#if !UNITY_V4 && !UNITY_V5
                yield return new object[] { typeof(IUnityContainerAsync).Name, typeof(IUnityContainerAsync) };
                yield return new object[] { typeof(IServiceProvider).Name, typeof(IServiceProvider) };
#endif
            }
        }

        public static IEnumerable<object[]> UnResolvableTypes_Data
        {
            get
            {
                foreach (var type in UnResolvableTypes)
                {
                    yield return new object[] { type.Name, type };
                }
            }
        }

        public static IEnumerable<object[]> ResolvableTypes_Data
        {
            get
            {
                foreach (var type in ResolvableTypes)
                {
                    yield return new object[] { type.Name, type };
                }
            }
        }

        #endregion


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
                    DefaultInt,              // Default
                    DefaultValueInt,         // DefaultValue
                    RegisteredInt,           // Registered
                    NamedInt,                // Named
                    InjectedInt,             // Injected
                    OverriddenInt,           // Overridden
                    false                    // Is resolvable from empty
                };
                #endregion

                #region String
                yield return new object[]
                {
                    typeof(string).Name,     // Name
                    typeof(string),          // Type
                    DefaultString,           // Default
                    DefaultValueString,      // DefaultValue
                    RegisteredString,        // Registered
                    NamedString,             // Named
                    InjectedString,          // Injected
                    OverriddenString,        // Overridden
                    false                    // Is resolvable from empty
                };
                #endregion

                #region Unresolvable
                yield return new object[]
                {
                    typeof(Unresolvable).Name,// Name
                    typeof(Unresolvable),     // Type
                    null,                     // Default
                    null,                     // DefaultValue
                    RegisteredUnresolvable,   // Registered
                    NamedUnresolvable,        // Named
                    InjectedUnresolvable,     // Injected
                    OverriddenUnresolvable,   // Overridden
                    false                     // Is resolvable from empty
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

        public static IEnumerable<object[]> Implicit_Data
        {
            get
            {
                foreach (var type in FromNamespaces("Implicit", string.Empty)
                                        .Where(t => !t.IsGenericTypeDefinition))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        public static IEnumerable<object[]> Annotated_Required_Data
        {
            get
            {
                foreach (var type in FromNamespaces("Annotated", "Required")
                                        .Where(t => !t.IsGenericTypeDefinition))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }

        public static IEnumerable<object[]> Annotated_Optional_Data
        {
            get
            {
                foreach (var type in FromNamespaces("Annotated", "Optional")
                                        .Where(t => !t.IsGenericTypeDefinition))
                {
                    yield return new object[]
                    {
                        type.Name,
                        type
                    };
                }
            }
        }
    }
}


