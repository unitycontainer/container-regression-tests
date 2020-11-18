using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Properties
{
    [TestClass]
    public partial class Baseline : BaselinePattern
    {
        #region Scaffolding

        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [ClassInitialize]
        public static void ClassInit(TestContext context) 
            => ClassInitialize(context.FullyQualifiedTestClassName
                 .Substring(0, context.FullyQualifiedTestClassName.LastIndexOf(".")));

        #endregion


        #region Injection

        protected override InjectionMember GetByNameMember(Type type, string name)
            => new InjectionProperty("Property");

        protected override InjectionMember GetByNameOptional(Type type, string name)
#if NET45 || NET451
            => new InjectionProperty("Property", new OptionalParameter(type, name));
#elif NET46 || NET461
            => new InjectionProperty("Property", true);
#else
            => new OptionalProperty("Property");
#endif

        protected override InjectionMember GetResolvedMember(Type type, string name)
            => new InjectionProperty("Property", new ResolvedParameter(type, name));

        protected override InjectionMember GetOptionalMember(Type type, string name)
            => new InjectionProperty("Property", new OptionalParameter(type, name));

        protected override InjectionMember GetOptionalOptional(Type type, string name)
#if NET45 || NET451
            => new InjectionProperty("Property", new OptionalParameter(type, name));
#elif NET46 || NET461
            => new InjectionProperty("Property", new OptionalParameter(type, name));
#else
            => new OptionalProperty("Property", new OptionalParameter(type, name));
#endif

        protected override InjectionMember GetGenericMember(Type _, string name)
            => new InjectionProperty("Property", new GenericParameter("T", name));

        protected override InjectionMember GetGenericOptional(Type type, string name)
            => new InjectionProperty("Property", new OptionalGenericParameter("T", name));

        protected override InjectionMember GetInjectionValue(object argument)
            => new InjectionProperty("Property", argument);

        protected override InjectionMember GetInjectionOptional(object argument)
#if NET45 || NET451
            => new InjectionProperty("Property", argument);
#elif NET46 || NET461
            => new InjectionProperty("Property", argument);
#else
            => new OptionalProperty("Property", argument);
#endif

        #endregion


        #region Unsupported
        //#if !V4
        //        // Constructors cann't be injected by name
        //        public override void Injected_ByName(string test, Type type, string name, Type dependency, object expected) { }
        //        public override void Injected_ByName_Required(string test, Type type, string name, Type dependency, object expected) { }
        //        public override void Injected_ByName_Optional(string test, Type type, string name, Type dependency, object expected) { }
        //        public override void Injected_ByName_Default(string test, Type type, string name, Type dependency, object expected) { }
        //#endif
        #endregion
    }
}
