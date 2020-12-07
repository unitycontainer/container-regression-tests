
#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
#endif

#region Constructors

namespace Regression.Implicit.Constructors
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

namespace Regression.Optional.Constructors
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

namespace Regression.Required.Constructors
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

namespace Regression.Implicit.Methods
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Regression.Optional.Methods
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Regression.Required.Methods
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}


#endregion


#region Fields
#if !UNITY_V4
namespace Regression.Implicit.Fields
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Regression.Optional.Fields
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Regression.Required.Fields
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}
#endif
#endregion


#region Properties

namespace Regression.Implicit.Properties
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Regression.Optional.Properties
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}

namespace Regression.Required.Properties
{
    public class Inherited_Import<TDependency> : BaselineTestType<TDependency> { }
    public class Inherited_Twice<TDependency> : Inherited_Import<TDependency> { }
}
#endregion