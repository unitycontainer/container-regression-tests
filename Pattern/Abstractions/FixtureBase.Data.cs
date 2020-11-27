using System;

namespace Regression
{
    public abstract partial class FixtureBase
    {
        public const string Null           = "null";
        protected const string TDependency = "TDependency";

        #region Integer

        public const int NamedInt        = 1234;
        public const int DefaultInt      = 3456;
        public const int DefaultValueInt = 4567;
        public const int InjectedInt     = 6789;
        public const int RegisteredInt   = 8901;
        public const int OverriddenInt   = 9012;
        
        #endregion

        
        #region String
        
        public const string NamedString        = "named";
        public const string DefaultString      = "default";
        public const string DefaultValueString = "default_value";
        public const string RegisteredString   = "registered";
        public const string InjectedString     = "injected";
        public const string OverriddenString   = "overridden";
        
        #endregion


        #region Unresolvable
        
        public readonly static Unresolvable NamedUnresolvable      = Unresolvable.Create(NamedString);
        public readonly static Unresolvable DefaultUnresolvable      = Unresolvable.Create(DefaultString);
        public readonly static Unresolvable DefaultValueUnresolvable = Unresolvable.Create(DefaultValueString);
        public readonly static Unresolvable RegisteredUnresolvable = Unresolvable.Create(RegisteredString);
        public readonly static Unresolvable InjectedUnresolvable   = SubUnresolvable.Create(InjectedString);
        public readonly static Unresolvable OverriddenUnresolvable = SubUnresolvable.Create(OverriddenString);
        
        #endregion


        #region Struct
        
        public readonly static object RegisteredStruct = new TestStruct(55, "struct");
        public readonly static object NamedStruct      = new TestStruct(44, "named struct");
        
        #endregion


        #region Unresolvable Type Instances
        
        public const bool RegisteredBool              = true;
        public const long RegisteredLong              = 12;
        public const short RegisteredShort            = 23;
        public const float RegisteredFloat            = 34;
        public const double RegisteredDouble          = 45;
        public static Type RegisteredType             = typeof(FixtureBase);
        public static ICloneable RegisteredICloneable = new object[0];
        public static Delegate RegisteredDelegate     = (Func<int>)(() => 0);
        
        #endregion
    }
}


