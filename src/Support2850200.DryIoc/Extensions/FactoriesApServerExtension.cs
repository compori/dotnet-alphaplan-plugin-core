using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class FactoriesApServerExtension
    {
        /// <summary>
        /// Register the support of the AP server Namespace APIs.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithFactoriesApServer(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }

            // register ApServer Factory
            registrator.Register<Factories.ApServerFactory>();
            return registrator
                .WithFactoriesApServerVersion2100287()
                .WithFactoriesApServerVersion2850200();
        }
    }
}
