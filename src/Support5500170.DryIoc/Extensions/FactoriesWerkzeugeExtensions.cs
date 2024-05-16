using Compori.Alphaplan.Plugin.Support.Factories;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesWerkzeugeExtensions
    {
        /// <summary>
        /// Register the support of the Wawi Namespace APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesWerkzeuge(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            // register Wawi factory
            registrator.Register<WerkzeugeFactory>();
            
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
