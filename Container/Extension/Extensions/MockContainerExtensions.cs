#if UNITY_V4
using Microsoft.Practices.Unity;
#else
using Unity;
using Unity.Extension;
#endif


namespace Regression.Container
{
    public interface IMockConfiguration : IUnityContainerExtensionConfigurator
    {
    }


    public class MockContainerExtension : UnityContainerExtension, 
                                          IMockConfiguration
    {
        private bool _initialized = false;

        public bool InitializeWasCalled 
            => _initialized;

        public new ExtensionContext Context 
            => base.Context;

        protected override void Initialize() 
            => _initialized = true;
    }


    public class ContainerExtensionWithNonDefaultConstructor : UnityContainerExtension,
                                                               IUnityContainerExtensionConfigurator
    {
        public ContainerExtensionWithNonDefaultConstructor(IUnityContainer container)
        {
        }

        protected override void Initialize()
        {
        }
    }
}
