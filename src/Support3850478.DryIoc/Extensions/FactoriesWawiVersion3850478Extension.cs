using Compori.Alphaplan.Plugin.Support.Factories;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesWawiVersion3850478Extension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs for version 3850.478.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesWawiVersion3850478(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            //
            // Register additional Wawi API for Version 3850.478.
            //
            registrator.Register(
                reuse: Reuse.Singleton,
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateArtikelSet()),
                setup: Setup.With(preventDisposal: true));

            registrator.Register(
                reuse: Reuse.Singleton,
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateBuchungsgruppe()),
                setup: Setup.With(preventDisposal: true));

            return registrator;
        }
    }
}
