using Base;
using Base.Plugins;
using Compori.Alphaplan.Plugin.Support.DryIoc.Extensions;
using DryIoc;

namespace Compori.Alphaplan.Plugin.Support.DryIoc
{
    public static class Registration
    {
        /// <summary>
        /// Register the support Namespace.
        /// </summary>
        /// <param name="registrator">The registrator.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="information">The information.</param>
        /// <param name="plugin">The plugin.</param>
        public static void Register(IRegistrator registrator, IManagerPlugins manager, IInformationBase information, PluginBase plugin)
        {
            registrator.WithSupport(manager, information, plugin);
        }
    }
}
