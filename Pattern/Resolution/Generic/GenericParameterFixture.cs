using Microsoft.VisualStudio.TestTools.UnitTesting;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
using Unity.Lifetime;
#endif

namespace Resolution
{
    public partial class Generics
    {
        [Ignore]
        [TestMethod]
        public void CanCallNonGenericConstructorOnOpenGenericType()
        {
            //Container.RegisterType(typeof(ClassWithOneGenericParameter<>),
            //            new InjectionConstructor("Fiddle", new InjectionParameter<object>("someValue")));

            //ClassWithOneGenericParameter<Service> result = Container.Resolve<ClassWithOneGenericParameter<Service>>();

            //Assert.IsNull(result.InjectedValue);
        }

        [Ignore]
        [TestMethod]
        public void CanCallConstructorTakingGenericParameter()
        {
            //Container.RegisterType(typeof(ClassWithOneGenericParameter<>),
            //        new InjectionConstructor(new GenericParameter("T")));

            //Account a = new Account();
            //Container.RegisterInstance<Account>(a);

            //ClassWithOneGenericParameter<Account> result = Container.Resolve<ClassWithOneGenericParameter<Account>>();
            //Assert.AreSame(a, result.InjectedValue);
        }

        [Ignore]
        [TestMethod]
        public void CanConfiguredNamedResolutionOfGenericParameter()
        {
            //Container.RegisterType(typeof(ClassWithOneGenericParameter<>),
            //        new InjectionConstructor(new GenericParameter("T", "named")));

            //Account a = new Account();
            //Container.RegisterInstance<Account>(a);
            //Account named = new Account();
            //Container.RegisterInstance<Account>("named", named);

            //ClassWithOneGenericParameter<Account> result = Container.Resolve<ClassWithOneGenericParameter<Account>>();
            //Assert.AreSame(named, result.InjectedValue);
        }
    }
}
