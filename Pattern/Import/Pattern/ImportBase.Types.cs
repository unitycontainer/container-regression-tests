using Regression;
using System;

namespace Import
{
    public abstract partial class ImportBase 
    {
        public abstract class ImportBaseType : FixtureBaseType
        {
            #region Constructors

            protected ImportBaseType() => ImportType = typeof(object);
            public ImportBaseType(Type type) => ImportType = type;

            #endregion


            #region Properties

            public virtual object Injected { get; protected set; }
            public virtual object Override { get; protected set; }
            public virtual object Registered { get; protected set; }
            public virtual Type ImportType { get; protected set; }

            #endregion
        }
    }
}


