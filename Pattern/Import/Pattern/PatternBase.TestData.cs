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
        public static IEnumerable<object[]> UnResolvableFromEmpty_Data
        {
            get
            {
                yield return new object[] { "typeof(Unresolvable)", typeof(Unresolvable) };
                yield return new object[] { "typeof(string)",       typeof(string)};
                yield return new object[] { "typeof(int)",          typeof(int)};
                yield return new object[] { "typeof(bool)",         typeof(bool)};
                yield return new object[] { "typeof(long)",         typeof(long)};
                yield return new object[] { "typeof(short)",        typeof(short)};
                yield return new object[] { "typeof(float)",        typeof(float)};
                yield return new object[] { "typeof(double)",       typeof(double)};
                yield return new object[] { "typeof(Type)",         typeof(Type)};
                yield return new object[] { "typeof(ICloneable)",   typeof(ICloneable)};
                yield return new object[] { "typeof(Delegate)",     typeof(Delegate)};
            }
        }

        // Test Data
        public static IEnumerable<object[]> ResolvableFromEmpty_Data
        {
            get
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //                          Test Name                       Type                                    Name    Expected
                yield return new object[] { "IUnityContainer",              typeof(IUnityContainer),                null,   typeof(IUnityContainer)              };
                yield return new object[] { "object",                       typeof(object),                         null,   typeof(object)                       };
                yield return new object[] { "Lazy<IUnityContainer>",        typeof(Lazy<IUnityContainer>),          null,   typeof(Lazy<IUnityContainer>)        };
                yield return new object[] { "Func<IUnityContainer>",        typeof(Func<IUnityContainer>),          null,   typeof(Func<IUnityContainer>)        };
                yield return new object[] { "object[]",                     typeof(object[]),                       null,   typeof(object[])                     };
#if !V4
                yield return new object[] { "List<int>",                    typeof(List<int>),                      null,   typeof(List<int>)                    };
                yield return new object[] { "List<string>",                 typeof(List<string>),                   null,   typeof(List<string>)                 };
                yield return new object[] { "IEnumerable<IUnityContainer>", typeof(IEnumerable<IUnityContainer>),   null,   typeof(IEnumerable<IUnityContainer>) };
#endif
#if !V4 && !V5
                yield return new object[] { "IUnityContainerAsync",         typeof(IUnityContainerAsync),           null,   typeof(IUnityContainerAsync)         };
                yield return new object[] { "IServiceProvider",             typeof(IServiceProvider),               null,   typeof(IServiceProvider)             };
#endif
            }
        }
    }
}


