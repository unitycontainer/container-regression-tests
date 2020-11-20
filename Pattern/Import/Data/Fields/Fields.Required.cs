using Regression;
using System;
using System.ComponentModel;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

namespace Regression.Annotated.Fields.Required
{
}

namespace Regression.Annotated.Fields.Required.WithDefault
{
}

namespace Regression.Annotated.Fields.Required.WithDefaultAttribute
{
}

namespace Regression.Annotated.Fields.Required.WithDefaultAndAttribute
{
}


namespace Fields.Required
{
    public class Required_Dependency_Value : PatternBaseType
    {
        [Dependency] public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Class : PatternBaseType
    {
        [Dependency] public Unresolvable Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Dynamic : PatternBaseType
    {
        [Dependency] public dynamic Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Generic<T> : PatternBaseType
    {
        [Dependency] public T Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_Dependency_Named<T> : PatternBaseType
    {
        [Dependency(PatternBase.Name)] public T Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_WithDefault_Value : PatternBaseType
    {
        [Dependency]
        [DefaultValue(PatternBase.DefaultInt)]
        public int Field;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }

    public class Required_WithDefault_Class : PatternBaseType
    {
        [Dependency]
        [DefaultValue(PatternBase.DefaultString)]
        public string Field = PatternBase.DefaultString;

        public override object Value { get => Field; protected set => throw new NotSupportedException(); }
    }
}
