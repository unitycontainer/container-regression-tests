using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
        public static IEnumerable<Type> Unsupported_Types
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
                yield return typeof(List<>);
                yield return typeof(Type);
                yield return typeof(ICloneable);
                yield return typeof(Delegate);
            }
        }

        public static IEnumerable<Type> Supported_Types
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

        #region Type Based Data

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

        public static IEnumerable<object[]> InvalidTypes_Data
        {
            get
            {
                foreach (var type in Unsupported_Types)
                {
                    yield return new object[] { type.Name, type };
                }
            }
        }

        public static IEnumerable<object[]> Unsupported_Data
        {
            get
            {
                foreach (var type in Unsupported_Types)
                {
                    if (type.IsGenericTypeDefinition) continue;
                    yield return new object[] { type.Name, type };
                }
            }
        }

        public static IEnumerable<object[]> SupportedTypes_Data
        {
            get
            {
                foreach (var type in Supported_Types)
                {
                    yield return new object[] { type.Name, type };
                }
            }
        }

        #endregion

        #region Data Sets

        public static IEnumerable<object[]> Type_Test_Data
        {
            get
            {
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

        public static IEnumerable<object[]> Type_Compatibility_Data
        {
            get
            {
                foreach (var set in Type_Test_Data)
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

