#if UNITY_V4
using Microsoft.Practices.Unity;
#elif UNITY_V5
using Unity;
using Unity.Extension;
#else
using Unity.Extension;
#endif


namespace Regression.Container
{
    public class BuilderAwareExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
        }
    }
}
