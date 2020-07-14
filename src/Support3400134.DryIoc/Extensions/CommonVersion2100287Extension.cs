using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class CommonVersion2100287Extension
    {
        /// <summary>
        /// Register the the protocol provider support for version 2100.287.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithProtocolProviderVersion2100287(this IRegistrator registrator)
        {
            if (registrator == null)
            {
                return null;
            }
            registrator.Register<Common.IProtocolProvider, Common.ProtocolProvider>(reuse: Reuse.Singleton);
            registrator.Register<Common.IErrorScopeFactory, Common.ErrorScopeFactory>(reuse: Reuse.Singleton);
            return registrator;
        }
    }
}
