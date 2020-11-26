using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
        #region Fields

        private static string _type { get; set; }
        private static string _root { get; set; }
        private static string _member { get; set; }
        private static string _prefix { get; set; }

        protected IUnityContainer Container;

        public const string Name = "name";

        #endregion


        #region Scaffolding

        protected static void ClassInitialize(TestContext context)
        {
            var type = Type.GetType(context.FullyQualifiedTestClassName);
            var root = type.Namespace.Split(".");

            _type = type.Namespace;
            _prefix = root.First();
            _member = root.Last();
            _root = $"{type.BaseType.Namespace}.{_member}";

            // Import.Implicit.Constructors
            // Import.Annotated.Constructors.Optional
            // Import.Override.Fields.WithDefaultAttribute

            var offset = type.BaseType.Namespace.LastIndexOf(".");
        }

        public virtual void TestInitialize() => Container = new UnityContainer();

        #endregion


        #region Registrations

        protected virtual void RegisterTypes()
        {
            Container.RegisterInstance(RegisteredInt)
                     .RegisterInstance(Name, NamedInt)
                     .RegisterInstance(RegisteredString)
                     .RegisterInstance(Name, NamedString)
                     .RegisterInstance(RegisteredUnresolvable)
                     .RegisterInstance(Name, NamedUnresolvable)
#if !V4 // Only Unity v5 and up allow `null` as a value
                     .RegisterInstance(typeof(string),       Null, (object)null)
                     .RegisterInstance(typeof(Unresolvable), Null, (object)null)
#endif
                     .RegisterInstance(typeof(TestStruct), RegisteredStruct)
                     .RegisterInstance(typeof(TestStruct), Name, NamedStruct);
        }


        protected virtual void RegisterArrayTypes()
        {
            Container.RegisterInstance<int>(RegisteredInt)
                     .RegisterInstance<int>("int_0", 0)
                     .RegisterInstance<int>("int_1", 1)
                     .RegisterInstance<int>("int_2", 2)
                     .RegisterInstance<int>("int_3", 3)

                     .RegisterInstance<string>(RegisteredString)
#if !V4 // Only Unity v5 and up allow `null` as a value
                     .RegisterInstance<string>("string_0", (string)null)
#endif
                     .RegisterInstance<string>("string_1", "string_1")
                     .RegisterInstance<string>("string_2", "string_2")
                     .RegisterInstance<string>("string_3", "string_3")

                     .RegisterInstance<Unresolvable>(RegisteredUnresolvable)
#if !V4 // Only Unity v5 and up allow `null` as a value
                     .RegisterInstance<Unresolvable>("Unresolvable_0", (Unresolvable)null)
#endif
                     .RegisterInstance<Unresolvable>("Unresolvable_1", Unresolvable.Create("1"))
                     .RegisterInstance<Unresolvable>("Unresolvable_2", Unresolvable.Create("2"))
                     .RegisterInstance<Unresolvable>("Unresolvable_3", Unresolvable.Create("3"));
        }


        protected virtual void RegisterUnResolvableTypes()
        {
            Container.RegisterInstance(RegisteredInt)
                     .RegisterInstance(RegisteredString)
                     .RegisterInstance(RegisteredUnresolvable)
                     .RegisterInstance(typeof(TestStruct), RegisteredStruct)
                     .RegisterInstance(RegisteredBool)
                     .RegisterInstance(RegisteredLong)
                     .RegisterInstance(RegisteredShort)
                     .RegisterInstance(RegisteredFloat)
                     .RegisterInstance(RegisteredDouble)
                     .RegisterInstance(RegisteredType)
                     .RegisterInstance(RegisteredICloneable)
                     .RegisterInstance(RegisteredDelegate);
        }

        #endregion


        #region Implementation

        protected static IEnumerable<Type> FromNamespace(string postfix)
        {
            var @namespace = $"{_root}.{postfix}";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => (t.Namespace?.Equals(@namespace) ?? false));
        }

        protected static IEnumerable<Type> FromNamespaces(string prefix, string @namespace)
        {
            var regex = $"({_prefix}).*({prefix}).*({_member}).*({@namespace})$";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => t.Namespace is not null)
                           .Where(t => Regex.IsMatch(t.Namespace, regex));
        }

        protected static IEnumerable<Type> FromNamespaces(string @namespace)
        {
            var regex = $"({_prefix}).*({_member}).*({@namespace})";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => t.Namespace is not null)
                           .Where(t => Regex.IsMatch(t.Namespace, regex));
        }

        protected static Type GetType(string name)
        {
            return Type.GetType($"{_root}.{name}") ??
                   Type.GetType($"{_type}.{name}");
        }

        protected static Type GetType(string @namespace, string name)
        {
            return Type.GetType($"{_prefix}.{@namespace}.{_member}.{name}") ??
                   Type.GetType($"{_type}.{@namespace}.{name}");
        }

        protected virtual Type GetImportType(Type type) => type;

        #endregion
    }
}
