using System;
#if UNITY_V4
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Resolution;
#endif

namespace Regression
{
    public abstract partial class FixtureBase
    {
        #region Fields

        protected static Func<object, InjectionMember> InjectionMember_Value;
        protected static Func<InjectionMember>         InjectionMember_Default;

        protected static Func<object, ResolverOverride> MemberOverride;
        protected static Func<string, object, ResolverOverride> MemberOverride_ByName;

        protected static Func<Type, string, object, ResolverOverride> MemberOverride_WithContract;

        #endregion

        protected static void LoadInjectionProxies()
        {
            Type support = Type.GetType($"{typeof(FixtureBase).FullName}+{Member}");
            
            if (support is null) return;


            InjectionMember_Value = (Func<object, InjectionMember>)support
                .GetMethod("GetInjectionValue").CreateDelegate(typeof(Func<object, InjectionMember>));

            InjectionMember_Default = (Func<InjectionMember>)support
                .GetMethod("GetInjectionDefault").CreateDelegate(typeof(Func<InjectionMember>));


            MemberOverride = (Func<object, ResolverOverride>)support
                .GetMethod("GetMemberOverride").CreateDelegate(typeof(Func<object, ResolverOverride>));

            MemberOverride_ByName = (Func<string, object, ResolverOverride>)support
                .GetMethod("GetMemberOverrideByName").CreateDelegate(typeof(Func<string, object, ResolverOverride>));

            MemberOverride_WithContract = (Func<Type, string, object, ResolverOverride>)support
                .GetMethod("GetMemberOverrideWithContract").CreateDelegate(typeof(Func<Type, string, object, ResolverOverride>));
        }
    }
}
