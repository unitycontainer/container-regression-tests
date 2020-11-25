using System;
using System.Collections.Generic;
using System.Linq;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression
{
    public abstract partial class PatternBase
    {
        #region Constants

        protected const string TDependency = "TDependency";

        #region Integer
        public const int NamedInt = 1234;
        public const int DefaultInt = 3456;
        public const int DefaultValueInt = 4567;
        public const int InjectedInt = 6789;
        public const int RegisteredInt = 8901;
        public const int OverriddenInt = 9012;
        #endregion

        #region String
        public const string Null = "null";
        public const string NamedString = "named_string";
        public const string DefaultString = "default_string";
        public const string DefaultValueString = "default_value_string";
        public const string RegisteredString = "registered_string";
        public const string InjectedString = "injected_string";
        public const string OverriddenString = "overridden_string";
        #endregion

        #region Unresolvable
        public readonly static Unresolvable RegisteredUnresolvable = Unresolvable.Create("registered");
        public readonly static Unresolvable NamedUnresolvable = Unresolvable.Create("named");
        public readonly static Unresolvable InjectedUnresolvable = SubUnresolvable.Create("injected");
        public readonly static Unresolvable OverriddenUnresolvable = SubUnresolvable.Create("overridden");
        #endregion

        #region Struct
        public readonly static object RegisteredStruct = new TestStruct(55, "struct");
        public readonly static object NamedStruct = new TestStruct(44, "named struct");
        #endregion

        #region Unresolvable Type Instances
        public const bool RegisteredBool = true;
        public const long RegisteredLong = 12;
        public const short RegisteredShort = 23;
        public const float RegisteredFloat = 34;
        public const double RegisteredDouble = 45;
        public static Type RegisteredType = typeof(PatternBase);
        public static ICloneable RegisteredICloneable = new object[0];
        public static Delegate RegisteredDelegate = (Func<int>)(() => 0);
        #endregion

        #endregion
    }
}


