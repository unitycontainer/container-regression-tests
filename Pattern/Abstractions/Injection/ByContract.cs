using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Injection
{
    public abstract partial class Pattern
    {
        const string InjectDependency3Const = "Inject {1} dependency by {2} and {3}";

#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod("Inject Unnamed dependency by InjectionMember()"), TestCategory(CATEGORY_INJECT)]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Default(string test, Type type, object defaultValue, object defaultAttr,
                                           object registered, object named, object injected, object overridden,
                                           object @default)
            => Assert_Injection(
                BaselineTestType.MakeGenericType(type),
                InjectionMember_Default(), 
                @default, registered);




#if BEHAVIOR_V4 || BEHAVIOR_V5
        [Ignore("Known Issue")]
#endif
        [PatternTestMethod("Inject Named dependency by InjectionMember()"), TestCategory(CATEGORY_INJECT)]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Named_Default(string test, Type type, object defaultValue, object defaultAttr,
                                                 object registered, object named, object injected, object overridden,
                                                 object @default)

            => Assert_Injection(BaselineTestNamed.MakeGenericType(type),
                                InjectionMember_Default(), 
                                @default, registered);




        [PatternTestMethod(InjectDependency3Const), TestCategory(CATEGORY_INJECT)]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Unnamed_Type_Null(string test, Type type, object defaultValue, object defaultAttr,
                                                     object registered, object named, object injected, object overridden,
                                                     object @default) 

            => Assert_Injection(BaselineTestType.MakeGenericType(type),
                                InjectionMember_Contract(type, null), 
                                @default, registered);




        [PatternTestMethod(InjectDependency3Const), TestCategory(CATEGORY_INJECT)]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Named_Type_Null(string test, Type type, object defaultValue, object defaultAttr,
                                                   object registered, object named, object injected, object overridden,
                                                   object @default) 

            => Assert_Injection(BaselineTestNamed.MakeGenericType(type),
                                InjectionMember_Contract(type, null), @default, registered);


        

        [PatternTestMethod(InjectDependency3Const), TestCategory(CATEGORY_INJECT)]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Unnamed_Type_Name(string test, Type type, object defaultValue, object defaultAttr,
                                                    object registered, object named, object injected, object overridden,
                                                    object @default) 

            => Assert_Injection(BaselineTestType.MakeGenericType(type), 
                                InjectionMember_Contract(type, Name), @default, named);




        [PatternTestMethod(InjectDependency3Const), TestCategory(CATEGORY_INJECT)]
        [DynamicData(nameof(Test_Type_Data), typeof(PatternBase))]
        public virtual void Inject_Named_Type_Name(string test, Type type, object defaultValue, object defaultAttr,
                                                   object registered, object named, object injected, object overridden,
                                                   object @default)

            => Assert_Injection(BaselineTestType.MakeGenericType(type),
                                InjectionMember_Contract(type, Name), @default, named);
    }
}
