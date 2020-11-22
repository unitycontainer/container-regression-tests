using System;

namespace Regression
{
    public abstract class PatternBaseType
    {
        public virtual object Value { get; protected set; }

        public virtual object Expected { get; }

        public virtual Type Dependency => typeof(object);
    }

    public struct TestStruct
    {
        public int Integer;
        public object Instance;

        public TestStruct(int value, object instance)
        {
            Integer = value;
            Instance = instance;
        }
    }

    public class Unresolvable
    {
        public readonly string ID;

        protected Unresolvable(string id) { ID = id; }

        public static Unresolvable Create(string name) => new Unresolvable(name);

        public override string ToString()
        {
            return $"Unresolvable.{ID}";
        }
    }

    public class SubUnresolvable : Unresolvable
    {
        private SubUnresolvable(string id)
            : base(id)
        {
        }
        public override string ToString()
        {
            return $"SubUnresolvable.{ID}";
        }
        public new static SubUnresolvable Create(string name) => new SubUnresolvable(name);
    }
}


