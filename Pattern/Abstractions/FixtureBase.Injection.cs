using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Manager
{
    public abstract partial class FixtureBase
    {
        #region Fields

        protected static Func<Type, InjectionMember> InjectionMember_Required_ByName;
        protected static Func<Type, InjectionMember> InjectionMember_Optional_ByName;

        protected static Func<Type, InjectionMember> InjectionMember_Required_ByType;
        protected static Func<Type, InjectionMember> InjectionMember_Optional_ByType;

        protected static Func<object, InjectionMember> InjectionMember_Value;

        protected static Func<string, object, ResolverOverride> Override_MemberOverride;
        protected static Func<Type, string, object, ResolverOverride> Override_MemberOverride_WithType;
        protected static Func<Type, Type, string, object, ResolverOverride> Override_MemberOverride_OnType;

        #endregion

        protected static void LoadInjectionFuncs()
        {
            Type support = Type.GetType($"{typeof(FixtureBase).FullName}+{_member}");
            
            if (support is null) return;

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
    }
}
