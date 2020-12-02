﻿using System;
using static Selection.SelectionBase;
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif


namespace Selection.Annotated.Properties.Required
{
    public class BaselineTestType<TItem1, TItem2>
        : PropertySelectionBase
    {
        [Dependency] public TItem1 Property1 { get => (TItem1)Data[0]; set => Data[0] = value; }
        [Dependency] public TItem2 Property2 { get => (TItem2)Data[1]; set => Data[1] = value; }
    }

    public class NoPublicMember<TDependency>
    {
        [Dependency]
        private TDependency Property { get; set; }
    }
}


namespace Selection.Annotated.Properties.Required.EdgeCasesThrowing
{
    public class StructProperty : PropertySelectionBase
    {
        [Dependency] public TestStruct Property { get; set; }
    }

    public class OpenGenericType<T>
    {
        [Dependency] public T Property { get; set; }
    }
}