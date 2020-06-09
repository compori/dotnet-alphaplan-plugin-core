using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesApServerVersion2100287Extension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs for version 2100.287.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesApServerVersion2100287(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            //
            // Register ApServer APIs
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateLogin()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateReader()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateService()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<Factories.ApServerFactory>(), factory => factory.CreateWriter()),
                setup: Setup.With(preventDisposal: true));

            return registrator;
        }
    }
}
