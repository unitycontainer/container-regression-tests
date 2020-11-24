﻿using System;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Constructors.Required
{
    #region Generic

    public class BaselineTestType<TDependency>
        : PatternBaseType
    {
        public BaselineTestType([Dependency] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }

    public class BaselineTestTypeNamed<TDependency>
        : PatternBaseType
    {
        public BaselineTestTypeNamed([Dependency(PatternBase.Name)] TDependency value) => Value = value;
        public override object Default => default(TDependency);
    }


    public class BaselineInheritedType<TDependency>
        : BaselineTestType<TDependency>
    {
        public BaselineInheritedType([Dependency] TDependency value)
            : base(value)
        { }
    }

    public class BaselineInheritedTwice<TDependency>
        : BaselineInheritedType<TDependency>
    {
        public BaselineInheritedTwice([Dependency] TDependency value)
            : base(value)
        { }
    }


    public class BaselineTestType_Ref<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Ref([Dependency] ref TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    public class BaselineTestType_Out<TDependency>
        : PatternBaseType where TDependency : class
    {
        public BaselineTestType_Out([Dependency] out TDependency _)
            => throw new InvalidOperationException("should never execute");
    }

    #endregion


    #region Test Data

    public class Required_Int : PatternBaseType
    {
        public Required_Int([Dependency] int value) => Value = value;

        public override object Default => 0;
        public override object Injected => PatternBase.InjectedInt;
        public override object Registered => PatternBase.RegisteredInt;
        public override Type ImportType => typeof(int);
    }

    public class Required_String : PatternBaseType
    {
        public Required_String([Dependency] string value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedString;
        public override object Registered => PatternBase.RegisteredString;
        public override Type ImportType => typeof(string);
    }

    public class Required_Unresolvable : PatternBaseType
    {
        public Required_Unresolvable([Dependency] Unresolvable value) => Value = value;

        public override object Default => null;
        public override object Injected => PatternBase.InjectedUnresolvable;
        public override object Registered => PatternBase.RegisteredUnresolvable;
        public override Type ImportType => typeof(Unresolvable);
    }

    #endregion
}
