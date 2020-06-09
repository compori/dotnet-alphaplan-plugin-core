using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesApServerVersion2850200Extension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs for version 2850.200.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesApServerVersion2850200(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }


            //
            // Register additional ApServer API for Version 2850.200
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateLizenzInfo()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateSemaphore()),
                setup: Setup.With(preventDisposal: true));


            return registrator;
        }
    }
}
