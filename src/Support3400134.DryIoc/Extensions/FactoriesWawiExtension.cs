using Compori.Alphaplan.Plugin.Support.Factories;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesWawiExtension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesWawi(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            // register Wawi factory
            registrator.Register<WawiFactory>();

            return registrator
                .WithFactoriesWawiVersion2100287()
                .WithFactoriesWawiVersion2850200()
                .WithFactoriesWawiVersion3400134();
        }
    }
}
