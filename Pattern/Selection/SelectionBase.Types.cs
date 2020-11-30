using System.Reflection;

namespace Selection
{
    public abstract partial class SelectionBase
    {
        #region Base Types

        public abstract class SelectionBaseType
        {
            protected static readonly BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            
            public virtual object this[int index] => new object();

            public virtual bool IsSuccessfull => true;
        }

        public class ConstructorSelectionBase : SelectionBaseType
        {
            protected object[] Data;

            public ConstructorSelectionBase() => Data = new object[GetType().GetConstructors(Flags).Length];

            public override object this[int index] => Data[index];
        }

        public class MethodSelectionBase : SelectionBaseType
        {
            protected object[] Data;

            public MethodSelectionBase() => Data = new object[GetType().GetMethods(Flags).Length];

            public override object this[int index] => Data[index];
        }

        public class FieldSelectionBase : SelectionBaseType
        {
            protected FieldInfo[] Members;

            public FieldSelectionBase() => Members = GetType().GetFields(Flags);

            public override object this[int index] => Members[index].GetValue(this);
        }

        public class PropertySelectionBase : SelectionBaseType
        {
            protected object[] Data;

            public PropertySelectionBase() => Data = new object[GetType().GetProperties(Flags).Length];

            public override object this[int index] => Data[index];
        }

        #endregion


        #region Test Types

        public class DummySelection : SelectionBaseType { }
        
        public class UnresolvableDummySelection : SelectionBaseType 
        {
            private UnresolvableDummySelection() { }
        }

        public struct TestStruct
        {
        }

        #endregion
    }
}
