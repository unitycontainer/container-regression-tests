using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#if V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif

namespace Regression
{
    /// <summary>
    /// Testing unsupported (out and ref) parameter types
    /// </summary>
    /// <example>
    /// 
    /// public class PocoType 
    /// {
    ///     [InjectionConstructor]
    ///     public PocoType(ref int value) { }
    ///     
    ///     [InjectionMethod]
    ///     public void Method(out int value) { }
    /// }
    /// 
    /// </example>
    public abstract partial class InjectedPattern
    {
        /// <summary>
        /// Tests injecting of REF and OUT parameters with various ways
        /// </summary>
        /// <param name="type">Name of test type</param>
        /// <param name="method"></param>
        [DataTestMethod]
        [DynamicData(nameof(Parameter_Validation_Data))]
        [ExpectedException(typeof(InvalidOperationException))]
        public virtual void Injected_Parameters(Type type, string method)
        {
            Type constructed = type.IsGenericTypeDefinition
                             ? type.MakeGenericType(typeof(Unresolvable))
                             : type;
            
            InjectionMember member;

            try
            {
                var factory = GetType().GetMethod(method, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                member = (InjectionMember)factory.Invoke(this, new[] { typeof(Unresolvable), null });
            }
            catch (TargetInvocationException ex)
            when (ex.InnerException is NotSupportedException)
            {
                throw new InvalidOperationException();
            }

            if (type.IsGenericType)
            {
                Type definition = type.IsGenericTypeDefinition
                                ? type
                                : type.GetGenericTypeDefinition();
    
                Container.RegisterType(definition, member);
            }
            else
            {
                Container.RegisterType(type, member);
            }


            // Arrange
            RegisterTypes();

            try
            {
                // Act
                _ = Container.Resolve(constructed) as PatternBaseType;
            }
            catch (ResolutionFailedException ex)
            {
                throw new InvalidOperationException("As expected", ex);
            }

        }

        #region Test Data

        public static IEnumerable<object[]> Parameter_Validation_Data
        {
            get
            {
                foreach (var info in typeof(InjectedPattern).GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                                                .Where(method => method.Name.StartsWith("Get") && method.Name.EndsWith("Member"))
                                                                .Select(method => method.Name))
                {
                    yield return new object[] { GetType("Implicit_Dependency_Ref"), info };
                    yield return new object[] { GetType("Implicit_Dependency_Out"), info };
                    yield return new object[] { GetType("Implicit_Generic_Ref`1") , info };
                    yield return new object[] { GetType("Implicit_Generic_Out`1") , info };
                    yield return new object[] { GetType("Required_Dependency_Ref"), info };
                    yield return new object[] { GetType("Required_Dependency_Out"), info };
                    yield return new object[] { GetType("Required_Generic_Ref`1") , info };
                    yield return new object[] { GetType("Required_Generic_Out`1") , info };
                    yield return new object[] { GetType("Optional_Dependency_Ref"), info };
                    yield return new object[] { GetType("Optional_Dependency_Out"), info };
                    yield return new object[] { GetType("Optional_Generic_Ref`1") , info };
                    yield return new object[] { GetType("Optional_Generic_Out`1" ), info };
                }
            }
        }

        #endregion
    }
}
