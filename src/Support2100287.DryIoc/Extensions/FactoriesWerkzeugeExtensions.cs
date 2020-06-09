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
            registrator.Register<Factories.WerkzeugeFactory>();
            return registrator.WithFactoriesWerkzeugeVersion2100287();
        }
    }
}
