using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Selection.Annotated
{
    public abstract partial class Pattern
    {
        public static IEnumerable<Type> NoPublicMember_Types
        {
            get
            {
                var @namespace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                var set = @namespace.Substring(0, @namespace.IndexOf('.'));
                var member = FullyQualifiedTestClassName.Substring(0, FullyQualifiedTestClassName.IndexOf('.'));

                foreach (var annotation in Annotation_Category_Names)
                {
                    yield return GetTestType("NoPublicMember`1", annotation, member, set);
                }
            }
        }

        public static IEnumerable<object[]> NoPublicMember_Data
        {
            get
            {
                var types = new[] { typeof(object), typeof(string) };
                foreach (var definition in NoPublicMember_Types)
                {
                    foreach (var type in types)
                    {
                        var target = definition.MakeGenericType(type);
                        yield return new object[] { target.Name, target };
                    }
                }
            }
        }

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
    }
}
