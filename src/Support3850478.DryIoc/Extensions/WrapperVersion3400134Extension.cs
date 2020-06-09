using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class WrapperVersion3400134Extension
    {
        /// <summary>
        /// Register the support of the wrappers APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithWrappersVersion3400134(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            registrator.Register<Base.Wrapper.Remoting>(
                reuse: Reuse.Singleton, 
                setup: Setup.With(preventDisposal: true)
            );
            registrator.Register<Base.Wrapper.Semaphore>(
                reuse: Reuse.Singleton, 
                setup: Setup.With(preventDisposal: true)
            );

            return registrator;
        }
    }
}
