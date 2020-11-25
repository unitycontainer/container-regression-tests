using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
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
    public abstract partial class ImportBase : PatternBase
    {
        #region Fields

        protected static Type ImplicitImportType;
        protected static Type RequiredImportType;
        protected static Type RequiredImportNamed;
        protected static Type OptionalImportType;
        protected static Type OptionalImportNamed;

        #endregion


        #region Scaffolding

        new protected static void ClassInitialize(TestContext context)
        {
            PatternBase.ClassInitialize(context);

            ImplicitImportType = GetType("Implicit", "BaselineTestType`1");
            RequiredImportType = GetType("Annotated", "Required.BaselineTestType`1");
            OptionalImportType = GetType("Annotated", "Optional.BaselineTestType`1");
            RequiredImportNamed = GetType("Annotated", "Required.BaselineTestTypeNamed`1");
            OptionalImportNamed = GetType("Annotated", "Optional.BaselineTestTypeNamed`1");

            LoadInjectionFuncs(GetType("Support"));
        }

        #endregion


        #region Injection Support

        private static void LoadInjectionFuncs(Type support)
        {
            InjectionMember_Required_ByName = (Func<Type, InjectionMember>)support
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

        protected static Func<string, object, ResolverOverride> Override_MemberOverride;
        protected static Func<Type, string, object, ResolverOverride> Override_MemberOverride_WithType;
        protected static Func<Type, Type, string, object, ResolverOverride> Override_MemberOverride_OnType;

        #endregion
    }
}
