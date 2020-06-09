using Compori.Alphaplan.Plugin.Support.Factories;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesWawiVersion3400134Extension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs for version 3400.134.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesWawiVersion3400134(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            //
            // Register additional Wawi API for Version 3400.134.
            //
            registrator.Register(
                reuse: Reuse.Singleton, 
                made: Made.Of(request => ServiceInfo.Of<WawiFactory>(), factory => factory.CreateTexte()),
                setup: Setup.With(preventDisposal: true));

            return registrator;
        }
    }
}