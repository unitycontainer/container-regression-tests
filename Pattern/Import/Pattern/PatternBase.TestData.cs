using System;
using System.Collections.Generic;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class PatternBase
    {
        // Serves collection of unresolvable types
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

        public static IEnumerable<Type> ContainerTypes
        {
            get
            {
                yield return typeof(IUnityContainer);
#if !BEHAVIOR_V4 && !BEHAVIOR_V5
                yield return typeof(IUnityContainerAsync);
                yield return typeof(IServiceProvider);
#endif
            }
        }


        public static IEnumerable<Type> ResolvableTypes
        {
            get
            {
                yield return typeof(IUnityContainer);
                yield return typeof(object);
                yield return typeof(Lazy<IUnityContainer>);
                yield return typeof(Func<IUnityContainer>);
                yield return typeof(object[]);
#if !BEHAVIOR_V4
                yield return typeof(List<int>);
                yield return typeof(List<string>);
                yield return typeof(IEnumerable<IUnityContainer>);
#endif
#if !BEHAVIOR_V4 && !BEHAVIOR_V5
                yield return typeof(IUnityContainerAsync);
                yield return typeof(IServiceProvider);
#endif
            }
        }

        #region Test Data Sources

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
    }
}


