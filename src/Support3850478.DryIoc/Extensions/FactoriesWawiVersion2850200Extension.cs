using Compori.Alphaplan.Plugin.Support.Factories;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesWawiVersion2850200Extension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs for version 2850.200.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesWawiVersion2850200(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            //
            // Register additional Wawi API for Version 2850.200
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateAdressgruppe()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateLagerProtokoll()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateSeriennummer()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateUebersetzungen()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateWarengruppe()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateXDatei()),
                setup: Setup.With(preventDisposal: true));
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateZahlungsbedingungen()),
                setup: Setup.With(preventDisposal: true));

            return registrator;
        }
    }
}
