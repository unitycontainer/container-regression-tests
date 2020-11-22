﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression
{
    public abstract partial class PatternBase
    {
        #region Fields

        private static string _root { get; set; }
        private static string _data { get; set; }


        protected IUnityContainer Container;

        public const string Name = "name";

        #region Integer
        public const int NamedInt        = 1234;
        public const int DefaultInt      = 3456;
        public const int DefaultValueInt = 4567;
        public const int InjectedInt     = 6789;
        public const int RegisteredInt   = 8901;
        public const int OverriddenInt   = 9012;
        #endregion
        
        #region String
        public const string Null                = "null";
        public const string NamedString         = "named_string";
        public const string DefaultString       = "default_string";
        public const string DefaultValueString  = "default_value_string";
        public const string RegisteredString    = "registered_string";
        public const string InjectedString      = "injected_string";
        public const string OverriddenString    = "overridden_string";
        #endregion

        #region Unresolvable
        public readonly static Unresolvable RegisteredUnresolvable = Unresolvable.Create("registered");
        public readonly static Unresolvable NamedUnresolvable      = Unresolvable.Create("named");
        public readonly static Unresolvable InjectedUnresolvable   = SubUnresolvable.Create("injected");
        public readonly static Unresolvable OverriddenUnresolvable = SubUnresolvable.Create("overridden");
        #endregion

        #region Struct
        public readonly static object RegisteredStruct = new TestStruct(55, "struct");
        public readonly static object NamedStruct = new TestStruct(44, "named struct");
        #endregion

        #region Unresolvable Type Instances
        public const bool        RegisteredBool       = true;
        public const long        RegisteredLong       = 12;
        public const short       RegisteredShort      = 23;
        public const float       RegisteredFloat      = 34;
        public const double      RegisteredDouble     = 45;
        public static Type       RegisteredType       = typeof(PatternBase);
        public static ICloneable RegisteredICloneable = new object[0];
        public static Delegate   RegisteredDelegate   = (Func<int>)(() => 0);
        #endregion

        #endregion

        protected static void ClassInitialize(TestContext context)
        {
            var type = Type.GetType(context.FullyQualifiedTestClassName);
            _root = type.Namespace;
            _data = $"{type.BaseType.Namespace}.{_root}";

            LoadInjectionFuncs(Type.GetType($"{_root}.Support"));
        }

        public virtual void TestInitialize() => Container = new UnityContainer();

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




        #region Implementation

        protected static IEnumerable<Type> FromNamespace(string postfix)
        {
            var @namespace = $"{_data}.{postfix}";
            return Assembly.GetExecutingAssembly()
                           .DefinedTypes
                           .Where(t => (t.Namespace?.Equals(@namespace) ?? false));
        }

        protected static Type GetType(string name)
        {
            return Type.GetType($"{_data}.{name}") ??
                   Type.GetType($"{_root}.{name}");
        }

        protected static Type GetType(string @namespace, string name)
        {
            return Type.GetType($"{_data}.{@namespace}.{name}") ??
                   Type.GetType($"{_root}.{@namespace}.{name}");
        }

        protected static Type GetRootType(string name)
        {
            var fullName = $"{_root}.{name}";
            return Type.GetType(fullName);
        }

        #endregion


        #region Injection

        private static void LoadInjectionFuncs(Type support)
        { 
            GetByNameMember     = (Func<Type, string, InjectionMember>)support.GetMethod("GetByNameMember")
                                                                              .CreateDelegate(typeof(Func<Type, string, InjectionMember>));
            GetByNameOptional   = (Func<Type, string, InjectionMember>)support.GetMethod("GetByNameOptional")
                                                                              .CreateDelegate(typeof(Func<Type, string, InjectionMember>));
            GetResolvedMember   = (Func<Type, string, InjectionMember>)support.GetMethod("GetResolvedMember")
                                                                              .CreateDelegate(typeof(Func<Type, string, InjectionMember>));
            GetOptionalMember   = (Func<Type, string, InjectionMember>)support.GetMethod("GetOptionalMember")
                                                                              .CreateDelegate(typeof(Func<Type, string, InjectionMember>));
            GetOptionalOptional = (Func<Type, string, InjectionMember>)support.GetMethod("GetOptionalOptional")
                                                                              .CreateDelegate(typeof(Func<Type, string, InjectionMember>));
            GetGenericMember    = (Func<Type, string, InjectionMember>)support.GetMethod("GetGenericMember")
                                                                              .CreateDelegate(typeof(Func<Type, string, InjectionMember>));
            GetGenericOptional  = (Func<Type, string, InjectionMember>)support.GetMethod("GetGenericOptional")
                                                                              .CreateDelegate(typeof(Func<Type, string, InjectionMember>));
            GetInjectionValue    = (Func<object, InjectionMember>)support.GetMethod("GetInjectionValue")
                                                                         .CreateDelegate(typeof(Func<object, InjectionMember>));
            GetInjectionOptional = (Func<object, InjectionMember>)support.GetMethod("GetInjectionOptional")
                                                                         .CreateDelegate(typeof(Func<object, InjectionMember>));
        }

        protected static Func<Type, string, InjectionMember> GetByNameMember;
        protected static Func<Type, string, InjectionMember> GetByNameOptional;
        protected static Func<Type, string, InjectionMember> GetResolvedMember;
        protected static Func<Type, string, InjectionMember> GetOptionalMember;
        protected static Func<Type, string, InjectionMember> GetOptionalOptional;
        protected static Func<Type, string, InjectionMember> GetGenericMember;
        protected static Func<Type, string, InjectionMember> GetGenericOptional;
        protected static Func<object, InjectionMember>       GetInjectionValue;
        protected static Func<object, InjectionMember>       GetInjectionOptional;

        #endregion
    }
}
