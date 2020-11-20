using Regression;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Injection;
#endif


namespace Regression.Annotated.Properties.Required
{
}

namespace Regression.Annotated.Properties.Required.WithDefault
{
}

namespace Regression.Annotated.Properties.Required.WithDefaultAttribute
{
}

namespace Regression.Annotated.Properties.Required.WithDefaultAndAttribute
{
}


namespace Properties.Required
{
    public class Required_Dependency_Value : PatternBaseType
    {
        [Dependency] public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Class : PatternBaseType
    {
        [Dependency] public Unresolvable Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Dynamic : PatternBaseType
    {
        [Dependency] public dynamic Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Generic<T> : PatternBaseType
    {
        [Dependency] public T Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Named<T> : PatternBaseType
    {
        [Dependency(PatternBase.Name)] public T Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_WithDefault_Value : PatternBaseType
    {
        [Dependency]
        [DefaultValue(PatternBase.DefaultInt)]
        public int Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }

    public class Required_WithDefault_Class : PatternBaseType
    {
        [Dependency]
        [DefaultValue(PatternBase.DefaultString)]
        public string Property { get; set; }

        public override object Value { get => Property; protected set => throw new NotSupportedException(); }
    }
}
