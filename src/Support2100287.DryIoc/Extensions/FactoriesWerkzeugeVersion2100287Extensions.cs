using Compori.Alphaplan.Plugin.Support.Factories;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesWerkzeugeVersion2100287Extensions
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs for version 2100.287.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesWerkzeugeVersion2100287(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            //
            // Register Werkzeuge APIs
            //
            registrator.Register(
                reuse: Reuse.Singleton,
                made: Made.Of(request => ServiceInfo.Of<WerkzeugeFactory>(), factory => factory.CreateProtokoll()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton,
                made: Made.Of(request => ServiceInfo.Of<WerkzeugeFactory>(), factory => factory.CreateStandard()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton,
                made: Made.Of(request => ServiceInfo.Of<WerkzeugeFactory>(), factory => factory.CreateStatusMonitor()),
                setup: Setup.With(preventDisposal: true));
            
            return registrator;
        }
    }
}
