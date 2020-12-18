using System;
#if UNITY_V5
using Unity;
using Unity.Extension;
#else
using Unity.Extension;
#endif


namespace Regression.Container
{
    /// <summary>
    /// Implemented on a class when it wants to receive notifications
    /// about the build process.
    /// </summary>
    public interface IBuilderAware
    {
        /// <summary>
        /// Called by the <see cref="BuilderAwareStrategy"/> when the object is being built up.
        /// </summary>
        /// <param name="buildKey">The key of the object that was just built up.</param>
        void OnBuiltUp(Type type, string? name);

        /// <summary>
        /// Called by the <see cref="BuilderAwareStrategy"/> when the object is being torn down.
        /// </summary>
        void OnTearingDown();
    }
}
