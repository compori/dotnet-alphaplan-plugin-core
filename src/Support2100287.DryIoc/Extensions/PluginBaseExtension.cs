using Base;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class PluginBaseExtension
    {
        /// <summary>
        /// Register the support of the Plugin.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="information">The information.</param>
        /// <param name="plugin">The plugin.</param>
        /// <returns>IContainer.</returns>
        public static IRegistrator WithPluginBase(this IRegistrator registrator, Base.Plugins.IManagerPlugins manager, IInformationBase information, PluginBase plugin)
        {
            return registrator?.WithPluginBaseVersion2100287(manager, information, plugin);
        }
    }
}
