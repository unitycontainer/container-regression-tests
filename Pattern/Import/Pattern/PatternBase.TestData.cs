using System;
using System.Collections.Generic;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
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
                var poco_type = PatternBase.GetType("Implicit`1");

                yield return new object[] { $"Unresolvable: {typeof(Unresolvable).Name}", poco_type.MakeGenericType(typeof(Unresolvable)) };
                yield return new object[] { $"Unresolvable: {typeof(string).Name}",       poco_type.MakeGenericType(typeof(string))};
                yield return new object[] { $"Unresolvable: {typeof(int).Name}",          poco_type.MakeGenericType(typeof(int))};
                yield return new object[] { $"Unresolvable: {typeof(bool).Name}",         poco_type.MakeGenericType(typeof(bool))};
                yield return new object[] { $"Unresolvable: {typeof(long).Name}",         poco_type.MakeGenericType(typeof(long))};
                yield return new object[] { $"Unresolvable: {typeof(short).Name}",        poco_type.MakeGenericType(typeof(short))};
                yield return new object[] { $"Unresolvable: {typeof(float).Name}",        poco_type.MakeGenericType(typeof(float))};
                yield return new object[] { $"Unresolvable: {typeof(double).Name}",       poco_type.MakeGenericType(typeof(double))};
                yield return new object[] { $"Unresolvable: {typeof(Type).Name}",         poco_type.MakeGenericType(typeof(Type))};
                yield return new object[] { $"Unresolvable: {typeof(ICloneable).Name}",   poco_type.MakeGenericType(typeof(ICloneable))};
                yield return new object[] { $"Unresolvable: {typeof(Delegate).Name}",     poco_type.MakeGenericType(typeof(Delegate))};
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
                yield return new object[] { "List<int>",                    typeof(List<int>),                      null,   typeof(List<int>) };
                yield return new object[] { "List<string>",                 typeof(List<string>),                   null,   typeof(List<string>) };
                yield return new object[] { "IEnumerable<IUnityContainer>", typeof(IEnumerable<IUnityContainer>),   null,   typeof(IEnumerable<IUnityContainer>) };
#endif
#if !V4 && !V5
                yield return new object[] { "IUnityContainerAsync",         typeof(IUnityContainerAsync),           null,   typeof(IUnityContainerAsync) };
                yield return new object[] { "IServiceProvider",             typeof(IServiceProvider),               null,   typeof(IServiceProvider) };
#endif
            }
        }
    }
}


