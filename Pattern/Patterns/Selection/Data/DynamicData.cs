using System;
using System.Collections.Generic;
using System.Linq;

namespace Selection
{
    public abstract partial class Pattern
    {
        public static IEnumerable<object[]> TestCases_Data
        {
            get
            {
                var types = FromPatternNamespace("TestCases").ToArray();
                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(DummySelection) };
            }
        }


        public static IEnumerable<object[]> TestCases_Throwing_Data
        {
            get
            {
                var types = FromPatternNamespace("TestCasesThrowing").ToArray();
                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(UnresolvableDummySelection) };
            }
        }

        public static IEnumerable<Type> Validation_Types
        {
            get
            {
                yield return GetTestType("NoPublicMember`1");
            }
        }


        public static IEnumerable<object[]> Validation_Data
        {
            get
            {
                var types = new[] { typeof(object), typeof(string) };
                foreach (var definition in Validation_Types)
                { 
                    foreach (var type in types)
                    {
                        var target = definition.MakeGenericType(type);
                        yield return new object[] { target.Name, target };
                    }
                }
            }
        }


    }
}
