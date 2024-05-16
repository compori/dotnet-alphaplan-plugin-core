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
            registrator.UseInstance<IManagerBase>(manager);

            return registrator;
        }
    }
}
