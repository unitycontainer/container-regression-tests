using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Selection.Injected
{
    public abstract partial class Pattern
    {
        [TestMethod("Select by Parameter (First)"), TestProperty(SELECTION, BY_TYPE)]
        public virtual void Select_ByParameter_First()
        {
            var target = BaselineTestType.MakeGenericType(TypesForward);

            // Arrange
            Container.RegisterType(target, InjectionMember_Value(new ResolvedParameter(TypesForward[0])));

            // Act
            var instance = Container.Resolve(target) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[1] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[0]);
        }

        [TestMethod("Select by Parameter (Second)"), TestProperty(SELECTION, BY_TYPE)]
        public virtual void Select_ByParameter_Second()
        {
            var target = BaselineTestType.MakeGenericType(TypesForward);

            // Arrange
            Container.RegisterInstance(Name)
                     .RegisterType(target, InjectionMember_Value(new ResolvedParameter(TypesForward[1])));

            // Act
            var instance = Container.Resolve(target) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[2] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[1]);
        }

        [TestMethod("Select by Parameter (Reversed)"), TestProperty(SELECTION, BY_TYPE)]
        public virtual void Select_ByParameter_Reversed()
        {
            var target = BaselineTestType.MakeGenericType(TypesReverse);

            // Arrange
            Container.RegisterInstance(Name)
                     .RegisterType(target, InjectionMember_Value(new ResolvedParameter(TypesReverse[1])));

            // Act
            var instance = Container.Resolve(target) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
#if BEHAVIOR_V4

            // With two constructors:
            //
            // public BaselineTestType(object value)
            // public BaselineTestType(string value)
            //
            // and registration like this: 
            //
            // .RegisterType(target, new InjectionConstructor(new ResolvedParameter(typeof(string))))
            // 
            // Unity v4 with correctly resolve string, but incorrectly pickup first 
            // compatible constructor. Since 'BaselineTestType(object value)' can be assigned 'string',
            // unity will accept this constructor if it comes first. 

            var parameters = instance.Data[1] as object[];
#else
            var parameters = instance.Data[2] as object[];
#endif
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesReverse[1]);
        }

        [TestMethod("Select by Parameter (First Two)"), TestProperty(SELECTION, BY_TYPE)]
        public virtual void Select_ByParameter_FirstTwo()
        {
            var target = BaselineTestType.MakeGenericType(TypesForward);

            // Arrange
            Container.RegisterInstance(Name)
                     .RegisterType(target, InjectionMember_Args(new[] 
                        { new ResolvedParameter(TypesForward[0]), 
                          new ResolvedParameter(TypesForward[1]) }));

            // Act
            var instance = Container.Resolve(target) as SelectionBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[4] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(2, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[0]);
            Assert.IsInstanceOfType(parameters[1], TypesForward[1]);
        }

    }
}
