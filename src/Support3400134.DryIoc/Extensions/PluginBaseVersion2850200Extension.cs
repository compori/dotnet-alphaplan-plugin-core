using Base;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class PluginBaseVersion2850200Extension
    {
        /// <summary>
        /// Register the support of the Plugin for version 2850.200.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="information">The information.</param>
        /// <param name="plugin">The plugin.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithPluginBaseVersion2850200(this IRegistrator registrator, Base.Plugins.IManagerPlugins manager, IInformationBase information, PluginBase plugin)
        {
            if (registrator == null)
            {
                return null;
            }

            Guard.AssertArgumentIsNotNull(manager, nameof(manager));
            registrator.UseInstance<IManagerBase>(manager);
            return registrator;
        }
    }
}
