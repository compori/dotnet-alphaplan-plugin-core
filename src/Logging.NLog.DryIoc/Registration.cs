using Compori.Alphaplan.Plugin.Support.Common;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Logging.NLog.DryIoc
{
    public static class Registration
    {
        /// <summary>
        /// Register the support Namespace.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        public static void Register(IRegistrator registrator)
        {
            registrator.Register<IProtocolProvider, ProtocolProvider>(reuse: Reuse.Singleton);
        }
    }
}
