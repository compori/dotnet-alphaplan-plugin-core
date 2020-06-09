using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class CommonExtension
    {
        /// <summary>
        /// Register the the protocol provider support.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WitProtocolProvider(this IRegistrator registrator)
        {
            return registrator?
                .WithProtocolProviderVersion2100287()
                .WithProtocol();
        }
    }
}
