namespace Regression
{
    public abstract class PatternBaseType
    {
        // Test Constants
        protected const int NamedInt = 123;
        protected const int DefaultInt = 345;
        protected const int InjectedInt = 678;
        protected const int RegisteredInt = 890;
        protected const string Name = "name";
        protected const string Null = "null";
        protected const string NamedString = "named";
        protected const string DefaultString = "default";
        protected const string InjectedString = "injected";
        protected const string RegisteredString = "registered";
        public readonly static Unresolvable RegisteredUnresolvable = Unresolvable.Create("singleton");
        public readonly static Unresolvable NamedSingleton = Unresolvable.Create("named");
        public readonly static Unresolvable InjectedSingleton = SubUnresolvable.Create("injected");
        public readonly static object RegisteredStruct = new TestStruct(55, "struct");


        public virtual object Value { get; protected set; }

    }
}
