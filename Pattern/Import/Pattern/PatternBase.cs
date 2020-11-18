using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression
{
    public abstract class PatternBase
    {
        #region Fields

        // Test Constants
        public const int NamedInt = 123;
        public const int DefaultInt = 345;
        public const int DefaultValueInt = 3456;
        public const int InjectedInt = 678;
        public const int RegisteredInt = 890;
        public const string Name = "name";
        public const string Null = "null";
        public const string NamedString = "named";
        public const string DefaultString = "default";
        public const string DefaultValueString = "default_attr";
        public const string InjectedString = "injected";
        public const string RegisteredString = "registered";
        public readonly static Unresolvable RegisteredUnresolvable = Unresolvable.Create("singleton");
        public readonly static Unresolvable NamedSingleton = Unresolvable.Create("named");
        public readonly static Unresolvable InjectedSingleton = SubUnresolvable.Create("injected");
        public readonly static object RegisteredStruct = new TestStruct(55, "struct");

        private static IDictionary<string, TypeInfo> _types;

        // Test types
        protected static Type PocoType;
        protected static Type Required;
        protected static Type Optional;
        protected static Type Required_Named;
        protected static Type Optional_Named;
        protected static Type PocoType_Default_Value;
        protected static Type Required_Default_Value;
        protected static Type Optional_Default_Value;
        protected static Type PocoType_Default_Class;
        protected static Type Required_Default_String;
        protected static Type Optional_Default_Class;

        protected IUnityContainer Container;

        #endregion

        protected static void ClassInitialize(string name)
        {
            _types = Assembly.GetExecutingAssembly()
                             .DefinedTypes
                             .Where(t => t.Namespace == name)
                             .ToDictionary(t => t.Name);

            #region Test Types
            PocoType = Type.GetType($"{name}.Implicit_Dependency_Generic`1");
            Required = Type.GetType($"{name}.Required_Dependency_Generic`1");
            Optional = Type.GetType($"{name}.Optional_Dependency_Generic`1");

            Required_Named = Type.GetType($"{name}.Required_Dependency_Named`1");
            Optional_Named = Type.GetType($"{name}.Optional_Dependency_Named`1");

            PocoType_Default_Value = Type.GetType($"{name}.Implicit_WithDefault_Value");
            Required_Default_Value = Type.GetType($"{name}.Required_WithDefault_Value");
            Optional_Default_Value = Type.GetType($"{name}.Optional_WithDefault_Value");

            PocoType_Default_Class  = Type.GetType($"{name}.Implicit_WithDefault_Class");
            Required_Default_String = Type.GetType($"{name}.Required_WithDefault_Class");
            Optional_Default_Class  = Type.GetType($"{name}.Optional_WithDefault_Class");
            #endregion


            #region Injection Support
            var support = Type.GetType($"{name}.Support");
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
            #endregion
        }

        public virtual void TestInitialize() => Container = new UnityContainer();


        #region Implementation

        protected static TypeInfo GetType(string name) => _types[name];

        protected virtual void RegisterTypes()
        {
            Container.RegisterInstance(RegisteredInt)
                     .RegisterInstance(RegisteredString)
                     .RegisterInstance(RegisteredUnresolvable)
                     .RegisterInstance(typeof(TestStruct), RegisteredStruct)
#if !V4 // Only Unity v5 and up allow `null` as a value
                     .RegisterInstance(typeof(string), Null, (object)null)
                     .RegisterInstance(typeof(Unresolvable), Null, (object)null)
#endif
                     .RegisterInstance(Name, NamedInt)
                     .RegisterInstance(Name, NamedSingleton);
        }

        #endregion


        #region Injection

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
