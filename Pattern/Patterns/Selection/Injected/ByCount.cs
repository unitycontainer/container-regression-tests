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
#if !UNITY_V4
        [TestMethod, TestProperty(SELECTION, BY_COUNT)]
        [DynamicData(nameof(Test_Types_Data), typeof(Selection.Pattern))]
        public virtual void Select_ByCount_Takes_First(string test, Type type)
        {
            var target = type.MakeGenericType(TypesForward);

            // Arrange
            Container.RegisterType(target, new InjectionConstructor(new ResolvedParameter()));


            // Act
            var instance = Container.Resolve(target) as ConstructorSelectionBase;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotInstanceOfType(instance, typeof(Array));
        }

        [TestMethod, TestProperty(SELECTION, BY_COUNT)]
        [DynamicData(nameof(Test_Types_Data), typeof(Selection.Pattern))]
        public virtual void Select_ByCount_Still_First(string test, Type type)
        {
            var target = type.MakeGenericType(TypesReverse);

            // Arrange
            Container.RegisterType(target, new InjectionConstructor(new ResolvedParameter()));


            // Act
            var instance = Container.Resolve(target) as ConstructorSelectionBase;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsNotInstanceOfType(instance, typeof(Array));
        }
#endif
    }
}
