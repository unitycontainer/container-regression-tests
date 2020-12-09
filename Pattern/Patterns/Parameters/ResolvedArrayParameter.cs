using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System;
using System.Collections;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Parameters
{
    public partial class Pattern
    {
        #region Success

        [PatternTestMethod("Ctor(type) with no arguments"), TestProperty(PARAMETER, nameof(ResolvedArrayParameter))]
        [DynamicData(nameof(Test_Variants_Data))]
        public void ResolvedArrayParameter_Type(Type type, Type definition,
                                                string member, string import,
                                                Func<object, InjectionMember> func,
                                                object registered, object named, object injected, object @default,
                                                bool isNamed) 
            => Assert_ResolvedArray_Injected(definition, type,
                func(new ResolvedArrayParameter(type)),
                Array.CreateInstance(type, 0));


        [PatternTestMethod("Ctor(type, ...) with values"), TestProperty(PARAMETER, nameof(ResolvedArrayParameter))]
        [DynamicData(nameof(Test_Variants_Data))]
        public void ResolvedArrayParameter_Value(Type type, Type definition,
                                                 string member, string import,
                                                 Func<object, InjectionMember> func,
                                                 object registered, object named, object injected, object @default,
                                                 bool isNamed) 
            => Assert_ResolvedArray_Injected(definition, type,
                func(new ResolvedArrayParameter(type, registered, named, injected, @default)),
                new object[] { registered, named, injected, @default });


        [PatternTestMethod("Ctor(type, ...) with resolvers"), TestProperty(PARAMETER, nameof(ResolvedArrayParameter))]
        [DynamicData(nameof(Test_Variants_Data))]
        public void ResolvedArrayParameter_Resolvers(Type type, Type definition,
                                                     string member, string import,
                                                     Func<object, InjectionMember> func,
                                                     object registered, object named, object injected, object @default,
                                                     bool isNamed)
        {
            Container.RegisterInstance(type, registered);
            Container.RegisterInstance(type, Name, named);

            Assert_ResolvedArray_Injected(definition, type,
                           func(new ResolvedArrayParameter(type, 
                                                           new ResolvedParameter(type), 
                                                           new OptionalParameter(type, Name), 
                                                           new InjectionParameter(injected),
                                                           new ValidatingResolver(@default))),
                           new object[] { registered, named, injected, @default });
        }


        [PatternTestMethod("Ctor(type, values) on object[] array"), TestProperty(PARAMETER, nameof(ResolvedArrayParameter))]
        [DynamicData(nameof(Test_Array_Data))]
        public void ResolvedArrayParameter_Object(Type type, Type definition,
                                                  string member, string import,
                                                  Func<object, InjectionMember> func,
                                                  object registered, object named, object injected, object @default,
                                                  bool isNamed)
        {
            var target = definition.MakeGenericType(type);
            var injection = func(new ResolvedArrayParameter(type, registered, named, injected, @default));

            // Arrange
            Container.RegisterType(null, target, null, null, injection);

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.IsInstanceOfType(instance.Value, type.MakeArrayType());

            var list = instance.Value as IList;
            var expected = new object[] { registered, named, injected, @default };

            Assert.IsNotNull(list);
            Assert.IsNotNull(expected);

            for (var i = 0; i < expected.Length; i++)
                Assert.IsTrue(list.Contains(expected[i]));
        }

        #endregion


        #region Failing

        [PatternTestMethod("Ctor(null) with no arguments"), TestProperty(PARAMETER, nameof(ResolvedArrayParameter))]
        [DynamicData(nameof(Test_Variants_Data))]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ResolvedArrayParameter_Null(Type type, Type definition,
                                                string member, string import,
                                                Func<object, InjectionMember> func,
                                                object registered, object named, object injected, object @default,
                                                bool isNamed)
        {
            Assert_ResolvedArray_Injected(definition, type,
                           func(new ResolvedArrayParameter(null)),
                           Array.CreateInstance(type, 0));
        }


        [PatternTestMethod("Ctor(generic, ...) throws"), TestProperty(PARAMETER, nameof(ResolvedArrayParameter))]
        [DynamicData(nameof(Test_Variants_Data))]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ResolvedArrayParameter_Generic(Type type, Type definition,
                                                   string member, string import,
                                                   Func<object, InjectionMember> func,
                                                   object registered, object named, object injected, object @default,
                                                   bool isNamed) 
            => Assert_ResolvedArray_Injected(definition, type,
                func(new ResolvedArrayParameter(definition, registered, named, injected, @default)),
                Array.CreateInstance(type, 0));

        #endregion


        #region Implementation

        protected void Assert_ResolvedArray_Injected(Type definition, Type type, InjectionMember injection, object values)
        {
            var array = type.MakeArrayType();
            var target = definition.MakeGenericType(array);

            // Arrange
            Container.RegisterType(null, target, null, null, injection);

            // Act
            var instance = Container.Resolve(target, null) as FixtureBaseType;

            // Validate
            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, target);
            Assert.IsInstanceOfType(instance.Value, array);

            var list = instance.Value as IList;
            var expected = values as IList;

            Assert.IsNotNull(list);
            Assert.IsNotNull(expected);

            for (var i = 0; i < expected.Count; i++)
                Assert.IsTrue(list.Contains(expected[i]));
        }

        #endregion
    }
}
