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
        private static string _prefix { get; set; }
        
        protected IUnityContainer Container;

        protected static Type BaselineTestType;
        protected static Type BaselineTestNamed;
        protected static Type BaselineArrayType;
        protected static Type BaselineConsumer;

        #endregion


        #region Properties

        public TestContext TestContext 
        { 
            get => StaticContext; set => StaticContext = value; 
        }

        public static TestContext ClassContext;

        public static TestContext StaticContext;

        protected static string Category { get; private set; }
        protected static string Dependency { get; private set; }
        protected static string Member { get; private set; }
        
        protected virtual string DependencyName => string.Empty;

        protected Type CorrespondingTypeDefinition 
            => Type.GetType($"{Category}.{Dependency}.{Member}.{TestContext.TestName}") ?? BaselineTestType;

        #endregion


        #region Scaffolding

        // Pattern namespace should be in this format:
        // "ExecutedCategory.DependencyType.MemberTested"

        // Category could be:
        // 1. Import
        // 2. Selection
        // 3. etc.

        // Recognized Dependency Types:
        // 1. Implicit
        // 2. Optional
        // 3. Required

        // Members are:
        // 1. Constructors
        // 2. Methods
        // 3. Fields
        // 4. Properties

        // Example: Import.Implicit.Constructors

        protected static void ClassInitialize(TestContext context)
        {
            ClassContext = context;

            var type  = Type.GetType(context.FullyQualifiedTestClassName);
            var root  = type.Namespace.Split('.');
            var @base = type.BaseType.Namespace.Split('.');

            Member     = root.Last();
            Category   = @base.First();
            Dependency = @base.Last();

            _type = type.Namespace;
            _prefix = root.First();
            _root = $"{type.BaseType.Namespace}.{Member}";

            BaselineTestType = GetTestType("BaselineTestType`1");
            BaselineTestNamed = GetTestType("BaselineTestTypeNamed`1");
            BaselineArrayType = GetTestType("BaselineArrayType`1");
            BaselineConsumer = GetTestType("BaselineConsumer`1");
        }

        public virtual void TestInitialize() => Container = new UnityContainer();

        #endregion


        #region Get Test Type

        protected static Type GetTestType(string name)
        {
            return Type.GetType($"{Category}.{Dependency}.{Member}.{name}") ??
                   Type.GetType($"Regression.{Dependency}.{Member}.{name}");
        }
        
        protected static Type GetTestType(string dependency, string name)
        {
            return Type.GetType($"{Category}.{dependency}.{Member}.{name}") ??
                   Type.GetType($"Regression.{dependency}.{Member}.{name}");
        }

        protected static IEnumerable<Type> FromTestNamespaces(string name)
        {
            var regex = $"({_prefix}).*({Member}).*({name})";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => t.Namespace is not null)
                           .Where(t => Regex.IsMatch(t.Namespace, regex));
        }

        #endregion


        #region Get Type

        protected static Type GetType(string name)
        {
            return Type.GetType($"{_root}.{name}") ??
                   Type.GetType($"{_type}.{name}");
        }

        protected static Type GetType(string @namespace, string name)
        {
            return Type.GetType($"{_prefix}.{@namespace}.{Member}.{name}") ??
                   Type.GetType($"{_type}.{@namespace}.{name}");
        }
        
        
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
#if !BEHAVIOR_V4 && !UNITY_V4 // Only Unity v5 and up allow `null` as a value
                     .RegisterInstance(typeof(string),       Null, (object)null)
                     .RegisterInstance(typeof(Unresolvable), Null, (object)null)
#endif
                     .RegisterInstance(typeof(TestStruct), RegisteredStruct)
                     .RegisterInstance(typeof(TestStruct), Name, NamedStruct);
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
            var regex = $"({_prefix}).*({prefix}).*({Member}).*({@namespace})$";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => t.Namespace is not null)
                           .Where(t => Regex.IsMatch(t.Namespace, regex));
        }

        protected static IEnumerable<Type> FromPatternNamespace(string @namespace)
        {
            var regex = $"({_root}).*(.)({@namespace})$";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => t.Namespace is not null)
                           .Where(t => Regex.IsMatch(t.Namespace, regex));
        }

        protected static IEnumerable<Type> FromNamespaces(string @namespace)
        {
            var regex = $"({_prefix}).*({Member}).*({@namespace})";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => t.Namespace is not null)
                           .Where(t => Regex.IsMatch(t.Namespace, regex));
        }

        #endregion
    }
}
