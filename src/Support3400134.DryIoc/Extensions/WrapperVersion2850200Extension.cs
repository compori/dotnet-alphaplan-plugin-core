using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class WrapperVersion2850200Extension
    {
        /// <summary>
        /// Register the support of the wrappers APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithWrappersVersion2850200(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            registrator.Register<Base.Wrapper.Email>(
                reuse: Reuse.Singleton, 
                setup: Setup.With(preventDisposal: true)
            );
            registrator.Register<Base.Wrapper.Kommando>(
                reuse: Reuse.Singleton, 
                setup: Setup.With(preventDisposal: true)
            );
            registrator.Register<Base.Wrapper.Protokoll>(
                reuse: Reuse.Singleton,
                setup: Setup.With(preventDisposal: true)
            );
            registrator.Register<Base.Wrapper.StatusMonitor>(
                reuse: Reuse.Singleton, 
                setup: Setup.With(preventDisposal: true)
            );

            return registrator;
        }
    }
}
