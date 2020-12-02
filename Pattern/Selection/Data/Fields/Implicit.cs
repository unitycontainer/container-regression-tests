﻿using static Selection.SelectionBase;
using System;

namespace Selection.Implicit.Fields
{
    public class BaselineTestType<TItem1, TItem2>
        : FieldSelectionBase
    {
        public TItem1 Field1;
        public TItem2 Field2;
    }

    public class NoPublicMember<TDependency>
    {
        private TDependency Field;
        protected TDependency Dummy()
        {
            Field = default;
            return Field;
        }
    }
}