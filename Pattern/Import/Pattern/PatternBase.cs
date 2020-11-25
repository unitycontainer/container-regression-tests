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
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Import
{
    public abstract partial class PatternBase
    {
        #region Fields

        private static string _root { get; set; }
        private static string _data { get; set; }
        private static string _prefix { get; set; }

        protected IUnityContainer Container;

        public const string Name = "name";

        protected static Type ImplicitImportType;
        protected static Type RequiredImportType;
        protected static Type RequiredImportNamed;
        protected static Type OptionalImportType;
        protected static Type OptionalImportNamed;

        #endregion


        #region Scaffolding

        protected static void ClassInitialize(TestContext context)
        {
            var type = Type.GetType(context.FullyQualifiedTestClassName);
            _root = type.Namespace;
            _data = $"{type.BaseType.Namespace}.{_root}";
            _prefix = _data.Substring(0, _data.IndexOf("."));

            LoadInjectionFuncs(Type.GetType($"{_root}.Support"));

            ImplicitImportType = GetType("Implicit", "BaselineTestType`1");
            RequiredImportType = GetType("Annotated", "Required.BaselineTestType`1");
            OptionalImportType = GetType("Annotated", "Optional.BaselineTestType`1");
            RequiredImportNamed = GetType("Annotated", "Required.BaselineTestTypeNamed`1");
            OptionalImportNamed = GetType("Annotated", "Optional.BaselineTestTypeNamed`1");
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
            var @namespace = $"{_data}.{postfix}";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => (t.Namespace?.Equals(@namespace) ?? false));
        }

        protected static IEnumerable<Type> FromNamespaces(string prefix, string @namespace)
        {
            var regex = $"({_prefix}).*({prefix}).*({_root}).*({@namespace})$";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => t.Namespace is not null)
                           .Where(t => Regex.IsMatch(t.Namespace, regex));
        }

        protected static IEnumerable<Type> FromNamespaces(string @namespace)
        {
            var regex = $"({_prefix}).*({_root}).*({@namespace})";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => t.Namespace is not null)
                           .Where(t => Regex.IsMatch(t.Namespace, regex));
        }

        protected static Type GetType(string name)
        {
            return Type.GetType($"{_data}.{name}") ??
                   Type.GetType($"{_root}.{name}");
        }

        protected static Type GetType(string @namespace, string name)
        {
            return Type.GetType($"{_data}.{@namespace}.{name}") ??
                   Type.GetType($"{_prefix}.{@namespace}.{_root}.{name}");
        }

        protected virtual Type GetImportType(Type type) => type;

        #endregion


        #region Injection Support

        private static void LoadInjectionFuncs(Type support)
        { 
            InjectionMember_Required_ByName  = (Func<Type, InjectionMember>)support
                .GetMethod("GetInjectionMember_ByName_Required").CreateDelegate(typeof(Func<Type, InjectionMember>));

            InjectionMember_Optional_ByName = (Func<Type, InjectionMember>)support
                .GetMethod("GetInjectionMember_ByName_Optional").CreateDelegate(typeof(Func<Type, InjectionMember>));

            InjectionMember_Required_ByType = (Func<Type, InjectionMember>)support
                .GetMethod("GetInjectionMember_ByType_Required").CreateDelegate(typeof(Func<Type, InjectionMember>));

            InjectionMember_Optional_ByType = (Func<Type, InjectionMember>)support
                .GetMethod("GetInjectionMember_ByType_Optional").CreateDelegate(typeof(Func<Type, InjectionMember>));

            InjectionMember_Value = (Func<object, InjectionMember>)support
                .GetMethod("GetInjectionValue").CreateDelegate(typeof(Func<object, InjectionMember>));

            Override_MemberOverride = (Func<string, object, ResolverOverride>)support
                .GetMethod("GetMemberOverride").CreateDelegate(typeof(Func<string, object, ResolverOverride>));
            
            Override_MemberOverride_WithType = (Func<Type, string, object, ResolverOverride>)support
                .GetMethod("GetMemberOverrideWithType").CreateDelegate(typeof(Func<Type, string, object, ResolverOverride>));

            Override_MemberOverride_OnType = (Func<Type, Type, string, object, ResolverOverride>)support
                .GetMethod("GetMemberOverrideOnType").CreateDelegate(typeof(Func<Type, Type, string, object, ResolverOverride>));
        }

        protected static Func<Type, InjectionMember> InjectionMember_Required_ByName;
        protected static Func<Type, InjectionMember> InjectionMember_Optional_ByName;

        protected static Func<Type, InjectionMember> InjectionMember_Required_ByType;
        protected static Func<Type, InjectionMember> InjectionMember_Optional_ByType;
        
        protected static Func<object, InjectionMember> InjectionMember_Value;

        protected static Func<string, object, ResolverOverride>       Override_MemberOverride;
        protected static Func<Type, string, object, ResolverOverride> Override_MemberOverride_WithType;
        protected static Func<Type, Type, string, object, ResolverOverride> Override_MemberOverride_OnType;

        #endregion
    }
}
