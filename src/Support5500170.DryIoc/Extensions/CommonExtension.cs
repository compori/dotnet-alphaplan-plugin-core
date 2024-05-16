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
            if (registrator == null)
            {
                return null;
            }
            registrator.Register<Common.IProtocolProvider, Common.ProtocolProvider>(reuse: Reuse.Singleton);
            registrator.Register<Common.IErrorScopeFactory, Common.ErrorScopeFactory>(reuse: Reuse.Singleton);

            return registrator.WithProtocol();
        }
    }
}
