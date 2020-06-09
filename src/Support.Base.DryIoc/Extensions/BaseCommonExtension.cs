using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class BaseCommonExtension
    {
        /// <summary>
        /// Register the the protocol provider support.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithProtocol(this IRegistrator registrator)
        {
            registrator?.Register<Common.IProtocol, Common.Protocol>(reuse: Reuse.Singleton);
            return registrator;
        }
    }
}
