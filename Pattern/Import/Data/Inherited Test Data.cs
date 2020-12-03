#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

#region Constructors

namespace Import.Implicit.Constructors
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency>
    {
        public Inherited_Import(TDependency value) : base(value) { }
    }

    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency>
    {
        public Inherited_Twice(TDependency value) : base(value) { }
    }
}

namespace Import.Optional.Constructors
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency>
    {
        [InjectionConstructor] public Inherited_Import([OptionalDependency] TDependency value) : base(value) { }
    }

    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency>
    {
        [InjectionConstructor] public Inherited_Twice([OptionalDependency] TDependency value) : base(value) { }
    }
}

namespace Import.Required.Constructors
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency>
    {
        [InjectionConstructor] public Inherited_Import([Dependency] TDependency value) : base(value) { }
    }

    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency>
    {
        [InjectionConstructor] public Inherited_Twice([Dependency] TDependency value) : base(value) { }
    }
}

#endregion


#region Methods

namespace Import.Implicit.Methods
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Import.Optional.Methods
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Import.Required.Methods
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}


#endregion


#region Fields
#if !UNITY_V4
namespace Import.Implicit.Fields
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Import.Optional.Fields
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Import.Required.Fields
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}
#endif
#endregion


#region Properties

namespace Import.Implicit.Properties
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Import.Optional.Properties
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Import.Required.Properties
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}
#endregion