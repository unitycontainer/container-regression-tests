using System.Collections.Generic;
using System.Linq;

namespace Import.Common
{
    public abstract partial class Pattern : ImportBase
    {
        public static IEnumerable<object[]> WithDefaultValue_Data
        {
            get
            {
                var types = FromNamespace("WithDefault").ToArray();

                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(DummyImport) };
            }
        }

        public static IEnumerable<object[]> WithDefaultAttribute_Data
        {
            get
            {
                var types = FromNamespace("WithDefaultAttribute").ToArray();

                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(DummyImport) };
            }
        }

        public static IEnumerable<object[]> WithDefaultAndAttribute_Data
        {
            get
            {
                var types = FromNamespace("WithDefaultAndAttribute").ToArray();

                foreach (var type in types) yield return new object[] { type.Name, type };
                if (0 == types.Length) yield return new object[] { "Empty", typeof(DummyImport) };
            }
        }
    }
}
