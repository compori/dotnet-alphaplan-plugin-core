using Base;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc.Extensions
{
    public static class PluginBaseVersion2100287Extension
    {
        /// <summary>
        /// Register the support of the Plugin for version 2100.287.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="information">The information.</param>
        /// <param name="plugin">The plugin.</param>
        /// <returns>IRegistrator.</returns>
        public static IRegistrator WithPluginBaseVersion2100287(this IRegistrator registrator, Base.Plugins.IManagerPlugins manager, IInformationBase information, PluginBase plugin)
        {
            if (registrator == null)
            {
                return null;
            }

            Guard.AssertArgumentIsNotNull(manager, nameof(manager));
            Guard.AssertArgumentIsNotNull(information, nameof(information));
            Guard.AssertArgumentIsNotNull(plugin, nameof(plugin));

            registrator.UseInstance(manager);
            registrator.UseInstance(information);
            registrator.UseInstance(plugin);
            registrator.UseInstance<ClientBase>(plugin);
            registrator.UseInstance<IPluginBase>(plugin);

            return registrator;
        }
    }
}
