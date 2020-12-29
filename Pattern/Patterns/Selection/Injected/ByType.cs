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

        [TestMethod, TestProperty(SELECTION, BY_TYPE)]
        [DynamicData(nameof(Test_Types_Data), typeof(Selection.Pattern))]
        public virtual void Select_ByType_Takes_First(string test, Type type)
        {
            var target = type.MakeGenericType(TypesForward);

            // Arrange
            Container.RegisterType(target, new InjectionConstructor(new ResolvedParameter(TypesForward[0])));


            // Act
            var instance = Container.Resolve(target) as ConstructorSelectionBase;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[1] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[0]);
        }

        [TestMethod, TestProperty(SELECTION, BY_TYPE)]
        [DynamicData(nameof(Test_Types_Data), typeof(Selection.Pattern))]
        public virtual void Select_ByType_Still_First(string test, Type type)
        {
            var target = type.MakeGenericType(TypesReverse);

            // Arrange
            Container.RegisterType(target, new InjectionConstructor(new ResolvedParameter(TypesForward[0])));


            // Act
            var instance = Container.Resolve(target) as ConstructorSelectionBase;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);

            var parameters = instance.Data[1] as object[];
            Assert.IsNotNull(parameters);
            Assert.AreEqual(1, parameters.Length);
            Assert.IsInstanceOfType(parameters[0], TypesForward[0]);
        }
    }
}
