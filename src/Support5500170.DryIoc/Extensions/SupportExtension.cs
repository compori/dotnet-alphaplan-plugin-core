using Base;
using Base.Plugins;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class SupportExtension
    {
        /// <summary>
        /// Register the support Namespace.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="information">The information.</param>
        /// <param name="plugin">The plugin.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithSupport(this IRegistrator registrator, IManagerPlugins manager, IInformationBase information, PluginBase plugin)
        {
            return registrator?
                .WithPluginBase(manager, information, plugin)
                .WithFactoriesApServer()
                .WithFactoriesWawi()
                .WithFactoriesWerkzeuge()
                .WitProtocolProvider()
                .WithWrappers()
                .WithDataTable();
        }
    }
}
