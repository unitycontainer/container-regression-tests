using System;
using System.Collections.Generic;
using System.Linq;

namespace Regression
{
    public abstract partial class PatternBase
    {

        protected static TestDataSource[] Test_Data_Set = new TestDataSource[]
        {
            #region String

            new TestDataSource<string>(
                    null,                       // default
                    DefaultString,              // DefaultValue
                    DefaultValueString,         // DefaultAttributeValue
                    RegisteredString,           // Registered
                    NamedString,                // Named
                    InjectedString,             // Injected
                    OverriddenString            // Overridden
                ),
                
            #endregion


            #region Integer
#if !BEHAVIOR_V4
            new TestDataSource<int>(
                    0,                          // default
                    DefaultInt,                 // DefaultValue
                    DefaultValueInt,            // DefaultAttributeValue
                    RegisteredInt,              // Registered
                    NamedInt,                   // Named
                    InjectedInt,                // Injected
                    OverriddenInt               // Overridden
                ),
#endif
            #endregion


            #region Unresolvable
                
            new TestDataSource<Unresolvable>(
                    null,                       // default
                    DefaultUnresolvable,        // DefaultValue
                    DefaultValueUnresolvable,   // DefaultAttributeValue
                    RegisteredUnresolvable,     // Registered
                    NamedUnresolvable,          // Named
                    InjectedUnresolvable,       // Injected
                    OverriddenUnresolvable      // Overridden
                ),
            
            #endregion
        };


        public static IEnumerable<object[]> Test_Type_Data 
            => Test_Data_Set.Select(set => (object[])set);

        public static IEnumerable<object[]> Type_Compatibility_Data
#if BEHAVIOR_V4
            => Test_Type_Data.Where(set => set[1] is Type type && !type.IsValueType);
#else
            => Test_Type_Data;
#endif

        public static IEnumerable<object[]> BuiltInTypes_Data 
            => Unity_BuiltIn_Types.Select(type => new object[] { type.Name, type });

        public static IEnumerable<object[]> Unity_Recognized_Types_Data
            => Unity_Recognized_Types.Select(type => new object[] { type.Name, type });

        public static IEnumerable<object[]> Unity_Unrecognized_Types_Data 
            => Unity_Unrecognized_Types.Where(type => !type.IsGenericTypeDefinition)
                                       .Select(type => new object[] { type.Name, type });

        public static IEnumerable<object[]> InvalidTypes_Data 
            => Unity_Unrecognized_Types.Select(type => new object[] { type.Name, type });


        #region TestDataSource

        public class TestDataSource
        {
            protected object[] _data;

            protected TestDataSource(Type type, object @default,
                object defaultValue, object defaultAttribute,
                object registered, object named,
                object injected, object overridden)
            {
                _data = new object[]
                    {
                    type.Name,
                    type,
                    defaultValue,
                    defaultAttribute,
                    registered,
                    named,
                    injected,
                    overridden,
                    @default,
                    };
            }

            public string Name => (string)_data[0];
            public Type Type => (Type)_data[1];

            public object Registered => _data[4];
            public object Named => _data[5];

            public object Default => _data[8];
            public object DefaultValue => _data[2];
            public object DefaultAttribute => _data[3];

            public object Injected => _data[6];
            public object Overridden => _data[7];


            public static explicit operator object[](TestDataSource source) => source._data;
        }

        public class TestDataSource<T> : TestDataSource
        {
            public TestDataSource(object @default,
                                  object defaultValue, object defaultAttribute,
                                  object registered, object named,
                                  object injected, object overridden)
                : base(typeof(T), @default, defaultValue, defaultAttribute,
                       registered, named, injected, overridden)
            {
            }
        }
        #endregion
    }
}

