using Regression;
using System;
using System.Reflection;

namespace Selection
{
    public abstract partial class Pattern
    {
        public static readonly BindingFlags PatternDefaultFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        #region Base Types


        public abstract class SelectionBaseType : FixtureBaseType
        {
            protected SelectionBaseType() => Value = new object[0];
            
            protected SelectionBaseType(Func<Type, MemberInfo[]> func)
            {
                var members = func(GetType());

                Default = members;
                Value = new object[members.Length];
            }

            public object[] Data => (object[])Value;
            
            public virtual object this[int index] => ((object[])Value)[index];

            public virtual bool IsSuccessful => true;
        }

        public abstract class SelectionBaseType<TMemberInfo> : SelectionBaseType
            where TMemberInfo : MemberInfo
        {
            protected SelectionBaseType(Func<Type, MemberInfo[]> func)
                : base(func) { }

            public MemberInfo[] Members => (MemberInfo[])Default;
        }


        public class ConstructorSelectionBase : SelectionBaseType<ConstructorInfo>
        {
            public ConstructorSelectionBase() 
                : base(t => t.GetConstructors(PatternDefaultFlags))
            { }
        }

        public class MethodSelectionBase : SelectionBaseType<MethodInfo>
        {
            public MethodSelectionBase()
                : base(t => t.GetMethods(PatternDefaultFlags))
            { }
        }

        public class FieldSelectionBase : SelectionBaseType<FieldInfo>
        {
            public FieldSelectionBase()
                : base(t => t.GetFields(PatternDefaultFlags))
            { }

            public override object this[int index] => ((FieldInfo[])Default)[index].GetValue(this);
        }

        public class PropertySelectionBase : SelectionBaseType<PropertyInfo>
        {
            public PropertySelectionBase()
                : base(t => t.GetProperties(PatternDefaultFlags))
            { }
        }

        #endregion


        #region Empty Types

        public class DummySelection : SelectionBaseType 
        {
        }

        public class UnresolvableDummySelection : SelectionBaseType
        {
            private UnresolvableDummySelection()
            {
            }
        }

        #endregion


        #region Test Types

        public struct TestStruct
        {
        }

        #endregion
    }
}
